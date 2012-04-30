package sharpen.xobotos.config;

import com.thoughtworks.xstream.annotations.XStreamAlias;
import com.thoughtworks.xstream.annotations.XStreamAsAttribute;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

import java.util.List;

@XStreamAlias(value="location-filter")
public final class LocationFilter {
	@XStreamImplicit(itemFieldName="include")
	List<String> _include;

	@XStreamImplicit(itemFieldName="exclude")
	List<String> _exclude;

	@XStreamAsAttribute
	@XStreamAlias("regex")
	boolean _is_regex;

	@XStreamAsAttribute
	@XStreamAlias("must-match")
	private boolean _mustMatch;

	@XStreamAsAttribute
	@XStreamAlias("substring")
	boolean _is_substring;

	public enum Match {
		NO_MATCH,
		POSITIVE,
		NEGATIVE
	};

	boolean matches(final List<String> list, final String name) {
		for (final String item : list) {
			if (_is_regex) {
				if (name.matches(item))
					return true;
			} else if (_is_substring) {
				if (name.startsWith(item))
					return true;
			} else {
				if (name.equals(item))
					return true;
			}
		}
		return false;
	}

	public Match matches(final String name) {
		if ((_include != null) && matches(_include, name))
			return Match.POSITIVE;
		if ((_exclude != null) && matches(_exclude, name))
			return Match.NEGATIVE;
		if (_mustMatch)
			return Match.NO_MATCH;
		return _include == null ? Match.POSITIVE : Match.NO_MATCH;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append('{');
		if (_is_regex)
			sb.append('?');
		else if (_is_substring)
			sb.append('$');
		if (_mustMatch)
			sb.append("&");
		boolean first = true;
		if (_include != null) {
			for (String text : _include) {
				if (first)
					first = false;
				else
					sb.append(',');
				sb.append("+" + text);
			}
		}
		if (_exclude != null) {
			for (String text : _exclude) {
				if (first)
					first = false;
				else
					sb.append(',');
				sb.append("-" + text);
			}
		}
		sb.append('}');
		return sb.toString();
	}
}
