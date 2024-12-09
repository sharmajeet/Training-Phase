using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Brocode_Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Explicit Type Conversion
            double n1 = 24.44;
            Console.WriteLine("Before Converting : " + n1);
            int n2 = Convert.ToInt32(n1);

            Console.WriteLine("After Converting : " + n2);

            //Implicit Type Conversion
            int num = 10; 
            double res = (double)num;
            Console.WriteLine("Implicit Conversion : " + res) ;

            //Math  Class

            var i = 10;
            var ans = Math.Pow(10, i);
            Console.WriteLine("Power ans is : " +ans  );

            //generating random number

            Random random = new Random();
            int r_num = random.Next(1,10);
            Console.WriteLine(r_num);

            //if else condition

            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(age);

            if (age >= 18)
            {
                Console.WriteLine("You are eligible!");
            }
            else if (age >= 18 && age <= 60)
            {
                Console.WriteLine("You are eligible voting and driving");
            }
            else
            {
                Console.WriteLine("u are not eligible usr");
            }
        }
    }
}
