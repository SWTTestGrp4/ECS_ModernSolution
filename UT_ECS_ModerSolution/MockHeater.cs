using System;
using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class MockHeater: IHeater
    {

        public bool ResultHeaterIsOn { get; set; }
        public void TurnOn()
        {
            ResultHeaterIsOn = true;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            ResultHeaterIsOn = false;
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

}