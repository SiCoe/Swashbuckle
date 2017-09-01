using System.Web.Http.Description;
using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    public abstract class XmlCommentsOperationFilter : XmlCommentsFilter, IOperationFilter
    {
        protected XmlCommentsOperationFilter(XPathDocument xmlDoc)
            : base(xmlDoc) { }

        public abstract void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription);
    }
}