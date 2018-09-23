using System;

namespace Graphics
{
    public static class Sprite_box
    {
        public static void DisplaySprite(int x_TopToBottom, int y_LeftToRight, string[] sprite)
        {
            Console.SetCursorPosition(x_TopToBottom, y_LeftToRight);
            foreach (var line in sprite) //display each line of the sprite + jumpline
            {
                Console.Write(line);
                Console.SetCursorPosition(x_TopToBottom, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(Console.WindowWidth - 3, Console.WindowHeight - 2);
        }
        //skin du joueur
        public static string _player_base = "°v°";
        public static string _player_wow = "*v*";
        public static string _player_depressed = "-v-";
        //sprite des objets
        public static string[] _house1 = {
                @"  _______| |__",
                @" /            \",
                @"/______________\",
                @"|        __    |",
                @"|       | ,|   |",
                @"|_______|__|___|"
            };
        public static string[] _house2 = {
                @"  _____\ \_",
                @" /         \",
                @"/  __       \",
                @"| | ,|      |",
                @"|_|__|______|"
            };
        public static string[] _dynosaur = {
                @"      _______ ",
                @"    ./     [°\",
                @"   ././   \ \ ",
                @".__/_|————|_| ",
            };
        //=~=~=~=~=~=~=~=~=~=~=~=~=~=~
        //          Weapons
        //=~=~=~=~=~=~=~=~=~=~=~=~=~=~
        /**
         * Weapons are
         * 8 char. large and 4 char. height
         */
        public static string[] _woodenStick =
        {
                @"    / / ",
                @" ()/-/  ",
                @" |/ /   ",
                @" /_/    ",
        };

        public static string[] _sharpenedStick =
        {
                @"    /|  ",
                @"   / /  ",
                @"  / /   ",
                @" / /    ",
        };

        public static string[] _stove =
{
                @"  ____  ",
                @" /    \\",
                @" \_  _//",
                @"   ||   ",
        };
    }
}