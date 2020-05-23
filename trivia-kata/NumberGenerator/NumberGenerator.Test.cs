using Xunit;

namespace trivia_kata.NumberGenerator
{
    public class NumberGeneratorTest
    {
        [Fact]
        public void Should_Give_Number()
        {
            var generator = new NumberGenerator(new [] {3, 2, 4, 7});
            
            Assert.Equal(3, generator.Next(5));
            Assert.Equal(2, generator.Next(5));
            Assert.Equal(4, generator.Next(5));
            Assert.Equal(1, generator.Next(3));
        }
    }
}