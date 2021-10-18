using System;
public class Divisor
{
    long numero;
    long divisors;

    public Divisor(long num)
    {
        this.numero = num;
        divisors = 2;
        //Console.WriteLine("--" + numero);
    }
    public bool isPrime()
    {
        if (divisors == 2)
        {
            return true;
        }
        return false;
    }
    public long getDivisores()
    {
        return divisors;
    }
    public void numOfPosDivisors(long[] dates)
    {
        long from = dates[0];
        long to = dates[1];
        int inc = 1;
        //long count = 0;

        if (this.numero % 2 == 1)
        { // Num is odd
            inc = 2;
            if (from % 2 == 0)
            { // From is even 
                from++;
            }
        }
        for (long k = from; k <= to; k += inc)
        {
            if (this.numero % k == 0)
            {
                //Console.WriteLine(k);
                this.divisors++;
            }
        }
    }
    public void numOfPosDivisors(object num)
    {
        long numero = (long) num;
        long[] dates = {2, numero/2}; 
        this.numOfPosDivisors(dates);
        //this.divisors += 2;
    }
}