package gov.nist.javax.sip;

import javax.sip.ServerTransaction;


public interface ServerTransactionExt extends ServerTransaction, TransactionExt {
    /**
     * Return the canceled Invite transaction corresponding to an
     * incoming CANCEL server transaction.
     *
     * @return -- the canceled Invite transaction.
     *
     */
    public ServerTransaction getCanceledInviteTransaction();
}
