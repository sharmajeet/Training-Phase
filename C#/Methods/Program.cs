using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        public static void Greet(String para)
        {
            Console.WriteLine("Hello "+para + " Feel Happy!!");
        }

        public static void TypesofPara (dynamic para)
        {
            Console.WriteLine("Value of Parameter is  : " + para);
        }

        //try-catch block of operations
        public static void ExceptionHandling()
        {
            try
            {
                Console.WriteLine("Enter value that u  want to divide : ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter value that u want to divide with : ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                int res = num1 / num2;

                Console.WriteLine("Ans is  : " + res);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("This is finally block which is run all time !!");
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Example for Methods");
            String name = "Jeet";
            Greet(name);

            TypesofPara(10000);
            TypesofPara("Hi there!");
            TypesofPara(100.00);

            ExceptionHandling();

        }
    }
}
