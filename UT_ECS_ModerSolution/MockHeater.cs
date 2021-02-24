using System;
using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class MockHeater: IHeater
    {

        public bool Result { get; set; }
        public void TurnOn()
        {
            Result = true;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            Result = false;
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

}