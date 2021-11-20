using System;

namespace task1
{
    class Program
    {
        static int[] _mass;

        static void MassCreate(int len)
        {
            _mass = new int[len];
        }

        static void MassFill(int num)
        {
            int ch = 1;

            for (int i = 0; i < _mass.Length; i++)
            {
                _mass[i] = ch;

                ch++;
            }
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                int n;
                int m;

                n = int.Parse(args[0]); //n
                m = int.Parse(args[1]); //m

                MassCreate(n);

                MassFill(n);

                string res = "1";

                int counter = m;
                int i = 0;
                int curVal = 0;

                while (curVal != _mass[0])
                {

                    if (counter != 0)
                    {
                        i = 0;
                    }
                    else
                    {
                        counter = m - 1;
                    }

                    while (i < _mass.Length)
                    {
                        curVal = _mass[i];

                        i++;

                        counter--;

                        if (counter == 0)
                        {
                            if (curVal == _mass[0])
                            {
                                break;
                            }

                            res += curVal;

                            break;
                        }
                    }
                }

                Console.WriteLine(res);
            }
            else { Console.WriteLine("Введите ключи."); Console.ReadKey(); }
        }
    }
}
