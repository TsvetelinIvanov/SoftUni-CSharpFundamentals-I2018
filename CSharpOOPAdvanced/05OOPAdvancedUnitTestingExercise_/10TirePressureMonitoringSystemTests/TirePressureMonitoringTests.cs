using System;
using System.Reflection;
using _10TirePressureMonitoringSystem;
using Moq;
using NUnit.Framework;

namespace _10TirePressureMonitoringSystemTests
{
    [TestFixture]
    public class TirePressureMonitoringTests
    {
        private const int NegativePressure = -10;
        private const int LowerPressure = 15;
        private const int BottomValidPressure = 17;
        private const int ValidPrssure = 19;
        private const int TopValidPressure = 21;
        private const int HigherPressure = 26;

        [Test]
        public void ThrowsExceptionByNegativePressure()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(NegativePressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo _sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            _sensor.SetValue(classInstance, mockSensor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => classInstance.Check());
        }

        [Test]
        public void LowerPressureActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(LowerPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo _sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            _sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));


            checkMethod.Invoke(classInstance, null);

            Assert.IsTrue(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }

        [Test]
        public void BottomValidPressureNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(BottomValidPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo _sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            _sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void ValidPressureNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(ValidPrssure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo _sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            _sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void TopValidPressureNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(TopValidPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo _sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            _sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void HigherPressureActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(HigherPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo _sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            _sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsTrue(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }
    }
}