using ECS_ModernSolution;

namespace UT_ECS_ModernSolution
{
    public class FakeHeater: IHeater
    {
        public void TurnOn()
        {
            
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

}