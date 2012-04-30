package javax.sip;

import java.util.EventObject;
import javax.sip.message.Response;

public class ResponseEvent extends EventObject {
    private Dialog mDialog;
    private Response mResponse;
    private ClientTransaction mClientTransaction;

    public ResponseEvent(Object source, ClientTransaction clientTransaction,
            Dialog dialog, Response response) {
        super(source);
        mDialog = dialog;
        mResponse = response;
        mClientTransaction = clientTransaction;
    }

    public Dialog getDialog() {
        return mDialog;
    }

    public Response getResponse() {
        return mResponse;
    }

    public ClientTransaction getClientTransaction(){
        return mClientTransaction;
    }
}
