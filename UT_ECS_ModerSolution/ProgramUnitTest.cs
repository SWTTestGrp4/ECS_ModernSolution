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
            //Vi ønsker hjælp fra Frank til at forstå hvordan man tester en runtime-configurable feature
        }
    }
}