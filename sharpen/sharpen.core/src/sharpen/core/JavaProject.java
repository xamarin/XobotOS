/* Copyright (C) 2004 - 2008  Versant Inc.  http://www.db4o.com

This file is part of the sharpen open source java to c# translator.

sharpen is free software; you can redistribute it and/or modify it under
the terms of version 2 of the GNU General Public License as published
by the Free Software Foundation and as clarified by db4objects' GPL 
interpretation policy, available at
http://www.db4o.com/about/company/legalpolicies/gplinterpretation/
Alternatively you can write to db4objects, Inc., 1900 S Norfolk Street,
Suite 350, San Mateo, CA 94403, USA.

sharpen is distributed in the hope that it will be useful, but WITHOUT ANY
WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
59 Temple Place - Suite 330, Boston, MA  02111-1307, USA. */

package sharpen.core;

import java.io.*;
import java.util.*;

import org.eclipse.core.resources.*;
import org.eclipse.core.runtime.*;
import org.eclipse.core.runtime.jobs.*;
import org.eclipse.jdt.core.*;
import org.eclipse.jdt.launching.*;

import sharpen.core.framework.resources.*;

public class JavaProject extends SimpleProject {
	
	public static class Builder {

		public final IProgressMonitor progressMonitor;
		public final JavaProject project;

		public Builder(IProgressMonitor pm, String projectName) throws CoreException {
			this.progressMonitor = pm;
			this.project = new JavaProject(projectName);
		}

		public Builder sourceFolders(Iterable<String> sourceFolders) throws CoreException {
			for (String srcFolder : sourceFolders) {
				sourceFolder(srcFolder);
			}
			return this;
		}

		public Builder sourceFolder(String srcFolder) throws CoreException {
			progressMonitor.subTask("source folder: " + srcFolder);
			project.addSourceFolder(srcFolder);
			return this;
		}

		public Builder classpath(Iterable<String> classpath) throws JavaModelException {
			for (String cp : classpath) {
				progressMonitor.subTask("classpath entry: " + cp);
				if (!new File(cp).exists()) throw new IllegalArgumentException("'" + cp + "' not found.");
				project.addClasspathEntry(cp);
			}
			return this;
		}

		public Builder nature(String natureId) throws CoreException {
			project.addNature(natureId);
			return this;
		}

		public Builder projectReferences(Iterable<String> projectReferences) throws CoreException {
			for (String projectReference : projectReferences) {
				final IProject reference = WorkspaceUtilities.getProject(projectReference);
				project.addReferencedProject(reference, null);
			}
			return this;
		}

		public Builder persistentProperty(QualifiedName key, String value) throws CoreException {
			project.getProject().setPersistentProperty(key, value);
			return this;
		}
		
	}
	
	private IJavaProject _javaProject;

	private final List<IPackageFragmentRoot> _sourceFolders = new ArrayList<IPackageFragmentRoot>();

	/**
	 * @throws CoreException
	 */
	public JavaProject() throws CoreException {
		this("TestProject");
	}
	
	public JavaProject(String projectName) throws CoreException {
		super(projectName);

		_javaProject = JavaCore.create(_project);
		setJavaNature();
		initializeClassPath();
		createOutputFolder(getBinFolder());
		addSystemLibraries();
	}

	public JavaProject(IJavaProject javaProject) throws CoreException {
		super(javaProject.getProject(), null);
		_javaProject = javaProject;
	}

	private void initializeClassPath() throws JavaModelException {
		_javaProject.setRawClasspath(new IClasspathEntry[0], null);
	}
	
	@Override
	public void addReferencedProject(IProject reference, IProgressMonitor monitor) throws CoreException {
	    super.addReferencedProject(reference, monitor);
	    addClasspathEntry(JavaCore.newProjectEntry(reference.getFullPath(), true));
	}
	
	public IPackageFragmentRoot addSourceFolder(String path) throws CoreException {
		final IPackageFragmentRoot sourceFolder = createSourceFolder(path);
		_sourceFolders.add(sourceFolder);
		
		return sourceFolder;
	}

	/**
	 * @throws CoreException
	 */
	public void buildProject(IProgressMonitor monitor) throws CoreException {
		_project.build(IncrementalProjectBuilder.FULL_BUILD, monitor);
	}
	
	public void joinAutoBuild() {
		joinBuild(ResourcesPlugin.FAMILY_AUTO_BUILD);
	}

	public void joinBuild() {
		joinBuild(ResourcesPlugin.FAMILY_MANUAL_BUILD);
	}

