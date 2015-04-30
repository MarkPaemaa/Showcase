using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DIP.Manual
{
    public interface IDocumentPersister
    {
        void PersistDocument(string serializedDocument, string targetFileName);
    }

    public class DocumentPersister
    {
        private static readonly Dictionary<Func<string, bool>, IDocumentPersister> DocumentRetrievers = new Dictionary<Func<string, bool>, IDocumentPersister>();

        public static void PersistDocument(string serializedDoc, string targetFileName)
        {

        }

        public static IDocumentPersister ForFileName(string targetFileName)
        {
            return DocumentRetrievers.First(x => x.Key(targetFileName)).Value;
        }

    }
}
