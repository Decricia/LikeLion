using System;
using System.Diagnostics;
using System.Threading;

namespace ShootingGame1
{
    struct Player
    {
        public int X;
        public int Y;
        public string[] Shape;

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Shape = new string[]
            {
                "->",
                "■■>",
                "->"
            };
        }
    }

    class Game
    {
        private Player player;
        private Stopwatch stopwatch;
        private long prevTime;

        public Game()
        {
            player = new Player(0, 12);
            stopwatch = new Stopwatch();
            prevTime = 0;

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;
        }

        public void Run()
        {
            stopwatch.Start();

            while (true)
            {
                long currentTime = stopwatch.ElapsedMilliseconds;

                if (currentTime - prevTime >= 100)  // 0.1초마다 갱신
                {
                    Console.Clear();

                    if (!HandleInput())
                        break; // ESC 키 누르면 종료

                    DrawPlayer();
                    prevTime = currentTime; // 이전 시간 갱신
                }
            }
        }

        private bool HandleInput()
        {
            if (!Console.KeyAvailable)
                return true;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (player.Y > 0) player.Y--; break;
                case ConsoleKey.DownArrow: if (player.Y < Console.WindowHeight - 3) player.Y++; break;
                case ConsoleKey.LeftArrow: if (player.X > 0) player.X--; break;
                case ConsoleKey.RightArrow: if (player.X < Console.WindowWidth - 3) player.X++; break;
                case ConsoleKey.Spacebar: Console.Write("미사일키"); break;
                case ConsoleKey.Escape: return false; // ESC 키 입력 시 게임 종료
            }

            return true;
        }

        private void DrawPlayer()
        {
            for (int i = 0; i < player.Shape.Length; i++)
            {
                Console.SetCursorPosition(player.X, player.Y + i);
                Console.WriteLine(player.Shape[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}
