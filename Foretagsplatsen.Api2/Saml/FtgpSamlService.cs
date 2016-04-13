using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Foretagsplatsen.Api2.Saml
{
    public class FtgpSamlService
    {
        private const string SamlResponseXmlNamespace = "urn:oasis:names:tc:SAML:2.0:protocol";
        private const string SamlResponseXmlPrefix = "samlp";
        private const string SamlAssertionXmlNamespace = "urn:oasis:names:tc:SAML:2.0:assertion";
        private const string SamlAssertionXmlPrefix = "saml";
        private const string NameFormat = "urn:oasis:names:tc:SAML:2.0:attrname-format:basic";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        private readonly X509Certificate2 privateCertificate;
        private readonly X509Certificate2 publicFtgpCertificate;
        private readonly string issuerText;

        public FtgpSamlService(X509Certificate2 privateCertificate, X509Certificate2 publicFtgpCertificate, string issuer)
        {
            this.privateCertificate = privateCertificate;
            this.publicFtgpCertificate = publicFtgpCertificate;

            this.issuerText = issuer;
        }

        public XmlDocument CreateResponseDocument(FtgpSamlAssertionInfo samlAssertionInfo)
        {
            if (samlAssertionInfo?.Roles == null || !samlAssertionInfo.Roles.Any())
            {
                throw new ArgumentException("The SAML assertion info does not contain any roles.");
            }

            var document = new XmlDocument();
            var id = Guid.NewGuid().ToString();

            var response = CreateEmptyResponse(document, id);

            var issuer = CreateIssuer(document, issuerText);
            var encryptedAssertion = CreateEncryptedAssertion(document, samlAssertionInfo);

            response.AppendChild(issuer);
            response.AppendChild(encryptedAssertion);

            document.AppendChild(response);

            SignDocument(document, id);

            return document;
        }

        public XmlDocument CreateEncryptedAssertionDocument(FtgpSamlAssertionInfo samlAssertionInfo)
        {
            if (samlAssertionInfo?.Roles == null || !samlAssertionInfo.Roles.Any())
            {
                throw new ArgumentException("The SAML assertion info does not contain any roles.");
            }

            var document = new XmlDocument();

            var encryptedAssertion = CreateEncryptedAssertion(document, samlAssertionInfo);

            document.AppendChild(encryptedAssertion);

            return document;
        }

        private XmlElement CreateEncryptedAssertion(XmlDocument document, FtgpSamlAssertionInfo samlAssertionInfo)
        {
            var encryptedAssertion = CreateEmptyEncryptedAssertion(document);

            var signedAssertionDocument = CreateSignedAssertionDocument(samlAssertionInfo);

            var encryptedAssertionElement = EncryptElement(signedAssertionDocument.DocumentElement);

            encryptedAssertion.AppendChild(document.ImportNode(encryptedAssertionElement, true));

            return encryptedAssertion;
        }

        private XmlDocument CreateSignedAssertionDocument(FtgpSamlAssertionInfo samlAssertionInfo)
        {
            var document = new XmlDocument();

            var assertion = CreateEmptyAssertion(document, samlAssertionInfo.AssertionId);

            var issuer = CreateIssuer(document, issuerText);
            var conditions = CreateConditions(document, samlAssertionInfo.NotBefore, samlAssertionInfo.NotOnOrAfter);
            var nameAttributeStatement = CreateAttributeStatement(document, "name", samlAssertionInfo.Name);
            var emailAttributeStatement = CreateAttributeStatement(document, "emailaddress", samlAssertionInfo.Email);
            var languageAttributeStatement = CreateAttributeStatement(document, "language", samlAssertionInfo.Language);
            var roleAttributeStatement = CreateAttributeStatement(document, "role", samlAssertionInfo.Roles);

            assertion.AppendChild(issuer);
            assertion.AppendChild(conditions);
            assertion.AppendChild(nameAttributeStatement);
            assertion.AppendChild(emailAttributeStatement);
            assertion.AppendChild(languageAttributeStatement);
            assertion.AppendChild(roleAttributeStatement);

            if (!string.IsNullOrEmpty(samlAssertionInfo.AgencyId))
            {
                var agencyAttributeStatement = CreateAttributeStatement(document, "agency", samlAssertionInfo.AgencyId);
                assertion.AppendChild(agencyAttributeStatement);
            }

            document.AppendChild(assertion);

            SignDocument(document, samlAssertionInfo.AssertionId);

            return document;
        }

        private XmlElement EncryptElement(XmlElement element)
        {
            var encryptedXml = new EncryptedXml();
            var encryptedData = encryptedXml.Encrypt(element, publicFtgpCertificate);

            return encryptedData.GetXml();
        }

        private XmlElement CreateAttributeStatement(XmlDocument document, string name, string value)
        {
            return CreateAttributeStatement(document, name, new List<string> {value});
        }

        private XmlElement CreateAttributeStatement(XmlDocument document, string name, IEnumerable<string> values)
        {
            var attributeStatement = document.CreateElement(SamlAssertionXmlPrefix, "AttributeStatement", SamlAssertionXmlNamespace);
            var attribute = document.CreateElement(SamlAssertionXmlPrefix, "Attribute", SamlAssertionXmlNamespace);
            attribute.Attributes.Append(CreateAttribute(document, "Name", name));
            attribute.Attributes.Append(CreateAttribute(document, "NameFormat", NameFormat));

            foreach (var value in values)
            {
                var attributeValue = document.CreateElement(SamlAssertionXmlPrefix, "AttributeValue", SamlAssertionXmlNamespace);
                attributeValue.InnerText = value;
                attribute.AppendChild(attributeValue);
            }

            attributeStatement.AppendChild(attribute);

            return attributeStatement;
        }

        private XmlElement CreateConditions(XmlDocument document, DateTime notBefore, DateTime notOnOrAfter)
        {
            var conditions = document.CreateElement(SamlAssertionXmlPrefix, "Conditions", SamlAssertionXmlNamespace);
            conditions.Attributes.Append(CreateAttribute(document, "NotBefore", notBefore.ToString(DateTimeFormat)));
            conditions.Attributes.Append(CreateAttribute(document, "NotOnOrAfter", notOnOrAfter.ToString(DateTimeFormat)));

            return conditions;
        }

        private XmlElement CreateIssuer(XmlDocument document, string issuer)
        {
            var issuerElement = document.CreateElement(SamlAssertionXmlPrefix, "Issuer", SamlAssertionXmlNamespace);

            issuerElement.InnerText = issuer;

            return issuerElement;
        }

        private XmlElement CreateEmptyEncryptedAssertion(XmlDocument document)
        {
            return document.CreateElement(SamlAssertionXmlPrefix, "EncryptedAssertion", SamlAssertionXmlNamespace);
        }

        private XmlElement CreateEmptyAssertion(XmlDocument document, string id)
        {
            var assertion = document.CreateElement(SamlAssertionXmlPrefix, "Assertion", SamlAssertionXmlNamespace);

            assertion.Attributes.Append(CreateAttribute(document, "Version", "2.0"));
            assertion.Attributes.Append(CreateAttribute(document, "ID", id));
            assertion.Attributes.Append(CreateAttribute(document, "IssueInstant", DateTime.Now.ToString(DateTimeFormat)));

            return assertion;
        }

        private XmlElement CreateEmptyResponse(XmlDocument document, string id)
        {
            var response = document.CreateElement(SamlResponseXmlPrefix, "Response", SamlResponseXmlNamespace);

            response.Attributes.Append(CreateAttribute(document, "Version", "2.0"));
            response.Attributes.Append(CreateAttribute(document, "ID", id));
            response.Attributes.Append(CreateAttribute(document, "IssueInstant", DateTime.Now.ToString(DateTimeFormat)));

            return response;
        }

        private XmlAttribute CreateAttribute(XmlDocument document, string name, string value)
        {
            var attribute = document.CreateAttribute(name);
            attribute.Value = value;

            return attribute;
        }

        private void SignDocument(XmlDocument document, string id)
        {
            var signature = SamlSignedXml.CreateSignature(document, privateCertificate, "ID", id);

            if (document.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            document.DocumentElement.InsertBefore(signature, document.DocumentElement.ChildNodes[1]);
        }
    }
}