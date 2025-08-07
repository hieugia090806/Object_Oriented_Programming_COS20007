using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTest
{
    public class ItemTest
    {
        Item axe = new Item(new string[] { "axe" }, "a power wooden axe", "+10 ATK points Damage");
        Item sword = new Item(new string[] { "sword" }, "a valubale iron sword", "This is a sword, + 20 ATK points Damage");
        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual(axe.ShortDescription, "a power wooden axe (axe)"); 
            Assert.AreNotEqual(axe.ShortDescription, "This is a shovel"); 

            Assert.AreEqual(sword.ShortDescription, "a valubale iron sword (sword)"); 
            Assert.AreNotEqual(sword.ShortDescription, "This is a shovel"); 
        }
        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual(axe.FullDescription, "+10 ATK points Damage"); 
            Assert.AreNotEqual(axe.FullDescription, "a power wooden axe (axe)"); 

            Assert.AreEqual(sword.FullDescription, "This is a sword, + 20 ATK points Damage"); 
            Assert.AreNotEqual(sword.FullDescription, "an iron sword (sword)"); 
        }
        [Test]
        public void TestItemIdentifiable()
        {
            Assert.IsFalse(axe.AreYou("sword")); 
            Assert.IsTrue(axe.AreYou("axe")); 

            Assert.IsFalse(sword.AreYou("axe"));
            Assert.IsTrue(sword.AreYou("sword")); 
        }
    }

}
