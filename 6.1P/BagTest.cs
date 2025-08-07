using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTest
{
    public class BagTest
    {
        private Bag bag;
        private Item key;
        private Item book;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "Bag" }, "A small Bag", "A bag for holding all items.");
            key = new Item(new string[] { "Key" }, "A small Key", "A key for opening a door.");
            book = new Item(new string[] { "Book" }, "A useful book", "A book that is filled with knowledge.");
        }
        [Test]
        public void TestBagLocatesItself()
        {
            GameObject locatedBag = bag.Locate("bag");
            Assert.AreEqual(bag, locatedBag);
        }
        [Test]
        public void TestBagLocatesItems()
        {
            Setup();
            bag.Inventory.Put(key);
            GameObject locatedItem = bag.Locate("key");
            Assert.AreEqual(key, locatedItem);
        }
        [Test]
        public void TestBagLocatesNothing()
        {
            GameObject locatedObject = bag.Locate("book");
            Assert.IsNull(locatedObject, "Bag should not locate an item that is not in it.");
        }
        [Test]
        public void TestBagInBag()
        {
            Bag bag1 = new Bag(new string[] { "outer" }, "Outer Bag", "A larger bag.");
            Bag bag2 = new Bag(new string[] { "inner" }, "Inner Bag", "A smaller bag.");
            bag1.Inventory.Put(bag2);
            bag1.Inventory.Put(key);
            bag2.Inventory.Put(book);

            GameObject locatedInnerBag = bag1.Locate("inner");
            GameObject locatedKeyInB1 = bag1.Locate("key");
            GameObject locatedKeyInB2 = bag2.Locate("key");

            Assert.AreEqual(bag2, locatedInnerBag);
            Assert.AreEqual(key, locatedKeyInB1);

            Assert.AreNotEqual(key, locatedKeyInB2);

            GameObject locatedbookinb1 = bag1.Locate("book");
            GameObject locatedbookinb2 = bag2.Locate("book");

            Assert.AreEqual(book, locatedbookinb2);
            Assert.AreNotEqual(book, locatedbookinb1);
        }
        [Test]
        public void TestBagFullDescription()
        {
            bag.Inventory.Put(key);
            bag.Inventory.Put(book);

            string expectedstring = "In A small Bag can see: A small Key (key)\nA useful book (book)\n";

            Assert.AreEqual(expectedstring, bag.FullDescription);
        }
    }
}
