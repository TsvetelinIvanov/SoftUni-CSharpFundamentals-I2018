using NUnit.Framework;
using System;

namespace _01SkeletonForTestingTests
{
    [TestFixture]
    class DummyTests
    {
        private const int AttackPoints = 10;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            //Dummy dummy = new Dummy(20, 10);
            //dummy.TakeAttack(5);
            //Assert.That(dummy.Health, Is.EqualTo(15));
            this.dummy.TakeAttack(3);
            Assert.IsTrue(this.dummy.Health < DummyHealth, "Dummy does'n lose health after an attack.");
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenIsAttacked()
        {
            //Dummy dummy = new Dummy(5, 10);
            //dummy.TakeAttack(6);            
            //Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
            this.dummy.TakeAttack(6);
            this.dummy.TakeAttack(6);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.dummy
            .TakeAttack(6));
            Assert.That(exception.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGiveExperience()
        {
            //Dummy dummy = new Dummy(0, 10);
            //dummy.GiveExperience();
            //Assert.That(dummy.GiveExperience().Equals(10));
            while (!this.dummy.IsDead())
            {
                this.dummy.TakeAttack(AttackPoints);
            }

            int gotEcperience = this.dummy.GiveExperience();
            //Assert.AreEqual(10, gotEcperience, "Dead dummy does'n give experiance.");
            Assert.That(gotEcperience, Is.EqualTo(10), "Dead dummy does'n give experiance.");
        }

        [Test]
        public void AliveDummyNotGiveExperience()
        {
            //Dummy dummy = new Dummy(10, 10);
            //dummy.GiveExperience();
            //Assert.That(!dummy.GiveExperience().Equals(10));
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
            Assert.That(exception.Message, Is.EqualTo("Target is not dead."));
        }
    }    
}