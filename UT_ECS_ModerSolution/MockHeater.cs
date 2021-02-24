using System;
using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class MockHeater: IHeater
    {
        public int OnCounter { get;  set; }
        public int OffCounter { get; set; }
        public bool ResultHeaterIsOn { get; set; }
        public void TurnOn()
        {
            ResultHeaterIsOn = true;
            OnCounter++;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            ResultHeaterIsOn = false;
            OffCounter++;
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

}