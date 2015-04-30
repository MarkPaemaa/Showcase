using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolidPrinciples.OCP
{
    public class InputParser
    {
        public virtual Document ParseInput(string inputDataFromXML)
        {
            Document doc;

            try
            {
                var xDocument = XDocument.Parse(inputDataFromXML);
                doc = new Document();
                doc.Title = xDocument.Root.Element("title").Value;
                doc.Text = xDocument.Root.Element("text").Value;
            }
            catch (Exception)
            {
                throw new InvalidInputFormatException();
            }

            return doc;
        }

        // What if there is a different File format for conversion - like JSON (even though JSON to JSON is not great), but there
        // might be some transformation put in the middle.
        // This is Meyer's way - virtual overrides

        public class JsonInputParser : InputParser
        {
            public override Document ParseInput(string inputDataFromXML)
            {
                return JsonConvert.DeserializeObject<Document>(inputDataFromXML);
            }
        }

    }
}
