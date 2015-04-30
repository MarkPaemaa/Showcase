using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SRP
{
    public class DocumentStorage
    {
        public string GetData(string sourceFileName)
        {
            if (!File.Exists(sourceFileName))
                throw new FileNotFoundException();

            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public void PersistDocument(string serializedDoc, string targetFileName)
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
}
