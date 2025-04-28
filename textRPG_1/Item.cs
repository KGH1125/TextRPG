using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG_1
{
    enum TYPE{
        attack, defense
    }
    internal class Item
    {
        public string name = "";
        public TYPE type;
        public int stat;
        public string info = "";
        public int price;
        public bool isEquipped = false;
    }
}
