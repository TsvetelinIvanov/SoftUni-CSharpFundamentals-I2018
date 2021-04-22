using _07Hack;
using Moq;
using NUnit.Framework;
using System;

namespace _07HackTests
{
    [TestFixture]
    public class HackTests
    {
        private const int NegativeValueInteger = -111;
        private const int AbsoluteValueInteger = 111;
        private const double NegativeValueDouble = -111.1;
        private const double AbsoluteValueDouble = 111.1;
        private const double NegativeFloorValueDouble = -112;
        private const double PositiveFloorValueDouble = 111;
        private const decimal NegativeValueDecimal = -111.1m;
        private const decimal AbsoluteValueDecimal = 111.1m;
        private const decimal NegativeFloorValueDecimal = -112m;
        private const decimal PositiveFloorValueDecimal = 111m;

        [Test]
        public void MathAbsWorksWithZero()
        {
            decimal expectedValue = 0m;

            //Assert.AreEqual(expectedValue, Program.GetMatAbsZero());
            Assert.That(Program.GetMatAbsZero(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathAbsWorksWithInteger()
        {
            Mock<IInteger> mockInteger = new Mock<IInteger>();
            mockInteger.Setup(m => m.GetMathAbs(NegativeValueInteger)).Returns(Math.Abs(NegativeValueInteger));
            int expectedValue = AbsoluteValueInteger;
            int actualValue = mockInteger.Object.GetMathAbs(NegativeValueInteger);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathAbsWorksWithDouble()
        {
            Mock<IDouble> mockDouble = new Mock<IDouble>();
            mockDouble.Setup(m => m.GetMathAbs(NegativeValueDouble)).Returns(Math.Abs(NegativeValueDouble));

            double expectedValue = AbsoluteValueDouble;
            double actualValue = mockDouble.Object.GetMathAbs(NegativeValueDouble);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathFloorWorksWithNegativeDouble()
        {
            Mock<IDouble> mockDouble = new Mock<IDouble>();
            mockDouble.Setup(m => m.GetMathFloor(NegativeValueDouble)).Returns(Math.Floor(NegativeValueDouble));

            double expectedValue = NegativeFloorValueDouble;
            double actualValue = mockDouble.Object.GetMathFloor(NegativeValueDouble);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathFloorWorksWithPositiveDouble()
        {
            Mock<IDouble> mockDouble = new Mock<IDouble>();
            mockDouble.Setup(m => m.GetMathFloor(AbsoluteValueDouble)).Returns(Math.Floor(AbsoluteValueDouble));

            double expectedValue = PositiveFloorValueDouble;
            double actualValue = mockDouble.Object.GetMathFloor(AbsoluteValueDouble);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathAbsWorksWithDecimal()
        {
            Mock<IDecimal> mockDecimal = new Mock<IDecimal>();
            mockDecimal.Setup(m => m.GetMathAbs(NegativeValueDecimal)).Returns(Math.Abs(NegativeValueDecimal));

            decimal expectedValue = AbsoluteValueDecimal;
            decimal actualValue = mockDecimal.Object.GetMathAbs(NegativeValueDecimal);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathFloorWorksWithNegativeDecimal()
        {
            Mock<IDecimal> mockDecimal = new Mock<IDecimal>();
            mockDecimal.Setup(m => m.GetMathFloor(NegativeValueDecimal)).Returns(Math.Floor(NegativeValueDecimal));

            decimal expectedValue = NegativeFloorValueDecimal;
            decimal actualValue = mockDecimal.Object.GetMathFloor(NegativeValueDecimal);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MathFloorWorksWithPositiveDecimal()
        {
            Mock<IDecimal> mockDecimal = new Mock<IDecimal>();
            mockDecimal.Setup(m => m.GetMathFloor(AbsoluteValueDecimal)).Returns(Math.Floor(AbsoluteValueDecimal));

            decimal expectedValue = PositiveFloorValueDecimal;
            decimal actualValue = mockDecimal.Object.GetMathFloor(AbsoluteValueDecimal);

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}