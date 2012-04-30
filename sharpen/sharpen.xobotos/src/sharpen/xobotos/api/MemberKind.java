package sharpen.xobotos.api;

import com.thoughtworks.xstream.annotations.XStreamAlias;

@XStreamAlias(value="member-kind")
public enum MemberKind {
	CLASS,
	INTERFACE,
	ENUM,
	ANONYMOUS_CLASS,
	METHOD,
	STATIC_CONSTRUCTOR,
	CONSTRUCTOR,
	DESTRUCTOR,
	FIELD
}
