using System;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            string input = Console.ReadLine();

            while (input != "exit")
            {
                switch (input)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        chronometer.Lap();
                        break;
                    case "laps":
                        chronometer.Laps.ToString();
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
