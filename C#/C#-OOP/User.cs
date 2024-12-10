using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP
{
     class User
    {
         String name;
        int age;
        int salary;
        
        User(string name, int age, int salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

       static public void getUserData(string name, int age)
        {
            Console.WriteLine($"User name is {name} and Age is {age} .");
        }
    }
}
