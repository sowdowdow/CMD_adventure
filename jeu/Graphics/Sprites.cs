using System;

namespace Graphics
{
    /**
     * This class cantain all the visuals of the game
     * 
     * It is constituted of strings arrays
     * Each line represent an ordinate to 
     * display
     */
    public static class Sprites
    {
        //Player skins
        public static string _player_base = "°v°";
        public static string _player_wow = "*v*";
        public static string _player_depressed = "-v-";

        //Objects skins
        public static string[] _house1 = {
                @"          ) )",
                @"  _______| |__",
                @" /            \",
                @"/______________\",
                @"|        __    |",
                @"|       | ,|   |",
                @"|_______|__|___|"
            };
        public static string[] _house2 = {
                @"       `",
                @"      ( (",
                @"  _____\ \_",
                @" /         \",
                @"/  __       \",
                @"| | ,|      |",
                @"|_|__|______|"
            };
        public static string[] _neighbourhood1 =
        {
                @"                                                             \ /",
                @"                                        |                   - O -",
                @"                                       -+-                   / \",
                @"              \                       /_|_\",
                @"              ))            ^         /___\         ))",
                @"             .-#-----.     /|\     .---'-'---.    .-#-----.",
                @"      ___   /_________\   //|\\   /___________\  /_________\  ",
                @"     /___\  | [] _  []|   //|\\   | A /^\ A   |  |  [] _ []| _.O,_",
                @".....|[#[|..|   |*|   |.....|.....|   |'|     |..|    |*|  |..(^)....",
        };
        public static string[] _dynosaur1 = {
                @"      _______ ",
                @"    ./.....'°\",
                @"   ././...\.\ ",
                @".__/_|————|_| ",
            };
        public static string[] _dottedFloor1 = {
                @".,....,... ......, ..... . .. .,. . ....",
            };

        /**=~=~=~=~=~=~=~=~=~=~=~=~=~=~
        *          Weapons
        *=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~
        *
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