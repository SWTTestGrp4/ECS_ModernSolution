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
            
            uut = new ECS(10, 45,fakeSensor, fakeHeater);
        }

        [TestCase(5)]
        [TestCase(50)]

        public void GetCurTemp_ValueOverAndUnderMinThreshold_returnsTestCaseValues(int fakeTemp)
        {
            fakeSensor.Temp = fakeTemp;
            Assert.That(uut.GetCurTemp(), Is.EqualTo(fakeTemp));
        }

        [Test]
        public void Regulate_ValueOverMinThreshold_HeaterOff()
        {
            fakeSensor.Temp = 15;
            uut.Regulate();

            Assert.That(fakeHeater.Result, Is.EqualTo(false));
        }

        [Test]
        public void Regulate_ValueUnderMinThreshold_HeaterOn()
        {
            fakeSensor.Temp = 5;
            uut.Regulate();

            Assert.That(fakeHeater.Result, Is.EqualTo(true));
        }
    }
}