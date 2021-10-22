using System;
using System.Diagnostics;
//using System.Threading;

namespace Demo_Divisores
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = 19_876_543_937L;
            int threads = 2;

            Console.WriteLine("Number: " + num);
            Console.WriteLine("[Main process]");
            Stopwatch mainTime = new Stopwatch();//obj to take the time no concurrent
            mainTime.Start();
            Divisor divisor = new Divisor(num);
            divisor.numOfPosDivisors(num);
            Console.WriteLine("divs: " + divisor.getDivisores());
            Console.WriteLine("Is Prime: " + divisor.isPrime());
            mainTime.Stop();
            Console.WriteLine($"Time: {mainTime.Elapsed.TotalSeconds} s");

            Console.WriteLine("[Concurrent process] Threads: {0}", threads);
            Stopwatch concurretTime = new Stopwatch();//obj to take the time concurrent
            concurretTime.Start();
            DivisorConc divisorConc = new DivisorConc(num, threads);
            divisorConc.startProccesConcurrent();
            Console.WriteLine("divs: " + divisorConc.getDivisores());
            Console.WriteLine("Is Prime: " + divisorConc.isPrime());
            concurretTime.Stop();
            Console.WriteLine($"Time: {concurretTime.Elapsed.TotalSeconds} s");
        }
    }
}
