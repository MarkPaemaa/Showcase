using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.ISP
{
    // This is an example of Polymorphic using Interfaces

    public interface IDocumentSerializer
    {
        string Serialize(Document document);
    }

    public class JsonDocumentSerializer : IDocumentSerializer
    {
        public string Serialize(Document doc)
        {
            return JsonConvert.SerializeObject(doc);
        }
    }

    public class CamelCaseDocumentSerializer : IDocumentSerializer
    {
        public string Serialize(Document doc)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(JsonConvert.SerializeObject(doc));
        }
    }

}
