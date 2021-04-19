using _01SkeletonForTesting;

namespace _01SkeletonForTestingTests
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
        }
    }    
}
