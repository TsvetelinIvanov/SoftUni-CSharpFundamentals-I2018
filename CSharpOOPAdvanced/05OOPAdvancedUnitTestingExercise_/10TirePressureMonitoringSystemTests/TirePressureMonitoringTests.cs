using System;
using System.Reflection;
using Moq;
using NUnit.Framework;
using _10TirePressureMonitoringSystem;

namespace _10TirePressureMonitoringSystemTests
{
    [TestFixture]
    public class TirePressureMonitoringTests
    {
        private const int ValidPrssure = 19;
        private const int BottomValidPressure = 17;
        private const int TopValidPressure = 21;
        private const int NegativePressure = -10;
        private const int LowerPressure = 15;
        private const int HigherPressure = 26;

        [Test]
        public void ThrowsExceptionByNegativePressure()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(NegativePressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => classInstance.Check());
        }

        [Test]
        public void LowerPressureActivatesAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(LowerPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));


            checkMethod.Invoke(classInstance, null);

            Assert.IsTrue(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }

        [Test]
        public void HigherPressureActivatesAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(HigherPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsTrue(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }

        [Test]
        public void ValidPressureDoesNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(ValidPrssure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void BottomValidPressureDoesNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(BottomValidPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void TopValidPressureDoesNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(TopValidPressure);
            Type alarmType = typeof(Alarm);
            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.IsFalse(classInstance.AlarmOn);
            //Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }
    }
}
