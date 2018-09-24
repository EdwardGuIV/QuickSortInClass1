using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an unsorted array of string elements
            //string[] unsorted = { "z", "e", "x", "c", "m", "q", "a" };
            string path = @"c:/Users/Edward.Gurley/eg-jf-jd.csv";
            string[] unsorted = File.ReadAllLines(path);
            var results = new List<Tuple<int, Guid, double>>();

            var reader = new StreamReader(File.OpenRead(path));
            

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var val1 = int.Parse(values[0]);
                var val2 = Guid.Parse(values[1]);
                var val3 = double.Parse(values[2]);

                Tuple<int, Guid, double> myTuple = Tuple.Create<int, Guid, double>(val1, val2, val3);

                results.Add(Tuple.Create(val1, val2, val3));
            }
            

            // Print the unsorted array
            for (int i = 0; i < 100; i++)
            {
                Console.Write(unsorted[i] + "\n");
            }

            Console.WriteLine();

            // Sort the array
            Quicksort(unsorted, 0, 100 - 1);

            // Print the sorted array
            for (int i = 0; i < 100; i++)
            {
                Console.Write(unsorted[i] + "\n");
            }

            Console.WriteLine();

            Console.ReadLine();
            
        }

   

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        
    }
}
