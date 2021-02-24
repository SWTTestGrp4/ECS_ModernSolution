﻿using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class StubSensor : ISensor
    {
        public bool SelfTestResult { get; set; }
        public int Temp { get; set; }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return SelfTestResult;
        }
    }

   
}