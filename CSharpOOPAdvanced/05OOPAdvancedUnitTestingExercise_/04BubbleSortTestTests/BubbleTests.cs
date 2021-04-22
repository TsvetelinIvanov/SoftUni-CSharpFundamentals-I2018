using _04BubbleSortTest;
using NUnit.Framework;
using System.Linq;

namespace _04BobbleSortTestTests
{
    [TestFixture]
    public class BubbleTests
    {
        [Test]
        [TestCase(-3, 8, 234, 17, 45)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(null)]
        [TestCase(-3, 8, -234, 17, 45)]
        [TestCase(9, 2, 3, 4, 5, 6, 7, 0, 8, 1)]
        [TestCase(9, 8, 7, 6, 5, 4, 3, 2, 1, 0)]
        public void BubbleSortWorks(params int[] numbers)
        {
            Bubble bubble = new Bubble();
            int[] sortedNumbers = numbers.OrderBy(n => n).ToArray();

            bubble.Sort(numbers);

            Assert.That(numbers, Is.EquivalentTo(sortedNumbers));
            //CollectionAssert.AreEqual(sortedNumbers, numbers);
        }
    }
}