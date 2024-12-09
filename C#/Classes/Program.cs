using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{

    //this is example for class 
    class myclass
    {
        String name;
        int age;
       public static void Greet()
        {
            Console.WriteLine("Hello World!!");
        }

        public static void Greet(String name)
        {
            Console.WriteLine($"Hello {name} Welcome to the Team!!");
        }

        public static void humanBeing(String name, int age)
        {
            Console.WriteLine($"{name}  is {age} years old");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
             myclass.Greet();
            myclass.Greet("Jeet");

            Human h1 = new Human();
            h1.name = "jeet sharma";
            h1.age = 21;
            h1.Greet();
            h1.Data(h1.name, h1.age);

        }
    }

    class Human
    {
        public String name;
      public int age;

        public void Data(String name , int age)
        {
            Console.WriteLine($"{name} is {age} years old.");
        }
        public void Greet()
        {
            Console.WriteLine("Hellow");
        }
    }
}
