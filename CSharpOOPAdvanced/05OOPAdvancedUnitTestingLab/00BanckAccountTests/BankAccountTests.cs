using NUnit.Framework;

namespace BanckAccountTests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            BankAccount account = new BankAccount(2000m);
            Assert.That(account.Amount, Is.EqualTo(2000m));
        }
    }
}