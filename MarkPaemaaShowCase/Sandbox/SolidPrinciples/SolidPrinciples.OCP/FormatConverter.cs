using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SolidPrinciples.OCP
{
    public class FormatConverter
    {
        private readonly IDocumentSerializer _documentSerializer;
        private readonly InputParser _inputParser;

        public FormatConverter()
        {
            //_documentSerializer = new JsonDocumentSerializer();
            _documentSerializer = new CamelCaseDocumentSerializer();
            _inputParser = new InputParser();
        }

        public bool ConvertFormat(string sourceFileName, string targetFileName)
        {
            string input;
            var documentStorage = GetDocumentStorageForFileName(sourceFileName);
            try
            {
                input = documentStorage.GetData(sourceFileName);
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            var doc = _inputParser.ParseInput(input);
            var serializedDoc = _documentSerializer.Serialize(doc);

            try 
            {
                documentStorage.PersistDocument(serializedDoc, targetFileName);
            }
            catch (AccessViolationException)
            {
                return false;
            }
            return true;
        }

        // SRP - Single Responsibility Principle breakage - as it has logic of what to do etc.
        private DocumentStorage GetDocumentStorageForFileName(string fileName)
        {
            if (IsBlobStorageUrl(fileName))
                return new BlobDocumentStorage();

            if (fileName.StartsWith("http"))
                throw new NotImplementedException();

            return new FileDocumentStorage();
        }

        private bool IsBlobStorageUrl(string filename)
        {
            return filename.Contains("blob.core.windows.net");
        }
    }
}
