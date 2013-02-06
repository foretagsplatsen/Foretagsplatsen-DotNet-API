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
        private readonly string referenceAttributeId = "";

        public SamlSignedXml(XmlDocument document, string referenceAttributeId)
            : base(document)
        {
            this.referenceAttributeId = referenceAttributeId;
        }

        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            return (XmlElement)document.SelectSingleNode(string.Format("//*[@{0}='{1}']", referenceAttributeId, idValue));
        }
    }
}