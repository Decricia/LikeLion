using System;

class Program
{
    static int day = 1;
    static int dungeonFloor = 1;
    static int accuracy = 70;
    static int attackPower = 30; // 기본 공격력
    static int maxHp = 200; // 최대 HP
    static int hp = maxHp; // 현재 HP
    static int gold = 10000;
    static int experience = 0;
    static int level = 1; // 플레이어 레벨
    static string equippedBow = "단궁";
    static Random random = new Random();

    static bool isSleep = false; // 적이 수면 상태에 있는지 확인
    static bool isFrozen = false; // 적이 얼음 상태에 있는지 확인


    static string[] enemies = { "오크", "고블린", "슬라임", "늑대인간", "해골" };
    static int monsterCount = 1;

    static void Main()
    {
        while (day <= 14)
        {
            Console.Clear();
            DisplayStatus();
            DisplayMenu();
            HandleInput();
        }
    }

    static void DisplayStatus()
    {
        Console.WriteLine($"DAY {day} | 던전 층: {dungeonFloor}");
        Console.WriteLine($"레벨: {level} | HP: {hp}/{maxHp} | 정확도: {accuracy}% | 공격력: {attackPower} | 금화: {gold} | 경험치: {experience}");
        Console.WriteLine($"장착된 무기: {equippedBow}\n");
    }

    static void DisplayMenu()
    {
        if (day == 13)
        {
            // 13일에는 탐험 외에 휴식과 상점만 가능
            Console.WriteLine("1. 휴식 (HP 회복)");
            Console.WriteLine("2. 상점");
            Console.Write("행동을 선택하세요: ");
        }
        else if (day == 14)
        {
            // 14일에는 보스 몬스터 등장
            Console.WriteLine("1. 보스와 전투");
            Console.Write("행동을 선택하세요: ");
        }
        else
        {
            Console.WriteLine("1. 탐험");
            Console.WriteLine("2. 휴식 (HP 회복)");
            Console.WriteLine("3. 무기 변경");
            Console.WriteLine("4. 상점");
            Console.Write("행동을 선택하세요: ");
        }
    }

    static void HandleInput()
    {

        string choice = Console.ReadLine();
        if (day == 13)
        {
            if (choice == "1")
            {
                Rest();
            }
            else if (choice == "2")
            {
                VisitShop();
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. Enter를 눌러 계속 진행하세요.");
                Console.ReadLine();
            }
        }
        else if (day == 14)
        {
            if (choice == "1")
            {
                Battle("사자왕 아서");
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. Enter를 눌러 계속 진행하세요.");
                Console.ReadLine();
            }
        }
        else
        {
            if (choice == "1")
            {
                Explore();
            }
            else if (choice == "2")
            {
                Rest();
            }
            else if (choice == "3")
            {
                ChangeWeapon();
            }
            else if (choice == "4")
            {
                VisitShop();
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. Enter를 눌러 계속 진행하세요.");
                Console.ReadLine();
            }
        }
    }

    static void Explore()
    {
        Console.WriteLine("던전을 탐험합니다...");
        dungeonFloor++;
        day++;
        Battle(); // 전투 시작
    }

    static void Rest()
    {
        Console.WriteLine("휴식을 취하고 HP를 회복합니다.");
        hp = Math.Min(maxHp, hp + 30);
        day++;
        Console.ReadLine();
    }

    static void ChangeWeapon()
    {
        if (equippedBow == "단궁")
        {
            equippedBow = "장궁";
            accuracy += 5;
            attackPower += 15; // 장궁을 착용하면 공격력 15 증가
        }
        else
        {
            equippedBow = "단궁";
            accuracy -= 5;
            attackPower -= 10;
        }
        Console.WriteLine($"무기를 {equippedBow}로 변경했습니다.");
        Console.ReadLine();
    }

