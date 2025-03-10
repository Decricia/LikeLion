using System;
using System.Threading;

class AdventureGame
{
    static Random rand = new Random();
    static int gold = 500;
    static int health = 100;
    static int power = 10;
    static int experience = 0;
    static int level = 1;
    static int accuracy = 60;
    static int days = 21;

    static void Main(string[] args)
    {
        Console.WriteLine("🎯 활과 모험의 세계에 오신 것을 환영합니다! 🏹");
        Thread.Sleep(1000);

        bool isAlive = true;
        while (isAlive && days > 0)
        {
            Console.Clear();
            Console.WriteLine($"현재 상태: 체력 {health} | 골드 {gold} | 공격력 {power} | 명중률 {accuracy}% | 경험치 {experience} | 레벨 {level} | 남은 날 {days}");
            Console.WriteLine("\n1. 탐험하기 🏕️");
            Console.WriteLine("2. 장비 뽑기 🎲 (1000골드)");
            Console.WriteLine("3. 휴식하기 💤 (체력 +20)");
            Console.WriteLine("4. 게임 종료");
            Console.Write("입력: ");

            int input;
            if (!int.TryParse(Console.ReadLine(), out input)) continue;

            if (input == 1)  // 탐험하기
            {
                Explore(ref isAlive);
                days--; // 하루 경과
            }
            else if (input == 2) // 장비 뽑기
            {
                DrawWeapon();
            }
            else if (input == 3) // 휴식하기
            {
                Console.WriteLine("휴식을 취합니다...(+20 체력)");
                health += 20;
                Thread.Sleep(1000);
                days--; // 하루 경과
            }
            else if (input == 4) // 게임 종료
            {
                Console.WriteLine("게임을 종료합니다.");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                Thread.Sleep(1000);
            }
        }
        Console.WriteLine("⏳ 21일이 지나 게임이 종료되었습니다!");
    }

    static void Explore(ref bool isAlive)
    {
        Console.Clear();
        Console.WriteLine("탐험을 떠납니다...");
        Thread.Sleep(1000);

        int monsterHealth = rand.Next(30, 51); // 몬스터 체력 30~50
        Console.WriteLine($"⚔️ 몬스터를 만났습니다! (체력: {monsterHealth})");

        while (monsterHealth > 0 && health > 0)
        {
            Console.WriteLine("공격을 시도합니다...");
            if (rand.Next(1, 101) <= accuracy) // 명중 여부 결정
            {
                Console.WriteLine("🎯 공격이 적중했습니다!");
                monsterHealth -= power;
                Console.WriteLine($"몬스터 체력: {monsterHealth}");
            }
            else
            {
                Console.WriteLine("❌ 공격이 빗나갔습니다!");
            }

            if (monsterHealth > 0)
            {
                int damage = rand.Next(3, 11); // 몬스터 반격 (3~10)
                Console.WriteLine($"몬스터의 반격! (체력 -{damage})");
                health -= damage;
            }

            if (health <= 0)
            {
                Console.WriteLine("💀 체력이 0이 되어 사망했습니다... 게임 오버!");
                isAlive = false;
                return;
            }
        }

        Console.WriteLine("🎉 몬스터를 물리쳤습니다!");
        experience += 40;
        Console.WriteLine($"+40 경험치 (총 경험치: {experience})");
        LevelUp();
        Thread.Sleep(1000);
    }

    static void LevelUp()
    {
        if (experience >= level * 100)
        {
            experience = 0;
            level++;
            accuracy += 2;
            Console.WriteLine($"🎉 레벨업! 현재 레벨: {level}, 명중률: {accuracy}%");
        }
    }

    static void DrawWeapon()
    {
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.Clear();
            Console.WriteLine("🎲 장비를 뽑습니다...");
            Thread.Sleep(1000);

            int rnd = rand.Next(1, 101); // 1~100 랜덤
            if (rnd == 1)
            {
                Console.WriteLine("SSS급 전설의 활 (명중률 +10%) 획득!");
                accuracy += 10;
            }
            else if (rnd <= 10)
            {
                Console.WriteLine("SS급 희귀한 활 (명중률 +7%) 획득!");
                accuracy += 7;
            }
            else if (rnd <= 30)
            {
                Console.WriteLine("S급 강철 활 (명중률 +5%) 획득!");
                accuracy += 5;
            }
            else
            {
                Console.WriteLine("낡은 활 (명중률 +2%) 획득!");
                accuracy += 2;
            }
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("골드가 부족합니다. (1000 골드 필요)");
            Thread.Sleep(1000);
        }
    }
}
