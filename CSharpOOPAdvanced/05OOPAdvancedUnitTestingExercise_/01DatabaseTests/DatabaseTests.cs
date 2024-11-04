using _01Database;
using NUnit.Framework;

namespace _01DatabaseTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;

        private Database database;

        [SetUp]
        public void TestInitialization()
        {
            this.database = new Database();
        }

        [Test]
        public void ThrowsExceptionWhenAddInFullDatabase()
        {
            this.AddNumbers(DatabaseCapacity);

            //Assert.Throws<InvalidOperationException>(() => this.database.Add(9));
            Assert.That(() => this.database.Add(9), Throws.InvalidOperationException.With.Message.EqualTo("Database is full!"));
        }

        [Test]
        public void ThrowsExceptionWhenRemoveInEmptyDatabase()
        {
            //Assert.Throws<InvalidOperationException>(() => this.database.Remove());
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Database is empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(15)]
        [TestCase(16)]
        public void AddNumbersInDatabaseIncreasesCount(int numberOfAdditions)
        {
            this.AddNumbers(numberOfAdditions);

            //Assert.AreEqual(numberOfAdditions, this.database.Count, "Adding numbers doesn't update the count correctly!");
            Assert.That(this.database.Count, Is.EqualTo(numberOfAdditions), "Adding numbers doesn't update the count correctly!");
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(16, 0)]
        [TestCase(1, 1)]
        [TestCase(7, 1)]
        [TestCase(7, 3)]
        [TestCase(7, 7)]
        [TestCase(16, 7)]
        [TestCase(16, 15)]
        [TestCase(16, 16)]
        public void RemoveNumbersFromDatabaseDecreasesCount(int numberOfAdditions, int numberOfRemovals)
        {
            this.AddNumbers(numberOfAdditions);
            this.RemoveNumbers(numberOfRemovals);

            int expectedCount = numberOfAdditions - numberOfRemovals;
            //Assert.AreEqual(expectedCount, this.database.Count, "Remuving numbers doesn't update the count correctly!");
            Assert.That(this.database.Count, Is.EqualTo(expectedCount), "Remuving numbers doesn't update the count correctly!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(15)]
        [TestCase(16)]
        public void FetchReturnsNumberOfElementsAfterAddition(int numberOfAdditions)
        {
            this.AddNumbers(numberOfAdditions);
            int[] databaseContent = this.database.Fetch();

            //Assert.AreEqual(numberOfAdditions, databaseContent.Length);
            Assert.That(databaseContent.Length, Is.EqualTo(numberOfAdditions));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(15)]
        [TestCase(16)]
        public void FetchReturnsElementsAfterAddition(int numberOfAdditions)
        {
            this.AddNumbers(numberOfAdditions);
            int[] databaseContent = this.database.Fetch();

            for (int i = 0; i < numberOfAdditions; i++)
            {
                //Assert.AreEqual(i, databaseContent[i]);
                Assert.That(databaseContent[i], Is.EqualTo(i));
            }
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(16, 0)]
        [TestCase(1, 1)]
        [TestCase(7, 1)]
        [TestCase(7, 3)]
        [TestCase(7, 7)]
        [TestCase(16, 7)]
        [TestCase(16, 15)]
        [TestCase(16, 16)]
        public void FetchReturnsNumberOfElementsAfterRemoval(int numberOfAdditions, int numberOfRemovals)
        {
            this.AddNumbers(numberOfAdditions);
            this.RemoveNumbers(numberOfRemovals);
            int[] databaseContent = this.database.Fetch();

            int expectedNumberOfElements = numberOfAdditions - numberOfRemovals;
            //Assert.AreEqual(expectedNumberOfElements, databaseContent.Length);
            Assert.That(databaseContent.Length, Is.EqualTo(expectedNumberOfElements));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(16, 0)]
        [TestCase(1, 1)]
        [TestCase(7, 1)]
        [TestCase(7, 3)]
        [TestCase(7, 7)]
        [TestCase(16, 7)]
        [TestCase(16, 15)]
        [TestCase(16, 16)]
        public void FetchReturnsElementsAfterRemoval(int numberOfAdditions, int numberOfRemovals)
        {
            this.AddNumbers(numberOfAdditions);
            this.RemoveNumbers(numberOfRemovals);
            int[] databaseContent = this.database.Fetch();

            for (int i = 0; i < numberOfAdditions - numberOfRemovals; i++)
            {
                //Assert.AreEqual(i, databaseContent[i]);
                Assert.That(databaseContent[i], Is.EqualTo(i));
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(1, 10, 89)]
        [TestCase(1, -67, 6789, 89000)]
        [TestCase(0, int.MinValue, int.MaxValue)]
        [TestCase(1, 1, 1, 1, 1, 1, 1)]
        [TestCase(1, 6, 7, 8, 11, 15, 147, 578, 1, 6, 7, 8, 11, 15, 147, 578)]
        public void InitializationConstructorWithCollectionOfNumbers(params int[] numbers)
        {
            this.database = new Database(numbers);

            int[] databaseContent = this.database.Fetch();

            for (int i = 0; i < numbers.Length; i++)
            {
                //Assert.AreEqual(numbers[i], databaseContent[i]);
                Assert.That(databaseContent[i], Is.EqualTo(numbers[i]));
            }
        }

        [Test]
        [TestCase(10, 19)]
        [TestCase(0, -9)]
        [TestCase(int.MinValue, int.MaxValue)]
        public void InitializationConstructorWithNumbers(int firsNumber, int secondNumber)
        {
            this.database = new Database(firsNumber, secondNumber);

            int[] databaseContent = this.database.Fetch();

            //Assert.AreEqual(firsNumber, databaseContent[0]);
            Assert.That(databaseContent[0], Is.EqualTo(firsNumber));
            //Assert.AreEqual(secondNumber, databaseContent[1]);
            Assert.That(databaseContent[1], Is.EqualTo(secondNumber));
        }

        [Test]
        public void ThrowsExceptionWhenCollectionIsBiggerThanCapacity()
        {
            int[] biggerThanCapacityCollection = new int[DatabaseCapacity + 1];

            //Assert.Throws<InvalidOperationException>(() => this.database = new Database(biggerThanCapacityCollection));
            Assert.That(() => this.database = new Database(biggerThanCapacityCollection), Throws.InvalidOperationException.With.Message.EqualTo("Database is full!"));
        }

        [Test]
        public void DoesNotThrowExceptionByInicializationWithNull()
        {
            Assert.DoesNotThrow(() => this.database = new Database(null));
        }

        private void AddNumbers(int numberOfAdditions)
        {
            for (int i = 0; i < numberOfAdditions; i++)
            {
                this.database.Add(i);
            }
        }

        private void RemoveNumbers(int numberOfRemovals)
        {
            for (int i = 0; i < numberOfRemovals; i++)
            {
                this.database.Remove();
            }
        }
    }
}
