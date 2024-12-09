using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] cars = new string[5];

            cars[0] = "Tesla";
            cars[1] = "Honda City";
            cars[2] = "Kwid";
            cars[3] = "Range Rover";
            cars[4] = "BMW";

            for (int i = 0; i < cars.Length; i++) { 
                Console.WriteLine(cars[i]);
            }

            foreach (String car in cars) { 
                Console.WriteLine(car);
            }
        }
    }
}
