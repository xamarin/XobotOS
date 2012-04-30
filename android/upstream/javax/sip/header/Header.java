package javax.sip.header;

import java.io.Serializable;

public interface Header extends Cloneable, Serializable {
    String getName();

    Object clone();
    boolean equals(Object obj);
    int hashCode();
    String toString();
}
