using ECS_ModernSolution;
using NUnit.Framework;

namespace UT_ECS_ModernSolution
{
    public class ProgramUnitTest
    {
        private Program uut;

        [SetUp]
        public void Setup()
        {
            uut = new Program();
        }

        [Test]
        public void SwitchCase1_ReadKeyAndSetItToMinThreshold_ThresholdIsUpdated()
        {
            //Vi �nsker hj�lp fra Frank til at forst� hvordan man tester en runtime-configurable feature
        }
    }
}