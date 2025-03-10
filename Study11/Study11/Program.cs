using System;
using System.Collections.Generic;

public class Enemy
{
    public int enemyX;
    public int enemyY;

    public Enemy()
    {
        enemyX = 77;
        enemyY = 12;
    }

    public virtual void EnemyDraw()
    {
        string enemy = "<-0->";
        Console.SetCursorPosition(enemyX, enemyY);
        Console.Write(enemy);
    }

    public virtual void EnmeyMove()
    {
        Random rand = new Random();
        enemyX--;

        if (enemyX < 2)
        {
            enemyX = 75;
            enemyY = rand.Next(2, 22);
        }
    }

    public virtual int GetScore()
    {
        return 100;  // 기본 적의 점수
    }

    public virtual bool CheckCollision(int bulletX, int bulletY)
    {
        // 기본적인 충돌 처리 (미사일의 위치와 적의 위치 비교)
        return (bulletX >= enemyX - 2 && bulletX <= enemyX + 2) && (bulletY == enemyY);
    }
}

public class Enemy2 : Enemy  // 새로운 적 2
{
    public Enemy2() : base()
    {
        enemyX = 77;
        enemyY = new Random().Next(2, 22);
    }

    public override void EnmeyMove()
    {
        Random rand = new Random();
        enemyX -= 2;  // 속도 더 빠르게

        if (enemyX < 2)
        {
            enemyX = 75;
            enemyY = rand.Next(2, 22);
        }
    }

    public override void EnemyDraw()
    {
        string enemy = "<-o->";  // 새로운 적의 모양
        Console.SetCursorPosition(enemyX, enemyY);
        Console.Write(enemy);
    }

    public override int GetScore()
    {
        return 200;  // 새로운 적의 점수
    }

    public override bool CheckCollision(int bulletX, int bulletY)
    {
        return (bulletX >= enemyX - 2 && bulletX <= enemyX + 2) && (bulletY == enemyY);
    }
}

public class Enemy3 : Enemy  // 새로운 적 3
{
    public Enemy3() : base()
    {
        enemyX = 77;
        enemyY = new Random().Next(2, 22);
    }

    public override void EnmeyMove()
    {
        Random rand = new Random();
        enemyX -= 3;  // 가장 빠른 속도

        if (enemyX < 2)
        {
            enemyX = 75;
            enemyY = rand.Next(2, 22);
        }
    }

    public override void EnemyDraw()
    {
        string enemy = "<-0-0->";  // 또 다른 새로운 적의 모양
        Console.SetCursorPosition(enemyX, enemyY);
        Console.Write(enemy);
    }

    public override int GetScore()
    {
        return 300;  // 가장 높은 점수
    }

    public override bool CheckCollision(int bulletX, int bulletY)
    {
        return (bulletX >= enemyX - 3 && bulletX <= enemyX + 3) && (bulletY == enemyY);
    }
}

public class Bullet
{
    public int x, y;
    public bool fire;

    public Bullet()
    {
        fire = false;
    }
}

public class Player
{
    public int playerX = 10;
    public int playerY = 12;
    public int score = 0;
    public int itemCount = 0;
    public Bullet[] playerBullet = new Bullet[20]; // 미사일 최대 20개

    public Player()
    {
        for (int i = 0; i < 20; i++)
        {
            playerBullet[i] = new Bullet();
        }
    }

    public void GameMain()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow && playerX > 1) playerX--;
            if (key == ConsoleKey.RightArrow && playerX < 78) playerX++;
            if (key == ConsoleKey.UpArrow && playerY > 1) playerY--;
            if (key == ConsoleKey.DownArrow && playerY < 22) playerY++;
            if (key == ConsoleKey.Spacebar) Fire();
        }

        // 플레이어 그리기 (화살표 모양으로 되돌리기)
        string playerIcon = ">";
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(playerIcon);
    }

    public void Fire()
    {
        for (int i = 0; i < 20; i++)
        {
            if (!playerBullet[i].fire)
            {
                playerBullet[i].fire = true;
                playerBullet[i].x = playerX + 1;  // 플레이어 옆에서 발사
                playerBullet[i].y = playerY;
                break;
            }
        }
    }

    public void BulletDraw()
    {
        for (int i = 0; i < 20; i++)
        {
            if (playerBullet[i].fire)
            {
                Console.SetCursorPosition(playerBullet[i].x, playerBullet[i].y);
                Console.Write("-");  // '-'로 미사일 표시

                // 미사일 이동
                playerBullet[i].x++;  // 오른쪽으로 이동
                if (playerBullet[i].x >= 78)  // 화면 밖으로 나가면 미사일 비활성화
                {
                    playerBullet[i].fire = false;
                }
            }
        }
    }

    public void ClashEnemyAndBullet(List<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            //미사일과 적 충돌 처리
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet[i].fire)
                {
                    if (enemy.CheckCollision(playerBullet[i].x, playerBullet[i].y))
                    {
                        // 미사일을 막고 적을 처치
                        playerBullet[i].fire = false;

                        // 적이 처치되면 점수 추가
                        score += enemy.GetScore();  // 각 적의 점수를 가져와서 더함

                        // 적 재위치
                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);

        Player player = new Player();
        List<Enemy> enemies = new List<Enemy>
        {
            new Enemy(),   // 기본 적
            new Enemy2(),  // 새로운 적2
            new Enemy3()   // 새로운 적3
        };

        int dwTime = Environment.TickCount;

        while (true)
        {
            if (dwTime + 50 < Environment.TickCount)
            {
                dwTime = Environment.TickCount;
                Console.Clear();

                player.GameMain();

                // 플레이어의 미사일 그리기
                if (player.itemCount == 0)
                {
                    player.BulletDraw();
                }
                else if (player.itemCount == 1)
                {
                    player.BulletDraw();
                    player.BulletDraw();  // 이 부분은 적절히 미사일을 여러 개 발사하는 로직으로 변경 가능
                }
                else
                {
                    player.BulletDraw();
                    player.BulletDraw();
                }

                // 적 그리기 및 이동
                foreach (var enemy in enemies)
                {
                    enemy.EnmeyMove();
                    enemy.EnemyDraw();
                }

                // 적과 미사일 충돌 체크 및 점수 업데이트
                player.ClashEnemyAndBullet(enemies);

                // 점수 출력
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Score: " + player.score);
            }
        }
    }
}
