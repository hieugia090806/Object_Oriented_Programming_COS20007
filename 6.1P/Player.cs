using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    //Change internal to public
    public class Player : GameObject, IHaveInventory //Add IHaveinventory to the Player class to implement the interface
    {
        //Set attributes
        private Inventory _inventory;
        //Methods and constructors
        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
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
                return $"{Name}, {base.FullDescription}\nList of Items that you have:\n{_inventory.ItemList}";
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
