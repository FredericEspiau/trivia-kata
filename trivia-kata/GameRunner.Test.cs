using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace trivia_kata
{
    [UseReporter(typeof(RiderReporter))]
    public class GameRunnerTest
    {
        [Fact]
        public void Should_Execute_Tests()
        {
            var textWriter = new TextWriter.TextWriter();
            GameRunner.Run(textWriter,
                new NumberGenerator.NumberGenerator(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}));
            
            Approvals.Verify(textWriter.Text);
        }
    }
}