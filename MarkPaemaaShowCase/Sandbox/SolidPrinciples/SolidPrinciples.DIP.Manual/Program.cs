using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DIP.Manual
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\InputDocument.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\OutputDocument.json");

            ConfigureStorage();

            var documentSerializer = new CamelCaseDocumentSerializer();
            var inputParser = new SolidPrinciples.DIP.Manual.InputParser.JsonInputParser();

            var formatConverter = new FormatConverter(documentSerializer, inputParser);
            if (!formatConverter.ConvertFormat(sourceFileName, targetFileName))
            {
                Console.WriteLine("File conversion failed.");
                Console.ReadLine();
            }

        }

        private static void ConfigureStorage()
        {
            var blobStorage = new BlobDocumentStorage();
            var fileStorage = new FileDocumentStorage();
            var httpInputRetriver = new HttpInputRetriever();

            //InputRetriever
        }
    }
}
