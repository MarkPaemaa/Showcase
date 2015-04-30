using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldExample
{
    class Program
    {
        static List<int> ages = new List<int>();

        static void AddInitialAgesToList()
        {
            ages.Add(8);
            ages.Add(12);
            ages.Add(35);
            ages.Add(15);
            ages.Add(40);
            ages.Add(55);
        }

        static IEnumerable<int> FilterAbove20()
        {
            foreach (int i in ages)
            {
                if (i > 20)
                {
                    yield return i;   // This is stateful 
                    // When reentering will continue from index
                }
            }
        }

        static void Main(string[] args)
        {
            AddInitialAgesToList();

            foreach (int i in FilterAbove20())
            {
                Console.WriteLine(i);
            }
            Console.ReadLine(); // pause to see
        }
    }
}
