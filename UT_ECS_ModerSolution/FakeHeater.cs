using System;
using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class FakeHeater: IHeater
    {

        public bool result { get; set; }
        public void TurnOn()
        {
            result = true;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            result = false;
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

}