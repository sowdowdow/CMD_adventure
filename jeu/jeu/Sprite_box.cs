using System;

namespace game
{
    public class Sprite_box
    {
        public void DisplaySprite(int x_TopToBottom, int y_LeftToRight, string[] sprite)
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
        public string _player_base = "°v°";
        public string _player_wow = "*v*";
        public string _player_depressed = "-v-";
        //sprite des objets
        public string[] _house1 = {
                @"  _______| |__",
                @" /            \",
                @"/______________\",
                @"|        __    |",
                @"|       | ,|   |",
                @"|_______|__|___|"
            };
        public string[] _house2 = {
                @"  _____\ \_",
                @" /         \",
                @"/  __       \",
                @"| | ,|      |",
                @"|_|__|______|"
            };
        public string[] _dynosaur = {
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
        public string[] _woodenStick =
        {
                @"    / / ",
                @" ()/-/  ",
                @" |/ /   ",
                @" /_/    ",
        };

        public string[] _sharpenedStick =
        {
                @"    /|  ",
                @"   / /  ",
                @"  / /   ",
                @" / /    ",
        };

        public string[] _stove =
{
                @"  ____  ",
                @" /    \\",
                @" \_  _//",
                @"   ||   ",
        };
    }
}