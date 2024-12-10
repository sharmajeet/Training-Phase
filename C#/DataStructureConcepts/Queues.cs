using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DataStructureConcepts
{
    public class Queues
    {
        public static void WorkingWithQueue()
        {
            //creating queues
            Queue<String> que = new Queue<String>();

            //adding elements
            que.Enqueue("A");
            que.Enqueue("B");
            que.Enqueue("C");
            que.Enqueue("D");

            //traversing queue
            Console.WriteLine("Printing Queue data : ");
            for (int i = 0; i < que.Count; i++) {
                Console.WriteLine(que.ElementAt(i));
            }

            //printing Peek / top of queue
            Console.WriteLine("Peek is  : " + que.Peek()) ;

            //removig elements from queues
            que.Dequeue();

            //again printing queues
            Console.WriteLine("Printing Queue data after deletion : ");
            for (int i = 0; i < que.Count; i++)
            {
                Console.WriteLine(que.ElementAt(i));
            }
        }
    }
}
