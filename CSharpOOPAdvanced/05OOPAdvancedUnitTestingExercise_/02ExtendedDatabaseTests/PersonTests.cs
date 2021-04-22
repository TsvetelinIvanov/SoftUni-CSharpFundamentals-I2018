using _02ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace _02ExtendedDatabaseTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void WorkingConstructorInitialization()
        {
            Person person = new Person(111, "TestUsername");

            Assert.That(person, !Is.EqualTo(null));
            Assert.That(person.Id, Is.EqualTo(111));
            Assert.That(person.Username, Is.EqualTo("TestUsername"));
            //Assert.AreNotEqual(null, person);
            //Assert.AreEqual(111, person.Id);
            //Assert.AreEqual("TestUsername", person.Username)
        }

        [Test]
        public void PopertiesHaveNonPublicSetters()
        {
            Type personPype = typeof(Person);
            PropertyInfo[] proertiesWithPublicSetters = personPype.GetProperties().Where(p => p.SetMethod.IsPublic).ToArray();

            Assert.That(proertiesWithPublicSetters.Length, Is.EqualTo(0));
            //Assert.AreEqual(0, proertiesWithPublicSetters.Length);
        }
    }
}