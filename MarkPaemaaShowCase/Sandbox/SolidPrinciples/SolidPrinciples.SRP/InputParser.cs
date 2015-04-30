using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolidPrinciples.SRP
{
    public class InputParser
    {
        public Document ParseInput(string inputDataFromXML)
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
    }
}
