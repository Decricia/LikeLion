using System;
using System.Collections.Generic;

namespace Inventory
{
    // 아이템 구조체
    struct Item
    {
        public string Name;
        public int Count;

        public Item(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }

    // 인벤토리 클래스
    class Inventory
    {
        private List<Item> items = new List<Item>();
        private int maxItems;

        public Inventory(int maxItems)
        {
            this.maxItems = maxItems;
        }

        // 아이템 추가
        public void AddItem(string name, int count)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    items[i] = new Item(name, items[i].Count + count);
                    return;
                }
            }

            if (items.Count < maxItems)
            {
                items.Add(new Item(name, count));
            }
            else
            {
                Console.WriteLine("인벤토리가 가득 찼습니다.");
            }
        }

        // 아이템 제거
        public void RemoveItem(string name, int count)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    if (items[i].Count >= count)
                    {
                        items[i] = new Item(name, items[i].Count - count);
                        if (items[i].Count == 0)
                        {
                            items.RemoveAt(i);
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템 개수가 부족합니다!");
                        return;
                    }
                }
            }
            Console.WriteLine("아이템을 찾을 수 없습니다!");
        }

        // 인벤토리 출력
        public void ShowInventory()
        {
            Console.WriteLine("현재 인벤토리:");
            if (items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Name} (x{item.Count})");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory(10);

            // 테스트: 아이템 추가
            inventory.AddItem("포션", 5);
            inventory.AddItem("칼", 1);
            inventory.AddItem("포션", 3); // 포션 개수 추가

            inventory.ShowInventory();

            // 아이템 사용
            Console.WriteLine("포션 2개 사용");
            inventory.RemoveItem("포션", 2);
            inventory.ShowInventory();

            // 테스트: 없는 아이템 제거
            Console.WriteLine("방패 1개 제거 시도");
            inventory.RemoveItem("방패", 1);
            inventory.ShowInventory();

            // 테스트: 모든 포션 제거
            Console.WriteLine("포션 6개 사용(초과 사용 테스트)");
            inventory.RemoveItem("포션", 6);
            inventory.ShowInventory();
        }
    }
}
