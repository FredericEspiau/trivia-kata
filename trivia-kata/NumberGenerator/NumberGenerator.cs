namespace trivia_kata.NumberGenerator
{
    public class NumberGenerator: INumberGenerator
    {
        private int[] Values { get; }
        private int Index { get; set; }

        public NumberGenerator(int[] values)
        {
            Values = values;
        }
        public int Next(int max)
        {
            return Values[Index++] % max;

        }
    }
}