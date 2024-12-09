using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Guessing_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int min = 1;
            int max = 100;
            int guess = 0; ;
            int number;
            int guesses = 0;

            number = random.Next(min, max + 1);

            while (guess != number)
            {

                Console.WriteLine("Guess the number between " + min + "and " + max + " .");
                guess = Convert.ToInt32(Console.ReadLine());


                if (guess == number)
                {
                    Console.WriteLine("Congratulations !!!1");
                }
                if (guess < number)
                {
                    Console.WriteLine(guess + " is too low!");
                }
                if (guess > number)
                {
                    Console.WriteLine(guess + " is to high!");
                }

                guesses++;
            }
            Console.WriteLine("you guess coorect output in " + guesses + " .");
        }
    }
}
