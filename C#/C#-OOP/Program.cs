using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User.getUserData("Jeet", 22);

            //without creating constructor
            //Human human = new Human();
            //human.name = "Jeet Sharma ";
            //human.Eat();
            //human.age = 22;
            //human.Sleep();

            //with constructor
            Human human = new Human("Jeet sharma",21);
            Human human1 = new Human("Jeet sharma");

            //this is derive class where 'animalSouund()' method is override
            Lion lion = new Lion();
            lion.animalSound();

            Dog dog = new Dog();
            dog.animalSound();

            //that is a base class where pure 'animalSound()' method is present
            Animal an = new Animal();
            an.animalSound();

            //bank  -interface
            //Bank bank = new Bank();  -- it gives error ..bcz obj of abstract class is not valid
            Customer customer = new Customer();
            customer.TransferMoney(100);


        }
    }

    
}
