using System;
using System.Windows;
namespace ECS_ModernSolution
{
    public class ECS
    {
        private int _minThreshold;
        private int _maxThreshold = 45;

        public int MaxThreshold
        {
            get { return _maxThreshold; }
            set { _maxThreshold = value; }
        }


        public int MinThreshold
        {
            get { return _minThreshold; }
            set { _minThreshold = value; }
        }


        private readonly ISensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int minThr, int maxThr, ISensor tempSensor, IHeater heater)
        {
            _minThreshold = minThr;
            _maxThreshold = maxThr;
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _minThreshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
            if (t>= MaxThreshold)
            {
                Console.WriteLine("Window opened");
            }
            else
            {
                Console.WriteLine("Window closed");
            }

        }

        public void SetThreshold(int thr)
        {
            _minThreshold = thr;
        }

        public int GetThreshold()
        {
            return _minThreshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}