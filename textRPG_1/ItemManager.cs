using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG_1
{
    internal class ItemManager
    {
        private Item CreateItem(string name, string type, int stat, string inpo, int price)
        {
            return new Item
            {
                name = name,
                type = type,
                stat = stat,
                inpo = inpo,
                price = price
            };
        }
        //상점 기본 아이템 추가
        public List<Item> StartItem()
        {
            List<Item> items = new List<Item>
                {
                    CreateItem("낡은 검", "attak", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 100),
                    CreateItem("청동 도끼", "attak", 5, "어디선가 사용됐던거 같은 도끼입니다.", 200),
                    CreateItem("스파르타의 창", "attak", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 300),
                    CreateItem("수련자 갑옷", "defense", 2, "수련에 도움을 주는 갑옷입니다.", 1000),
                    CreateItem("무쇠 갑옷", "defense", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1500),
                    CreateItem("스파르타의 갑옷", "defense", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 2000)
                };
            return items;
        } 
    }
}
