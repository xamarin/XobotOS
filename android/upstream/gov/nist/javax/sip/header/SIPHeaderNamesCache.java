package gov.nist.javax.sip.header;

import java.util.HashMap;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

/**
 * @author yanick.belanger
 */
public abstract class SIPHeaderNamesCache
{
    private static final HashMap lowercaseMap = new HashMap();

    static {
        Field[] fields = SIPHeaderNames.class.getFields();
        for (int i = 0; i < fields.length; i++) {
            Field field = fields[i];
            if (field.getType().equals(String.class) && Modifier.isStatic(field.getModifiers())) {
                try {
                    String value = (String) field.get(null);
                    String lowerCase = value.toLowerCase();
                    lowercaseMap.put(value, lowerCase);
                    lowercaseMap.put(lowerCase, lowerCase);
                } catch (IllegalAccessException e) {
                }
            }
        }
    }

    public static String toLowerCase(String headerName) {
        String lowerCase = (String) lowercaseMap.get(headerName);
        if (lowerCase == null) {
            return headerName.toLowerCase();
        }
        else {
            return lowerCase;
        }
    }
}
