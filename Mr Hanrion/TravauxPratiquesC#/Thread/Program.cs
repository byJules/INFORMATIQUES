using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleThreadEx1
{
    class Program
    {
        
        static void f()
        {

                        
                for (int i = 0; i < 300; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    //Thread.Sleep(100);
                    Console.WriteLine("Thread1 " + i + "° passage");
                }
            
        }
        static void g()
        {

            
            
                for (int i = 0; i < 300; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Thread.Sleep(100);
                    Console.WriteLine("Thread2 " + i + "° passage");
                }
            
        }
        static void Main()
        {
            Console.WriteLine("Début du programme");
            Thread t1 = new Thread(new ThreadStart(f));
            Thread t2 = new Thread(new ThreadStart(g));
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();
            Console.WriteLine("Fin des deux threads");
            Console.ReadLine();
        }
    }
}
