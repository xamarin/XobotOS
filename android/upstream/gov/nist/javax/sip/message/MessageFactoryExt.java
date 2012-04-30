package gov.nist.javax.sip.message;

import javax.sip.header.ContentTypeHeader;
import javax.sip.header.ServerHeader;
import javax.sip.header.UserAgentHeader;
import javax.sip.message.MessageFactory;

/**
 * Intefaces that will be supported by the next release of JAIN-SIP.
 *
 * @author mranga
 *
 */
public interface MessageFactoryExt extends MessageFactory {
    /**
     * Set the common UserAgent header for all Requests created from this message factory.
     * This header is applied to all Messages created from this Factory object except those
     * that take String for an argument and create Message from the given String.
     *
     * @param userAgent -- the user agent header to set.
     *
     */

    public void setDefaultUserAgentHeader(UserAgentHeader userAgent);


    /**
     * Set the common Server header for all Responses created from this message factory.
     * This header is applied to all Messages created from this Factory object except those
     * that take String for an argument and create Message from the given String.
     *
     * @param userAgent -- the user agent header to set.
     * 
     * @since 2.0
     *
     */

    public void setDefaultServerHeader(ServerHeader userAgent);

    /**
     * Set default charset used for encoding String content. Note that this
     * will be applied to all content that is encoded. The default is UTF-8.
     * 
     * @since 2.0
     *
     * @param charset -- charset to set.
     * @throws NullPointerException if null arg
     * @throws IllegalArgumentException if Charset is not a known charset.
     *
     */
    public  void setDefaultContentEncodingCharset(String charset)
            throws NullPointerException,IllegalArgumentException ;
    
    /**
     * Create a MultipartMime attachment from a list of content type, subtype and content.
     * 
     * @since 2.0
     * 
     * @throws NullPointerException, IllegalArgumentException
     */
    public MultipartMimeContent createMultipartMimeContent(ContentTypeHeader multipartMimeContentTypeHeader,
            String[] contentType, 
            String[] contentSubtype, 
            String[] contentBody);
    
    
    
    
    
}
