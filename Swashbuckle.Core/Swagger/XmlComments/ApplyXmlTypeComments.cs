using System.Reflection;
using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    public class ApplyXmlTypeComments : XmlCommentsModelFilter
    {
        private const string SummaryTag = "summary";

        public ApplyXmlTypeComments(string filePath)
            : this(new XPathDocument(filePath)) { }

        public ApplyXmlTypeComments(XPathDocument xmlDoc)
            : base(xmlDoc) { }

        public override void Apply(Schema model, ModelFilterContext context)
        {
            XPathNavigator navigator;
            lock (XmlDoc)
            {
                navigator = XmlDoc.CreateNavigator();
            }

            var commentId = XmlCommentsIdHelper.GetCommentIdForType(context.SystemType);
            var typeNode = navigator.SelectSingleNode(string.Format(MemberXPath, commentId));

            if (typeNode != null)
            {
                var summaryNode = typeNode.SelectSingleNode(SummaryTag);
                if (summaryNode != null)
                    model.description = summaryNode.ExtractContent();
            }

            if (model.properties != null)
            {
                foreach (var entry in model.properties)
                {
                    var jsonProperty = context.JsonObjectContract.Properties[entry.Key];
                    if (jsonProperty == null) continue;

                    ApplyPropertyComments(navigator, entry.Value, jsonProperty.PropertyInfo());
                }
            }
        }

        protected static void ApplyPropertyComments(XPathNavigator navigator, Schema propertySchema, PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return;

            var commentId = XmlCommentsIdHelper.GetCommentIdForProperty(propertyInfo);
            var propertyNode = navigator.SelectSingleNode(string.Format(MemberXPath, commentId));
            if (propertyNode == null) return;

            var propSummaryNode = propertyNode.SelectSingleNode(SummaryTag);
            if (propSummaryNode != null)
            {
                propertySchema.description = propSummaryNode.ExtractContent();
            }
        }
    }
}