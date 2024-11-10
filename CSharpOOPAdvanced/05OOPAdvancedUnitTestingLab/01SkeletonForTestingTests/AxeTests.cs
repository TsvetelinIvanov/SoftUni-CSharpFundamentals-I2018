using System;
using NUnit.Framework;

namespace _01SkeletonForTestingTests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperiance = 10;

        private Axe axe;
        private Dummy dummy;
        
        [SetUp]
        public void TestInitialization()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperiance);            
        }

        [Test]       
        public void AxeLoosesDurabilityAfterAttack()
        {            
            this.axe.Attack(this.dummy);

            //Assert.AreEqual(0, this.axe.DurabilityPoints, "Durability doesn't change after atack");
            Assert.That(axe.DurabilityPoints, Is.EqualTo(0), "Axe durability dosen't change after attack.");
        }

        [Test]
        public void BrokenAxeCannotAttackAndThrowsException()
        {
            //Axe axe = new Axe(1, 1);
            //Dummy dummy = new Dummy(10, 10);
            this.axe.Attack(this.dummy);

            //InvalidOperationException invalidOperationException = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
            //Assert.That(invalidOperationException.Message, Is.EqualTo("Axe is broken."));
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));            
        }
    }
}
