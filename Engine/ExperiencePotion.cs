using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ExperiencePotion : Potion
    {
        public int AmountToAdd { get; set; }

        public ExperiencePotion(int id, string name, string namePlural, int price, int amountToAdd) : base(id, name, namePlural, price)
        {
            AmountToAdd = amountToAdd;
        }
    }
}