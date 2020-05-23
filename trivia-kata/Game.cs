using System.Collections.Generic;
using System.Linq;
using trivia_kata.TextWriter;

namespace trivia_kata
{
    public class Game
    {
        private readonly bool[] _inPenaltyBox = new bool[6];

        private readonly int[] _places = new int[6];
        private readonly List<string> _players = new List<string>();

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly int[] _purses = new int[6];
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();

        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;

        public Game(ITextWriter textWriter)
        {
            TextWriter = textWriter;

            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast("Science Question " + i);
                _sportsQuestions.AddLast("Sports Question " + i);
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        private ITextWriter TextWriter { get; }

        private static string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void Add(string playerName)
        {
            _players.Add(playerName);
            _places[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            TextWriter.WriteLine(playerName + " was added");
            TextWriter.WriteLine("They are player number " + _players.Count);
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            TextWriter.WriteLine(_players[_currentPlayer] + " is the current player");
            TextWriter.WriteLine("They have rolled a " + roll);

            if (_inPenaltyBox[_currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    TextWriter.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    _places[_currentPlayer] = _places[_currentPlayer] + roll;
                    if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                    TextWriter.WriteLine(_players[_currentPlayer]
                                         + "'s new location is "
                                         + _places[_currentPlayer]);
                    TextWriter.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    TextWriter.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                _places[_currentPlayer] = _places[_currentPlayer] + roll;
                if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                TextWriter.WriteLine(_players[_currentPlayer]
                                     + "'s new location is "
                                     + _places[_currentPlayer]);
                TextWriter.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                TextWriter.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }

            if (CurrentCategory() == "Science")
            {
                TextWriter.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }

            if (CurrentCategory() == "Sports")
            {
                TextWriter.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }

            if (CurrentCategory() != "Rock") return;

            TextWriter.WriteLine(_rockQuestions.First());
            _rockQuestions.RemoveFirst();
        }

        private string CurrentCategory()
        {
            switch (_places[_currentPlayer])
            {
                case 0:
                case 4:
                case 8:
                    return "Pop";
                case 1:
                case 5:
                case 9:
                    return "Science";
                case 2:
                case 6:
                case 10:
                    return "Sports";
                default:
                    return "Rock";
            }
        }

        public bool WasCorrectlyAnswered()
        {
            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    TextWriter.WriteLine("Answer was correct!!!!");
                    _purses[_currentPlayer]++;
                    TextWriter.WriteLine(_players[_currentPlayer]
                                         + " now has "
                                         + _purses[_currentPlayer]
                                         + " Gold Coins.");

                    var winner = DidPlayerWin();
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;

                    return winner;
                }

                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;
                return true;
            }

            {
                TextWriter.WriteLine("Answer was correct!!!!");
                _purses[_currentPlayer]++;
                TextWriter.WriteLine(_players[_currentPlayer]
                                     + " now has "
                                     + _purses[_currentPlayer]
                                     + " Gold Coins.");

                var winner = DidPlayerWin();

                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
        }

        public bool WrongAnswer()
        {
            TextWriter.WriteLine("Question was incorrectly answered");
            TextWriter.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;

            return true;
        }


        private bool DidPlayerWin()
        {
            return _purses[_currentPlayer] != 6;
        }
    }
}