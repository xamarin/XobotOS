package org.bouncycastle.jce.provider;

// BEGIN android-added
import java.math.BigInteger;
// END android-added
import java.security.InvalidAlgorithmParameterException;
import java.security.PublicKey;
import java.security.cert.CertPath;
import java.security.cert.CertPathParameters;
import java.security.cert.CertPathValidatorException;
import java.security.cert.CertPathValidatorResult;
import java.security.cert.CertPathValidatorSpi;
import java.security.cert.PKIXCertPathChecker;
import java.security.cert.PKIXCertPathValidatorResult;
import java.security.cert.PKIXParameters;
import java.security.cert.TrustAnchor;
import java.security.cert.X509Certificate;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

import javax.security.auth.x500.X500Principal;

import org.bouncycastle.asn1.DEREncodable;
import org.bouncycastle.asn1.DERObjectIdentifier;
import org.bouncycastle.asn1.x509.AlgorithmIdentifier;
// BEGIN android-added
import org.bouncycastle.crypto.Digest;
import org.bouncycastle.crypto.digests.OpenSSLDigest;
// END android-added
import org.bouncycastle.jce.exception.ExtCertPathValidatorException;
import org.bouncycastle.x509.ExtendedPKIXParameters;

/**
 * CertPathValidatorSpi implementation for X.509 Certificate validation � la RFC
 * 3280.
 */
