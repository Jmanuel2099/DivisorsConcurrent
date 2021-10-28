using System;
public class Divisor
{

    long numero;
    long divisors;

    public Divisor(long num)
    {
        this.numero = num;
        divisors = 2;
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
        Console.WriteLine(from + " , "+ to);
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
        for (long k = from; k <= to && this.divisors <= 2; k += inc)
        {
            if (this.numero % k == 0)
            {
                this.divisors++;
            }
        }
    }
    public void numOfPosDivisors()
    {
        long[] dates = { 2, this.numero / 2 };
        this.numOfPosDivisors(dates);
    }
}