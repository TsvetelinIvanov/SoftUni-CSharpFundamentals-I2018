using _01SkeletonForTesting;
using Moq;
using NUnit.Framework;

namespace _01SkeletonForTestingTests
{
    [TestFixture]
    public class Herotests
    {
        private const string HeroName = "Hero";

        [Test]
        public void HeroGainExperienceAfterAttackIfTargetDies()
        {
            FakeDeadTarget fakeDeadTarget = new FakeDeadTarget();
            FakeWeapon fakeWeapon = new FakeWeapon();
            Hero hero = new Hero(HeroName, fakeWeapon);

            hero.Attack(fakeDeadTarget);
            int expectedExperience = fakeDeadTarget.GiveExperience();

            Assert.That(hero.Experience, Is.EqualTo(expectedExperience));
            //Assert.AreEqual(expectedExperience, hero.Experience);
        }

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDiesMoqVersion()
        {
            Mock<ITarget> mockFakeDeadTarget = new Mock<ITarget>();
            mockFakeDeadTarget.Setup(m => m.Health).Returns(0);
            mockFakeDeadTarget.Setup(m => m.GiveExperience()).Returns(10);
            mockFakeDeadTarget.Setup(m => m.IsDead()).Returns(true);

            Mock<IWeapon> mockFakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, mockFakeWeapon.Object);

            hero.Attack(mockFakeDeadTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(mockFakeDeadTarget.Object.GiveExperience()));
            //Assert.AreEqual(mockFakeDeadTarget.Object.GiveExperience(), hero.Experience);
        }
    }    
}