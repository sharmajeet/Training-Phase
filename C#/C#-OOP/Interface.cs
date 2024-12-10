using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP
{
    

    abstract class Bank
    {
        public void TransferMoney(int amount)
        {
            Console.WriteLine("Bank Transfer Money to your account.");
        }
    }

    class Customer : Bank
    {

        public static void SavingAmount()
        {
            Console.WriteLine("Saving of user");
        }
    }

}
