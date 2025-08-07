using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Swin_Adveture_Task;

namespace Swin_Adventure_Test
{
    [TestFixture]
    public class Tests
    {
        IdentifiableObject ident;
        [SetUp]
        public void Setup()
        {
            ident = new IdentifiableObject(new string[] { "105565520", "Gia", "Hieu" });
        }
        [Test]
        public void TestAreYou()
        {
            Assert.That(ident.AreYou("105565520"), Is.True);
            Assert.That(ident.AreYou("Gia"), Is.True);
        }
        [Test]
        public void TestNotAreYou()
        {
            Assert.That(ident.AreYou("unknown_id"), Is.False);
        }
        [Test]
        public void TestFirstID()
        {
            Assert.That(ident.FirstID, Is.EqualTo("105565520"));
        }
        [Test]
        public void TestAddIdentifier()
        {
            ident.AddIdentifier("NewID");
            Assert.That(ident.AreYou("NewID"), Is.True);
        }
        [Test]
        public void TestFirstIDWithNoiDs()
        {
            IdentifiableObject emptyIdent = new IdentifiableObject(new string[] { });
            Assert.That(emptyIdent.FirstID, Is.EqualTo(""));
        }
        [Test]
        public void TestAddID()
        {
            ident.AddIdentifier("James");
            Assert.That(ident.AreYou("James"), Is.True);
        }
        [Test]
        public void TestPriviliegeEscalation()
        {
            ident.PriviliegeEscalation("6520");
            Assert.That(ident.FirstID, Is.EqualTo("Task_2_4_P"));
        }
    }
}
