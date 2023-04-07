using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class Game
    {
        private Dice[] _dices;

        public static int element = 0;

        // count value is the amount of rerolls available + 1
        public static int count = 3;

        // counts the total score for each roll/reroll
        public static int[] totals = new int[count];

        Menu menu = new Menu();

        // Creates the array containing the amount of dice
        // and the amount of sides each die has based on the setup.
        private Dice[] CreateDice(int diceCount, int sides)
        {
            Dice[] dices = new Dice[diceCount];
            for (int i = 0; i < diceCount; i++)
            {
                dices[i] = new Dice(sides);
            }
            return dices;
        }

        // Creates the default dice setup and displays the menu choices.
        public void Run()
        {
            _dices = CreateDice(5, 6);
            Console.WriteLine("Welcome!");
            Console.WriteLine("\nPress any key to continue..");
            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                menu.ShowMenu(menu._menuItems);
                switch (InputHelper.ReadInteger("Enter your selection: ", 0, menu._menuItems.Count))
                {
                    case 1:
                        Roll();
                        break;
                    case 2:
                        Console.WriteLine("\nGoodbye.");
                        Environment.Exit(1);
                        return;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private void Roll()
        {
            // reset total counters to zero
            for (int i = 0; i < totals.Length; i++)
            {
                totals[i] = 0;
            }

            if (_dices == null)
            {
                Console.WriteLine("There are no dice.");
                return;
            }

            Console.WriteLine("Rolling dice...\n");
            for (int i = 0; i < _dices.Length; i++)
            {
                _dices[i].Roll();
            }
            Console.WriteLine(string.Join(", ", (object[])_dices));

            int total = 0;
            for (int i = 0; i < _dices.Length; i++)
            {
                total += _dices[i].Value;
            }
            Console.WriteLine($"Total sum rolled is {total}.");
            totals[0] = total;

            Reroll();
            Console.WriteLine("\nPress any key to continue..");
        }

        // Gets new values for the user selected set of dice.
        private void Reroll()
        {
            bool reroll = true;
            int rollMax = 0;            // limits the amount of times player can reroll (default: 0 = 2 rerolls)
            int totalRerollCount = 0;   // counts how many total die were rerolled

            while (reroll)
            {
                if (rollMax > 0)
                    reroll = false;
                string userInput = InputHelper.ReadString("\nDo you want to reroll any dice? Yes or No?");
                if (userInput == "YES")
                {
                    rollMax++;
                    Console.WriteLine("Select whether or not you would like to reroll each dice.");
                    for (int i = 0; i < _dices.Length; i++)
                    {
                        Console.WriteLine($"\nDice number {i + 1}: {_dices[i]}");
                        string userInput2 = InputHelper.ReadString("Do you want to reroll this die? Yes or No?");
                        if (userInput2 == "YES")
                        {
                            _dices[i]._isSelectedForReroll = true;
                            totalRerollCount++;
                        }
                        else if (userInput2 == "NO")
                        {
                            _dices[i]._isSelectedForReroll = false;
                        }
                    }

                    Console.WriteLine("\nRolling...");
                    for (int i = 0; i < _dices.Length; i++)
                    {
                        _dices[i].Reroll();
                    }

                    Console.WriteLine(string.Join(", ", (object[])_dices));

                    int total = 0;
                    for (int i = 0; i < _dices.Length; i++)
                    {
                        total += _dices[i].Value;
                    }
                    Console.WriteLine($"Total sum rolled is {total}\n");
                    
                    for (int i = 1; i < totals.Length; i++)
                    {
                        if (rollMax == i)
                        {
                            totals[i] = total;
                        }
                    }

                }
                else if (userInput == "NO")
                {
                    Console.WriteLine("No selected.\n");
                    reroll = false;
                }
            }
            Console.WriteLine($"Total Reroll Count: {totalRerollCount}\n");
            Score();            
        }

        private void Score()
        {
            for (int i = 0; i < _dices.Length; i++)
            {
                int count = _dices[i].Counter();
                Console.WriteLine($"Dice {i+1} was rerolled {count} time(s)");
            }

            Console.WriteLine();

            for (int i = 0; i < totals.Length; i++) 
            {
                if (totals[i] != 0)
                {
                    Console.WriteLine($"Score {i + 1} value: {totals[i]}");
                }
            }
        }
    }
}
