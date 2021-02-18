using System;

namespace ECS_ModernSolution
{
    internal class TempSensor : ISensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
            //return 5; for testing
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}