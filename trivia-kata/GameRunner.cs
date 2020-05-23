using trivia_kata.NumberGenerator;
using trivia_kata.TextWriter;
using Console = trivia_kata.TextWriter.Console;
using Random = trivia_kata.NumberGenerator.Random;

namespace trivia_kata
{
    public static class GameRunner
    {
        private static bool _notAWinner;

        public static void Run(ITextWriter textWriter, INumberGenerator numberGenerator)
        {
            var aGame = new Game(textWriter);

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            do
            {
                aGame.Roll(numberGenerator.Next(5) + 1);

                _notAWinner = numberGenerator.Next(9) == 7 ? aGame.WrongAnswer() : aGame.WasCorrectlyAnswered();
            } while (_notAWinner);
        }

        public static void Main()
        {
            Run(new Console(), new Random());
        }
    }
}