    static void VisitShop()
    {
        Console.WriteLine("상점에 오신 것을 환영합니다!");
        Console.WriteLine("1. 독 화살 (1000원)");
        Console.WriteLine("2. 전기 화살 (1000원)");
        Console.WriteLine("3. 수면 화살 (1000원)");
        Console.WriteLine("4. 얼음 화살 (1000원)");
        Console.WriteLine("5. 불 화살 (1000원)");
        Console.WriteLine("6. 공격력 증가 포션 (2000원) - 공격력 +5");
        Console.WriteLine("7. HP 증가 포션 (2000원) - HP +30");
        Console.WriteLine("8. 정확도 증가 포션 (2000원) - 정확도 +2");
        Console.WriteLine("9. 나가기");
        Console.Write("구매할 아이템을 선택하세요: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                BuyArrow("독 화살");
                break;
            case "2":
                BuyArrow("전기 화살");
                break;
            case "3":
                BuyArrow("수면 화살");
                break;
            case "4":
                BuyArrow("얼음 화살");
                break;
            case "5":
                BuyArrow("불 화살");
                break;
            case "6":
                BuyStatPotion("공격력 증가 포션", 2000, "attackPower", 5);
                break;
            case "7":
                BuyStatPotion("HP 증가 포션", 2000, "hp", 30);
                break;
            case "8":
                BuyStatPotion("정확도 증가 포션", 2000, "accuracy", 2);
                break;
            case "9":
                Console.WriteLine("상점을 나갑니다.");
                break;
            default:
                Console.WriteLine("잘못된 선택입니다.");
                break;
        }
        Console.ReadLine();
    }

    static void BuyStatPotion(string potionName, int price, string statName, int statValue)
    {
        if (gold >= price)
        {
            gold -= price;
            Console.WriteLine($"{potionName}을(를) 구매했습니다!");

            // 스탯 증가
            if (statName == "attackPower")
            {
                attackPower += statValue;
                Console.WriteLine($"공격력이 {statValue}만큼 증가했습니다. 현재 공격력: {attackPower}");
            }
            else if (statName == "hp")
            {
                hp += statValue;
                Console.WriteLine($"HP가 {statValue}만큼 증가했습니다. 현재 HP: {hp}");
            }
            else if (statName == "accuracy")
            {
                accuracy += statValue;
                Console.WriteLine($"정확도가 {statValue}만큼 증가했습니다. 현재 정확도: {accuracy}");
            }
        }
        else
        {
            Console.WriteLine("금액이 부족하여 포션을 구매할 수 없습니다.");
        }
    }


