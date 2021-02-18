using ECS_ModernSolution;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace UT_ECS_ModernSolution
{
    public class Tests
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

        [TestCase]
        public void Test1()
        {
            fakeSensor.Temp = 5;
            Assert.Pass();
        }
    }

    internal class FakeSensor : ISensor
    {
        public int Temp { get; set; }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

    internal class FakeHeater: IHeater
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