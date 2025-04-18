using System;
using System.Collections.Generic;

namespace textRPG_1
{
    internal class Inventory
    {
        public List<Item> userInventory = new List<Item>();

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");

            if (userInventory.Count == 0)
            {
                Console.WriteLine("- 인벤토리에 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < userInventory.Count; i++)
                {
                    string type = (userInventory[i].type == "attak") ? "공격력" : "방어력";
                    string isEq = (userInventory[i].isEquipped == true) ? "[E]" : "";
                    Console.WriteLine($"- {isEq} {userInventory[i].name} | {type} + {userInventory[i].stat} | {userInventory[i].inpo}");
                }
            }

            Console.WriteLine("\n1. 장착관리 \n2. 나가기");
        }

        public void UpdateInventory()
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");

            if (userInventory.Count == 0)
            {
                Console.WriteLine("- 인벤토리에 아이템이 없습니다.");
                Console.WriteLine("0. 나가기");
                GameManager.GetValidInput(0);
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[장착 관리]");
                for (int i = 0; i < userInventory.Count; i++)
                {
                    string type = (userInventory[i].type == "attak") ? "공격력" : "방어력";
                    string isEq = (userInventory[i].isEquipped == true) ? "[E]" : "";
                    Console.WriteLine($"{i + 1}. {isEq} {userInventory[i].name} | {type} + {userInventory[i].stat} | {userInventory[i].inpo}");
                }
                Console.WriteLine("0. 나가기");

                // 유효한 번호 리스트 생성
                List<int> validInputs = new List<int>();
                for (int i = 0; i < userInventory.Count; i++)
                { 
                    validInputs.Add(i + 1);
                    validInputs.Add(0);
                }
                
                int choice = GameManager.GetValidInput(validInputs.ToArray());
                if (choice == 0)
                {
                    break;
                }
                else
                {
                    int idx = choice - 1;
                    userInventory[idx].isEquipped = !userInventory[idx].isEquipped;
                    // 캐릭터에 스탯 반영도 여기서 가능
                }
            }
        }
    }
}
