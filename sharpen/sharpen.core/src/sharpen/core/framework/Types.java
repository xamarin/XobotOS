package sharpen.core.framework;

import java.util.List;

public class Types {

	@SuppressWarnings("unchecked")
	public static <T> T cast(Object o) {
		return (T) o;
	}

	public static <T> List<T> cast(List list) {
		return (List<T>) list;
	}

}
