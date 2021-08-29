using System;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Rational(int numerator, int denominator = 1)
        {
            Numerator = numerator;
            Denominator = denominator;
            if (!IsNan)
                Reduce();
        }

        public bool IsNan
        {
            get=> (Denominator == 0);
        }

        private static int GreatestCommonDevider(int v1, int v2)
        {
            if (v2 == 0)
                return Math.Abs(v1);
            return GreatestCommonDevider(v2, v1 % v2);
        }

        private void Reduce()
        {
            int divisor = Math.Sign(Denominator) * GreatestCommonDevider(Numerator, Denominator);
            if (divisor == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            else
            {
                Numerator /= divisor;
                Denominator /= divisor;
            }
        }

        public Rational Invert()
        {
            return new Rational(Denominator, Numerator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.IsNan)
                return b;
            var c = b.Invert();
            return new Rational(a.Numerator * c.Numerator, a.Denominator * c.Denominator);
        }

        public static Rational operator +(Rational a, Rational b)
        {
            a.ConvertDenominatorToOther(b);
            return new Rational(a.Numerator + b.Numerator, a.Denominator);
        }

        public static Rational operator -(Rational r)
        {
            return new Rational(-r.Numerator, r.Denominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return (a + -b);
        }

        public static implicit operator double(Rational r) // Implicit conversion to double
        {
            return r.IsNan ? double.NaN : (double)r.Numerator / r.Denominator;
        }

        public static implicit operator Rational(int value) // Implicit conversion to Rational from int
        {
            return new Rational(value);
        }

        public static explicit operator int(Rational rational) // Explicit conversion to int
        {
            if (rational.IsNan || rational.Numerator % rational.Denominator != 0)
            {
                throw new ArgumentException();
            }
            return rational.Numerator / rational.Denominator;
        }

        private void ConvertDenominatorToOther(Rational other)
        {
            int tmp = Denominator;
            Numerator *= other.Denominator;
            Denominator *= other.Denominator;

            other.Numerator *= tmp;
            other.Denominator *= tmp;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
