using NUnit.Framework;
using System;

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
            Assert.That(axe.DurabilityPoints, Is.EqualTo(0), "Axe durability dosen't change after attack.");
            //Assert.AreEqual(0, this.axe.DurabilityPoints, "Durability doesn't change after atack");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            //Axe axe = new Axe(1, 1);
            //Dummy dummy = new Dummy(10, 10);
            this.axe.Attack(this.dummy);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
            InvalidOperationException invalidOperationException = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
            //Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}