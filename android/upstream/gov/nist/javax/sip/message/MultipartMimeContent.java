package gov.nist.javax.sip.message;

import java.util.Iterator;
import java.util.List;

import javax.sip.header.ContentTypeHeader;

public interface MultipartMimeContent {

    public abstract boolean add(Content content);

    /**
     * Return the Content type header to assign to the outgoing sip meassage.
     * 
     * @return
     */
    public abstract ContentTypeHeader getContentTypeHeader();

    public abstract String toString();

    /**
     * Set the content by its type.
     * 
     * @param content
     */
    public abstract void addContent( Content content);
    
    /**
     * Retrieve the list of Content that is part of this MultitypeMime content.
     * 
     * @return - the content iterator. Returns an empty iterator if no content list present.
     */
    public Iterator<Content> getContents();
    
    /**
     * Get the number of Content parts.
     * 
     * @return - the content parts.
     */
    public int getContentCount();

}
