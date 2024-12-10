using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureConcepts
{
    public class HashSet
    {
        public static void WorkingWithHashSet()
        {
            HashSet<int> nums = new HashSet<int>();

            //adding in nums
            nums.Add(1);
            nums.Add(2);
            nums.Add(3);
            nums.Add(4);
            nums.Add(5);
            nums.Add(2);
            nums.Add(3);

            // traversing
            Console.WriteLine("Printing values of Hashset : ");
            foreach (int i in nums)
            {
                Console.WriteLine(i + " ");
            }

            Console.WriteLine("Total number of values : " + nums.Count);
        }
    }
}
