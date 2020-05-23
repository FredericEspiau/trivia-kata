namespace trivia_kata.TextWriter
{
    public class TextWriter : ITextWriter
    {
        public TextWriter()
        {
            Text = string.Empty;
        }

        public string Text { get; private set; }

        public void WriteLine(string lineToAdd)
        {
            Text += string.IsNullOrEmpty(Text) ? lineToAdd : '\n' + lineToAdd;
        }
    }
}