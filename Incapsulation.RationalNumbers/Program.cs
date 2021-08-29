using System;
using System.Collections.Generic;
using System.Linq;
using Incapsulation.RationalNumbers;
using NUnitLite;

class Program
{
	static void Main(string[] args)
	{
        //new AutoRun().Execute(args);
        int r = (int)new Rational(0, 1);
        Console.WriteLine((new Rational(1, 2) / new Rational(1, 0)).IsNan);
        Console.ReadLine();

    }
}
