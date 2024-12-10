using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP
{
    internal class Human
    {
       public String name;
       public int age;

        //constructor
        public Human(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("Simple Constructor");
        }

        //constructor Overloading
        public Human(string name)
        {
            this.name = name;
            Console.WriteLine("Overlaoding Construcotr");
        }

        public void Eat()
        {
            Console.WriteLine(name + "Is Eating!");
        }

       public  void Sleep()
        {
            Console.WriteLine(name + "Is Sleeping!");
        }
    }
}
