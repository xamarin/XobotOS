package gov.nist.javax.sip.message;

import java.text.ParseException;

import javax.sip.header.ContentDispositionHeader;
import javax.sip.header.ContentTypeHeader;

public class ContentImpl implements Content {
   
   
    /*
     * The content type header for this chunk of content.
     */
   
    private Object content;

    private String boundary;
    
    private ContentTypeHeader contentTypeHeader;
    
    private ContentDispositionHeader contentDispositionHeader;

    

    public ContentImpl( String content, String boundary ) {
        this.content = content;
    
        this.boundary = boundary;
    }

    

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.message.ContentExt#setContent(java.lang.String)
     */
    public void setContent(Object content) {
        this.content = content;
    }

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.message.ContentExt#getContentTypeHeader()
     */
    public ContentTypeHeader getContentTypeHeader() {
        return contentTypeHeader;
    }

    /*
     * (non-Javadoc)
     * @see gov.nist.javax.sip.message.Content#getContent()
     */
    public Object getContent() {
        return this.content;
    }
    

    /* (non-Javadoc)
     * @see gov.nist.javax.sip.message.ContentExt#toString()
     */
    public String toString() {
        // This is not part of a multipart message.
        if (boundary == null) {
            return content.toString();
        } else {
           if ( this.contentDispositionHeader != null ) {
            return "--" + boundary + "\r\n" + getContentTypeHeader() + 
                    this.getContentDispositionHeader().toString() + "\r\n"
                    + content.toString();
           } else {
               return "--" + boundary + "\r\n" + getContentTypeHeader() + "\r\n" +  content.toString();
           }
        }
    }



    /**
     * @param contentDispositionHeader the contentDispositionHeader to set
     */
    public void setContentDispositionHeader(ContentDispositionHeader contentDispositionHeader) {
        this.contentDispositionHeader = contentDispositionHeader;
    }



    /**
     * @return the contentDispositionHeader
     */
    public ContentDispositionHeader getContentDispositionHeader() {
        return contentDispositionHeader;
    }



    /**
     * @param contentTypeHeader the contentTypeHeader to set
     */
    public void setContentTypeHeader(ContentTypeHeader contentTypeHeader) {
        this.contentTypeHeader = contentTypeHeader;
    }


}
