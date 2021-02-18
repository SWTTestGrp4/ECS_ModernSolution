using System;

namespace ECS_ModernSolution
{
    public interface ISensor
    {
        public int GetTemp();

        public bool RunSelfTest();
    }
}