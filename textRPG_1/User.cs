using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG_1
{
    internal class User
    {
        public int Level { get; set; } = 1;
        public string name { get; set; } = "Tan";
        public string Job { get; set; } = "전사";
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 5;
        public int HP { get; set; } = 100;
        public int Money { get; set; } = 1500;

        public void ShowUserInfo()
        {
            Console.Clear();

            // 장착 아이템의 추가 스탯 계산
            int addAttack = GameManager.Instance.inventory.userInventory
                .Where(item => item.isEquipped && item.type == "attack")
                .Sum(item => item.stat);

            int addDefense = GameManager.Instance.inventory.userInventory
                .Where(item => item.isEquipped && item.type == "defense")
                .Sum(item => item.stat);

            Console.WriteLine("Lv. " + Level.ToString("D2"));
            Console.WriteLine(name + " ( " + Job + " )");
            Console.WriteLine($"공격력 : {Attack + addAttack} (+{addAttack})");
            Console.WriteLine($"방어력 : {Defense + addDefense} (+{addDefense})");
            Console.WriteLine("체 력 : " + HP);
            Console.WriteLine("Gold : " + Money + "G");
            Console.WriteLine("\n0.나가기");

        }
    }
}
