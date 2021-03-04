using System;
using ECS_ModernSolution;

namespace UT_ECS_ModerSolution
{
    public class MockHeater: IHeater
    {
        public int OnCounter { get;  set; }
        public int OffCounter { get; set; }
        public bool SelfTestResult { get; set; }
        public bool HeaterIsOn { get; set; }
        public void TurnOn()
        {
            OnCounter++;
            HeaterIsOn = true;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            OffCounter++;
            HeaterIsOn = false;
            Console.WriteLine("Heater turned off");
        }

        public bool RunSelfTest()
        {
            return SelfTestResult;
        }
    }

}