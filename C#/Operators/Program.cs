using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Value of Temp : "); 
            double temp =  Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(temp);

            if(temp == 0)
            {
                Console.WriteLine("Enter a valid input for temp");
            }
            else if(temp >= 50)
            {
                Console.WriteLine("Heat Wave");
            }
            else if( temp<50 && temp >= 35)
            {
                Console.WriteLine("Sunny Weather!");
            }
            else if(temp <35 && temp >= 25)
            {
                Console.WriteLine("There is Cold OutSide");
            }
            else
            {
                Console.WriteLine("Snowww");
            }
        }
    }
}
