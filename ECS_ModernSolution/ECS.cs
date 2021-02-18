using System;
using System.Windows;
namespace ECS_ModernSolution
{
    public class ECS
    {
        private int _threshold;
        private int _maxThreshold = 45;

        public int MaxThreshold
        {
            get { return _maxThreshold; }
            set { _maxThreshold = value; }
        }

        private readonly ISensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr, ISensor tempSensor, IHeater heater)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
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
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
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