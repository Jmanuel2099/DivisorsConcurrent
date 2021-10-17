using System;
using System.Diagnostics;
using System.Threading;

namespace Demo_Divisores
{
    class Program
    {
        static void Main(string[] args)
        {
            //long num = 19_876_543_937L;
            long num = 18;
            int threads = 2;
            Stopwatch mainTime = new Stopwatch();//obj to take the time no concurrent
            Stopwatch concurretTime = new Stopwatch();//obj to take the time concurrent
            /*long start = 0;
            long end = num / threads;
            Thread[] trs = new Thread[threads];*/

            Console.WriteLine("Number: " + num);
            Console.WriteLine("[Main process]");
            mainTime.Start();
            Divisor divisor = new Divisor(num, 2, num / 2);
            divisor.getDivisorsPost();
            Console.WriteLine("divs: " + divisor.getDivisores());
            mainTime.Stop();
            Console.WriteLine($"Time: {mainTime.Elapsed.TotalMilliseconds} ms");

            Console.WriteLine("[Concurrent process] Threads: {0}", threads);
            concurretTime.Start();
            DivisorConc divisorConc = new DivisorConc(num, threads);
            divisorConc.isPrimeConc();
            Console.WriteLine("divs: " + divisor.getDivisores());
            concurretTime.Stop();
            Console.WriteLine($"Time: {concurretTime.Elapsed.TotalMilliseconds} ms");
        }
    }
}