public class PKIXCertPathValidatorSpi
        extends CertPathValidatorSpi
{
    // BEGIN android-added

    // From http://src.chromium.org/viewvc/chrome/trunk/src/net/base/x509_certificate.cc?revision=78748&view=markup
    private static final Set<BigInteger> SERIAL_BLACKLIST = new HashSet<BigInteger>(Arrays.asList(
        // Not a real certificate. For testing only.
        new BigInteger(1, new byte[] {(byte)0x07,(byte)0x7a,(byte)0x59,(byte)0xbc,(byte)0xd5,(byte)0x34,(byte)0x59,(byte)0x60,(byte)0x1c,(byte)0xa6,(byte)0x90,(byte)0x72,(byte)0x67,(byte)0xa6,(byte)0xdd,(byte)0x1c}),

        new BigInteger(1, new byte[] {(byte)0x04,(byte)0x7e,(byte)0xcb,(byte)0xe9,(byte)0xfc,(byte)0xa5,(byte)0x5f,(byte)0x7b,(byte)0xd0,(byte)0x9e,(byte)0xae,(byte)0x36,(byte)0xe1,(byte)0x0c,(byte)0xae,(byte)0x1e}),
        new BigInteger(1, new byte[] {(byte)0xd8,(byte)0xf3,(byte)0x5f,(byte)0x4e,(byte)0xb7,(byte)0x87,(byte)0x2b,(byte)0x2d,(byte)0xab,(byte)0x06,(byte)0x92,(byte)0xe3,(byte)0x15,(byte)0x38,(byte)0x2f,(byte)0xb0}),
        new BigInteger(1, new byte[] {(byte)0xb0,(byte)0xb7,(byte)0x13,(byte)0x3e,(byte)0xd0,(byte)0x96,(byte)0xf9,(byte)0xb5,(byte)0x6f,(byte)0xae,(byte)0x91,(byte)0xc8,(byte)0x74,(byte)0xbd,(byte)0x3a,(byte)0xc0}),
        new BigInteger(1, new byte[] {(byte)0x92,(byte)0x39,(byte)0xd5,(byte)0x34,(byte)0x8f,(byte)0x40,(byte)0xd1,(byte)0x69,(byte)0x5a,(byte)0x74,(byte)0x54,(byte)0x70,(byte)0xe1,(byte)0xf2,(byte)0x3f,(byte)0x43}),
        new BigInteger(1, new byte[] {(byte)0xe9,(byte)0x02,(byte)0x8b,(byte)0x95,(byte)0x78,(byte)0xe4,(byte)0x15,(byte)0xdc,(byte)0x1a,(byte)0x71,(byte)0x0a,(byte)0x2b,(byte)0x88,(byte)0x15,(byte)0x44,(byte)0x47}),
        new BigInteger(1, new byte[] {(byte)0xd7,(byte)0x55,(byte)0x8f,(byte)0xda,(byte)0xf5,(byte)0xf1,(byte)0x10,(byte)0x5b,(byte)0xb2,(byte)0x13,(byte)0x28,(byte)0x2b,(byte)0x70,(byte)0x77,(byte)0x29,(byte)0xa3}),
        new BigInteger(1, new byte[] {(byte)0xf5,(byte)0xc8,(byte)0x6a,(byte)0xf3,(byte)0x61,(byte)0x62,(byte)0xf1,(byte)0x3a,(byte)0x64,(byte)0xf5,(byte)0x4f,(byte)0x6d,(byte)0xc9,(byte)0x58,(byte)0x7c,(byte)0x06}),
        new BigInteger(1, new byte[] {(byte)0x39,(byte)0x2a,(byte)0x43,(byte)0x4f,(byte)0x0e,(byte)0x07,(byte)0xdf,(byte)0x1f,(byte)0x8a,(byte)0xa3,(byte)0x05,(byte)0xde,(byte)0x34,(byte)0xe0,(byte)0xc2,(byte)0x29}),
        new BigInteger(1, new byte[] {(byte)0x3e,(byte)0x75,(byte)0xce,(byte)0xd4,(byte)0x6b,(byte)0x69,(byte)0x30,(byte)0x21,(byte)0x21,(byte)0x88,(byte)0x30,(byte)0xae,(byte)0x86,(byte)0xa8,(byte)0x2a,(byte)0x71})
    ));

    // From http://src.chromium.org/viewvc/chrome/branches/782/src/net/base/x509_certificate.cc?r1=98750&r2=98749&pathrev=98750
    private static final byte[][] PUBLIC_KEY_SHA1_BLACKLIST = {
        // C=NL, O=DigiNotar, CN=DigiNotar Root CA/emailAddress=info@diginotar.nl
        {(byte)0x41, (byte)0x0f, (byte)0x36, (byte)0x36, (byte)0x32, (byte)0x58, (byte)0xf3, (byte)0x0b, (byte)0x34, (byte)0x7d,
         (byte)0x12, (byte)0xce, (byte)0x48, (byte)0x63, (byte)0xe4, (byte)0x33, (byte)0x43, (byte)0x78, (byte)0x06, (byte)0xa8},
        // Subject: CN=DigiNotar Cyber CA
        // Issuer: CN=GTE CyberTrust Global Root
        {(byte)0xba, (byte)0x3e, (byte)0x7b, (byte)0xd3, (byte)0x8c, (byte)0xd7, (byte)0xe1, (byte)0xe6, (byte)0xb9, (byte)0xcd,
         (byte)0x4c, (byte)0x21, (byte)0x99, (byte)0x62, (byte)0xe5, (byte)0x9d, (byte)0x7a, (byte)0x2f, (byte)0x4e, (byte)0x37},
        // Subject: CN=DigiNotar Services 1024 CA
        // Issuer: CN=Entrust.net
        {(byte)0xe2, (byte)0x3b, (byte)0x8d, (byte)0x10, (byte)0x5f, (byte)0x87, (byte)0x71, (byte)0x0a, (byte)0x68, (byte)0xd9,
         (byte)0x24, (byte)0x80, (byte)0x50, (byte)0xeb, (byte)0xef, (byte)0xc6, (byte)0x27, (byte)0xbe, (byte)0x4c, (byte)0xa6},
        // Subject: CN=DigiNotar PKIoverheid CA Organisatie - G2
        // Issuer: CN=Staat der Nederlanden Organisatie CA - G2
        {(byte)0x7b, (byte)0x2e, (byte)0x16, (byte)0xbc, (byte)0x39, (byte)0xbc, (byte)0xd7, (byte)0x2b, (byte)0x45, (byte)0x6e,
         (byte)0x9f, (byte)0x05, (byte)0x5d, (byte)0x1d, (byte)0xe6, (byte)0x15, (byte)0xb7, (byte)0x49, (byte)0x45, (byte)0xdb},
        // Subject: CN=DigiNotar PKIoverheid CA Overheid en Bedrijven
        // Issuer: CN=Staat der Nederlanden Overheid CA
        {(byte)0xe8, (byte)0xf9, (byte)0x12, (byte)0x00, (byte)0xc6, (byte)0x5c, (byte)0xee, (byte)0x16, (byte)0xe0, (byte)0x39,
         (byte)0xb9, (byte)0xf8, (byte)0x83, (byte)0x84, (byte)0x16, (byte)0x61, (byte)0x63, (byte)0x5f, (byte)0x81, (byte)0xc5},
    };

    private static boolean isPublicKeyBlackListed(PublicKey publicKey) {
        byte[] encoded = publicKey.getEncoded();
        Digest digest = new OpenSSLDigest.SHA1();
        digest.update(encoded, 0, encoded.length);
        byte[] out = new byte[digest.getDigestSize()];
        digest.doFinal(out, 0);

        for (byte[] sha1 : PUBLIC_KEY_SHA1_BLACKLIST) {
            if (Arrays.equals(out, sha1)) {
                return true;
            }
        }
        return false;
    }

    // END android-added

    public CertPathValidatorResult engineValidate(
            CertPath certPath,
            CertPathParameters params)
            throws CertPathValidatorException,
            InvalidAlgorithmParameterException
    {
        if (!(params instanceof PKIXParameters))
        {
            throw new InvalidAlgorithmParameterException("Parameters must be a " + PKIXParameters.class.getName()
                    + " instance.");
        }

        ExtendedPKIXParameters paramsPKIX;
        if (params instanceof ExtendedPKIXParameters)
        {
            paramsPKIX = (ExtendedPKIXParameters)params;
        }
        else
        {
            paramsPKIX = ExtendedPKIXParameters.getInstance((PKIXParameters)params);
        }
        if (paramsPKIX.getTrustAnchors() == null)
        {
            throw new InvalidAlgorithmParameterException(
                    "trustAnchors is null, this is not allowed for certification path validation.");
        }

        //
        // 6.1.1 - inputs
        //

        //
        // (a)
        //
        List certs = certPath.getCertificates();
        int n = certs.size();

        if (certs.isEmpty())
        {
            throw new CertPathValidatorException("Certification path is empty.", null, certPath, 0);
        }
        // BEGIN android-added
        {
            X509Certificate cert = (X509Certificate) certs.get(0);

            if (cert != null) {
                BigInteger serial = cert.getSerialNumber();
                if (serial != null && SERIAL_BLACKLIST.contains(serial)) {
                    // emulate CRL exception message in RFC3280CertPathUtilities.checkCRLs
                    String message = "Certificate revocation of serial 0x" + serial.toString(16);
                    System.out.println(message);
                    AnnotatedException e = new AnnotatedException(message);
                    throw new CertPathValidatorException(e.getMessage(), e, certPath, 0);
                }
            }
        }
        // END android-added

        //
        // (b)
        //
        // Date validDate = CertPathValidatorUtilities.getValidDate(paramsPKIX);

        //
        // (c)
        //
        Set userInitialPolicySet = paramsPKIX.getInitialPolicies();

        //
        // (d)
        // 
        TrustAnchor trust;
        try
        {
            trust = CertPathValidatorUtilities.findTrustAnchor((X509Certificate) certs.get(certs.size() - 1),
                    paramsPKIX.getTrustAnchors(), paramsPKIX.getSigProvider());
        }
        catch (AnnotatedException e)
        {
            throw new CertPathValidatorException(e.getMessage(), e, certPath, certs.size() - 1);
        }

        if (trust == null)
        {
            throw new CertPathValidatorException("Trust anchor for certification path not found.", null, certPath, -1);
        }

        //
        // (e), (f), (g) are part of the paramsPKIX object.
        //
        Iterator certIter;
        int index = 0;
        int i;
        // Certificate for each interation of the validation loop
        // Signature information for each iteration of the validation loop
        //
        // 6.1.2 - setup
        //

        //
        // (a)
        //
        List[] policyNodes = new ArrayList[n + 1];
        for (int j = 0; j < policyNodes.length; j++)
        {
            policyNodes[j] = new ArrayList();
        }

        Set policySet = new HashSet();

        policySet.add(RFC3280CertPathUtilities.ANY_POLICY);

        PKIXPolicyNode validPolicyTree = new PKIXPolicyNode(new ArrayList(), 0, policySet, null, new HashSet(),
                RFC3280CertPathUtilities.ANY_POLICY, false);

        policyNodes[0].add(validPolicyTree);

        //
        // (b) and (c)
        //
        PKIXNameConstraintValidator nameConstraintValidator = new PKIXNameConstraintValidator();

        // (d)
        //
        int explicitPolicy;
        Set acceptablePolicies = new HashSet();

        if (paramsPKIX.isExplicitPolicyRequired())
        {
            explicitPolicy = 0;
        }
        else
        {
            explicitPolicy = n + 1;
        }

        //
        // (e)
        //
        int inhibitAnyPolicy;

        if (paramsPKIX.isAnyPolicyInhibited())
        {
            inhibitAnyPolicy = 0;
        }
        else
        {
            inhibitAnyPolicy = n + 1;
        }

        //
        // (f)
        //
        int policyMapping;

        if (paramsPKIX.isPolicyMappingInhibited())
        {
            policyMapping = 0;
        }
        else
        {
            policyMapping = n + 1;
        }

        //
        // (g), (h), (i), (j)
        //
        PublicKey workingPublicKey;
        X500Principal workingIssuerName;

        X509Certificate sign = trust.getTrustedCert();
        try
        {
            if (sign != null)
            {
                workingIssuerName = CertPathValidatorUtilities.getSubjectPrincipal(sign);
                workingPublicKey = sign.getPublicKey();
            }
            else
            {
                workingIssuerName = new X500Principal(trust.getCAName());
                workingPublicKey = trust.getCAPublicKey();
            }
        }
        catch (IllegalArgumentException ex)
        {
            throw new ExtCertPathValidatorException("Subject of trust anchor could not be (re)encoded.", ex, certPath,
                    -1);
        }

        AlgorithmIdentifier workingAlgId = null;
        try
        {
            workingAlgId = CertPathValidatorUtilities.getAlgorithmIdentifier(workingPublicKey);
        }
        catch (CertPathValidatorException e)
        {
            throw new ExtCertPathValidatorException(
                    "Algorithm identifier of public key of trust anchor could not be read.", e, certPath, -1);
        }
        DERObjectIdentifier workingPublicKeyAlgorithm = workingAlgId.getObjectId();
        DEREncodable workingPublicKeyParameters = workingAlgId.getParameters();

        //
        // (k)
        //
        int maxPathLength = n;

        //
        // 6.1.3
        //

        if (paramsPKIX.getTargetConstraints() != null
                && !paramsPKIX.getTargetConstraints().match((X509Certificate) certs.get(0)))
        {
            throw new ExtCertPathValidatorException(
                    "Target certificate in certification path does not match targetConstraints.", null, certPath, 0);
        }

        // 
        // initialize CertPathChecker's
        //
        List pathCheckers = paramsPKIX.getCertPathCheckers();
        certIter = pathCheckers.iterator();
        while (certIter.hasNext())
        {
            ((PKIXCertPathChecker) certIter.next()).init(false);
        }

        X509Certificate cert = null;

        for (index = certs.size() - 1; index >= 0; index--)
        {
            // BEGIN android-added
            if (isPublicKeyBlackListed(workingPublicKey)) {
                // emulate CRL exception message in RFC3280CertPathUtilities.checkCRLs
                String message = "Certificate revocation of public key " + workingPublicKey;
                System.out.println(message);
                AnnotatedException e = new AnnotatedException(message);
                throw new CertPathValidatorException(e.getMessage(), e, certPath, index);
            }
            // END android-added
            // try
            // {
            //
            // i as defined in the algorithm description
            //
            i = n - index;

            //
            // set certificate to be checked in this round
            // sign and workingPublicKey and workingIssuerName are set
            // at the end of the for loop and initialized the
            // first time from the TrustAnchor
            //
            cert = (X509Certificate) certs.get(index);
            boolean verificationAlreadyPerformed = (index == certs.size() - 1);

            //
            // 6.1.3
            //

            RFC3280CertPathUtilities.processCertA(certPath, paramsPKIX, index, workingPublicKey,
                verificationAlreadyPerformed, workingIssuerName, sign);

            RFC3280CertPathUtilities.processCertBC(certPath, index, nameConstraintValidator);

            validPolicyTree = RFC3280CertPathUtilities.processCertD(certPath, index, acceptablePolicies,
                    validPolicyTree, policyNodes, inhibitAnyPolicy);

            validPolicyTree = RFC3280CertPathUtilities.processCertE(certPath, index, validPolicyTree);

            RFC3280CertPathUtilities.processCertF(certPath, index, validPolicyTree, explicitPolicy);

            //
            // 6.1.4
            //

            if (i != n)
            {
                if (cert != null && cert.getVersion() == 1)
                {
                    throw new CertPathValidatorException("Version 1 certificates can't be used as CA ones.", null,
                            certPath, index);
                }

                RFC3280CertPathUtilities.prepareNextCertA(certPath, index);

                validPolicyTree = RFC3280CertPathUtilities.prepareCertB(certPath, index, policyNodes, validPolicyTree,
                        policyMapping);

                RFC3280CertPathUtilities.prepareNextCertG(certPath, index, nameConstraintValidator);

                // (h)
                explicitPolicy = RFC3280CertPathUtilities.prepareNextCertH1(certPath, index, explicitPolicy);
                policyMapping = RFC3280CertPathUtilities.prepareNextCertH2(certPath, index, policyMapping);
                inhibitAnyPolicy = RFC3280CertPathUtilities.prepareNextCertH3(certPath, index, inhibitAnyPolicy);

                //
                // (i)
                //
                explicitPolicy = RFC3280CertPathUtilities.prepareNextCertI1(certPath, index, explicitPolicy);
                policyMapping = RFC3280CertPathUtilities.prepareNextCertI2(certPath, index, policyMapping);

                // (j)
                inhibitAnyPolicy = RFC3280CertPathUtilities.prepareNextCertJ(certPath, index, inhibitAnyPolicy);

                // (k)
                RFC3280CertPathUtilities.prepareNextCertK(certPath, index);

                // (l)
                maxPathLength = RFC3280CertPathUtilities.prepareNextCertL(certPath, index, maxPathLength);

                // (m)
                maxPathLength = RFC3280CertPathUtilities.prepareNextCertM(certPath, index, maxPathLength);

                // (n)
                RFC3280CertPathUtilities.prepareNextCertN(certPath, index);

                Set criticalExtensions = cert.getCriticalExtensionOIDs();
                if (criticalExtensions != null)
                {
                    criticalExtensions = new HashSet(criticalExtensions);

                    // these extensions are handled by the algorithm
                    criticalExtensions.remove(RFC3280CertPathUtilities.KEY_USAGE);
                    criticalExtensions.remove(RFC3280CertPathUtilities.CERTIFICATE_POLICIES);
                    criticalExtensions.remove(RFC3280CertPathUtilities.POLICY_MAPPINGS);
                    criticalExtensions.remove(RFC3280CertPathUtilities.INHIBIT_ANY_POLICY);
                    criticalExtensions.remove(RFC3280CertPathUtilities.ISSUING_DISTRIBUTION_POINT);
                    criticalExtensions.remove(RFC3280CertPathUtilities.DELTA_CRL_INDICATOR);
                    criticalExtensions.remove(RFC3280CertPathUtilities.POLICY_CONSTRAINTS);
                    criticalExtensions.remove(RFC3280CertPathUtilities.BASIC_CONSTRAINTS);
                    criticalExtensions.remove(RFC3280CertPathUtilities.SUBJECT_ALTERNATIVE_NAME);
                    criticalExtensions.remove(RFC3280CertPathUtilities.NAME_CONSTRAINTS);
                }
                else
                {
                    criticalExtensions = new HashSet();
                }

                // (o)
                RFC3280CertPathUtilities.prepareNextCertO(certPath, index, criticalExtensions, pathCheckers);
                
                // set signing certificate for next round
                sign = cert;

                // (c)
                workingIssuerName = CertPathValidatorUtilities.getSubjectPrincipal(sign);

                // (d)
                try
                {
                    workingPublicKey = CertPathValidatorUtilities.getNextWorkingKey(certPath.getCertificates(), index);
                }
                catch (CertPathValidatorException e)
                {
                    throw new CertPathValidatorException("Next working key could not be retrieved.", e, certPath, index);
                }

                workingAlgId = CertPathValidatorUtilities.getAlgorithmIdentifier(workingPublicKey);
                // (f)
                workingPublicKeyAlgorithm = workingAlgId.getObjectId();
                // (e)
                workingPublicKeyParameters = workingAlgId.getParameters();
            }
        }

        //
        // 6.1.5 Wrap-up procedure
        //

        explicitPolicy = RFC3280CertPathUtilities.wrapupCertA(explicitPolicy, cert);

        explicitPolicy = RFC3280CertPathUtilities.wrapupCertB(certPath, index + 1, explicitPolicy);

        //
        // (c) (d) and (e) are already done
        //

        //
        // (f)
        //
        Set criticalExtensions = cert.getCriticalExtensionOIDs();

        if (criticalExtensions != null)
        {
            criticalExtensions = new HashSet(criticalExtensions);
            // these extensions are handled by the algorithm
            criticalExtensions.remove(RFC3280CertPathUtilities.KEY_USAGE);
            criticalExtensions.remove(RFC3280CertPathUtilities.CERTIFICATE_POLICIES);
            criticalExtensions.remove(RFC3280CertPathUtilities.POLICY_MAPPINGS);
            criticalExtensions.remove(RFC3280CertPathUtilities.INHIBIT_ANY_POLICY);
            criticalExtensions.remove(RFC3280CertPathUtilities.ISSUING_DISTRIBUTION_POINT);
            criticalExtensions.remove(RFC3280CertPathUtilities.DELTA_CRL_INDICATOR);
            criticalExtensions.remove(RFC3280CertPathUtilities.POLICY_CONSTRAINTS);
            criticalExtensions.remove(RFC3280CertPathUtilities.BASIC_CONSTRAINTS);
            criticalExtensions.remove(RFC3280CertPathUtilities.SUBJECT_ALTERNATIVE_NAME);
            criticalExtensions.remove(RFC3280CertPathUtilities.NAME_CONSTRAINTS);
            criticalExtensions.remove(RFC3280CertPathUtilities.CRL_DISTRIBUTION_POINTS);
        }
        else
        {
            criticalExtensions = new HashSet();
        }

        RFC3280CertPathUtilities.wrapupCertF(certPath, index + 1, pathCheckers, criticalExtensions);

        PKIXPolicyNode intersection = RFC3280CertPathUtilities.wrapupCertG(certPath, paramsPKIX, userInitialPolicySet,
                index + 1, policyNodes, validPolicyTree, acceptablePolicies);

        if ((explicitPolicy > 0) || (intersection != null))
        {
            return new PKIXCertPathValidatorResult(trust, intersection, cert.getPublicKey());
        }

        throw new CertPathValidatorException("Path processing failed on policy.", null, certPath, index);
    }

}
