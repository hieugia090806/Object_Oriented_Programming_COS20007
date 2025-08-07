using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure; 

namespace SwinAdventure
{
    public class Item : GameObject 
    {
        public Item(string[] ids, string name, string desc) : base(ids, name, desc)
        {

        }
    }
}
