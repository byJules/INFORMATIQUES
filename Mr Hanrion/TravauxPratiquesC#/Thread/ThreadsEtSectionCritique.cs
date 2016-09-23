using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Prog
{
    
    const int N = 100;
    void f()
    {
        lock (this)
        {

            for (int i = 0; i <= N; i++)
            {
                Console.WriteLine("Thread1 " + i + "° passage");
            }
        }
       

    }
    void g()
    {

        lock (this)
        {
            for (int i = 0; i <= N; i++)
            {
                Console.WriteLine("Thread2 " + i + "° passage");
            }
        }
       
    }
    
    static void Main()
    {
        Prog Obj2threads = new Prog();
        Console.WriteLine("Début du programme");
        Thread t1 = new Thread(new ThreadStart(Obj2threads.f));
        Thread t2 = new Thread(new ThreadStart(Obj2threads.g));

        t1.Start(); t2.Start();
        t1.Join(); t2.Join();
        Console.ReadLine();
    }
}

