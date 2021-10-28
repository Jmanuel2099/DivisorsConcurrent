using System;
using System.Threading;

public class DivisorConc
{
    long numero;
    int threads;
    Thread[] trs;
    bool isPrime;
    int divisors;
    long[,] listdates;

    public DivisorConc(long numero, int threads)
    {
        this.numero = numero;
        this.threads = threads;
        this.trs = new Thread[threads];
        this.isPrime = true;
        this.listdates = new long[threads, 2];
        this.divisors = 0;
    }
    public long getDivisores()
    {
        return this.divisors;
    }
    public bool getIsPrime()
    {
        if (this.divisors != 2)
        {
            this.isPrime = false;
            return this.isPrime; ;
        }
        return this.isPrime;
    }
    public long[,] getListadates()
    {
        /*for (int i = 0; i < this.divisors - 1; i++)
        {
            Console.WriteLine(this.listdates[i, 0] + " " + this.listdates[i, 1]);

        }*/
        return this.listdates;
    }
    public void startProccesConcurrent()
    {
        long numReal = (long)Math.Sqrt(this.numero);
        long start = 2;
        long end = numReal / this.threads;

        for (int i = 0; i < this.threads; i++)
        {
            if (i == this.threads - 1)
            {
                end = numReal;
            }
            this.trs[i] = new Thread(numOfPosDivisors);
            listdates[i, 0] = start;
            listdates[i, 1] = end;
            start = end + 1;
            end = (start + (numReal / this.threads) - 1);

        }

        int numThread = 0;
        foreach (var x in this.trs)
        {
            x.Start(numThread);
            numThread += 1;
        }
        foreach (var x in this.trs)
        {
            x.Join();
        }

    }
    public void numOfPosDivisors(object date)
    {
        //listaDates = [[2, 4969135984], [4969135985, 9938271968]]
        long from = this.listdates[(int)date, 0];
        long to = this.listdates[(int)date, 1];
        Divisor divisor = new Divisor(this.numero, from, to);
        divisor.numOfPosDivisors();
        this.divisors += divisor.getDivisores();
        //Console.WriteLine("div "+divisor.getDivisores());
        //Console.WriteLine("condiv: "+ this.divisors);
    }
}