using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uzupis
{
    class Program
    {
        public static int kintamasis = 1;
        public static System.Object thisLock = new System.Object();
        public static System.Object counterLock = new System.Object();
        // private static System.Object lockThis = new System.Object();
        public static int Kazkas;
        public static int skaic;
        public static Boolean finish;
        public static int counter = 0;
        //public static int Kazkas2;
        static void Main(string[] args)
        {
            Console.WriteLine("Iveskit N skaiciu : ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ivestas skaicius: " + N);
            Kazkas = N;
            finish = true;
            for (int i = 1; i <= N; i++)
            {
                int skaicius = new int();
                skaicius = i;
                ThreadStart obj = delegate () { Skaiciavimas(skaicius); };
                Thread t = new Thread(obj);
                t.Start(); //t.Join(); 
            }
            Console.ReadLine();
        }
        public static void Skaiciavimas(int a)
        {
            lock (thisLock)
            {
                int rezultatas = a * kintamasis;
                kintamasis = rezultatas;
                counter++;
                if (counter >= Kazkas)
                {
                    Console.WriteLine(a + " thread last : " + rezultatas);
                    Monitor.PulseAll(thisLock);
                }
                else
                {
                    Monitor.Wait(thisLock);
                    Console.WriteLine(a + " thread : " + rezultatas);
                }
            }
        }
    }
}
