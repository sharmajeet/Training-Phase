using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureConcepts
{
     class Lists
    {
        public static void generateList()
        {
            List<int> numbers = new List<int> { 1, 2, 3 };

            numbers.Add(4);

            numbers.Add(5);

            foreach (int i in numbers) {
                Console.Write(i + " ");
            }

            numbers.Remove(3);

            Console.WriteLine("After Deletion : ");

            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }

        }
    }
}
