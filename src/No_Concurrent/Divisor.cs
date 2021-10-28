using System;
public class Divisor
{

    long numero;
    int divisors;

    long ini;
    long end;

    bool isPrime;

    public Divisor(long num, long ini, long end)
    {
        this.numero = num;
        this.ini = ini;
        this.end = end;
        this.divisors = 2;
        this.isPrime = true;
    }
    public bool getIsPrime()
    {
        if (this.divisors != 2)
        {
            this.isPrime = false;
            return this.isPrime;
        }
        return this.isPrime;
    }
    public int getDivisores()
    {
        return divisors;
    }
    public void numOfPosDivisors()
    {
        long from = this.ini;
        long to = this.end;
        //Console.WriteLine(from + " , "+ to);
        int inc = 1;
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
}