using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolidPrinciples.RAG.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\InputDocument.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\OutputDocument.json");

            string inputDataFromXML = GetInput(sourceFileName);
            var document = GetDocument(inputDataFromXML);
            var serializedDoc = SerializeDocument(document);
            PersistDocument(serializedDoc, targetFileName);
        }

        private static string GetInput(string sourceFileName)
        {
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static Document GetDocument(string inputDataFromXML)
        {
            var xDocument = XDocument.Parse(inputDataFromXML);
            return new Document
            {
                Title = xDocument.Root.Element("title").Value,
                Text = xDocument.Root.Element("text").Value
            };
        }

        private static string SerializeDocument(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }
        
        private static void PersistDocument(string serializedDoc, string targetFileName)
        {
            using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(serializedDoc);
                sw.Close();
            }
        }
    }
}
