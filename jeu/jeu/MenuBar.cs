using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public static class MenuBar
    {
        private static String[] menu = { "Carte (a)", "Inventaire (z)", "Magasin (e)", "??? (r)", "Options (t)" };
        public static void Display()
        {
            GraphicTools drawer = new GraphicTools();
            int NumberOfTabs = menu.Length;
            int TotalStringLengthOfMenu = String.Join("", menu).Length;
            int AvailableSpace = (Console.WindowWidth - TotalStringLengthOfMenu);
            // 1 margin for left & right side of an element
            int MarginsSize = AvailableSpace / (NumberOfTabs * 2);

            //Line 1 - Border
            Console.BackgroundColor = ConsoleColor.Black;
            drawer.HorizontalLine(0, '-');

            //Line 2 - Items + Separators
            Console.SetCursorPosition(0, 1);
            for (int menuItem = 0; menuItem < NumberOfTabs; menuItem++)
            {
                //Margin of tabs
                //divise par 2 car 2x la même opération
                for (int j = 0; j < MarginsSize; j++)
                {
                    Console.Write(' ');
                }
                ConsoleColor previousColor = Console.ForegroundColor;
                if (Stats.activeTab != null)
                {
                    //Change the color for the active tab
                    Console.ForegroundColor = (menu[menuItem].Contains(Stats.activeTab)) ? ConsoleColor.Green : ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //Writing the item
                Console.Write(menu[menuItem]);
                //Switch back the color
                Console.ForegroundColor = previousColor;
                //Spacing between tabs
                for (int j = 1; j < MarginsSize; j++)
                {
                    Console.Write(" ");
                }
                if (menuItem < NumberOfTabs - 1)
                {
                    Console.Write("|");
                }
            }

            // Line 3 - Border
            drawer.HorizontalLine(2, '-');
            drawer.Cursor_StandBy();
        }
    }
}