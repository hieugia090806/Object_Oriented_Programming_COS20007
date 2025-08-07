namespace Clock
{
    internal class Program
    {
        private static void PrintCounter(Counter counter)
        {
            Console.WriteLine($"Counter Name: {counter.Name}, Ticks: {counter.Ticks}");
        }
        static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i = 0; i <= 9; i++)
            {
                myCounters[0].Increment();
            }

            for (int i = 1; i<= 14; i++)
            {
                myCounters[1].Increment();
            }

            Console.WriteLine("Print counters before reseting myCounters[2]");
            PrintCounter(myCounters[0]);
            PrintCounter(myCounters[1]);
            PrintCounter(myCounters[2]);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Print Counters after reseting myCounter[2]");
            myCounters[2].Reset();
            PrintCounter(myCounters[0]);
            PrintCounter(myCounters[1]);
            PrintCounter(myCounters[2]);
        }
    }
}
