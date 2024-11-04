namespace _04BubbleSortTest
{
    public class Bubble
    {
        public void Sort(int[] numbers)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;

                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] < numbers[i - 1])
                    {
                        int number = numbers[i - 1];
                        numbers[i - 1] = numbers[i];
                        numbers[i] = number;
                        swapped = true;
                    }
                }
            }
        }
    }
}
