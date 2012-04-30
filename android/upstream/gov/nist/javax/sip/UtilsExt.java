/*
 * JBoss, Home of Professional Open Source
 * This code has been contributed to the public domain.
 * 
 * This software is provided by NIST as a service and is expressly
 * provided "AS IS."  NIST MAKES NO WARRANTY OF ANY KIND, EXPRESS, IMPLIED
 * OR STATUTORY, INCLUDING, WITHOUT LIMITATION, THE IMPLIED WARRANTY OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT
 * AND DATA ACCURACY.  NIST does not warrant or make any representations
 * regarding the use of the software or the results thereof, including but
 * not limited to the correctness, accuracy, reliability or usefulness of
 * the software.
 *
 * Permission to use this software is contingent upon your acceptance
 * of the terms of this agreement.
 */
package gov.nist.javax.sip;

/**
 * @author jean.deruelle@gmail.com
 *
 */
public interface UtilsExt {

    /**
     * Generate a call identifier. This is useful when we want to generate a
     * call identifier in advance of generating a message.
     * @since 2.0
     */
    public String generateCallIdentifier(String address);

    /**
     * Generate a tag for a FROM header or TO header. Just return a random 4
     * digit integer (should be enough to avoid any clashes!) Tags only need to
     * be unique within a call.
     *
     * @return a string that can be used as a tag parameter.
     *
     * synchronized: needed for access to 'rand', else risk to generate same tag
     * twice
     * @since 2.0
     */
    public String generateTag();
    /**
     * Generate a cryptographically random identifier that can be used to
     * generate a branch identifier.
     *
     * @return a cryptographically random gloablly unique string that can be
     *         used as a branch identifier.
     * @since 2.0
     */
    public String generateBranchId();
    
    
}
