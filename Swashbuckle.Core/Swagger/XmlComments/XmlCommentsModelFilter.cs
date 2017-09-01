using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    public abstract class XmlCommentsModelFilter : XmlCommentsFilter, IModelFilter
    {
        protected XmlCommentsModelFilter(XPathDocument xmlDoc)
            : base(xmlDoc) { }

        public abstract void Apply(Schema model, ModelFilterContext context);
    }
}