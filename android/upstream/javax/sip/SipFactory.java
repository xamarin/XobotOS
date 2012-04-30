package javax.sip;

import java.lang.reflect.Constructor;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;
import javax.sip.address.AddressFactory;
import javax.sip.header.HeaderFactory;
import javax.sip.message.MessageFactory;

public class SipFactory {
    private static final String IP_ADDRESS_PROP = "javax.sip.IP_ADDRESS";
    private static final String STACK_NAME_PROP = "javax.sip.STACK_NAME";

    private static SipFactory sSipFactory = null;

    public static synchronized SipFactory getInstance() {
        if (sSipFactory == null) sSipFactory = new SipFactory();
        return sSipFactory;
    }

    // name-to-SipStack map; name could be IP address for backward compatibility
    private Map<String, SipStack> mNameSipStackMap =
            new HashMap<String, SipStack>();

    private SipFactory() {
    }

    public synchronized void resetFactory() {
        mNameSipStackMap.clear();
    }

    public synchronized SipStack createSipStack(Properties properties)
            throws PeerUnavailableException {
        // for backward compatibility, if IP_ADDRESS_PROP exists, use it and
        // ignore STACK_NAME_PROP.
        String name = properties.getProperty(IP_ADDRESS_PROP);
        if (name == null) {
            name = properties.getProperty(STACK_NAME_PROP);
            if (name == null ) {
                throw new PeerUnavailableException(
                        STACK_NAME_PROP + " property not found");
            }
        }

        SipStack sipStack = mNameSipStackMap.get(name);
        if (sipStack == null) {
            String implClassName = "gov.nist."
                    + SipStack.class.getCanonicalName() + "Impl";
            try {
                sipStack = Class.forName(implClassName)
                        .asSubclass(SipStack.class)
                        .getConstructor(new Class[] {Properties.class})
                        .newInstance(new Object[] {properties});
            } catch (Exception e) {
                throw new PeerUnavailableException(
                        "Failed to initiate " + implClassName, e);
            }
            mNameSipStackMap.put(name, sipStack);
        }
        return sipStack;
    }

    public AddressFactory createAddressFactory()
            throws PeerUnavailableException {
        try {
            return new gov.nist.javax.sip.address.AddressFactoryImpl();
        } catch (Exception e) {
            if (e instanceof PeerUnavailableException) {
                throw (PeerUnavailableException) e;
            } else {
                throw new PeerUnavailableException(
                        "Failed to create AddressFactory", e);
            }
        }
    }

    public HeaderFactory createHeaderFactory() throws PeerUnavailableException {
        try {
            return new gov.nist.javax.sip.header.HeaderFactoryImpl();
        } catch (Exception e) {
            if (e instanceof PeerUnavailableException) {
                throw (PeerUnavailableException) e;
            } else {
                throw new PeerUnavailableException(
                        "Failed to create HeaderFactory", e);
            }
        }
    }

    public MessageFactory createMessageFactory()
            throws PeerUnavailableException {
        try {
            return new gov.nist.javax.sip.message.MessageFactoryImpl();
        } catch (Exception e) {
            if (e instanceof PeerUnavailableException) {
                throw (PeerUnavailableException) e;
            } else {
                throw new PeerUnavailableException(
                        "Failed to create MessageFactory", e);
            }
        }
    }
}