	public void joinBuild(Object buildFamily) {
		try {
			Job.getJobManager().join(buildFamily, null);
		} catch (InterruptedException e) {
			// TODO: handle exception
			e.printStackTrace();
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}

	/**
	 * @return Returns the javaProject.
	 */
	public IJavaProject getJavaProject() {
		return _javaProject;
	}
	
	public void addClasspathEntry(String absolutePath) throws JavaModelException {
		if (containsClasspathEntry(absolutePath))
			return;
		addClasspathEntry(new Path(absolutePath));
	}

	private boolean containsClasspathEntry(String absolutePath) throws JavaModelException {
		for (IClasspathEntry entry : _javaProject.getRawClasspath()) {
			if (IClasspathEntry.CPE_LIBRARY != entry.getEntryKind())
				continue;
			if (entry.getPath().toFile().getAbsolutePath().equals(absolutePath))
				return true;
		}
		return false;
    }

	private void addClasspathEntry(IPath absolutePath) throws JavaModelException {
		IClasspathEntry newLibraryEntry = JavaCore.newLibraryEntry(absolutePath, null, null);
		addClasspathEntry(newLibraryEntry);
	}

	private void addClasspathEntry(IClasspathEntry newLibraryEntry) throws JavaModelException {
		IClasspathEntry[] oldEntries = _javaProject.getRawClasspath();
		IClasspathEntry[] newEntries = new IClasspathEntry[oldEntries.length + 1];
		System.arraycopy(oldEntries, 0, newEntries, 0, oldEntries.length);
		
		newEntries[oldEntries.length] = newLibraryEntry;
		_javaProject.setRawClasspath(newEntries, null);
	}

	/**
	 * @param name
	 * @return @throws
	 *         CoreException
	 */
	public IPackageFragment createPackage(String name) throws CoreException {
		return getMainSourceFolder().createPackageFragment(name, false, null);
	}

	/**
	 * @throws CoreException
	 */
	public IPackageFragmentRoot getMainSourceFolder() throws CoreException {
		if (_sourceFolders.size() == 0) {
			_sourceFolders.add(createDefaultSourceFolder());
		}
		return _sourceFolders.get(0);
	}

	public ICompilationUnit createCompilationUnit(String packageName, String cuName, String source) 
		throws CoreException {
		
		return createCompilationUnit(getMainSourceFolder(), packageName, cuName, source);
	}

	public ICompilationUnit createCompilationUnit(
			final IPackageFragmentRoot sourceFolder, String packageName,
			String cuName, String contents) throws JavaModelException,
			CoreException {
		
		IPackageFragment packageFragment = sourceFolder
				.getPackageFragment(packageName);
		if (!packageFragment.exists()) {
			packageFragment = sourceFolder.createPackageFragment(
					packageName, false, null);
		}
		return createCompilationUnit(packageFragment, cuName, contents);
	}

	/**
	 * @param packageFragment
	 * @param cuName
	 * @param source
	 * @return @throws
	 *         JavaModelException
	 */
	public ICompilationUnit createCompilationUnit(
			IPackageFragment packageFragment, String cuName, String source)
			throws CoreException {

		return packageFragment.createCompilationUnit(
				cuName, source, false, null);
	}

	/**
	 * @return @throws
	 *         CoreException
	 */
	private IFolder getBinFolder() throws CoreException {
		return safeGetFolder("bin");
	}

	private IFolder safeGetFolder(final String folderName) throws CoreException {
		IFolder folder = _project.getFolder(folderName);
		return folder.exists()
			? folder
			: createFolder(folderName);
	}

	/**
	 * @throws CoreException
	 */
	private void setJavaNature() throws CoreException {
		addNature(JavaCore.NATURE_ID);
	}

	public void addNature(String natureId) throws CoreException {
		WorkspaceUtilities.addProjectNature(_project, natureId);
	}

	/**
	 * @param binFolder
	 * @throws JavaModelException
	 */
	private void createOutputFolder(IFolder binFolder)
			throws JavaModelException {
		IPath outputLocation = binFolder.getFullPath();
		_javaProject.setOutputLocation(outputLocation, null);
	}

	/**
	 * @return @throws
	 *         CoreException
	 */
	private IPackageFragmentRoot createDefaultSourceFolder() throws CoreException {
		return createSourceFolder("src");
	}

	private IPackageFragmentRoot createSourceFolder(final String path) throws CoreException, JavaModelException {
		IFolder folder = safeGetFolder(path);
		IPackageFragmentRoot root = _javaProject.getPackageFragmentRoot(folder);
		IClasspathEntry newSourceEntry = JavaCore.newSourceEntry(root.getPath(),
				new IPath[] {});
		addClasspathEntry(newSourceEntry);
		return root;
	}

	/**
	 * @throws JavaModelException
	 */
	private void addSystemLibraries() throws JavaModelException {
		addClasspathEntry(JavaRuntime.getDefaultJREContainerEntry());
	}

	public List<ICompilationUnit> getAllCompilationUnits() throws CoreException {
		return JavaModelUtility.collectCompilationUnits(getJavaProject());
	}
}