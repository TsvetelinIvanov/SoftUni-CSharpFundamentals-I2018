﻿using _08CustomLinkedList;
using NUnit.Framework;
using System;
using System.Reflection;

namespace _08CustomLinkedListTests
{
    [TestFixture]
    public class DynamicListReflectionTests
    {
        private const int ExpectedZeroCount = 0;
        private const int ExpectedThreeElementsCount = 3;
        private const int LowerRemoveIndex = -4;
        private const int ValidRemoveIndex = 1;
        private const int HigherRemoveIndex = 10;

        [Test]
        public void CountReturnsZeroByEmptyCollection()
        {
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            int elementsCount = (int)dynamicListType.GetProperty("Count").GetValue(classInstance);

            //Assert.That(elementsCount, Is.EqualTo(ExpectedZeroCount), "Count doesn't return zero by empty collection!");
            Assert.AreEqual(ExpectedZeroCount, elementsCount, "Count doesn't return zero by empty collection!");
        }

        [Test]
        public void CountWorksByThreeElements()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int elementsCount = (int)dynamicListType.GetProperty("Count").GetValue(classInstance);

            //Assert.That(elementsCount, Is.EqualTo(ExpectedThreeElementsCount), "Count doesn't work correctly!");
            Assert.AreEqual(ExpectedThreeElementsCount, elementsCount, "Count doesn't work correctly!");
        }

        [Test]
        public void AddWorks()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            foreach (string element in testElements)
            {
                classInstance.Add(element);
            }

            for (int i = 0; i < testElements.Length; i++)
            {
                Assert.AreEqual(testElements[i], classInstance[i], "Add doesn't work correctly!");
                //Assert.That(classInstance[i], Is.EqualTo(testElements[i]), "Add doesn't work correctly!");
            }
        }

        [Test]
        public void SetElementAtSpecificIndexShouldWorks()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            foreach (var element in testElements)
            {
                classInstance.Add(element);
            }

            classInstance[0] = testElements[2];
            string expectedElement = testElements[2];
            string actualElement = classInstance[0];

            Assert.AreEqual(expectedElement, actualElement, "Setting element at specific index doesn't work correctly!");
            //Assert.That(actualElement, Is.EqualTo(expectedElement), "Setting element at specific index doesn't work correctly!");
        }

        [Test]
        public void AddWorksWithOneElement()
        {
            string[] testElements = new string[] { "single" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            FieldInfo head = dynamicListType.GetField("head", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            string expectedElement = testElements[0];
            string actualElement = classInstance[0];

            Assert.AreEqual(expectedElement, actualElement, "Add doesn't work correctly!");
            //Assert.That(actualElement, Is.EqualTo(expectedElement), "Add doesn't work correctly!");
        }

        [Test]
        public void AddWorksWithThreeElements()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            for (int i = 0; i < testElements.Length; i++)
            {
                Assert.AreEqual(testElements[i], classInstance[i], "Add doesn't work correctly!");
                //Assert.That(classInstance[i], Is.EqualTo(testElements[i]), "Add doesn't work correctly!");
            }
        }

        [Test]
        [TestCase(LowerRemoveIndex)]
        [TestCase(HigherRemoveIndex)]
        public void ThrowsExceptionByRemoveAtIncorectIndex(int incorectIndex)
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo removeAtMethod = dynamicListType.GetMethod("RemoveAt", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => classInstance.RemoveAt(incorectIndex), $"Incorect index: {incorectIndex}!");
        }

        [Test]
        public void RemoveAtWorks()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            MethodInfo removeAtMethod = dynamicListType.GetMethod("RemoveAt", BindingFlags.Instance | BindingFlags.Public);
            removeAtMethod.Invoke(classInstance, new object[] { ValidRemoveIndex });

            testElements = new string[] { "first", "third" };
            for (int i = 0; i < testElements.Length; i++)
            {
                Assert.AreEqual(testElements[i], classInstance[i], "RemoveAt doesn't work correctly!");
                //Assert.That(classInstance[i], Is.EqualTo(testElements[i]), "RemoveAt doesn't work correctly!");
            }
        }

        [Test]
        public void RemoveNonExistingElementReturnsMinusOne()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo removeMethod = dynamicListType.GetMethod("Remove", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int nonValidElement = (int)removeMethod.Invoke(classInstance, new object[] { "NonExistingElement" });
            int expectedReturn = -1;

            Assert.AreEqual(expectedReturn, nonValidElement, "Remove doesn't work correctly!");
            //Assert.That(nonValidElement, Is.EqualTo(expectedReturn), "Remove doesn't work correctly!");
        }

        [Test]
        public void RemoveWorks()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            MethodInfo removeMethod = dynamicListType.GetMethod("Remove", BindingFlags.Instance | BindingFlags.Public);
            removeMethod.Invoke(classInstance, new object[] { testElements[1] });

            testElements = new string[] { "first", "third" };
            for (int i = 0; i < testElements.Length; i++)
            {
                Assert.AreEqual(testElements[i], classInstance[i], "Remove doesn't work correctly!");
                //Assert.That(classInstance[i], Is.EqualTo(testElements[i]), "Remove doesn't work correctly!");
            }
        }

        [Test]
        public void IndexOfNonExistingElementReturnsMinusOne()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo indexOfMethod = dynamicListType.GetMethod("IndexOf", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int nonValidElement = (int)indexOfMethod.Invoke(classInstance, new object[] { "NonExistingElement" });
            int expectedReturn = -1;

            Assert.AreEqual(expectedReturn, nonValidElement, "IndexOf doesn't work correctly!");
            //Assert.That(nonValidElement, Is.EqualTo(expectedReturn), "IndexOf doesn't work correctly!");
        }

        [Test]
        public void IndexOfWorks()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo indexOfMethod = dynamicListType.GetMethod("IndexOf", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int actualElement = (int)indexOfMethod.Invoke(classInstance, new object[] { testElements[2] });
            int expectedElement = 2;

            Assert.AreEqual(expectedElement, actualElement, "IndexOf doesn't work correctly!");
            //Assert.That(actualElement, Is.EqualTo(expectedElement), "IndexOf doesn't work correctly!");
        }

        [Test]
        public void ContainsNonExistingElementReturnsFalse()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo containsMethod = dynamicListType.GetMethod("Contains", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            bool IsElementValid = (bool)containsMethod.Invoke(classInstance, new object[] { "NonExistingElement" });

            Assert.IsFalse(IsElementValid, "Contains doesn't work correctly!");
            //Assert.That(IsElementValid, Is.EqualTo(false), "Contains doesn't work correctly!");
        }

        [Test]
        public void ContainsExistingElementReturnsTrue()
        {
            string[] testElements = new string[] { "first", "second", "third" };
            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            MethodInfo containsMethod = dynamicListType.GetMethod("Contains", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (string element in testElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            bool IsElementValid = (bool)containsMethod.Invoke(classInstance, new object[] { "first" });

            Assert.IsTrue(IsElementValid, "Contains doesn't work correctly!");
            //Assert.That(IsElementValid, Is.EqualTo(true), "Contains doesn't work correctly!");
        }
    }
}