using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class InputHelper
    {
        // Takes user input and verifies that it is a valid integer.
        public static int ReadInteger(string query, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(query);
                if (int.TryParse(Console.ReadLine(), out int input) && input >= min && input <= max)
                    return input;
                Console.WriteLine($"You need to enter a valid number from {min} to {max}!");
            }
        }

        // Takes user input and verifies it is a valid string response.
        public static string ReadString(string query)
        {
            while (true)
            {
                Console.WriteLine(query);
                string input = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("You need to enter a valid response!");
                if (input == "YES")
                    return input;
                else if (input == "NO")
                    return input;
                else
                    Console.WriteLine("You need to enter a valid response!");
            }
        }
    }
}
