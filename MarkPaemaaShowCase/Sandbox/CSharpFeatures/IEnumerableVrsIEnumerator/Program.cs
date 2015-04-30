using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableVrsIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> ages = new List<int>();
            ages.Add(10);
            ages.Add(20);
            ages.Add(30);
            ages.Add(40);
            ages.Add(50);

            // The ages list using IEnumerable
            IEnumerable<int> agesEnum = (IEnumerable<int>)ages;

            foreach (int i in agesEnum)
            {
                Console.WriteLine(i);
            }

            // The ages list using IEnumerator
            // IEnumerator as a state and remembers a 'Current' item
            IEnumerator<int> agesEnumerator = ages.GetEnumerator();

            while (agesEnumerator.MoveNext())
            {
                Console.WriteLine(agesEnumerator.Current.ToString());
            }
            Console.ReadLine();

        }
    }
}
