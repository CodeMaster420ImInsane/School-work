using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiSeries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = 0;
            double sign;
            Console.WriteLine("Choose a number of decimal places: ");
            int dps = int.Parse(Console.ReadLine());
            for (int i =0; i < 100000; i++)
            {
                sign = Math.Pow(-1, i);
                pi += (sign * 1 / (2 * i + 1));
            }
            Console.WriteLine("Pi to {0} decimal places is {1}", dps, Math.Round(pi, dps));
        }
    }
}
