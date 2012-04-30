package javax.sip;

import java.util.EventObject;

public class DialogTerminatedEvent extends EventObject {
    private Dialog mDialog;

    public DialogTerminatedEvent(Object source, Dialog dialog) {
        super(source);
        mDialog = dialog;
    }

    public Dialog getDialog() {
        return mDialog;
    }
}
