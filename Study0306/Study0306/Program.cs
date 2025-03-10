using System;
using System.Collections.Generic;

namespace TEXTRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            MainGame mainGame = new MainGame();
            mainGame.Initialize();
            mainGame.Progress();
        }
    }

    // 기본 캐릭터 클래스 (플레이어, 몬스터가 상속받을 수 있음)
    public class Character
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }

        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
        }

        public virtual void Render()
        {
            Console.WriteLine($"{Name} - HP: {Hp}, Attack: {Attack}");
        }
    }

    // 플레이어 클래스
    public class Player : Character
    {
        public Player(string name, int hp, int attack)
        {
            Name = name;
            Hp = hp;
            Attack = attack;
        }
    }

    // 몬스터 클래스 (Character 상속)
    public class Monster : Character
    {
        public Monster(string name, int hp, int attack)
        {
            Name = name;
            Hp = hp;
            Attack = attack;
        }
    }

    // 필드 클래스
    public class Field
    {
        protected Player m_pPlayer;
        protected Monster m_pMonster;

        public void SetPlayer(ref Player player)
        {
            m_pPlayer = player;
        }

        public virtual void Progress()
        {
            Console.Clear();
            m_pPlayer.Render();
            DrawMap();
        }

        public virtual void DrawMap()
        {
            Console.WriteLine("1. 초보맵");
            Console.WriteLine("2. 중수맵");
            Console.WriteLine("3. 고수맵");
            Console.WriteLine("4. 전단계");
            Console.Write("맵을 선택하세요: ");
        }
    }

    // 메인 게임 클래스
    public class MainGame

    {
        private Player player;
        private Field field;

        public void Initialize()
        {
            player = new Player("모험가", 100, 10);
            field = new Field();
            field.SetPlayer(ref player);
        }

        public void Progress()
        {
            field.Progress();
        }
    }
}