    static void BuyArrow(string arrowName)
    {
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.WriteLine($"{arrowName}를 구매하셨습니다.");
        }
        else
        {
            Console.WriteLine("금액이 부족합니다.");
        }
    }

    static void BuyWeapon(string weaponName, int price, int attackBonus, int accuracyBonus)
    {
        if (gold >= price)
        {
            gold -= price;
            equippedBow = weaponName;
            attackPower += attackBonus;
            accuracy += accuracyBonus;
            Console.WriteLine($"{weaponName}를 구매하셨습니다.");
        }
        else
        {
            Console.WriteLine("금액이 부족합니다.");
        }
    }

    static void Battle(string enemyType = null)
    {
        string enemy = enemyType ?? enemies[random.Next(enemies.Length)];
        int enemyHP = 0;
        int enemyAttack = 0;
        int goldReward = 0;
        int expReward = 0;

        // 적 설정
        if (enemy == "사자왕 아서")
        {
            enemyHP = 500;
            enemyAttack = 50;
            goldReward = 1000;
            expReward = 50;
        }
        else
        {
            // 일반 몬스터 설정
            switch (enemy)
            {
                case "오크":
                    enemyHP = 200;
                    enemyAttack = 15;
                    goldReward = 300;
                    expReward = 20;
                    break;
                case "고블린":
                    enemyHP = 100;
                    enemyAttack = 5;
                    goldReward = 50;
                    expReward = 10;
                    break;
                case "슬라임":
                    enemyHP = 50;
                    enemyAttack = 10;
                    goldReward = 100;
                    expReward = 5;
                    break;
                case "늑대인간":
                    enemyHP = 200;
                    enemyAttack = 20;
                    goldReward = 200;
                    expReward = 20;
                    break;
                case "해골":
                    enemyHP = 150;
                    enemyAttack = 15;
                    goldReward = 150;
                    expReward = 15;
                    break;
            }
        }

        Console.WriteLine($"야생의 {enemy}이 나타났습니다! 적 HP: {enemyHP}");
        Console.ReadLine();

        while (enemyHP > 0 && hp > 0)
        {
            Console.WriteLine("1. 공격\n2. 화살 교체\n3. 도망");
            Console.Write("행동을 선택하세요: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // 상태 이상 해제 후 공격
                if (isSleep || isFrozen)
                {
                    // 상태 이상이 풀리고 나서 공격할 수 있게 처리
                    if (isSleep)
                    {
                        isSleep = false;
                        Console.WriteLine($"{enemy}의 수면 상태가 해제되었습니다.");
                    }

                    if (isFrozen)
                    {
                        isFrozen = false;
                        Console.WriteLine($"{enemy}의 얼음 상태가 해제되었습니다.");
                    }
                }

                // 무기별 공격 처리
                if (equippedBow == "단궁")
                {
                    // 단궁일 때 두 번 공격
                    for (int i = 1; i <= 2; i++)
                    {
                        if (random.Next(100) < accuracy)
                        {
                            enemyHP -= attackPower;
                            Console.WriteLine($"{enemy}에게 {i}번째 공격을 히트! 적 HP: {enemyHP}");
                        }
                        else
                        {
                            Console.WriteLine($"{i}번째 공격을 빗나갔습니다!");
                        }
                    }
                }
                else if (equippedBow == "장궁")
                {
                    // 롱보우일 때 한 번 공격
                    if (random.Next(100) < accuracy)
                    {
                        enemyHP -= attackPower;
                        Console.WriteLine($"{enemy}에게 장궁으로 공격을 히트! 적 HP: {enemyHP}");
                    }
                    else
                    {
                        Console.WriteLine("공격을 빗나갔습니다!");
                    }
                }
                else
                {
                    Console.WriteLine("장비된 활이 없습니다.");
                }
            }
            else if (choice == "2")
            {
                UseArrow(ref enemyAttack, ref enemyHP);
            }
            else if (choice == "3")
            {
                Console.WriteLine("안전하게 도망쳤습니다.");
                return;
            }

            if (enemyHP > 0)
            {
                // 적의 턴: 상태 이상에 걸린 경우 공격하지 않음
                if (isSleep || isFrozen)
                {
                    Console.WriteLine($"{enemy}은 상태 이상에 걸려 공격하지 못합니다.");
                }
                else
                {
                    hp -= enemyAttack;
                    Console.WriteLine($"{enemy}의 공격! 당신의 HP: {hp}");
                }
            }
        }

        if (hp > 0)
        {
            gold += goldReward;
            experience += expReward;
            Console.WriteLine($"당신은 {enemy}를 처치했습니다! {goldReward} 금화와 {expReward} 경험치를 획득했습니다.");
            LevelUp(); // 레벨업 체크
        }
        else
        {
            Console.WriteLine("당신은 패배했습니다...");
            day = 14; // 게임 종료 또는 적절한 종료 조건 설정
        }
        Console.ReadLine();
    }

    static void UseArrow(ref int enemyAttack, ref int enemyHP)
    {
        Console.WriteLine("사용할 화살을 선택하세요:");
        Console.WriteLine("1. 독 화살");
        Console.WriteLine("2. 전기 화살");
        Console.WriteLine("3. 수면 화살");
        Console.WriteLine("4. 얼음 화살");
        Console.WriteLine("5. 불 화살");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                UsePoisonArrow(ref enemyHP);
                break;
            case "2":
                UseElectricArrow(ref enemyAttack, ref enemyHP);
                break;
            case "3":
                UseSleepArrow();
                break;
            case "4":
                UseIceArrow(ref enemyHP);
                break;
            case "5":
                UseFireArrow(ref enemyHP);
                break;
            default:
                Console.WriteLine("잘못된 선택입니다.");
                break;
        }
    }

    static void UsePoisonArrow(ref int enemyHP)
    {
        // 독 화살 사용 시, 중첩된 독 피해
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.WriteLine("독 화살을 사용했습니다!");

            // 3번 사용하면 총 3회 중첩
            for (int i = 1; i <= 3; i++)
            {
                int poisonDamage = 10 * i; // 1회 중첩당 증가하는 피해
                enemyHP -= poisonDamage; // 적 HP 감소
                Console.WriteLine($"독 화살 {i}회 중첩! {poisonDamage}의 독 피해를 입혔습니다. 적 HP: {enemyHP}");
            }
        }
        else
        {
            Console.WriteLine("금액이 부족하여 독 화살을 사용할 수 없습니다.");
        }
    }


    static void UseElectricArrow(ref int enemyAttack, ref int enemyHP)
    {
        // 전기 화살 사용 시, 적에게 전기 속성 공격 +20, 적의 공격력 -5
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.WriteLine("전기 화살을 사용했습니다!");
            enemyAttack -= 5; // 적 공격력 감소
            Console.WriteLine("전기 공격! 적의 공격력이 5 감소했습니다.");

            int electricDamage = 20; // 전기 화살의 공격력
            enemyHP -= electricDamage; // 적 HP 감소
            Console.WriteLine($"전기 속성 공격! {electricDamage}의 전기 피해를 입혔습니다. 적 HP: {enemyHP}");
        }
        else
        {
            Console.WriteLine("금액이 부족하여 전기 화살을 사용할 수 없습니다.");
        }
    }

    static void UseSleepArrow()
    {
        // 수면 화살 사용 시, 적을 1턴 동안 잠재우기
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.WriteLine("수면 화살을 사용했습니다!");
            Console.WriteLine("적이 수면 상태에 빠졌습니다. 1턴 동안 공격할 수 없습니다.");

            // 수면 상태 활성화
            isSleep = true;
        }
        else
        {
            Console.WriteLine("금액이 부족하여 수면 화살을 사용할 수 없습니다.");
        }
    }

  
    static void UseIceArrow(ref int enemyHP)
    {
        // 얼음 화살 사용 시, 냉속성 공격력 +5, 적을 얼려서 공격 불가능 상태로 만들기
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.WriteLine("얼음 화살을 사용했습니다!");
            Console.WriteLine("냉속성 공격 +5!");

            int iceDamage = 5; // 얼음 화살의 공격력
            enemyHP -= iceDamage; // 적 HP 감소
            Console.WriteLine($"얼음 화살로 {iceDamage}의 피해를 입혔습니다. 적 HP: {enemyHP}");

            Console.WriteLine("적이 얼어붙어 공격할 수 없습니다.");

            // 얼음 상태 활성화
            isFrozen = true;
        }
        else
        {
            Console.WriteLine("금액이 부족하여 얼음 화살을 사용할 수 없습니다.");
        }
    }

    // 매 턴마다 적이 공격할 수 있는지 확인하는 메서드
    static void CheckEnemyStatus()
    {
        if (isSleep)
        {
            Console.WriteLine("적은 수면 상태입니다. 공격할 수 없습니다.");
            // 수면 상태가 끝난 후 처리
            isSleep = false; // 수면 상태 종료
        }

        if (isFrozen)
        {
            Console.WriteLine("적은 얼음 상태입니다. 공격할 수 없습니다.");
            // 얼음 상태가 끝난 후 처리
            isFrozen = false; // 얼음 상태 종료
        }
    }

    static void UseFireArrow(ref int enemyHP)
    {
        // 불 화살 사용 시, +50 화염속성 공격, 적이 불에 타게 함
        if (gold >= 1000)
        {
            gold -= 1000;
            Console.WriteLine("불 화살을 사용했습니다!");
            Console.WriteLine("화염속성 공격 +50!");

            int fireDamage = 50; // 불 화살의 공격력
            enemyHP -= fireDamage; // 적 HP 감소
            Console.WriteLine($"불 화살로 {fireDamage}의 피해를 입혔습니다. 적 HP: {enemyHP}");

            Console.WriteLine("적이 타오르며 추가적인 화염 피해를 입었습니다.");
            // 이후 연속 발사 시 화염속성 피해가 감소하는 부분도 처리
        }
        else
        {
            Console.WriteLine("금액이 부족하여 불 화살을 사용할 수 없습니다.");
        }
    }


    static void LevelUp()
    {
        if (experience >= 30 * level)
        {
            level++;
            accuracy += 2; // 레벨업 시 명중률 2% 증가
            maxHp += 20; // 최대 HP 20 증가
            hp = maxHp; // HP 회복
            Console.WriteLine($"레벨업! 새로운 레벨: {level}. 명중률 2% 증가, 최대 HP 20 증가.");
        }
    }
}
