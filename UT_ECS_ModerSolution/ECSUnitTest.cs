using ECS_ModernSolution;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace UT_ECS_ModernSolution
{
    public class ECSUnitTest
    {
        private ECS uut;
        private FakeSensor fakeSensor;
        private FakeHeater fakeHeater;
        [SetUp]
        public void Setup()
        {
            fakeSensor = new FakeSensor();
            fakeHeater = new FakeHeater();
            
            uut = new ECS(10,fakeSensor, fakeHeater);
        }

        [TestCase(5)]
        [TestCase(50)]

        public void GetCurTemp_ValueUnderAndOverThreshold_returnsTestCaseValues(int fakeTemp)
        {
            fakeSensor.Temp = fakeTemp;
            Assert.That(uut.GetCurTemp(), Is.EqualTo(fakeTemp));
        }
        
    }
}