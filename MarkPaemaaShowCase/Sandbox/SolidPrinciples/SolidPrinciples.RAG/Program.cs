using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolidPrinciples.RAG
{
    class Program
    {
        /*
         * Very Basic Program - Reads one record of XML from a basic XML file, 
         * Parses that to a Document object - defined in a class
         * And then Converts it to JSON and then saves it to disk
         * Very Basic Content Converter - crappy code - just to get it working etc
         * Starting Point to refactor.
         */

        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\InputDocument.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\OutputDocument.json");

            string inputDataFromXML;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                inputDataFromXML = reader.ReadToEnd();
            }

            var xDocument = XDocument.Parse(inputDataFromXML);
            var document = new Document
            {
                Title = xDocument.Root.Element("title").Value,
                Text = xDocument.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(document);

            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedDoc);
                sw.Close();
            }
        }
    }
}
