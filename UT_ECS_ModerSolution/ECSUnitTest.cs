using ECS_ModernSolution;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace UT_ECS_ModernSolution
{
    public class ECSUnitTest
    {
        private ECS uut;
        private StubSensor fakeSensor;
        private MockHeater fakeHeater;
        [SetUp]
        public void Setup()
        {
            fakeSensor = new StubSensor();
            fakeHeater = new MockHeater();
            
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

            Assert.That(fakeHeater.HeaterIsOn, Is.EqualTo(false));
        }

        [Test]
        public void Regulate_ValueUnderMinThreshold_HeaterOn()
        {
            fakeSensor.Temp = 5;
            uut.Regulate();

            Assert.That(fakeHeater.HeaterIsOn, Is.EqualTo(true));
        }

        [Test]
        public void Regulate_TempUnderThreshold_WindowClosed()
        {
            fakeSensor.Temp = 40;
            uut.Regulate();
            Assert.That(uut.WindowOpen, Is.EqualTo(false));
        }

        [Test]
        public void Regulate_TempOverThreshold_WindowOpen()
        {
            fakeSensor.Temp = 50;
            uut.Regulate();
            Assert.That(uut.WindowOpen, Is.EqualTo(true));
        }

        [TestCase(true, true, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(false, false, false)]
        public void RunSelfTest_AllCases_ReturnCorrectOutput(bool heaterResult, bool sensorResult, bool expectedResult)
        {
            fakeHeater.SelfTestResult = heaterResult;
            fakeSensor.SelfTestResult = sensorResult;

            Assert.That(uut.RunSelfTest, Is.EqualTo(expectedResult));
        }
    }
}