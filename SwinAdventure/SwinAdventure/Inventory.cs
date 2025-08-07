using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventure
{
    public class Inventory
    {
        public IEnumerable<Item> Items => _items;
        //Attributes
        private List<Item> _items;
        //Constructor & Methods
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
        public Item Take(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }
        public Item Fetch(string id)
        {
            return Take(id);
        }
        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (Item item in _items)
                {
                    itemList += item.ShortDescription + "\n";
                }
                return itemList;
            }
        }
    }
}
