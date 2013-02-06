using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Foretagsplatsen.Api2.Saml
{
    public class FtgpSamlAssertionService
    {
        private const string SamlXmlNamespace = "urn:oasis:names:tc:SAML:2.0:assertion";
        private const string SamlXmlPrefix = "saml";
        private const string NameFormat = "urn:oasis:names:tc:SAML:2.0:attrname-format:basic";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        private readonly X509Certificate2 privateCertificate;
        private readonly X509Certificate2 publicFtgpCertificate;
        private readonly string issuerText;

        public FtgpSamlAssertionService(X509Certificate2 privateCertificate, X509Certificate2 publicFtgpCertificate, string issuer)
        {
            this.privateCertificate = privateCertificate;
            this.publicFtgpCertificate = publicFtgpCertificate;

            this.issuerText = issuer;
        }

        public XmlDocument CreateEncryptedAssertionDocument(FtgpSamlAssertionInfo samlAssertionInfo)
        {
            if (samlAssertionInfo == null || samlAssertionInfo.Roles == null || !samlAssertionInfo.Roles.Any())
            {
                throw new Exception("The SAML assertion info does not contain any roles.");
            }

            var assertionDocument = CreateAssertionDocument(samlAssertionInfo);

            SignAssertionDocument(assertionDocument, samlAssertionInfo.AssertionId);

            var encryptedAssertionDocument = CreateEmptyEncryptedAssertionDocument();
            var encryptedData = CreateEncryptedData(assertionDocument.DocumentElement, publicFtgpCertificate);

            AddEncryptedData(encryptedAssertionDocument, encryptedData);

            return encryptedAssertionDocument;
        }

        private XmlDocument CreateAssertionDocument(FtgpSamlAssertionInfo samlAssertionInfo)
        {
            var doc = new XmlDocument();
           
            var assertion = CreateEmptyAssertion(doc, samlAssertionInfo.AssertionId, DateTime.Now);
            
            var issuer = CreateIssuer(doc, issuerText);
            var conditions = CreateConditions(doc, samlAssertionInfo.NotBefore, samlAssertionInfo.NotOnOrAfter);
            var nameAttributeStatement = CreateAttributeStatement(doc, "name", samlAssertionInfo.Name);
            var emailAttributeStatement = CreateAttributeStatement(doc, "emailaddress", samlAssertionInfo.Email);
            var languageAttributeStatement = CreateAttributeStatement(doc, "language", samlAssertionInfo.Language);
            var roleAttributeStatement = CreateAttributeStatement(doc, "role", samlAssertionInfo.Roles);

            assertion.AppendChild(issuer);
            assertion.AppendChild(conditions);
            assertion.AppendChild(nameAttributeStatement);
            assertion.AppendChild(emailAttributeStatement);
            assertion.AppendChild(languageAttributeStatement);
            assertion.AppendChild(roleAttributeStatement);

            if (!string.IsNullOrEmpty(samlAssertionInfo.AgencyId))
            {
                var agencyAttributeStatement = CreateAttributeStatement(doc, "agency", samlAssertionInfo.AgencyId);
                assertion.AppendChild(agencyAttributeStatement);
            }

            doc.AppendChild(assertion);

            return doc;
        }

        private void AddEncryptedData(XmlDocument encryptedAssertionDocument, EncryptedData encryptedData)
        {
            var importedEncryptedData = encryptedAssertionDocument.ImportNode(encryptedData.GetXml(), true);

            if (encryptedAssertionDocument.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            encryptedAssertionDocument.DocumentElement.AppendChild(importedEncryptedData);
        }

        private EncryptedData CreateEncryptedData(XmlElement assertion, X509Certificate2 publicCertificate)
        {
            var encryptedXml = new EncryptedXml();
            var encryptedData = encryptedXml.Encrypt(assertion, publicCertificate);

            return encryptedData;
        }

        private XmlDocument CreateEmptyEncryptedAssertionDocument()
        {
            var encryptedAssertionDocument = new XmlDocument();
            
            var encryptedAssertion = encryptedAssertionDocument.CreateElement(SamlXmlPrefix, "EncryptedAssertion", SamlXmlNamespace);
            
            encryptedAssertionDocument.AppendChild(encryptedAssertion);

            return encryptedAssertionDocument;
        }

        protected XmlElement CreateAttributeStatement(XmlDocument doc, string name, string value)
        {
            return CreateAttributeStatement(doc, name, new List<string> { value });
        }

        private XmlElement CreateAttributeStatement(XmlDocument doc, string name, IEnumerable<string> values)
        {
            var attributeStatement = doc.CreateElement(SamlXmlPrefix, "AttributeStatement", SamlXmlNamespace);
            var attribute = doc.CreateElement(SamlXmlPrefix, "Attribute", SamlXmlNamespace);
            attribute.Attributes.Append(CreateAttribute(doc, "Name", name));
            attribute.Attributes.Append(CreateAttribute(doc, "NameFormat", NameFormat));

            foreach (var value in values)
            {
                var attributeValue = doc.CreateElement(SamlXmlPrefix, "AttributeValue", SamlXmlNamespace);
                attributeValue.InnerText = value;
                attribute.AppendChild(attributeValue);
            }

            attributeStatement.AppendChild(attribute);

            return attributeStatement;
        }


        private XmlElement CreateConditions(XmlDocument doc, DateTime notBefore, DateTime notOnOrAfter)
        {
            var conditions = doc.CreateElement(SamlXmlPrefix, "Conditions", SamlXmlNamespace);
            conditions.Attributes.Append(CreateAttribute(doc, "NotBefore", notBefore.ToString(DateTimeFormat)));
            conditions.Attributes.Append(CreateAttribute(doc, "NotOnOrAfter", notOnOrAfter.ToString(DateTimeFormat)));

            return conditions;
        }

        private XmlElement CreateIssuer(XmlDocument doc, string issuer)
        {
            var issuerElement = doc.CreateElement(SamlXmlPrefix, "Issuer", SamlXmlNamespace);

            issuerElement.InnerText = issuer;

            return issuerElement;
        }

        private XmlElement CreateEmptyAssertion(XmlDocument doc, string id, DateTime issuerInstant)
        {
            var assertion = doc.CreateElement(SamlXmlPrefix, "Assertion", SamlXmlNamespace);

            assertion.Attributes.Append(CreateAttribute(doc, "Version", "2.0"));
            assertion.Attributes.Append(CreateAttribute(doc, "ID", id));
            assertion.Attributes.Append(CreateAttribute(doc, "IssueInstant", issuerInstant.ToString(DateTimeFormat)));

            return assertion;
        }

        private XmlAttribute CreateAttribute(XmlDocument doc, string name, string value)
        {
            var attribute = doc.CreateAttribute(name);
            attribute.Value = value;

            return attribute;
        }

        private void SignAssertionDocument(XmlDocument assertionDocument, string assertionId)
        {
            var signature = CreateSignature(assertionDocument, privateCertificate, "ID", assertionId);

            if (assertionDocument.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            assertionDocument.DocumentElement.InsertBefore(signature, assertionDocument.DocumentElement.ChildNodes[1]);
        }

        private XmlElement CreateSignature(XmlDocument doc, X509Certificate2 certificate, string referenceId, string referenceValue)
        {
            var sig = new SamlSignedXml(doc, referenceId);
            // Add the key to the SignedXml xmlDocument. 
            sig.SigningKey = certificate.PrivateKey;

            // Create a reference to be signed. 
            var reference = new Reference();

            reference.Uri = string.Empty;
            reference.Uri = "#" + referenceValue;

            // Add an enveloped transformation to the reference. 
            var env = new XmlDsigEnvelopedSignatureTransform();
            var env2 = new XmlDsigC14NTransform();

            reference.AddTransform(env);
            reference.AddTransform(env2);

            // Add the reference to the SignedXml object. 
            sig.AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate). 
            var keyInfo = new KeyInfo();
            var keyData = new KeyInfoX509Data(certificate);

            keyInfo.AddClause(keyData);

            sig.KeyInfo = keyInfo;

            // Compute the signature. 
            sig.ComputeSignature();

            // Get the XML representation of the signature and save it to an XmlElement object. 
            XmlElement xmlDigitalSignature = sig.GetXml();

            return xmlDigitalSignature;
        }
    }
}