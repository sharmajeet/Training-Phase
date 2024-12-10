using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Basics
{
    
    internal class Program
    {
        static void Main(string[] args)
        {

           List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, };

            //Query Syntax
            var querySyntax = from obj in list
                              where obj % 2 == 0
                              select obj;
            var oddNum = from obj in list
                         where obj % 2 != 0
                         select obj;

            //Method Syntax
            Console.WriteLine("Using method ");
            var methodQuery = list.Where(obj => obj % 2 == 0);
                foreach(var item in methodQuery)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Maximum value is  : ");
            var data = (from obj in list
                        select obj).Max();
            Console.WriteLine(data);
            Console.WriteLine();
            
            //running query
            foreach(var obj in querySyntax)
            {
                Console.WriteLine(obj);
            }

            foreach(var res in oddNum)
            { 
                Console.WriteLine(res);
            }

            //IEnumerable Operation
            Console.WriteLine("IEnumerable Operaition and result");    
            List<int> li = new List<int> { 1, 2, 3, 4, 5, 6 };

            IEnumerable<int> e_num = li;

            foreach (var number in e_num)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Yeild operation : ");
            Yeild_Keyword ints = new Yeild_Keyword();
            ints.GetEnumerator();


        }
    }
}
