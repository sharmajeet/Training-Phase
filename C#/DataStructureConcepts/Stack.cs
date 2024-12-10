using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureConcepts
{
    public class Stack
    {
        public static void WorkingWithStack()
        {
            //initializing stack
            Stack<String> st = new Stack<String>();

            //adding eleements in stack
            st.Push("Jeet");
            st.Push("hitu");
            st.Push("jay");
            st.Push("manav");

            //traversing and printing stack data
            Console.WriteLine("Printing stack data : ");
            for (int i = 0; i < st.Count; i++) {
                Console.WriteLine(st.ElementAt(i));
            }

            //peek / top operation 
            Console.WriteLine("Peek/Top of the stack is  : " + st.Peek());

            //delete stack elements
            Console.WriteLine("Delete operation in stack : " + st.Pop());

            //after deletion
            Console.WriteLine("Printing stack data after deletion : ");
            for (int i = 0; i < st.Count; i++)
            {
                Console.WriteLine(st.ElementAt(i));
            }
        } 
    }
}
