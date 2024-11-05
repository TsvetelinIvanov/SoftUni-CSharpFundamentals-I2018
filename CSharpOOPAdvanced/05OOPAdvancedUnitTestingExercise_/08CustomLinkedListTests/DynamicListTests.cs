using System;
using NUnit.Framework;
﻿using _08CustomLinkedList;

namespace _08CustomLinkedListTests
{
    [TestFixture]
    public class DynamicListTests
    {
        private DynamicList<int> dynamicList;

        [SetUp]
        public void TestInitialization()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [Test]
        public void ThrowsExceptionByCallingElementWithNegativeIndex()
        {
            int negativeIndex = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => { int testIndex = this.dynamicList[negativeIndex]; }, "It is wrong - the provided index is negative!");
        }

        [Test]
        public void ThrowsExceptionByCallingElementWithBiggerThanCountIndex()
        {
            int biggerThanCountIndex = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => { int testIndex = this.dynamicList[biggerThanCountIndex]; }, "It is wrong - the provided index is bigger than the count!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(19)]
        public void AddIncresesCount(int numberOfAdditions)
        {
            this.AddElements(numberOfAdditions);

            Assert.AreEqual(numberOfAdditions, this.dynamicList.Count, "Adding elements doesn't affect the colection's count!");
            //Assert.That(this.dynamicList.Count, Is.EqualTo(numberOfAdditions), "Adding elements doesn't affect the colection's count!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(19)]
        public void AddSavesElements(int numberOfAdditions)
        {
            this.AddElements(numberOfAdditions);

            for (int i = 0; i < numberOfAdditions; i++)
            {
                Assert.AreEqual(i, this.dynamicList[i], "Elements are not the same as the added elements!");
                //Assert.That(this.dynamicList[i], Is.EqualTo(i), "Elements are not the same as the added elements!");
            }
        }

        [Test]
        public void ThrowsExceptionByRemovingElementWithNegativeIndex()
        {
            int negativeIndexToRemove = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(negativeIndexToRemove), "It is wrong - the removed index is negative!");
        }

        [Test]
        public void ThrowsExceptionByRemovingElementWithBiggerThanCountIndex()
        {
            int biggerThanCountIndexToRemove = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(biggerThanCountIndexToRemove), "It is wrong - the removed index is bigger than the count!");
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(10, 1)]
        [TestCase(10, 6)]
        [TestCase(12, 10)]
        public void RemoveAtWorks(int numberOfAdditions, int indexToRemove)
        {
            this.AddElements(numberOfAdditions);

            this.dynamicList.RemoveAt(indexToRemove);

            Assert.AreEqual(indexToRemove + 1, this.dynamicList[indexToRemove], "The removed index is not the desired one!");
            //Assert.That(this.dynamicList[indexToRemove], Is.EqualTo(indexToRemove + 1), "The removed index is not the desired one!");
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(10, 1)]
        [TestCase(10, 6)]
        [TestCase(11, 10)]
        public void IndexOfWorksWhenDesiredIndexExists(int numberOfAdditions, int indexToReturn)
        {
            this.AddElements(numberOfAdditions);
            
            int expectedIndex = indexToReturn;
            int actualIndex = this.dynamicList.IndexOf(indexToReturn);

            Assert.AreEqual(expectedIndex, actualIndex, "The returned index is not the desired one!");
            //Assert.That(actualIndex, Is.EqualTo(expectedIndex), "The returned index is not the desired one!");
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(10, -1)]
        [TestCase(10, 16)]
        public void InexOfWorksWhenDesiredIndexDoesNotExist(int numberOfAdditions, int indexToReturn)
        {
            this.AddElements(numberOfAdditions);

            bool isReturnedValueNegative = this.dynamicList.IndexOf(indexToReturn) < 0;

            Assert.IsTrue(isReturnedValueNegative, "The returned value isn't negative!");
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(10, 1)]
        [TestCase(10, 6)]
        [TestCase(11, 10)]
        public void RemoveWorksWhenDesiredValueExists(int numberOfAdditions, int elementToRemove)
        {
            this.AddElements(numberOfAdditions);

            this.dynamicList.Remove(elementToRemove);

            Assert.AreEqual(-1, this.dynamicList.IndexOf(elementToRemove), "The removed element is still in the collection!");
            //Assert.That(this.dynamicList.IndexOf(elementToRemove), Is.EqualTo(-1), "The removed element is still in the collection!");
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(10, -1)]
        [TestCase(10, 16)]
        public void RemoveWorksWhenDesiredValueDoesNotExist(int numberOfAdditions, int indexToReturn)
        {
            this.AddElements(numberOfAdditions);

            bool isReturnedValuenegative = this.dynamicList.Remove(indexToReturn) < 0;

            Assert.IsTrue(isReturnedValuenegative, "The returned value isn't negative!");
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(10, 1)]
        [TestCase(10, 6)]
        [TestCase(11, 10)]
        public void RemoveWorksWhenDesiredIndexDoesNotExistAndReturnsIndexOfRemovedElement(int numberOfAdditions, int indexToReturn)
        {
            this.AddElements(numberOfAdditions);
            int expectedIndex = indexToReturn;

            int actualIndex = this.dynamicList.Remove(indexToReturn);

            Assert.AreEqual(expectedIndex, actualIndex, "The returned index is not the desired one!");
            //Assert.That(actualIndex, Is.EqualTo(expectedIndex), "The returned index is not the desired one!");
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(10, 1)]
        [TestCase(10, 6)]
        [TestCase(11, 10)]
        public void ContainsWorksWhenDesiredElementExists(int numberOfAdditions, int indexToContain)
        {
            this.AddElements(numberOfAdditions);

            Assert.IsTrue(this.dynamicList.Contains(indexToContain), "Contains doesn't work correctly!");
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(10, -1)]
        [TestCase(10, 16)]
        public void ContainsWorksWhenDesiredElementDoesNotExist(int numberOfAdditions, int indexToContain)
        {
            this.AddElements(numberOfAdditions);

            Assert.IsFalse(this.dynamicList.Contains(indexToContain), "Contains doesn't work correctly!");
        }

        private void AddElements(int numberOfAdditions)
        {
            for (int i = 0; i < numberOfAdditions; i++)
            {
                this.dynamicList.Add(i);
            }
        }
    }
}
