package javax.sip;

import java.util.EventObject;
import javax.sip.message.Request;

public class RequestEvent extends EventObject {
    private Dialog mDialog;
    private Request mRequest;
    private ServerTransaction mServerTransaction;

    public RequestEvent(Object source, ServerTransaction serverTransaction,
            Dialog dialog, Request request) {
        super(source);
        mDialog  = dialog;
        mRequest = request;
        mServerTransaction = serverTransaction;
    }

    public Dialog getDialog() {
        return mDialog;
    }

    public Request getRequest() {
        return mRequest;
    }

    public ServerTransaction getServerTransaction() {
        return mServerTransaction;
    }
}
