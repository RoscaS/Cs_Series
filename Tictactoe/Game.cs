using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tictactoe
{
    /// <summary>
    /// A simple Tic Tac Toe game made for the .NET classe
    /// By Sol Rosca INF3b (2019).
    /// </summary>
    class Game : Board, IEndable
    {
        private const string Draw = "Draw situation!";
        private const string Input1 = "what's your move [1, 9]?: ";
        private const string Input2 = "Invalid input, Try again [1, 9]: ";
        private const string Replay = "Press [y] to play again, anything else to exit.";
        private const string Victory = "just won this game!";


        private int _round;
        private Player _playing;
        private static readonly List<List<int>> Win;

        static Game() {
            Win = new List<List<int>> {
                new List<int> {0, 1, 2}, new List<int> {3, 4, 5}, new List<int> {6, 7, 8},
                new List<int> {0, 3, 6}, new List<int> {1, 4, 7}, new List<int> {2, 5, 8},
                new List<int> {0, 4, 8}, new List<int> {2, 4, 6}
            };
        }

        public Game(Player a, Player b) : base(a, b) {
            _playing = PlayerA;
            _round = 0;
        }

        /// <summary>
        /// Call for a user input and update game data according to it.
        /// </summary>
        private void Update() {
            Display();
            int input = UserInput();
            Grid[input - 1] = Tokens.IndexOf(_playing.Token);
            _playing = _playing.Equals(PlayerA) ? PlayerB : PlayerA;
            _round++;
        }

        /// <summary>
        /// Prompt playing player for an input.
        /// </summary>
        /// <returns>int</returns>
        private int UserInput() {
            Console.Write($"{PlayerA} {Input1}");
            string input = Console.ReadLine();

            while (!IsValidInput(input)) {
                Console.Write(Input2);
                input = Console.ReadLine();
            }

            return int.Parse(input);
        }

        /// <summary>
        /// Test if <c>input</c> is a valid value. 
        /// </summary>
        /// <param name="input">user input</param>
        /// <returns>bool</returns>
        private bool IsValidInput(string input) {
            int index;
            try {
                index = int.Parse(input);
            }
            catch (Exception e) {
                return false;
            }

            return Enumerable.Range(1, 10).Contains(index) && Grid[index - 1] == 0;
        }

        /// <summary>
        /// Start a new game.
        /// </summary>
        public void Start() {
            Player winner = null;
            while (winner == null) {
                if (_round == 9) break;
                Update();
                if (_round >= 2) winner = IsWinner();
            }

            EndRound(winner);
        }

        /// <summary>
        /// Check if there is a winner.
        /// </summary>
        /// <returns>Player</returns>
        public Player IsWinner() {
            foreach (var winCase in Win) {
                if (Grid[winCase[0]] != 0) {
                    if (Grid[winCase[0]] == Grid[winCase[1]]) {
                        if (Grid[winCase[0]] == Grid[winCase[2]]) {
                            return Grid[winCase[0]] == 1 ? PlayerA : PlayerB;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Called after a winner is found or in a draw situation.
        /// </summary>
        /// <param name="winner">Player</param>
        private void EndRound(Player winner) {
            if (winner != null) {
                winner.Wins++;
                string token = Tokens[Tokens.IndexOf(winner.Token)];
                Tokens[Tokens.IndexOf(winner.Token)] = token.ToUpper();
                Display();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{winner} {Victory}");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{Draw}");
            }

            Console.ResetColor();
            Rematch();
        }

        /// <summary>
        /// Prompt user for a rematch.
        /// </summary>
        private void Rematch() {
            Thread.Sleep(1000);
            Console.WriteLine(Replay);
            string input = Console.ReadLine();
            if (input == "y") Reset();
            else Environment.Exit(1);
        }

        /// <summary>
        /// Reset the Board and start a new Game.
        /// </summary>
        protected override void Reset() {
            base.Reset();
            _round = 0;
            _playing = PlayerA;
            Start();
        }

        /// <summary>
        /// Pretty print of the game situation.
        /// </summary>
        public void Display() {
            Console.Clear();
            string Tabs(int x) => new String(Convert.ToChar("\t"), x);
            string FormatPlayer(Player p) => $"{p.Wins} {p} ( {p.Token} )";
            string names = $"\n{FormatPlayer(PlayerA)}{Tabs(2)}{FormatPlayer(PlayerB)}";
            string spacer = _playing.Equals(PlayerA) ? "" : $"{Tabs(4)}";
            string underline = $"{spacer}{new String(Convert.ToChar("-"), PlayerA.Name.Length + 8)}";
            Console.WriteLine($"\n{names}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{underline}");
            Console.ResetColor();
            Console.WriteLine(base.ToString());
        }
    }
}