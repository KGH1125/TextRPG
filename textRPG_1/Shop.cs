using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG_1
{
    internal class Shop 
    {
        List<Item> itemlist = new ItemManager().StartItem();

        public void ShowShopList()
        {
            while (true)
            {
                int uMoney = GameManager.Instance.user.Money;
                List<int> validInputs = new List<int>();

                //상점목록 불러오기
                Console.Clear();
                Console.WriteLine($"[보유 골드]\n{uMoney}");
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < itemlist.Count; i++)
                {
                    Item shopItem = itemlist[i];
                    string type = (shopItem.type == "attack") ? "공격력" : "방어력";

                    bool ishave = GameManager.Instance.inventory.userInventory
                        .Any(invItem => invItem.name == shopItem.name);

                    string status = ishave ? "구매 완료" : $"{shopItem.price} G";
                    Console.WriteLine($"- {i + 1} {shopItem.name} | {type} + {shopItem.stat} | {shopItem.info} | {status}");

                    validInputs.Add(i + 1);
                }

                Console.WriteLine("\n0. 나가기");
                validInputs.Add(0);

                int selected = GameManager.GetValidInput(validInputs.ToArray());

                if (selected == 0)
                {
                    GameManager.Instance.Gotitle();
                    return;
                }

                Item selectedItem = itemlist[selected - 1];
                bool have = GameManager.Instance.inventory.userInventory
                    .Any(invItem => invItem.name == selectedItem.name);

                
                if (have)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (GameManager.Instance.user.Money >= selectedItem.price)
                {
                    GameManager.Instance.user.Money -= selectedItem.price;
                    GameManager.Instance.inventory.userInventory.Add(selectedItem);
                    Console.WriteLine($"{selectedItem.name} 을(를) 구매했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }

                Console.WriteLine("\n아무 키나 누르면 계속");
                Console.ReadKey();
            }
        }



    }
}
