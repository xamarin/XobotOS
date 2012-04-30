package sharpen.xobotos.api.templates;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

import sharpen.xobotos.config.LocationFilter;
import sharpen.xobotos.config.LocationFilter.Match;

import java.util.List;

public class AbstractLocationTemplate extends AbstractTemplate {

	@XStreamImplicit(itemFieldName = "location-filter")
	private List<LocationFilter> _locationFilters;

	public boolean hasLocationFilters() {
		return _locationFilters != null;
	}

	public Match matches(String name) {
		if (getName() != null) {
			if (name.equals(getName()))
				return Match.POSITIVE;
			else
				return Match.NO_MATCH;
		}

		if (_locationFilters == null)
			return Match.POSITIVE;

		for (final LocationFilter filter : _locationFilters) {
			Match match = filter.matches(name);
			if (match != Match.NO_MATCH)
				return match;
		}

		return Match.NO_MATCH;
	}

	@Override
	protected void print(StringBuilder sb) {
		if (_locationFilters != null) {
			for (final LocationFilter filter : _locationFilters) {
				sb.append(':');
				sb.append(filter);
			}
		}
		super.print(sb);
	}

}
