using NUnit.Framework;
using Clock;

namespace Clock
{
    public class Tests
    {
        Clock _clock;
        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }

        [Test] //First test
        public void TestClockStart()
        {
            Assert.IsTrue(_clock.Time() == "00:00:00", "Clock should start at 00:00:00");
        }
        [Test] //Second test
        public void Counter_IncrementAddsOne()
        {
            Counter counter = new Counter("TestCounter");
            int initialCount = counter.Ticks; 

            counter.Increment();
            int newCount = counter.Ticks;

            Assert.IsTrue(newCount == initialCount + 1, "Counter should increment by 1");
        }
        [Test] //Third test
        public void Counter_IncrementMultipleTimes()
        {
            Counter counter = new Counter("TestCounter");
            int increments = 5;

            for (int i = 0; i < increments; i++)
            {
                counter.Increment();
            }
            int finalCount = counter.Ticks;

            Assert.IsTrue(finalCount == increments, "Counter should equal the number of increments");
        }
        [Test]
        public void Counter_ResetSetsCountToZero_UsingIsTrue()
        {
            Counter counter = new Counter("TestCounter");
            counter.Increment(); 
            counter.Increment(); 
            Assert.IsTrue(counter.Ticks == 2, "Pre-condition: Counter should be at 2 before reset.");

            counter.Reset();
            int finalCount = counter.Ticks;

            Assert.IsTrue(finalCount == 0, "Reset should set the count back to 0.");
        }


    }
}