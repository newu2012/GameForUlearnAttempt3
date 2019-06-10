using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Potion : Item
    {
        public Potion(int id, string name, string namePlural, int price) : base(id, name, namePlural, price)
        {
        }
    }
}