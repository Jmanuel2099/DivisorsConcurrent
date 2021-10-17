using System;
public class Divisor
{

    long numero;
    long from;
    long to;
    long divisors;

    public Divisor(long num, long start, long end)
    {
        this.numero = num;
        this.from = start;
        this.to = end;
        divisors = 0;
    }
    public bool isPrime(long num)
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
    public void numOfPosDivisors()
    {
        int inc = 1;
        //long count = 0;

        if (this.numero % 2 == 1)
        { // Num is odd
            inc = 2;
            if (this.from % 2 == 0)
            { // From is even 
                this.from++;
            }
        }
        for (long k = this.from; k <= this.to; k += inc)
        {
            if (this.numero % k == 0)
            {
                //Console.WriteLine(k);
                this.divisors++;
            }
        }
    }

    public void getDivisorsPost() {
        Console.WriteLine(from+ "  "+ to);
        this.numOfPosDivisors();
        this.divisors += 2;
    }

}