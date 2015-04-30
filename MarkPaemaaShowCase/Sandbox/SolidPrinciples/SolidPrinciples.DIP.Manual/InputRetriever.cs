using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DIP.Manual
{
    public interface IInputRetriever
    {
        string GetData(string sourceFileName);
    }

    public class InputRetriever
    {
        private static readonly Dictionary<Func<string, bool>, IInputRetriever> InputRetrievers = new Dictionary<Func<string,bool>,IInputRetriever>();

        public static void RegisterInputRetriever(Func<string, bool> evaluator, IInputRetriever inputRetriever)
        {
            InputRetrievers.Add(evaluator, inputRetriever);
        }

        public static IInputRetriever ForFileName(string sourceFileName)
        {
            return InputRetrievers.First(x => x.Key(sourceFileName)).Value; 
        }
    }
}
