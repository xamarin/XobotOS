package gov.nist.javax.sip.header.extensions;

import gov.nist.javax.sip.header.ParametersHeader;

import java.text.ParseException;
import java.util.Iterator;

import javax.sip.header.ExtensionHeader;

public class References extends ParametersHeader  implements ReferencesHeader,ExtensionHeader  {

    private static final long serialVersionUID = 8536961681006637622L;
    
    
    private String callId;
    
    public References() {
        super(ReferencesHeader.NAME);
    }
  
   

  
    public String getCallId() {
       return callId;
    }

  
   
    public String getRel() {
        return this.getParameter(REL);
    }

   


    public void setCallId(String callId) {
        this.callId = callId;
    }

       
    public void setRel(String rel) throws ParseException{
      if ( rel != null ) {
          this.setParameter(REL,rel);
      }
    }

  
    public String getParameter(String name) {
        return super.getParameter(name);
    }

    
    public Iterator getParameterNames() {
        return super.getParameterNames();
    }

   
    public void removeParameter(String name) {
       super.removeParameter(name);
    }

    
    public void setParameter(String name, String value) throws ParseException {
       super.setParameter(name,value); 
    }

 
    public String getName() {
        return ReferencesHeader.NAME;
    }

   
    protected String encodeBody() {
        if ( super.parameters.isEmpty()) {
            return callId ;
        } else {
            return callId + ";" + super.parameters.encode();
        }
    }

   
    public void setValue(String value) throws ParseException {
        throw new UnsupportedOperationException("operation not supported");
    }

}
