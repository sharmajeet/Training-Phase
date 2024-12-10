using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureConcepts
{
     class Dictionary
    {
        public static void getDictionary()
        {
            Dictionary<int, String> dict = new Dictionary<int, String>();

            dict.Add(1, "Jeet sharma");
            dict.Add(2, "hitu sharma");

            for (int i = 0; i < dict.Count; i++)
            {
                KeyValuePair<int,String> pair = dict.ElementAt(i);
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
