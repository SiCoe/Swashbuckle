using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    internal class DefaultXmlCommentsFilterLoader : IXmlCommentsFilterLoader
    {
        public XmlCommentsOperationFilter GetXmlCommentsActionFilter(XPathDocument xmlDoc)
        {
            return new ApplyXmlActionComments(xmlDoc);
        }

        public XmlCommentsModelFilter GetXmlCommentsModelFilter(XPathDocument xmlDoc)
        {
            return new ApplyXmlTypeComments(xmlDoc);
        }
    }
}
