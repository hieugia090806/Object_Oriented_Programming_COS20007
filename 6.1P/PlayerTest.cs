using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTest
{
    public class Playertest
    {
        Player player = new Player("Truong Ngoc Gia Hieu", "a Swinburne warrior");

        Item axe = new Item(new string[] { "axe" }, "a power wooden axe", "+10 ATK points Damage");
        Item sword = new Item(new string[] { "sword" }, "a valuable iron sword", "This is a valuable sword, +20 ATK points Damage");
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }
        [Test]
        public void TestPlayerLocateItems()
        {
            player.Inventory.Put(sword);
            Item itemsLocated = (Item)player.Locate("sword");
            Assert.AreEqual(sword, itemsLocated);
        }
        [Test]
        public void TestPlayerLocateNothing()
        {
            Item itemLocated = (Item)player.Locate("Silver Arrow");
            Assert.IsNull(itemLocated);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            Player me = (Player)player.Locate("me");
            Player inventory = (Player)player.Locate("inventory");
            Assert.AreEqual(player, me);
            Assert.AreEqual(player, inventory);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            player.Inventory.Put(sword);
            player.Inventory.Put(axe);

            string expected = "Truong Ngoc Gia Hieu, a Swinburne warrior\nList of Items that you have:\na valuable iron sword (sword)\na power wooden axe (axe)\n";

            Assert.AreEqual(player.FullDescription, expected);
        }
    }
}
