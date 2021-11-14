using System;

namespace Quantum.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
