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

        [TestCase(50,0)]
        [TestCase(30, 0)]
        [TestCase(5, 1)]
        public void Regulate_TempSet_IfTempLessThan10HeaterOnCounterEqualToResult(int temp, int result)
        {
            fakeSensor.Temp = temp;
            uut.Regulate();

            Assert.That(fakeHeater.OnCounter, Is.EqualTo(result));
        }

        [TestCase(50, 0, 1, 5, 1, 1)]
        [TestCase(-10, 1, 0, 5, 2, 0)]
        [TestCase(50, 0, 1, 55, 0, 2)]
        public void Regulate_TempSetToTurnOnHeaterAndthenToTurnOff_OnCounterAndOffcounterIsEqualToResult(int temp1, int onResult1, int offResult1, int temp2, int onResult2, int offResult2 )
        {
            fakeSensor.Temp = temp1;
            uut.Regulate();

            Assert.That(fakeHeater.OnCounter, Is.EqualTo(onResult1));
            Assert.That(fakeHeater.OffCounter, Is.EqualTo(offResult1));
            fakeSensor.Temp = temp2;
            uut.Regulate();

            Assert.That(fakeHeater.OnCounter, Is.EqualTo(onResult2));
            Assert.That(fakeHeater.OffCounter, Is.EqualTo(offResult2));


        }
        //[Test]
        //public void Regulate_ValueUnderMinThreshold_HeaterOn()
        //{
        //    fakeSensor.Temp = 5;
        //    uut.Regulate();

        //    Assert.That(fakeHeater.ResultHeaterIsOn, Is.EqualTo(true));
        //}

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