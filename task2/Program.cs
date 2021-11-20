using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string[] textCirCoors = default;
                string[] textDotsCoords = default;
                float s;

                try
                {
                    textCirCoors = System.IO.File.ReadAllLines(args[0]); //circle
                    textDotsCoords = System.IO.File.ReadAllLines(args[1]); //dots
                }
                catch (Exception)//e)
                {
                    ///////////////////////////////
                    //Console.WriteLine(e.Message);
                    ///////////////////////////////
                }

                float radiusOfCir = float.Parse(textCirCoors[1]);

                var masCoordsOfCir = textCirCoors[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                float cirCoord1 = float.Parse(masCoordsOfCir[0]);
                float cirCoord2 = float.Parse(masCoordsOfCir[1]);

                for (int i = 0; i < textDotsCoords.Length; i++)
                {
                    var parts = textDotsCoords[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    float dotCoor1 = float.Parse(parts[0]);
                    float dotCoor2 = float.Parse(parts[1]);

                    s = (float)Math.Sqrt(Math.Pow((dotCoor1 - cirCoord1), 2) + Math.Pow((dotCoor2 - cirCoord2), 2));

                    if (s < radiusOfCir)
                    {
                        Console.WriteLine(1);
                    }
                    else if (s == radiusOfCir)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
            }
            else { Console.WriteLine("Введите аргументы."); Console.ReadKey(); }
        }
    }
}
