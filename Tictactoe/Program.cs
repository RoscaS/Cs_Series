namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args) {
            Player pa = new Player();
            Player pb = new Player();
            Game game = new Game(pa, pb);
            game.Start();
        }
    }
}