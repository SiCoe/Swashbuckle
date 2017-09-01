using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    public abstract class XmlCommentsFilter
    {
        protected const string MemberXPath = "/doc/members/member[@name='{0}']";
        protected XPathDocument XmlDoc { get; private set; }

        protected XmlCommentsFilter(XPathDocument xmlDoc)
        {
            XmlDoc = xmlDoc;
        }
    }
}