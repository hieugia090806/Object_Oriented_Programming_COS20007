using System;
using System.Collections.Generic;
using System.Text.RegularExpressions; // Import for Regex

namespace _1._2P
{
    internal class Greetingprogram
    {
        static void Main(string[] args)
        {
            Console.Title = "Task_1_2_P"; // Set the window title
            Console.Write("Dear user, please enter your name: ");
            string input = Console.ReadLine().Trim(); // Read input and trim whitespace

            if (input == "exit" || input == "Exit") //check for exit
            {
                Console.WriteLine("Goodbye!");
                return; // Exit the program
            }

            // Check if the input is null, empty, or contains special characters
            if (string.IsNullOrEmpty(input) || Regex.IsMatch(input, "[^a-zA-Z\\s]"))
            {
                Console.WriteLine("Welcome, nice to meet you!");
            }
            else
            {
                string[] user_name = input.Split(' '); // Split the input by spaces.

                if (user_name.Length >= 3)
                {
                    for (int i = 0; i < user_name.Length; i++)
                    {
                        Console.WriteLine($"Hi {user_name[i]}, how are you?");
                    }
                }
                else if (user_name.Length == 1)
                {
                    Console.WriteLine("Welcome Admin");
                }
            }

            Console.ReadKey(); // Wait for user to press any key before exiting
        }
    }
}
