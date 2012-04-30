package gov.nist.javax.sip;

import javax.sip.Dialog;
import javax.sip.SipProvider;

/**
 * Extensions for Next specification revision. These interfaces will remain unchanged and be
 * merged with the next revision of the spec.
 * 
 * 
 * @author mranga
 * 
 */
public interface DialogExt extends Dialog {

    /**
     * Returns the SipProvider that was used for the first transaction in this Dialog
     * 
     * @return SipProvider
     * 
     * @since 2.0
     */
    public SipProvider getSipProvider();

    /**
     * Sets a flag that indicates that this Dialog is part of a BackToBackUserAgent. If this flag
     * is set, INVITEs are not allowed to interleave and timed out ACK transmission results in a
     * BYE being sent to the other side. Setting this flag instructs the stack to automatically
     * handle dialog errors. Once this flag is set for a dialog, it cannot be changed.
     * This flag can be set on a stack-wide basis, on a per-provider basis or on a per Dialog basis.
     * This flag must only be set at the time of Dialog creation. If the flag is set after the first
     * request or response is seen by the Dialog, the behavior of this flag is undefined.
     * 
     * @since 2.0
     */
    public void setBackToBackUserAgent();
    
    
    /**
     * Turn off sequence number validation for this dialog. This passes all requests to the
     * application layer including those that arrive out of order. This is good for testing
     * purposes. Validation is delegated to the application and the stack will not attempt to
     * block requests arriving out of sequence from reaching the application. In particular, the
     * validation of CSeq and the ACK retransmission recognition are delegated to the application.
     * Your application will be responsible for error handling of these cases.
     * 
     * @since 2.0
     */
    public void disableSequenceNumberValidation();

  
    
    

}
