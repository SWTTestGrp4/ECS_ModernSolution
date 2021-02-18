using System;
using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class FakeHeater: IHeater
    {
        public void TurnOn()
        {
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

}