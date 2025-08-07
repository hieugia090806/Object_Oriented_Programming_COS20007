namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("------------------------------------");
            //Enter player name
            Console.Write("Dear brave warrior, please enter your name: ");
            string playername = Console.ReadLine();
            //Enter player description
            Console.WriteLine("Please enter player description:");
            string playerdescription = Console.ReadLine();
            Console.WriteLine("------------------------------------");
            //Two items and add them to the player inventory
            Player player = new Player(playername, playerdescription);
            Item shovel = new Item(new string[] { "shovel" }, "A shovel", "An excavating shovel");
            Item sword = new Item(new string[] { "sword" }, "A sword", "A sharp sword ");
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            // Create a bag and add it to player's inventory
            Bag backpack = new Bag(new string[] { "backpack" }, "A backpack", "A useful backpack");
            player.Inventory.Put(backpack);
            //Create another item and add it to the bag 
            Item book = new Item(new string[] { "book" }, "A book", "A thick book");
            backpack.Inventory.Put(book);
            Item gem = new Item(new string[] { "gem" }, "A gem", "A shiny gem");
            backpack.Inventory.Put(gem);
            Item shield = new Item(new string[] { "shield" }, "A shield", "A bronze shield");
            backpack.Inventory.Put(shield);
            Item gun = new Item(new string[] { "gun" }, "A gun", "A powerful gun");
            backpack.Inventory.Put(gun);
            Item map = new Item(new string[] { "map" }, "A map", "A detailed map");
            backpack.Inventory.Put(map);

            LookCommand lookCommand = new LookCommand();
            Console.WriteLine($"Hello, {player.Name}!\n{player.FullDescription}");
            Console.WriteLine("------------------------------------");
            //Main
            while (true)
            {
                Console.WriteLine("Please enter command: ");

                string commandLine = Console.ReadLine();
                string[] commandWords = commandLine.ToLower().Split(' ');
                if (string.IsNullOrWhiteSpace(commandLine))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                else if (commandWords.Length > 0 && commandWords[0] == "look" && commandWords.Length == 3)
                {
                    string result = lookCommand.Execute(player, commandWords);
                    Console.WriteLine(result);
                }
                else if (commandWords.Length > 0 && commandWords[0] == "quit" | commandWords[0] == "Quit" | commandWords[0] == "Exit" | commandWords[0] == "exit")
                {
                    Console.WriteLine("Exiting game. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("I don't understand that command.\nTry 'look at [item]' or 'look at [item] in [container]'.\nType 'quit' to exit.");
                }
            }

        }
    }
}
