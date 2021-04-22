using _02ExtendedDatabase;
using NUnit.Framework;
using System;

namespace _02ExtendedDatabaseTests
{
    [TestFixture]
    public class DatabaseTsts
    {
        private Database database;

        [SetUp]
        public void TestInitialization()
        {
            this.database = new Database();
        }

        [Test]
        public void WorkDatabaseConstructor()
        {
            IPerson firstPerson = new Person(001L, "First");
            IPerson secondPerson = new Person(010L, "Second");
            IPerson[] people = new IPerson[] { firstPerson, secondPerson };

            this.database = new Database(people);

            Assert.That(this.database.Count, Is.EqualTo(2), "Constructor doesn't work!");
            //Assert.AreEqual(2, this.database.Count, "Constructor doesn't work!");
        }

        [Test]
        public void WorkDatabaseConstructorWithNullParameter()
        {
            Assert.DoesNotThrow(() => this.database = new Database(null));
        }

        [Test]
        public void DatabaseAddPerson()
        {
            Person person = new Person(111, "TestUser");

            this.database.Add(person);

            Assert.That(this.database.Count, Is.EqualTo(1), $"Add {typeof(Person)} doesn't work!");
            //Assert.AreEqual(1, this.database.Count, $"Add {typeof(IPerson)} doesn't work");
        }

        [Test]
        [TestCase(0L, "Test", 1L, "Test")]
        [TestCase(0L, "Test", 0L, "Test1")]
        [TestCase(0L, "Test", 0L, "Test")]
        public void ThrowExceptionByAddingPersonWithExistingUsrnameOrId(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            Person firstPerson = new Person(firstId, firstUsername);
            Person secondPerson = new Person(secondId, secondUsername);

            this.database.Add(firstPerson);

            Assert.That(() => this.database.Add(secondPerson), Throws.InvalidOperationException.With.Message.EqualTo("This person already exist in database!"));
            //Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));                
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            Person firstPerson = new Person(1L, "First");
            Person secondPeson = new Person(10L, "Second");
            Person againFirstPerson = new Person(1, "First");

            this.database.Remove(secondPeson);
            this.database.Remove(againFirstPerson);

            Assert.That(this.database.Count, Is.EqualTo(0), $"Removing {typeof(IPerson)} don't work!");
            //Assert.AreEqual(0, this.database.Count, $"Removing {typeof(IPerson)} don't work!");
        }

        [Test]
        [TestCase(1L, 2L, 3L, "First", "Second", "Third", 1L)]
        [TestCase(1L, 2L, 3L, "First", "Second", "Third", 2L)]
        [TestCase(1L, 2L, 3L, "First", "Second", "Third", 3L)]
        public void FindById(long id1, long id2, long id3, string first, string second, string third, long id)
        {
            Person firstPerson = new Person(id1, first);
            Person secondPerson = new Person(id2, second);
            Person thirdPerson = new Person(id3, third);
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);
            this.database.Add(thirdPerson);

            IPerson person = this.database.FindById(id);

            Assert.That(person.Id, Is.EqualTo(id), $"Found {typeof(IPerson)} by Id is not the desired one!");
            //Assert.AreEqual(id, person.Id, $"Found {typeof(IPerson)} by Id is not the desired one!");
        }

        [Test]
        [TestCase(1L, 2L, 3L, "First", "Second", "Third", "First")]
        [TestCase(1L, 2L, 3L, "First", "Second", "Third", "Second")]
        [TestCase(1L, 2L, 3L, "First", "Second", "Third", "Third")]
        public void FindByUsername(long id1, long id2, long id3, string first, string second, string third, string username)
        {
            Person firstPerson = new Person(id1, first);
            Person secondPerson = new Person(id2, second);
            Person thirdPerson = new Person(id3, third);
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);
            this.database.Add(thirdPerson);

            IPerson person = this.database.FindByUsername(username);

            Assert.That(person.Username, Is.EqualTo(username), $"Found {typeof(IPerson)} by Username is not the desired one!");
            //Assert.AreEqual(username, person.Username, $"Found {typeof(IPerson)} by Username is not the desired one!");
        }

        [Test]
        public void ThrowsExceptionBySearchingUnexistingId()
        {
            this.database.Add(new Person(1, "First"));

            Assert.That(() => this.database.FindById(2), Throws.InvalidOperationException.With.Message.EqualTo("There is no user with this id: 2!"));
            //Assert.Throws<InvalidOperationException>(() => this.database.FindById(2));
        }

        [Test]
        public void ThrowsExceptionBySearchingNegativetId()
        {
            this.database.Add(new Person(1L, "First"));

            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void ThrowsExceptionBySearchingNullAssUsername()
        {
            this.database.Add(new Person(1, "First"));

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void ThrowsExceptionBySearchingUnexistentUsername()
        {
            this.database.Add(new Person(1, "First"));

            Assert.That(() => this.database.FindByUsername("first"), Throws.InvalidOperationException.With.Message.EqualTo("There is no user with this username: first!"));
            //Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("first"));
        }
    }
}