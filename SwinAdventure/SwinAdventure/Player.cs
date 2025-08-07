using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        //Attributes
        private Inventory _inventory;
        //Constructor & Methods
        public Player(string name, string desc) : base(new string[] { "me", "inventory"}, name, desc)
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
                return $"{Name}, {base.FullDescription}\nList of Items that you have:\n{ _inventory.ItemList}";
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
