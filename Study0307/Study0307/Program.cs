using System;
using System.Collections.Generic;
using System.Threading;

namespace BrickGame
{
    class Program
    {
        static Ball ball = new Ball();
        static Bar bar = new Bar();
        static List<Block> blocks = new List<Block>();

        static void Main()
        {
            Console.CursorVisible = false;
            InitializeBlocks();
            ball.Initialize();
            bar.Initialize();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow) bar.Move(-1);
                    if (key.Key == ConsoleKey.RightArrow) bar.Move(1);
                }

                ball.Progress();
                ball.CheckCollision(blocks, bar);
                Render();
                Thread.Sleep(100);
            }
        }

        static void InitializeBlocks()
        {
            for (int y = 2; y < 6; y++)
            {
                for (int x = 5; x < 75; x += 6)
                {
                    blocks.Add(new Block(x, y));
                }
            }
        }

        static void Render()
        {
            Console.Clear();
            ball.Render();
            bar.Render();
            foreach (var block in blocks) block.Render();
        }
    }

    struct BALLDATA
    {
        public int nX, nY, nReady, nDirect;
    }

    class Ball
    {
        BALLDATA m_tBall = new BALLDATA { nX = 30, nY = 10, nReady = 0, nDirect = 1 };

        public void Initialize() => Console.CursorVisible = false;
        public void Progress() { /* 기존 코드 유지 */ }
        public void Render() { Console.SetCursorPosition(m_tBall.nX, m_tBall.nY); Console.Write("●"); }

        public void CheckCollision(List<Block> blocks, Bar bar)
        {
            foreach (var block in blocks)
            {
                if (m_tBall.nX == block.X && m_tBall.nY == block.Y)
                {
                    blocks.Remove(block);
                    m_tBall.nDirect = (m_tBall.nDirect + 3) % 6; // 방향 반전
                    break;
                }
            }
            if (m_tBall.nY == 20 && m_tBall.nX >= bar.X && m_tBall.nX < bar.X + 7)
            {
                m_tBall.nDirect = (m_tBall.nDirect + 3) % 6;
            }
        }
    }

    class Bar
    {
        public int X { get; private set; } = 35;
        public void Initialize() { }
        public void Move(int direction) => X = Clamp(X + direction * 2, 1, 72);
        public void Render() { Console.SetCursorPosition(X, 20); Console.Write("═══════"); }

        private int Clamp(int value, int min, int max)
        {
            return value < min ? min : (value > max ? max : value);
        }
    }

    class Block
    {
        public int X { get; }
        public int Y { get; }
        public Block(int x, int y) { X = x; Y = y; }
        public void Render() { Console.SetCursorPosition(X, Y); Console.Write("■"); }
    }
}
