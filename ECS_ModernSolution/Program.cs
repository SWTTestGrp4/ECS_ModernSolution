using System;

namespace ECS_ModernSolution
{
    public class Application
    {
        public static void Main(string[] args)
        {
            
            var ecs = new ECS(28, new TempSensor(), new Heater());

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();

            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case '1':
                        ecs.SetThreshold(8);
                        Console.WriteLine("Threshold set to 10");
                        ecs.Regulate();
                        break;
                    case '2':
                        ecs.SetThreshold(50);
                        Console.WriteLine("Threshold set to 50");
                        ecs.Regulate();
                        break;
                }
            }
        }
    }
}
