using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP
{
    internal class Inheritance
    {

    }

    class Animal
    {
        public virtual void animalSound()
        {
            Console.WriteLine("Animal sound from base class");
        }
    }

    class Dog : Animal {
        
        public override void animalSound()
        {
            Console.WriteLine("Dog's are Barking");
        }
    }

    class Lion : Dog
    {
        public override void animalSound()
        {
            Console.WriteLine("Lions are not barking");
        }
    }
}
