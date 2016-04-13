using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Foretagsplatsen.Api2.Saml
{
    /// <summary>
    /// SamlSignedXml - Class is used to sign xml, basically the when the ID is retreived the correct ID is used.  
    /// without this, the id reference would not be valid.
    /// </summary>
    internal class SamlSignedXml : SignedXml
    {
        private readonly string referenceAttributeId;

        public SamlSignedXml(XmlElement element, string referenceAttributeId)
            : base(element)
        {
            this.referenceAttributeId = referenceAttributeId;
        }

        public SamlSignedXml(XmlDocument document, string referenceAttributeId)
            : base(document)
        {
            this.referenceAttributeId = referenceAttributeId;
        }

        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            return (XmlElement)document.SelectSingleNode($"//*[@{referenceAttributeId}='{idValue}']");
        }

        public static XmlElement CreateSignature(XmlDocument document, X509Certificate2 certificate, string referenceId, string referenceValue)
        {
            var samlSignedXml = new SamlSignedXml(document, referenceId);
            // Add the key to the SignedXml xmlDocument. 
            samlSignedXml.SigningKey = certificate.PrivateKey;

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
            samlSignedXml.AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate). 
            var keyInfo = new KeyInfo();
            var keyData = new KeyInfoX509Data(certificate);

            keyInfo.AddClause(keyData);

            samlSignedXml.KeyInfo = keyInfo;

            // Compute the signature. 
            samlSignedXml.ComputeSignature();

            // Get the XML representation of the signature and save it to an XmlElement object. 
            var xmlDigitalSignature = samlSignedXml.GetXml();

            return xmlDigitalSignature;
        }
    }
}