namespace HashingString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "lorem ipsum dolor";
            int[] scrummedValues = GetScrummedValues(text);

            Console.WriteLine("Scrummed Values:");
            foreach (int value in scrummedValues)
            {
                Console.WriteLine(value);
            }

            int sum = SumScrummedValues(scrummedValues);
            Console.WriteLine("Sum of Scrummed Values: " + sum);
        }

        static int[] GetScrummedValues(string text)
        {
            List<int> scrummedValues = new List<int>();

            for (int i = 0; i < text.Length; i += 4)
            {
                string word = text.Substring(i, Math.Min(4, text.Length - i));
                scrummedValues.Add(GetScrummedValue(word));
            }

            return scrummedValues.ToArray();
        }

        static int GetScrummedValue(string text)
        {
            if (text.Length > 4)
            {
                throw new ArgumentException("Text length must be at most 4 characters.");
            }

            int scrummedValue = 0;

            for (int i = 0; i < text.Length; i++)
            {
                scrummedValue |= (text[i] << (i * 8));
            }

            return scrummedValue;
        }

        static int SumScrummedValues(int[] values)
        {
            int sum = 0;

            foreach (int value in values)
            {
                sum = unchecked(sum + value);
            }

            return sum;
        }
    }
}