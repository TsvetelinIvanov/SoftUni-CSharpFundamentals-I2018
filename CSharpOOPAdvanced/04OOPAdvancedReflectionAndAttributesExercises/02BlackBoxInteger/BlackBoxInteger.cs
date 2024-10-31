namespace _02BlackBoxInteger
{
    public class BlackBoxInteger
    {
        private static int DefaultValue = 0;

        private int innerValue;

        private BlackBoxInteger(int innerValue)
        {
            this.innerValue = innerValue;
        }

        private BlackBoxInteger()
        {
            this.innerValue = DefaultValue;
        }

        private void Add(int added)
        {
            this.innerValue += added;
        }

        private void Subtract(int subtracted)
        {
            this.innerValue -= subtracted;
        }

        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }

        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }

        private void LeftShift(int shifter)
        {
            this.innerValue <<= shifter;
        }

        private void RightShift(int shifter)
        {
            this.innerValue >>= shifter;
        }
    }
}
