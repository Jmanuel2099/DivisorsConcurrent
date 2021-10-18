using System;
using System.Threading;

public class DivisorConc
{
    long numero;
    int threads;
    Thread[] trs;
    int divisors;

    long[,] listdates;



    public DivisorConc(long numero, int threads)
    {
        this.numero = numero;
        this.threads = threads;
        this.trs = new Thread[threads];
        listdates = new long[threads, 2];
        divisors = 2;
    }

    public void startProccesConcurrent()
    {
        long numReal = this.numero /2;
        long start = 2;
        long end = numReal / this.threads;
        //Divisor divisor = new Divisor(numReal);
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
    public long getDivisores()
    {
        return this.divisors;
    }
    public bool isPrime()
    {
        if (divisors == 2)
        {
            return true;
        }
        return false;
    }
    public void numOfPosDivisors( long from, long to) {
        int inc = 1;
        if (this.numero % 2 == 1) { // Num is odd
            inc = 2;
            if (from % 2 == 0) { // From is even 
                from++;
            }
        }
        for (long k = from; k <= to; k += inc) {
            if (this.numero % k == 0) {
                this.divisors++;
            }
        }
        
    }
    public void numOfPosDivisors(object date) {
        long from = listdates[(int)date, 0];
        long to = listdates[(int)date, 1];
        //Console.WriteLine("Object: {0}, from: {1}, to: {2}, numero: {3}", (int)date, from, to, this.numero);
        numOfPosDivisors( from, to);
    }
}