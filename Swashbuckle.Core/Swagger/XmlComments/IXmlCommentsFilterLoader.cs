using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    public interface IXmlCommentsFilterLoader
    {
        XmlCommentsOperationFilter GetXmlCommentsActionFilter(XPathDocument xmlDoc);
        XmlCommentsModelFilter GetXmlCommentsModelFilter(XPathDocument xmlDoc);
    }
}
