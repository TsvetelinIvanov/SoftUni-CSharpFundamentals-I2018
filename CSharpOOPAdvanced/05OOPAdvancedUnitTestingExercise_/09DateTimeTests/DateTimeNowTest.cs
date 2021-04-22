using _09DateTimeNowAddDays;
using Moq;
using NUnit.Framework;
using System;
using System.Globalization;

namespace _09DateTimeTests
{
    public class DateTimeNowTest
    {
        private static DateTime DateTimeNow = DateTime.Parse("04/09/2018", CultureInfo.InvariantCulture);
        private static DateTime DateTimeMinValue = DateTime.MinValue;
        private static DateTime DateTimeMaxValue = DateTime.MaxValue;

        private const int AddDaysToMiddle = 11;
        private const int AddDaysToEnd = 20;
        private const int AddDaysToNextMonth = 26;
        private const int AddDaysToPreviousMonth = -15;
        private const int AddDayInLeapYear = 1;
        private const int AddOneDay = 1;
        private const int SubtractOneDay = -1;

        [Test]
        public void AddDaysToTheMiddleOfMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToMiddle));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToMiddle).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDaysToTheEndOfMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToEnd));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToEnd).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDaysToNextMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToNextMonth));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToNextMonth).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDaysToPreviousMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToPreviousMonth));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeNow.AddDays(AddDaysToPreviousMonth).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDayToLeapYearShouldWorkCorrectly()
        {
            DateTime leapYear = DateTime.Parse("02/28/2020", CultureInfo.InvariantCulture);

            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(leapYear.AddDays(AddDayInLeapYear));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = leapYear.AddDays(AddDayInLeapYear).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);

            bool dayIsCorrect = mockDateTimeNow.Object.GiveDateTimeNow().Day.ToString().Equals("29");

            Assert.AreEqual(dayIsCorrect, true);
        }

        [Test]
        public void AddDayToNonLeapYearShouldWorkCorrectly()
        {
            DateTime leapYear = DateTime.Parse("02/28/2018", CultureInfo.InvariantCulture);

            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(leapYear.AddDays(AddDayInLeapYear));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = leapYear.AddDays(AddDayInLeapYear).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);

            bool dayIsCorrect = mockDateTimeNow.Object.GiveDateTimeNow().Day.ToString().Equals("1");

            Assert.AreEqual(dayIsCorrect, true);
        }

        [Test]
        public void AddDayToMinValueShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMinValue.AddDays(AddOneDay));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeMinValue.AddDays(AddOneDay).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void SubtractDayFromMinValueShouldThrowException()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            Assert.Throws<ArgumentOutOfRangeException>(() => mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMinValue.AddDays(SubtractOneDay)));
        }

        [Test]
        public void AddDayToMaxValueShouldThrowException()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            Assert.Throws<ArgumentOutOfRangeException>(() => mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMaxValue.AddDays(AddOneDay)));
        }

        [Test]
        public void SubtractDayFromMaxValueShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveDateTimeNow()).Returns(DateTimeMaxValue.AddDays(SubtractOneDay));

            string actualDate = mockDateTimeNow.Object.GiveDateTimeNow().Date.ToString();
            string expectedDate = DateTimeMaxValue.AddDays(SubtractOneDay).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }
    }
}