using _09DateTimeNowAddDays;
using Moq;
using NUnit.Framework;
using System;
using System.Globalization;

namespace _09DateTimeNowAddDaysTests
{
    [TestFixture]
    public class AddDayTests
    {
        private const int AddDaysToMiddle = 11;
        private const int AddDaysToEnd = 20;
        private const int AddDaysToNextMonth = 26;
        private const int AddDaysToPreviousMonth = -15;
        private const int AddOneDay = 1;
        private const int SubtractOneDay = -1;

        private static DateTime DateTimeNow = DateTime.Parse("04/09/2018", CultureInfo.InvariantCulture);
        private static DateTime DateTimeMinValue = DateTime.MinValue;
        private static DateTime DateTimeMaxValue = DateTime.MaxValue;

        [Test]
        public void AddDaysWorksToTheMiddleOfMonth()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToMiddle));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToMiddle).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "20.4.2018 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void AddDaysWorksToTheEndOfMonth()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToEnd));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToEnd).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "29.4.2018 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void AddDaysWorksToTheNextMonth()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToNextMonth));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToNextMonth).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "5.5.2018 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void AddDaysWorksToThePreviousMonth()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToPreviousMonth));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToPreviousMonth).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "25.3.2018 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void AddDaysWorksToLeapYear()
        {
            DateTime leapYear = DateTime.Parse("02/28/2020", CultureInfo.InvariantCulture);
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(leapYear.AddDays(AddOneDay));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = leapYear.AddDays(AddOneDay).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "29.2.2020 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));

            bool isDayCorrect = mockDateTimeNow.Object.GiveDateTimeNow().Day.ToString().Equals("29");

            Assert.IsTrue(isDayCorrect);
            //Assert.That(isDayCorrect, Is.EqualTo(true));
        }

        [Test]
        public void AddDaysWorksToNonLeapYear()
        {
            DateTime nonLeapYear = DateTime.Parse("02/28/2018", CultureInfo.InvariantCulture);
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(nonLeapYear.AddDays(AddOneDay));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = nonLeapYear.AddDays(AddOneDay).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "1.3.2018 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));

            bool isDayCorrect = mockDateTimeNow.Object.GiveDateTimeNow().Day.ToString().Equals("1");

            Assert.IsTrue(isDayCorrect);
            //Assert.That(isDayCorrect, Is.EqualTo(true));
        }

        [Test]
        public void AddDaysWorksToMinValue()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMinValue.AddDays(AddOneDay));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeMinValue.AddDays(AddOneDay).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "2.1.0001 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }

        [Test]
        public void ThrowsExceptionBySubtractingOneDayFromMinValue()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            Assert.Throws<ArgumentOutOfRangeException>(() => mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMinValue.AddDays(SubtractOneDay)));
        }

        [Test]
        public void ThrowsExceptionByAddingOneDayToMaxValue()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            Assert.Throws<ArgumentOutOfRangeException>(() => mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMaxValue.AddDays(AddOneDay)));
        }

        [Test]
        public void AddDaysWorksToMaxValue()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMaxValue.AddDays(SubtractOneDay));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeMaxValue.AddDays(SubtractOneDay).Date.ToString();
            //The DateTime format(expectedDate) depend from local settings and must be manipulate additionally (in this case it is copied from consoleprint, using the above expression)!
            //string expectedDate = "30.12.9999 г. 0:00:00";

            //Assert.AreEqual(expectedDate, actualDate);
            Assert.That(actualDate, Is.EqualTo(expectedDate));
        }
    }
}