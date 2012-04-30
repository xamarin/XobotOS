package gov.nist.javax.sip;

import javax.sip.SipProvider;

/**
 * Extensions to SipProvider under consideration for Version 2.0.
 * 
 * @since 2.0
 */

public interface SipProviderExt extends SipProvider {
    /**
     * Sets a flag that indicates that automatic error handling is enabled for this dialog (the
     * default when automatic dialog support is enabled). This flag is set by default to TRUE when
     * the Dialog is automatically created by the provider ( automatic dialog support is true) and
     * set to FALSE by default when the Dialog is created under program control ( automatic dialog
     * support is false). When this flag is set to true, the stack will automatically send the
     * following errors :
     * 
     * <ul>
     * <li> <b>500 Request Out of Order </b> for in-dialog requests that arrive out of order.
     * <li> <b>482 Loop Detected </b> When a loop is detected for merged INVITE requests.
     * <li> <b>400 Bad request </b> when a REFER is sent without a matching refer-to dialog.
     * </ul>
     * If this flag is set to false, the stack will not drop out of sequence ACKs but will pass
     * these up to the application for handling.
     * 
     * This flag is automatically set to true if any of the the following conditions is true:
     * <ul>
     * <li>The Back To Back User Agent flag is enabled for the Dialog.</li>
     * <li>The Automatic Dialog Support flag is enabled for the Dialog </li>
     * </ul>
     * 
     * This flag should only be set at the time of Dialog creation ( before the Dialog has seen its first
     * request or response). If set subsequently, the behavior of the flag is undefined.
     * 
     * @since 2.0
     */
    public void setDialogErrorsAutomaticallyHandled();
}
