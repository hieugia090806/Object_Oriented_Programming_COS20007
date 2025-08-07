namespace Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            
            for (int j = 0; j < 86700; j++)
            { 
                Thread.Sleep(6000); ///The bigger number is, the slower the clock will tick.
                Console.Clear();
                clock.Tick();
                Console.WriteLine(clock.Time());
            }
        }
    }
}
