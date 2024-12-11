using System;
using System.Collections.Generic;
using System.Linq;

class Yeild
{
    // Using yield keyword
    public IEnumerable<int> GetEvenNumbersWithYield(IEnumerable<int> numbers)
    {
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }

    // Without using yield keyword
    public List<int> GetEvenNumbersWithoutYield(IEnumerable<int> numbers)
    {
        List<int> evenNumbers = new List<int>();
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }
        return evenNumbers;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Delegate usage
        Calculator calc = new Calculator(Add);
        calc(10, 20);
        calc = new Calculator(Mul);
        calc(10, 20);
    }

    delegate void Calculator(int x, int y);

    static void Add(int a, int b)
    {
        Console.WriteLine("Sum: " + (a + b));
    }

    static void Mul(int a, int b)
    {
        Console.WriteLine("Product: " + (a * b));
    }
}
