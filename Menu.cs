using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class Menu
    {
        // Menu items
        public List<string> _menuItems = new List<string>
        {
            "Roll.",
            "Exit."
        };

        // Displays the menu
        public void ShowMenu(List<string> menuItems)
        {
            Console.WriteLine();
            for (int i = 0; i < menuItems.Count; i++)
                Console.WriteLine($"[{i + 1}] {menuItems[i]}");
            Console.WriteLine();
        }
    }
}
