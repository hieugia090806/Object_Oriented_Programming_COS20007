using SwinAdventure;
using NUnit.Framework;

namespace SwinAdventureTest
{
    public class IdentifiableObjectTests
    {
        private IdentifiableObject id;
        private IdentifiableObject id_for_final_test;
        private IdentifiableObject idWithNoIDs;
        [SetUp]
        public void Setup()
        {
            id = new IdentifiableObject(new string[] { "gia", "hieu", "mike", "bond" });
            idWithNoIDs = new IdentifiableObject(new string[] { });
            id_for_final_test = new IdentifiableObject(new string[] { "5520", "gia", "hieu"});
        }

        [Test]
        //First test
        public void TestAreYou()
        {
            // Assert that the object can correctly identify itself with the given identifiers
            Assert.IsTrue(id.AreYou("gia"));
            Assert.IsTrue(id.AreYou("hieu"));
        }
        //Second test
        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(id.AreYou("Jack"));
            Assert.IsFalse(id.AreYou("music"));
        }
        //Thrd test
        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(id.AreYou("MIKE"));
            Assert.IsTrue(id.AreYou("bOnD"));
        }
        //Fourth test
        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual("gia", id.FirstID);
        }
        //Fifth test
        [Test]
        public void TestFirstIDWithNoIDs()
        {
            Assert.AreEqual("", idWithNoIDs.FirstID);
        }
        //Sixth test
        [Test]
        public void TestAddID()
        {
            id.AddIdentifier("Seekers");
            id.AddIdentifier("Athol");
            id.AddIdentifier("Keith");
            id.AddIdentifier("Bruce");
            Assert.IsTrue(id.AreYou("Seekers"));
            Assert.IsTrue(id.AreYou("Athol"));
            Assert.IsTrue(id.AreYou("Keith"));
            Assert.IsTrue(id.AreYou("Bruce"));
        }
        //Finallt test
        [Test]
        public void TestPrivilegeEscalation()
        {
            // Act: escalate privilege using the correct pin (last 4 digits of student ID)
            id_for_final_test.PrivilegeEscalation("5520");

            Assert.That(id_for_final_test.FirstID, Is.EqualTo("COS20007"));
        }



    }
}