using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DIP.Manual
{
    public abstract class DocumentStorage : IInputRetriever, IDocumentPersister
    {
        public abstract string GetData(string sourceFileName);
        public abstract void PersistDocument(string serializedDoc, string targetFileName);
    }

    public class FileDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            if (!File.Exists(sourceFileName))
                throw new FileNotFoundException();

            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public override void PersistDocument(string serializedDoc, string targetFileName)
        {
            try
            {
                using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(serializedDoc);
                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw new AccessViolationException();
            }
        }
    }

    public class BlobDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            throw new NotImplementedException();
        }

        public override void PersistDocument(string serializedDoc, string targetFileName)
        {
            throw new NotImplementedException();
        }
    }

    public class HttpDocumentStorage : DocumentStorage
    {
        public override string GetData(string sourceFileName)
        {
            throw new NotImplementedException();
        }

        public override void PersistDocument(string serializedDoc, string targetFileName)
        {
            throw new NotImplementedException();
        }
    }

    public class HttpInputRetriever : IInputRetriever
    {
        public string GetData(string filename)
        {
            throw new NotImplementedException();
        }
    }

}
