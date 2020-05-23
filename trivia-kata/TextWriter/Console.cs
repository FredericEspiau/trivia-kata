namespace trivia_kata.TextWriter
{
    public class Console : ITextWriter
    {
        public void WriteLine(string lineToAdd)
        {
            System.Console.WriteLine(lineToAdd);
        }
    }
}