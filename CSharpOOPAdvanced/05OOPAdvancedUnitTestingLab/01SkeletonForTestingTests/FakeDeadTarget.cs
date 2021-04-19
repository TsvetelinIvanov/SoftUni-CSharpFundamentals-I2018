using _01SkeletonForTesting;

namespace _01SkeletonForTestingTests
{
    public class FakeDeadTarget : ITarget
    {
        public int Health => 0;

        public int GiveExperience() => 20;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {

        }
    }    
}