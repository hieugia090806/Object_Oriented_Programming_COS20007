using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    //Change from internal to public
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }
        public bool HasItem(string id) 
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Item item)
        {
            _items.Add(item);
        }
        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }
        public Item Take(string id)
        {
            Item TakeItem = Fetch(id);
            _items.Remove(TakeItem);
            return TakeItem;
        }
        public string ItemList 
        {
            get
            { 
                string ListItem = "";
                foreach (Item item in _items)
                {
                    ListItem = ListItem + item.ShortDescription + "\n";
                }
                return ListItem;
            }
        }
    }
}
