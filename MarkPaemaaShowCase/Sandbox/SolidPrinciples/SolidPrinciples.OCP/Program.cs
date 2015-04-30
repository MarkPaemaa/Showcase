using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\InputDocument.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\OutputDocument.json");

            var formatConverter = new FormatConverter();
            if (!formatConverter.ConvertFormat(sourceFileName, targetFileName))
            {
                Console.WriteLine("File conversion from XML to JSON failed.");
                Console.ReadLine();
            }
        }
    }
}
