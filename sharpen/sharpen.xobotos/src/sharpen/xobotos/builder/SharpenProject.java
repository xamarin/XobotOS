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

import java.io.*;

import sharpen.core.SharpenConstants;
import sharpen.core.framework.resources.*;

import org.eclipse.core.resources.*;
import org.eclipse.core.runtime.*;

import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.DomDriver;

public class SharpenProject implements ISharpenProject {
	
	private static QualifiedName PROJECT_SESSION_KEY = new QualifiedName("sharpen.core.builder", "SharpenProject");
	
	private static String SETTINGS_FILE = ".sharpen";
	
	public static ISharpenProject create(IProject project) throws CoreException {
		return create(project, null);
	}

	public static ISharpenProject create(IProject project, IProgressMonitor monitor) throws CoreException {
		if (!project.hasNature(SharpenNature.NATURE_ID)) {
			return null;
		}
		ISharpenProject cached = (ISharpenProject) project.getSessionProperty(PROJECT_SESSION_KEY);
		if (null == cached) {
			cached = new SharpenProject(project);
			project.setSessionProperty(PROJECT_SESSION_KEY, cached);
		}
		return cached;
	}
	
	private final IProject _project;
	
	private IProject _targetProject;
	
	private SharpenProject(IProject project) {
		_project = project;
		_targetProject = getUninitializedTargetProject(project);
	}

	private IProject getUninitializedTargetProject(IProject project) {
		return WorkspaceUtilities.getWorkspaceRoot().getProject(project.getName() + SharpenConstants.SHARPENED_PROJECT_SUFFIX);
	}

	public void setTargetProject(IProject project) {
		if (null == project) {
			throw new IllegalArgumentException("project");
		}
		_targetProject = project;
	}
	
	public IProject getTargetProject() {
		return _targetProject;
	}
	
	public void save(IProgressMonitor monitor) throws CoreException {
		WorkspaceUtilities.writeFile(getSettingsFile(), toEncodedXml(), WorkspaceUtilities.DEFAULT_CHARSET, monitor);
	}

	public static void writeFile(IFile file, final InputStream contents, final String charset, IProgressMonitor monitor) 
		throws CoreException {
		
		WorkspaceUtilities.writeFile(file, contents, charset, monitor);
		
	}

	private InputStream toEncodedXml() throws CoreException {
		return encode(toXml());
	}

	private String toXml() {
		XStream stream = createXStream();
		return stream.toXML(new Remembrance(this));
	}
	
	private IFile getSettingsFile() {
		return _project.getFile(SETTINGS_FILE);
	}
	
	private XStream createXStream() {
		XStream stream = new XStream(new DomDriver());
		stream.alias("sharpen", Remembrance.class);
		return stream;
	}

	private InputStream encode(String xml) throws CoreException {
		return WorkspaceUtilities.encode(xml, WorkspaceUtilities.DEFAULT_CHARSET);
	}

	public static final class Remembrance {
		public String targetFolder;
		
		public Remembrance(SharpenProject project) {
			targetFolder = project.getTargetProject().getFullPath().toPortableString();
		}
	}
}
