namespace trivia_kata.NumberGenerator
{
    public class Random: INumberGenerator
    {
        private System.Random InsideRandom { get; }

        public Random()
        {
            InsideRandom = new System.Random();
        }
        public int Next(int max)
        {
            return InsideRandom.Next(max);
        }
    }
}