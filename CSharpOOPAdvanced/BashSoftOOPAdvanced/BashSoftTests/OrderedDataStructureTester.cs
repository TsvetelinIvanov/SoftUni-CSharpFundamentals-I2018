using System;
using System.Collections.Generic;
using NUnit.Framework;
﻿using BashSoft.DataStructures;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoftTests
{
    [TestFixture]
    public class OrderedDataStructureTester
    {
        private const int DefaultCapacity = 16;
        private const int DefaultSize = 0;
        private const int ExampleInitialCapacity = 20;
        private const int ExampleCapacityForAllParameters = 30;
        private const int ExampleExpectedSize = 20;
        private const int ExampleExpectedCapacity = 32;

        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void TestInitializaton()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyConstructor()
        {
            Assert.That(this.names.Capacity, Is.EqualTo(DefaultCapacity), $"Initial capacity must be {DefaultCapacity}!");
            Assert.That(this.names.Size, Is.EqualTo(DefaultSize), $"Initial size must be {DefaultSize}!");
            //Assert.AreEqual(DefaultCapacity, this.names.Capacity, $"Initial capacity must be {DefaultCapacity}");
            //Assert.AreEqual(DefaultSize, this.names.Size, $"Initial size must be {DefaultSize}");
        }

        [Test]
        public void TestConstructorWithInitialCapacity()
        {            
            this.names = new SimpleSortedList<string>(ExampleInitialCapacity);

            Assert.That(this.names.Capacity, Is.EqualTo(ExampleInitialCapacity), "Capacity must be equal to the provided one!");
            Assert.That(this.names.Size, Is.EqualTo(DefaultSize), $"Initial size must be {DefaultSize}!");
            //Assert.AreEqual(ExampleInitialCapacity, this.names.Capacity, "Capacity must be equal to the provided one");
            //Assert.AreEqual(DefaultSize, this.names.Size, "Initial size must be {DefaultSize}");
        }

        [Test]
        public void TestConstructorWithAllParameters()
        {            
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, ExampleCapacityForAllParameters);

            Assert.That(this.names.Capacity, Is.EqualTo(ExampleCapacityForAllParameters), "Capacity must be equal to the provided one!");
            Assert.That(this.names.Size, Is.EqualTo(DefaultSize), $"Initial size must be {DefaultSize}!");
            //Assert.AreEqual(ExampleCapacityForAllParameters, this.names.Capacity, "Capacity must be equal to the provided one");
            //Assert.AreEqual(DefaultSize, this.names.Size, $"Initial size must be {DefaultSize}");
        }

        [Test]
        public void TestConstructorWithInitialComparer()
        {            
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.That(this.names.Capacity, Is.EqualTo(DefaultCapacity), $"Initial capacity must be {DefaultCapacity}!");
            Assert.That(this.names.Size, Is.EqualTo(DefaultSize), $"Initial size must be {DefaultSize}!");
            //Assert.AreEqual(DefaultCapacity, this.names.Capacity, $"Initial capacity must be {DefaultCapacity}");
            //Assert.AreEqual(DefaultSize, this.names.Size, $"Initial size must be {DefaultSize}");
        }

        [Test]
        public void AddIncreasesSize()
        {           
            this.names.Add("Name");

            Assert.That(this.names.Size, Is.EqualTo(1), "Add method didn't change the size!");
            //Assert.AreEqual(1, this.names.Size, "Add didn't change the size");
        }

        [Test]        
        public void AddNullIsNotPossible()
        {   
            Assert.That(() => this.names.Add(null), Throws.ArgumentNullException);
            // Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void AddElementsMustSortThemAutomatically()
        {
            this.names.Add("Georgi");
            this.names.Add("Rosen");
            this.names.Add("Balkan");

            Assert.That(this.names.JoinWith(", "), Is.EqualTo("Balkan, Georgi, Rosen"), "Elements are not sorted!");
            //Assert.AreEqual("Balkan, Georgi, Rosen", this.names.JoinWith(", "), "Elements are not sorted!");

            //Assert.AreEqual("Balkan", this.names.TakeElement(0), "Elements are not sorted");
            //Assert.AreEqual("Georgi", this.names.TakeElement(1), "Elements are not sorted");
            //Assert.AreEqual("Rosen", this.names.TakeElement(2), "Elements are not sorted");
        }

        [Test]
        public void AddElementsMoreThanCapacityMustHaveCorrectSize()
        {            
            int expectedSize = ExampleExpectedSize;            
            for (int i = 0; i < expectedSize; i++)
            {
                this.names.Add($"Name {i}");
            }

            Assert.That(this.names.Size, Is.EqualTo(expectedSize), $"Size must be {expectedSize}!");
            //Assert.AreEqual(expectedSize, this.names.Size, $"Size must be {expectedSize}");
        }

        [Test]
        public void AddElementsMoreThanCapacityMustHaveCorrectCapacity()
        { 
            
            for (int i = 0; i < ExampleInitialCapacity; i++)
            {
                this.names.Add($"Name {i}");
            }

            Assert.That(this.names.Capacity, Is.EqualTo(ExampleExpectedCapacity), "Capacity must be doubled!");
            //Assert.AreEqual(ExampleExpectedCapacity, this.names.Capacity, "Capacity must be doubled");
        }

        [Test]
        public void AddAllMustSaveAllTheGivenElements()
        {            
            List<string> collecion = new List<string>()
            {
                "First",
                "Second",
                "Third"
            };
            
            this.names.AddAll(collecion);

            Assert.That(this.names.Size, Is.EqualTo(3), "AddAll Method don't work correctly!");
            //Assert.AreEqual(3, this.names.Size, "AddAll Method don't work correctly");
        }

        [Test]        
        public void AddAllCannotWorkWithNull()
        {
            Assert.That(() => this.names.AddAll(null), Throws.ArgumentNullException);
            //Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
            
        }

        [Test]
        public void AddAllStoresTheElementsInSortedOrder()
        {
            List<string> collection = new List<string>()
            {
                "Georgi",
                "Rosen",
                "Balkan"
            };

            this.names.AddAll(collection);

            Assert.That(this.names.JoinWith(", "), Is.EqualTo("Balkan, Georgi, Rosen"), "Elements are not sorted!");
            //Assert.AreEqual("Balkan, Georgi, Rosen", this.names.JoinWith(", "), "Elements are not sorted!");

            //Assert.AreEqual("Balkan", this.names.TakeElement(0), "Elements are not sorted");
            //Assert.AreEqual("Georgi", this.names.TakeElement(1), "Elements are not sorted");
            //Assert.AreEqual("Rosen", this.names.TakeElement(2), "Elements are not sorted");
        }

        [Test]
        public void RemoveShouldDecresaseTheSize()
        {           
            this.names.AddAll(new string[] { "Rosen", "Georgi", "Balkan" });
            
            this.names.Remove("Georgi");

            Assert.That(this.names.Size, Is.EqualTo(2), "Size is not decreased after removing an element!" );
            //Assert.AreEqual(2, this.names.Size, "Size is not decreased after removing an element");
        }

        [Test]
        public void RemoveShouldRemoveTheExactOneSpecified()
        {
            this.names.AddAll(new string[] { "1", "2", "3" });

            this.names.Remove("2");

            Assert.That(this.names.JoinWith(", "), Is.EqualTo("1, 3"), "Removed element is wrong!");
            //Assert.AreEqual("1, 3", this.names.JoinWith(", "), "Removed element is wrong!");

            //Assert.AreEqual("1", this.names.TakeElement(0), "Removed element is wrong");
            //Assert.AreEqual("3", this.names.TakeElement(1), "Removed element is wrong");
        }

        [Test]        
        public void RemoveCannotWorkWithNull()
        {            
            this.names.AddAll(new string[] { "1", "2", "3" });

            Assert.That(() => this.names.Remove(null), Throws.ArgumentNullException);
           // Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));          
        }

        [Test]
        public void JoinWithShouldReturnAllElementsWithTheJoinerBetweenThem()
        {           
            this.names.AddAll(new string[] { "1", "2", "3" });

            Assert.That(this.names.JoinWith(", "), Is.EqualTo("1, 2, 3"), "Elements are not joined correctly!");
            //Assert.AreEqual("1, 2, 3", this.names.JoinWith(", "), "Elements are not joined correctly");
        }

        [Test]        
        public void JoinWithCannotWorkWithNull()
        {            
            this.names.AddAll(new string[] { "1", "2", "3" });

            Assert.That(() => this.names.JoinWith(null), Throws.ArgumentNullException);
            //Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));            
        }

        [Test]
        public void TakeElementWorks()
        {
            this.names.AddAll(new string[] { "1", "2", "3" });           

            Assert.That(this.names.TakeElement(0), Is.EqualTo("1"), "TakeElement does not return the desired element!");
            Assert.That(this.names.TakeElement(1), Is.EqualTo("2"), "TakeElement does not return the desired element!");
            Assert.That(this.names.TakeElement(2), Is.EqualTo("3"), "TakeElement does not return the desired element!");

            //Assert.AreEqual("1", this.names.TakeElement(0), "TakeElement does not return the desired element!");
            //Assert.AreEqual("2", this.names.TakeElement(1), "TakeElement does not return the desired element!");
            //Assert.AreEqual("3", this.names.TakeElement(2), "TakeElement does not return the desired element!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(9)]
        public void TakeElementDoesNotWorkWithInvalidIndex(int invalidIndex)
        {
            this.names.AddAll(new string[] { "1", "2", "3" });

            Assert.Throws<InvalidIndexException>(() => this.names.TakeElement(invalidIndex));            
        }
    }
}
