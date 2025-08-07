using System;


namespace Task_1_1_P
{
    public class Mainprogram
    {
        public static void Average()
        {
            Console.WriteLine("Please enter the array of integers: "); //Ask user for input the arrat of integers
            string input_numbers = Console.ReadLine(); //Read the input from the user
            string[] numbers = input_numbers.Split(' '); //Split the input string into an array of strings
            int[] number_list = new int[numbers.Length]; //Create an array of integers with the same length as the input string array
            Console.WriteLine("-----------------");
            Console.WriteLine("The arrays of integers you entered: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                number_list[i] = Convert.ToInt32(numbers[i]);
                sum += number_list[i];
            }
            int average = sum/numbers.Length;
            Console.WriteLine($"The average of the list is: {average}");

        }
        public static void Main(string[] args)
        {
            Average();
            Console.ReadKey(); //Wait for user to press a key before closing the console window
        }
    }
}
