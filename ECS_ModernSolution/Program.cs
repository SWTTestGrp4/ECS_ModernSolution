using System;

namespace ECS_ModernSolution
{
    public class Application
    {
        public static void Main(string[] args)
        {

            var ecs = new ECS(10, 45, new TempSensor(), new Heater());

            ecs.Regulate();

            Console.WriteLine("Press 1 to change minimum value of threshold");
            Console.WriteLine("Press 2 to change maximum value of threshold");

            while (true)
            {
                var key = Console.ReadKey(true);
                string minThr;
                string maxThr;
                int number;

                switch (key.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Write integer number for min threshold");
                        minThr = Console.ReadLine();
                        number = int.Parse(minThr);
                        ecs.MinThreshold = number;
                        ecs.Regulate();
                        break;
                    case '2':
                        Console.WriteLine("Write integer number for max threshold");
                        maxThr = Console.ReadLine();
                        number = int.Parse(maxThr);
                        ecs.MaxThreshold = number;
                        ecs.Regulate();
                        break;
                }
            }
        }
    }
}
