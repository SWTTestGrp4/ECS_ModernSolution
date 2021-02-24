using System;
using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class MockHeater: IHeater
    {
        public bool SelfTestResult { get; set; }
        public bool HeaterIsOn { get; set; }
        public void TurnOn()
        {
            HeaterIsOn = true;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            HeaterIsOn = false;
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return SelfTestResult;
        }
    }

}