using System.Collections.Generic;
using System.Linq;

namespace Tictactoe
{
    /// <summary>
    /// Simple Board used by <c>Game</c> class.
    /// </summary>
    class Board
    {
        protected Player PlayerA { get; }
        protected Player PlayerB { get; }
        protected List<int> Grid { get; private set; }
        public static List<string> Tokens;

        static Board() {
            Tokens = new List<string> {" ", "o", "x"};
        }

        protected Board(Player a, Player b) {
            Grid = new List<int>(new int[9].ToArray());
            PlayerA = a;
            PlayerB = b;
        }

        public int this[int idx] {
            get => Grid[idx];
            set => Grid[idx] = value;
        }

        /// <summary>
        /// Reset the values of <c>Grid</c> and <c>Tokens</c>
        /// </summary>
        protected virtual void Reset() {
            Grid = new List<int>(new int[9].ToArray());
            Tokens = new List<string> {" ", "o", "x"};
        }

        public override string ToString() {
            string T(int x) => Tokens[x];
            const string pad = "\t\t   ";
            const string separator = "\n\t\t  ---+---+---\n";
            return $"{pad}{T(this[0])} | {T(this[1])} | {T(this[2])}{separator}" +
                   $"{pad}{T(this[3])} | {T(this[4])} | {T(this[5])}{separator}" +
                   $"{pad}{T(this[6])} | {T(this[7])} | {T(this[8])}\n";
        }
    }
}