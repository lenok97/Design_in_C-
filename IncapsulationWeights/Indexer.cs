using System;

namespace Incapsulation.Weights
{
    public class Indexer
    {
        private double[] arr;
        private int start;

        public Indexer(){}

        public Indexer (double[] arr, int start, int length)
        {
            if (length < 0 || start < 0)
                throw new ArgumentException();
            if (start + length > arr.Length)
                throw new ArgumentException();
            this.arr = arr;
            this.start = start;
            this.Length = length;
        }

        public int Length { set; get; }

        private int Value (int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();
            return index;
        }

        public double this [int index]
        {
            get
            {
                Value(index);
                return arr[start + index];
            }
            set
            {
                Value(index);
                arr[start+index] = value;
            }
        }
    }
}
