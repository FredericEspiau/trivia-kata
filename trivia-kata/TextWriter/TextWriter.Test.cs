using Xunit;

namespace trivia_kata.TextWriter
{
    public class TextWriterTest
    {
        [Fact]
        public void Should_Add_Text()
        {
            var textWriter = new TextWriter();
            textWriter.WriteLine("line to add");

            Assert.Equal("line to add", textWriter.Text);
        }

        [Fact]
        public void Should_Add_Text_More_Than_One_Line()
        {
            var textWriter = new TextWriter();
            textWriter.WriteLine("first line");
            textWriter.WriteLine("second line");

            Assert.Equal("first line\nsecond line", textWriter.Text);
        }

        [Fact]
        public void Should_Have_Empty_Text()
        {
            var textWriter = new TextWriter();

            Assert.Equal(string.Empty, textWriter.Text);
        }
    }
}