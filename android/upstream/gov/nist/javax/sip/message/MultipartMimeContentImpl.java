package gov.nist.javax.sip.message;

import gov.nist.javax.sip.header.HeaderFactoryExt;
import gov.nist.javax.sip.header.HeaderFactoryImpl;
import gov.nist.javax.sip.parser.StringMsgParser;

import java.text.ParseException;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;

import javax.sip.header.ContentDispositionHeader;
import javax.sip.header.ContentTypeHeader;
import javax.sip.header.Header;
import javax.sip.header.HeaderFactory;
import javax.sip.message.Message;



/**
 * Content list for multipart mime content type.
 * 
 * @author M. Ranganathan
 * 
 */
public class MultipartMimeContentImpl implements MultipartMimeContent {
    private List<Content> contentList = new LinkedList<Content>();

    private ContentTypeHeader multipartMimeContentTypeHeader;

    private String boundary;

    public static String BOUNDARY = "boundary";

    /**
     * Creates a default content list.
     */
    public MultipartMimeContentImpl(ContentTypeHeader contentTypeHeader) {
        this.multipartMimeContentTypeHeader = contentTypeHeader;
        this.boundary = contentTypeHeader.getParameter(BOUNDARY);

    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.message.MultipartMimeContentExt#add(gov.nist.javax.sip.message.Content)
     */
    public boolean add(Content content) {
        return contentList.add((ContentImpl) content);
    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.message.MultipartMimeContentExt#getContentTypeHeader()
     */
    public ContentTypeHeader getContentTypeHeader() {
        return multipartMimeContentTypeHeader;
    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.message.MultipartMimeContentExt#toString()
     */
    @Override
    public String toString() {
        StringBuffer stringBuffer = new StringBuffer();

        for (Content content : this.contentList) {
            stringBuffer.append(content.toString());
        }
        return stringBuffer.toString();

    }

    /**
     * unpack a multipart mime packet and return a list of content packets.
     * 
     * @return -- an iterator of Content blocks.
     * 
     */
    public void createContentList(String body) throws ParseException {
        try {
            HeaderFactoryExt headerFactory = new HeaderFactoryImpl();
            String delimiter = this.getContentTypeHeader().getParameter(BOUNDARY);

            if (delimiter == null) {
                this.contentList = new LinkedList<Content>();
                ContentImpl content = new ContentImpl(body, delimiter);
                content.setContentTypeHeader(this.getContentTypeHeader());
                this.contentList.add(content);
                return;
            }

            String[] fragments = body.split("--" + delimiter + "\r\n");


            for (String nextPart : fragments) {
                // NOTE - we are not hanlding line folding for the sip header here.

                if (nextPart == null) {
                    return;
                }
                StringBuffer strbuf = new StringBuffer(nextPart);
                while (strbuf.length() > 0
                        && (strbuf.charAt(0) == '\r' || strbuf.charAt(0) == '\n'))
                    strbuf.deleteCharAt(0);

                if (strbuf.length() == 0)
                    continue;
                nextPart = strbuf.toString();
                int position = nextPart.indexOf("\r\n\r\n");
                int off = 4;
                if (position == -1) {
                    position = nextPart.indexOf("\n");
                    off = 2;
                }
                if (position == -1)
                    throw new ParseException("no content type header found in " + nextPart, 0);
                String rest = nextPart.substring(position + off);

                if (rest == null)
                    throw new ParseException("No content [" + nextPart + "]", 0);
                // logger.debug("rest = [[" + rest + "]]");
                String headers = nextPart.substring(0, position);
                ContentImpl content = new ContentImpl(rest, boundary);

                String[] headerArray = headers.split("\r\n");
                for (String hdr : headerArray) {
                    Header header = headerFactory.createHeader(hdr);
                    if (header instanceof ContentTypeHeader) {
                        content.setContentTypeHeader((ContentTypeHeader) header);
                    } else if (header instanceof ContentDispositionHeader) {
                        content.setContentDispositionHeader((ContentDispositionHeader) header);
                    } else {
                        throw new ParseException("Unexpected header type " + header.getName(), 0);
                    }
                    contentList.add(content);
                }

            }
        } catch (StringIndexOutOfBoundsException ex) {
            throw new ParseException("Invalid Multipart mime format", 0);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.message.MultipartMimeContentExt#getContentByType(java.lang.String,
     *      java.lang.String)
     */
    public Content getContentByType(String contentType, String contentSubtype) {
        Content retval = null;
        if (contentList == null)
            return null;
        for (Content content : contentList) {
            if (content.getContentTypeHeader().getContentType().equalsIgnoreCase(contentType)
                    && content.getContentTypeHeader().getContentSubType().equalsIgnoreCase(
                            contentSubtype)) {
                retval = content;
                break;
            }

        }
        return retval;
    }

    /*
     * (non-Javadoc)
     * 
     * @see gov.nist.javax.sip.message.MultipartMimeContentExt#setContent(java.lang.String,
     *      java.lang.String, gov.nist.javax.sip.message.Content)
     */
    public void addContent(Content content) {
        this.add(content);
    }

    public Iterator<Content> getContents() {
        return this.contentList.iterator();
    }

    
    public int getContentCount() {
        return this.contentList.size();
    }

}
