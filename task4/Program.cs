using System;
using System.Linq;

namespace task4
{
    internal class Program
    {
        static double Median(double[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                double[] mas = Array.Empty<double>();

                try
                {
                    mas = System.IO.File.ReadAllLines($@"{args[0]}").Select(i => double.Parse(i)).ToArray();
                }
                catch (Exception)//e)
                {
                    //Console.WriteLine(e.Message);
                }

                double m = Median(mas);

                double res = default;

                foreach (var item in mas)
                {
                    res += Math.Abs(item - m);
                }

                Console.WriteLine(res);
            }
            else { Console.WriteLine("Введите аргументы."); Console.ReadKey(); }
        }
    }
}
