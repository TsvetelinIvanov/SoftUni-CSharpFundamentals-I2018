using System;

namespace _10TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor _sensor = new Sensor();

        private bool _alarmOn = false;

        public bool AlarmOn
        {
            get { return this._alarmOn; }
        }

        public void Check()
        {
            double psiPressureValue = this._sensor.PopNextPressurePsiValue();

            if (psiPressureValue < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "Pressure cannot be negative!");
            }

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this._alarmOn = true;
            }
        }
    }
}