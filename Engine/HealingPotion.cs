using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HealingPotion : Potion
    {
        public int AmountToHeal { get; set; }

        public HealingPotion(int id, string name, string namePlural, int price, int amountToHeal) : base(id, name, namePlural, price)
        {
            AmountToHeal = amountToHeal;
        }
    }
}