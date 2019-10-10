namespace Tictactoe
{
    public class Player
    {
        private static int _count = 0;
        public string Name { get; }
        public string Token { get; }
        public int Wins { get; set; }

        public Player(string name = null) {
            _count++;
            Name = name != null ? name : $"Player {_count}";
            Token = Board.Tokens[_count];
            Wins = 0;
        }

        public override string ToString() {
            return Name;
        }
    }
}