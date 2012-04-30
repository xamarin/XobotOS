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

package sharpen.xobotos.builder;

import org.eclipse.core.resources.*;
import org.eclipse.core.runtime.CoreException;
import org.eclipse.core.runtime.IProgressMonitor;
import org.eclipse.jdt.core.ICompilationUnit;
import org.eclipse.jdt.core.IJavaProject;
import org.eclipse.jdt.core.JavaCore;

import sharpen.core.JavaModelUtility;
import sharpen.core.framework.resources.WorkspaceUtilities;
import sharpen.xobotos.Activator;
import sharpen.xobotos.XobotBuilder;
import sharpen.xobotos.config.ConfigFile;
import sharpen.xobotos.config.SourceInfo;
import sharpen.xobotos.config.xstream.XStreamUtils;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SharpenBuilder extends IncrementalProjectBuilder {

	class ChangedCompilationUnitCollector implements IResourceDeltaVisitor {

		private final ArrayList<ICompilationUnit> _changes = new ArrayList<ICompilationUnit>();

		@Override
		public boolean visit(IResourceDelta delta) throws CoreException {
			IResource resource = delta.getResource();
			switch (delta.getKind()) {
			case IResourceDelta.ADDED:
				changed(resource);
				break;
			case IResourceDelta.REMOVED:
				// handle removed resource
				break;
			case IResourceDelta.CHANGED:
				changed(resource);
				break;
			}
			//return true to continue visiting children.
			return true;
		}

		public List<ICompilationUnit> changes() {
			return _changes;
		}

		private void changed(IResource resource) {
			if (isSourceFile(resource)) {
				_changes.add((ICompilationUnit) JavaCore.create(resource));
			}
		}

		private boolean isSourceFile(IResource resource) {
			if (resource.getType() != IResource.FILE) {
				return false;
			}
			if (resource.getFileExtension() == null)
				return false;
			return resource.getFileExtension().equals("java");
		}
	}

	public static final String BUILDER_ID = Activator.PLUGIN_ID + ".sharpenBuilder";

	public static final String CONFIG_FILE_ARG = "configFile";

	private ConfigFile getConfigFile() {
		ICommand command = getCommand();
		Map<String,String> args = command.getArguments();
		if (!args.containsKey(CONFIG_FILE_ARG))
			throw new RuntimeException("Missing configFile section in builder spec.");
		String fileName = args.get(CONFIG_FILE_ARG);
		String fullPath = getProject().getLocation().append(fileName).toOSString();
		try {
			return XStreamUtils.read(fullPath, ConfigFile.class);
		} catch (Exception e) {
			throw new RuntimeException("Cannot read configuration file: " + fullPath);
		}
	}

	@Override
	protected void clean(IProgressMonitor monitor) throws CoreException {
		final ConfigFile configFile = getConfigFile();
		final SourceInfo sourceInfo = configFile.getSourceInfo();
		final IFolder outputFolder = getProject().getFolder(sourceInfo.getOutputFolder());
		outputFolder.delete(true, false, monitor);
	}

	@Override
	protected IProject[] build(int kind, Map<String,String> args, IProgressMonitor monitor)
			throws CoreException {
		final ConfigFile configFile = getConfigFile();
		final SourceInfo sourceInfo = configFile.getSourceInfo();
		final IFolder outputFolder = getProject().getFolder(sourceInfo.getOutputFolder());

		try {
			if (kind == CLEAN_BUILD) {
				outputFolder.delete(true, false, monitor);
				return null;
			} else if (kind == FULL_BUILD)
				outputFolder.delete(true, false, null);
			else if (kind == AUTO_BUILD || kind == INCREMENTAL_BUILD)
				WorkspaceUtilities.initializeTree(outputFolder, null);
			else
				return null;
		} catch (Exception e) {
			throw new RuntimeException("Cannot setup build environment: " + e);
		}

		Map<ICompilationUnit,Boolean> sources = new HashMap<ICompilationUnit,Boolean> ();

		final IJavaProject javaProject = JavaCore.create(getProject());
		final List<ICompilationUnit> allUnits = JavaModelUtility.collectCompilationUnits(javaProject);

		if (kind == FULL_BUILD) {
			for (final ICompilationUnit unit : allUnits) {
				sources.put(unit, true);
			}
		} else {
			for (final ICompilationUnit unit : allUnits) {
				sources.put(unit, false);
			}
			IResourceDelta delta = getDelta(getProject());
			ChangedCompilationUnitCollector collector = new ChangedCompilationUnitCollector();
			delta.accept(collector);
			for (final ICompilationUnit unit : collector.changes()) {
				sources.put(unit, true);
			}
		}

		XobotBuilder.run(configFile, getProject(), sources, monitor);
		return null;
	}
}
