using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_C_
{
     class Generics
    {
        public  void DisplayData<t>(t[] array)
        {
            foreach (t item in array) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


    }


}
