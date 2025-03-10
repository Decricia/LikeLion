using System;
using System.Collections.Generic;

namespace LeagueOfLegends
{
    // 기본 유닛 클래스
    class Champion
    {
        public string Name;
        protected int Health;

        public Champion()
        {
            Name = "Unknown";
            Health = 0;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name}이(가) 기본 공격을 합니다.");
        }

        public virtual void Skill()
        {
            Console.WriteLine($"{Name}이(가) 스킬을 사용합니다.");
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Name}이(가) 이동합니다.");
        }
    }

    // 마법사형 챔피언 (사일러스)
    class 사일러스 : Champion
    {
        public 사일러스()
        {
            Name = "사일러스";
            Health = 600;
        }

        public override void Attack()
        {
            Console.WriteLine("사일러스가 사슬로 기본 공격을 합니다.");
        }

        public override void Skill()
        {
            Console.WriteLine("사일러스가 적의 궁극기를 훔칩니다!");
        }
    }

    // 암살자형 챔피언 (아리)
    class 아리 : Champion
    {
        public 아리()
        {
            Name = "아리";
            Health = 500;
        }

        public override void Attack()
        {
            Console.WriteLine("아리가 구슬로 기본 공격을 합니다.");
        }

        public override void Skill()
        {
            Console.WriteLine("아리가 매혹 스킬을 사용하여 적을 홀립니다.");
        }
    }

    // 원거리 딜러 (진)
    class 진 : Champion
    {
        public 진()
        {
            Name = "진";
            Health = 550;
        }

        public override void Attack()
        {
            Console.WriteLine("진이 저격총으로 기본 공격을 합니다.");
        }

        public override void Skill()
        {
            Console.WriteLine("진이 4번째 총알을 장전하여 강력한 일격을 가합니다!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Champion> champions = new List<Champion>();

            champions.Add(new 사일러스());
            champions.Add(new 아리());
            champions.Add(new 진());

            foreach (var champion in champions)
            {
                champion.Move();
                champion.Attack();
                champion.Skill();
                Console.WriteLine();
            }
        }
    }
}
