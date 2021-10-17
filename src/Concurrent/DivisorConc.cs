using System;
using System.Threading;

public class DivisorConc
{
    long numero;
    int threads;
    Thread [] trs;

    public DivisorConc( long numero, int threads){
        this.numero = numero / 2;
        this.threads = threads;
        this.trs =  new Thread[threads];
    }

    public void isPrimeConc()
    {
        long start = 2;
        long end = this.numero / this.threads;
        //Thread[] trs = new Thread[this.threads];

        for (int i = 0; i < this.threads; i++)
        {
            if (i == this.threads-1)
            {
                end = this.numero;
            }
            Divisor divisor = new Divisor(this.numero, start, end);
            this.trs[i] = new Thread(new ThreadStart(divisor.getDivisorsPost));
            //Console.WriteLine("start: " + start + "end: " + end );
            start = end + 1;
            end = (start + (this.numero/this.threads)-1);
        }

        foreach (var x in this.trs)
        {
            x.Start();
        } 
    }
}