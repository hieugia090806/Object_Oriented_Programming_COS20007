using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class Bag : Item
    {
        //Attrubutes
        private Inventory _inventory;
        //Constructor and Methods
        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public override string FullDescription
        {
            get
            {
                return $"In {Name} you can see:\n{Inventory.ItemList}";
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
