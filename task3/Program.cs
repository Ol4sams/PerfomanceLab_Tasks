using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace task3
{
    class Tests
    {
        public List<Test> tests { get; set; }
    }
    class Test
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<Test> values { get; set; }
    }
    class Values
    {
        public List<Value> values { get; set; }
    }
    class Value
    {
        public int id { get; set; }
        public string value { get; set; }

    }
    class Program
    {
        static public void SetValues(Values dataValues, List<Test> dataTests)
        {
            foreach (var val in dataValues.values)
            {
                foreach (var test in dataTests)
                {
                    if (val.id == test.id)
                    {
                        test.value = val.value;
                    }

                    if (test.values == null)
                    {

                    }
                    else
                    {
                        SetValues(dataValues, test.values);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string tests = default;
                string values = default;

                Tests deserTests;
                Values deserValues;

                try
                {
                    tests = File.ReadAllText(args[0]); //tests.json
                    values = File.ReadAllText(args[1]); //values.json
                }
                catch (Exception)//e)
                {
                    //Console.WriteLine(e.Message);
                }

                deserTests = JsonSerializer.Deserialize<Tests>(tests);
                deserValues = JsonSerializer.Deserialize<Values>(values);

                SetValues(deserValues, deserTests.tests);

                string report = JsonSerializer.Serialize<Tests>(deserTests, new JsonSerializerOptions()
                {
                    IgnoreNullValues = true
                });

                try
                {
                    File.WriteAllText(@"report.json", report);
                }
                catch (Exception)//e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
            else { Console.WriteLine("Введите аргументы."); Console.ReadKey(); }
        }
    }
}