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

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public abstract class Configuration {

	public enum MappingFlags {
		None,
		CastResult
	}

	public static class MemberMapping {
		public final String name;
		public final MemberKind kind;
		public final MappingFlags flags;

		public MemberMapping(String name, MemberKind kind) {
			this.name = name;
			this.kind = kind;
			this.flags = MappingFlags.None;
		}

		public MemberMapping(String name, MemberKind kind, MappingFlags flags) {
			this.name = name;
			this.kind = kind;
			this.flags = flags;
		}

		@Override
		public String toString() {
			return "MemberMapping(" + name + ", " + kind + ")";
		}

		@Override
		public boolean equals(Object obj) {
			if (!(obj instanceof MemberMapping)) return false;
			MemberMapping other = (MemberMapping)obj;
			return name.equals(other.name) && kind.equals(other.kind) && flags.equals(other.flags);
		}
	}

	public static class NameMapping {
		public final String from;
		public final String to;

		public NameMapping(String from, String to) {
			this.from = from;
			this.to = to;
		}

		@Override
		public boolean equals(Object obj) {
			if (!(obj instanceof NameMapping)) return false;
			NameMapping other = (NameMapping)obj;
			return from.equals(other.from) && to.equals(other.to);
		}
	}

	public static class RegexMapping {
		public final Pattern pattern;
		public final String repl;

		public RegexMapping (Pattern pattern, String repl) {
			this.pattern = pattern;
			this.repl = repl;
		}

		public RegexMapping (String regex, String repl) {
			this.pattern = Pattern.compile(regex);
			this.repl = repl;
		}
	}

	public static class TypeMapping {
		public final String name;

		public TypeMapping(String name) {
			this.name = name;
		}
	}

	private static final WarningHandler NULL_WARNING_HANDLER = new WarningHandler();

	private Map<String, String> _typeMappings = new HashMap<String, String>();

	private Map<String, MemberMapping> _memberMappings = new HashMap<String, MemberMapping>();

	private Map<String, MemberMapping> _memberRenamings = new HashMap<String, MemberMapping>();

	private Map<String, String> _systemConvertWellKnownTypes = new HashMap<String, String>();

	private List<RegexMapping> _namespaceMappings = new ArrayList<RegexMapping>();

	private WarningHandler _warningHandler = Configuration.NULL_WARNING_HANDLER;

	private NamingStrategy _namingStrategy = NamingStrategy.DEFAULT;

	private boolean _ignoreErrors = false;

	private boolean _nativeInterfaces;

	private boolean _organizeUsings;

	private boolean _junitConvert;

	private List<String> _fullyQualifiedTypes = new ArrayList<String>();

	private boolean _createProblemMarkers = false;

	private String _header = "";

	private DocumentationOverlay _docOverlay = NullDocumentationOverlay.DEFAULT;

	private final List<String> _removedMethods = new ArrayList<String>();

	private final Set<String> _mappedEventAdds = new HashSet<String>();

	private final Map<String, String> _mappedEvents = new HashMap<String, String>();

	private List<String> _partialTypes = new ArrayList<String>();

	/**
	 * Maps package names to expressions used in conditional compilation.
	 * Sub-packages will be considered to match also.
	 */
	private Map<String, String> _conditionalCompilations = new HashMap<String, String>();

	protected void mapPrimitive(String typeName) {
		mapType(typeName, typeName);
	}

	public void setDocumentationOverlay(DocumentationOverlay docOverlay) {
		if (null == docOverlay) throw new IllegalArgumentException("docOverlay");
		_docOverlay = docOverlay;
	}

	public DocumentationOverlay documentationOverlay() {
		return _docOverlay;
	}

	public void setWarningHandler(WarningHandler warningHandler) {
		_warningHandler = warningHandler;
	}

	public WarningHandler getWarningHandler() {
		return _warningHandler;
	}

	public void setNamingStrategy(NamingStrategy namingStrategy) {
		_namingStrategy = namingStrategy;
	}

	public NamingStrategy getNamingStrategy() {
		return _namingStrategy;
	}

	public void mapNamespace(String fromRegex, String to) {
		_namespaceMappings.add(new RegexMapping(fromRegex, to));
	}

	public void mapNamespaces(List<RegexMapping> namespaceMappings) {
		_namespaceMappings.addAll(namespaceMappings);
	}

	public void mapMembers(Map<String, MemberMapping> memberMappings) {
		_memberMappings.putAll(memberMappings);
	}

	public String mappedNamespace(String namespace) {
		String mapped = applyNamespaceMappings(namespace);
		return _namingStrategy.namespace(mapped);
	}

	public String mappedTypeName(String typeName, String defaultValue) {
		final String mappedName = _typeMappings.get(typeName);
		if (mappedName != null)
			return mappedName;

		final int i = defaultValue.lastIndexOf('.');
		if (i < 0)
			return _namingStrategy.identifier(defaultValue);

		final String ns = applyNamespaceMappings(defaultValue.substring(0, i));
		return _namingStrategy.namespace(ns + "." + defaultValue.substring(i+1));
	}

	public String applyNamespaceMappings(String typeName) {
		for (RegexMapping mapping : _namespaceMappings) {
			Matcher matcher = mapping.pattern.matcher(typeName);
			if (!matcher.matches())
				continue;
			return matcher.replaceFirst(mapping.repl);
		}
		return typeName;
	}

	public MemberMapping mappedMember(String qualifiedName) {
		return _memberMappings.get(qualifiedName);
	}

	public MemberMapping renamedMember(String qualifiedName) {
		return _memberRenamings.get(qualifiedName);
	}

	public MemberMapping renamedMember(String qualifiedName, MemberKind kind) {
		MemberMapping mapping = _memberRenamings.get(qualifiedName);
		if (mapping == null || mapping.kind != kind)
			return null;
		return mapping;
	}

	public String getConvertRelatedWellKnownTypeName(String mappedConstructor) {
		return _systemConvertWellKnownTypes.get(mappedConstructor);
	}

	public void mapType(String from, String to) {
		_typeMappings.put(from, to);
	}

	public boolean typeHasMapping(String type) {
		return _typeMappings.containsKey(type);
	}

	public void mapField(String fromQualifiedName, String to) {
		mapMember(fromQualifiedName, new MemberMapping(to, MemberKind.Field));
	}

	public void mapMethod(String fromQualifiedName, String to) {
		mapMember(fromQualifiedName, new MemberMapping(to, MemberKind.Method));
	}

	public void mapIndexer(String fromQualifiedName) {
		mapMember(fromQualifiedName, new MemberMapping(null, MemberKind.Indexer));
	}

	public void mapProperty(String fromQualifiedName, String to) {
		mapMember(fromQualifiedName, new MemberMapping(to, MemberKind.Property));
	}

	public void setIgnoreErrors(boolean value) {
		_ignoreErrors = value;
	}

	public boolean getIgnoreErrors() {
		return _ignoreErrors;
	}

	protected void mapMember(String fromQualifiedName, MemberMapping mapping) {
		_memberMappings.put(fromQualifiedName, mapping);
	}

	void renameMember(String fromQualifiedName, MemberMapping mapping) {
		_memberRenamings.put(fromQualifiedName, mapping);
	}

	public void renameField(String fromQualifiedName, String to) {
		renameMember(fromQualifiedName, new MemberMapping(to, MemberKind.Field));
	}

	protected void mapWrapperConstructor(String from, String to, String wellKnownTypeName) {
		mapMethod(from, to);
		_systemConvertWellKnownTypes.put(to, wellKnownTypeName);
	}

	public boolean nativeInterfaces() {
		return _nativeInterfaces;
	}

	public void enableNativeInterfaces() {
		_nativeInterfaces = true;
	}

	public void enableOrganizeUsings() {
		_organizeUsings = true;
	}

	public boolean organizeUsings() {
		return _organizeUsings;
	}

	public void enableJUnitConversion () {
		_junitConvert = true;
	}

	public boolean junitConversion () {
		return _junitConvert;
	}

	public void addFullyQualifiedTypeName(String name) {
		_fullyQualifiedTypes.add(name);
	}

	public void addPartialType (String name) {
		_partialTypes.add (name);
	}

	public boolean shouldFullyQualifyTypeName(String name) {
		//if a type is configured to be fully qualified,
		//then also nested types of it need to be fully qualified
		for( String s : _fullyQualifiedTypes ) {
			if( name.equals(s) || name.startsWith(s + ".") ) {
				return true;
			}
		}
		return false;
	}

	public boolean shouldMakePartial(String name) {
		//if a type is configured to be fully qualified,
		//then also nested types of it need to be fully qualified
		for( String s : _partialTypes) {
			if( name.equals(s) || name.startsWith(s + ".") ) {
				return true;
			}
		}
		return false;
	}

	public void setCreateProblemMarkers(boolean value) {
		_createProblemMarkers = value;
	}

	public boolean createProblemMarkers() {
		return _createProblemMarkers;
	}

	public void setHeader(String header) {
		if (null == header) throw new IllegalArgumentException("header");
		_header = header;
	}

	public String header() {
		return _header;
	}

	public void removeMethod(String fullyQualifiedName) {
		_removedMethods.add(fullyQualifiedName);
	}

	public boolean isRemoved(String qualifiedName) {
		return _removedMethods.contains(qualifiedName);
	}

	public void mapEventAdd(String qualifiedMethodName) {
		_mappedEventAdds.add(qualifiedMethodName);
	}

	public boolean isMappedEventAdd(String qualifiedMethodName) {
		return _mappedEventAdds.contains(qualifiedMethodName);
	}

	public void mapEvent(String qualifiedMethodName, String eventArgsTypeName) {
		mapProperty(qualifiedMethodName, unqualify(qualifiedMethodName));
		_mappedEvents.put(qualifiedMethodName, eventArgsTypeName);
	}

	public String mappedEvent(String qualifiedMethodName) {
		return _mappedEvents.get(qualifiedMethodName);
	}

	private String unqualify(String qualifiedMethodName) {
		final int lastDot = qualifiedMethodName.lastIndexOf('.');
		return lastDot == -1
				? qualifiedMethodName
						: qualifiedMethodName.substring(lastDot+1);
	}

	public void mapEventAdds(Iterable<String> eventAddMappings) {
		for (String m : eventAddMappings) {
			mapEventAdd(m);
		}
	}

	public void mapEvents(Iterable<NameMapping> eventMappings) {
		for (NameMapping m : eventMappings) {
			mapEvent(m.from, m.to);
		}
	}

	public boolean isIgnoredAnnotation(String typeName) {
		return typeName.equals("java.lang.Override");
	}

	public void conditionalCompilation(Map<String, String> conditionalCompilation) {
		_conditionalCompilations = conditionalCompilation;
	}

	public String conditionalCompilationExpressionFor(String packageName) {
		for(String current : _conditionalCompilations.keySet()) {
			if (isSubPackage(current, packageName)) {
				return _conditionalCompilations.get(current);
			}
		}

		return null;
	}

	private boolean isSubPackage(String parentPackage, String packageName) {
		return packageName.startsWith(parentPackage);
	}

	public String toInterfaceName(String name) {
		if (!nativeInterfaces()) {
			return name;
		}
		return "I" + name;
	}

	public abstract boolean isIgnoredExceptionType(String exceptionType);

}
