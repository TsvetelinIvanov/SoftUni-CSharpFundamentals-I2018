using System;

namespace _10TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor sensor = new Sensor();

        private bool alarmOn = false;

        public bool AlarmOn
        {
            get { return this.alarmOn; }
        }

        public void Check()
        {
            double psiPressureValue = this.sensor.PopNextPressurePsiValue();

            if (psiPressureValue < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "Pressure cannot be negative!");
            }

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.alarmOn = true;
            }
        }
    }
}
