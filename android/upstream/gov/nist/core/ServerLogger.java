/*
 * JBoss, Home of Professional Open Source.
 * 
 * This code has been contributed to the public domain.
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
package gov.nist.core;

import java.util.Properties;

import javax.sip.SipStack;

import gov.nist.javax.sip.message.SIPMessage;

/**
 * @author jean.deruelle@gmail.com
 *
 */
public interface ServerLogger extends LogLevels {
	
   
	 void closeLogFile();
	 
	 void logMessage(SIPMessage message, String from, String to, boolean sender, long time);
	 
	 void logMessage(SIPMessage message, String from, String to, String status,
	            boolean sender, long time);
	 
	 void logMessage(SIPMessage message, String from, String to, String status,
	            boolean sender);
	            	
	 void logException(Exception ex);
	 
	 public void setStackProperties(Properties stackProperties);
	 
	 public void setSipStack(SipStack sipStack);
	 
	
}
