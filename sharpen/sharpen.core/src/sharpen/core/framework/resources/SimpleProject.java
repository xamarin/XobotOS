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

package sharpen.core.framework.resources;


import org.eclipse.core.resources.*;
import org.eclipse.core.runtime.*;

public class SimpleProject {

	protected final IProject _project;

	public SimpleProject(String name) throws CoreException {
		this(name, null);
	}
	
	public SimpleProject(String name, IProgressMonitor monitor) throws CoreException {
		this(WorkspaceUtilities.getProject(name), monitor);
	}
	
	public SimpleProject(IProject project, IProgressMonitor monitor) throws CoreException {
		_project = project;
		WorkspaceUtilities.initializeProject(_project, monitor);
	}
	
	public String getName() {
		return _project.getName();
	}

	public IFolder createFolder(String name) throws CoreException {
		return createFolder(name, null);
	}
	
	public IFolder createFolder(String name, IProgressMonitor monitor) throws CoreException {
		IFolder folder = getFolder(name);
		folder.create(false, true, monitor);
		return folder;
	}

	public IFolder getFolder(String name) {
	    return _project.getFolder(name);
    }

	public IProject getProject() {
		return _project;
	}
	
	public void dispose() {
		try {
			_project.delete(true, true, null);
		} catch (CoreException x) {
			// just ignore if the resource cant be deleted immediately
			x.printStackTrace();
		}
	}
	
	public void addReferencedProject(IProject reference, IProgressMonitor monitor) throws CoreException {
		if (null == reference) throw new IllegalArgumentException("reference");
		WorkspaceUtilities.addProjectReference(_project, reference, monitor);
	}

	public IFile getFile(String path) {
		return _project.getFile(path);
	}
}