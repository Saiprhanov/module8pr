using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module8prac3
{
    class RangeOfArray
    {
        private int lowerBound;
        private int upperBound;
        private int[] data;

        public RangeOfArray(int lowerBound, int upperBound)
        {
            if (lowerBound > upperBound)
            {
                throw new ArgumentException("Lower bound cannot be greater than upper bound.");
            }

            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            int size = upperBound - lowerBound + 1;
            data = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index < lowerBound || index > upperBound)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return data[index - lowerBound];
            }
            set
            {
                if (index < lowerBound || index > upperBound)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                data[index - lowerBound] = value;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RangeOfArray array = new RangeOfArray(-9, 15);

            // Записываем и читаем значения в массиве
            array[-9] = 10;
            array[0] = 20;
            array[15] = 30;

            Console.WriteLine($"array[-9]: {array[-9]}");
            Console.WriteLine($"array[0]: {array[0]}");
            Console.WriteLine($"array[15]: {array[15]}");
            Console.ReadKey();
        }
    }
}
