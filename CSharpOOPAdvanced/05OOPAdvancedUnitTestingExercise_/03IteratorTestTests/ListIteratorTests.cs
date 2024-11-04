using System.Linq;
using System.Reflection;
using NUnit.Framework;
﻿using _03IteratorTest;

namespace _03IteratorTestTests
{
    [TestFixture]
    public class ListIteratorTests
    {
        private ListIterator listIterator;
        private string[] initializingCollection;

        [SetUp]
        public void TestInitializaton()
        {
            this.initializingCollection = new string[] { "one", "two", "three" };
            this.listIterator = new ListIterator(this.initializingCollection);
        }

        [Test]
        public void ThrowsExceptionWithNullInitializationConstructor()
        {
            Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
            //Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }

        [Test]
        public void MoveReturnsTrue()
        {
            Assert.That(this.listIterator.Move(), Is.EqualTo(true));
            //Assert.AreEqual(true, this.listIterator.Move());
        }

        [Test]
        public void MoveReturnsFalseWhenIsOnLastElement()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.That(this.listIterator.Move(), Is.EqualTo(false));
            //Assert.AreEqual(false, this.listIterator.Move());
        }

        [Test]
        public void MoveMovesNextIndex()
        {
            this.listIterator.Move();
            object internalIndexValue = typeof(ListIterator).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "currentIndex").GetValue(this.listIterator);

            Assert.That(internalIndexValue, Is.EqualTo(1));
            //Assert.AreEqual(1, internalIndexValue);
        }

        [Test]
        public void HasNextReturnsTrue()
        {
            Assert.That(this.listIterator.HasNext(), Is.EqualTo(true));
            //Assert.IsTrue(this.listIterator.HasNext());
        }

        [Test]
        public void HasNextReturnsFalseWhenIsOnLastElement()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.That(this.listIterator.HasNext(), Is.EqualTo(false));
            //Assert.IsFalse(this.listIterator.HasNext());
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void PrintWorksCorrectly(int elementToReturnIndex)
        {
            for (int i = 0; i < elementToReturnIndex; i++)
            {
                this.listIterator.Move();
            }

            Assert.That(this.listIterator.Print(), Is.EqualTo(this.initializingCollection[elementToReturnIndex]));
            //Assert.AreEqual(this.initializingCollection[elementToReturnIndex]), this.listIterator.Print());
        }

        [Test]
        public void ThrowsExceptionWhenPrintFromEmptyCollection()
        {
            this.listIterator = new ListIterator(new string[0]);

            Assert.That(() => this.listIterator.Print(), Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
            //InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.listIterator.Print());
            //Assert.AreEqual("Invalid Operation!", exception.Message);            
        }
    }
}
