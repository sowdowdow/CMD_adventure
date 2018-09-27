using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    /**
     * The prompt box is visual device allowing the player to prompt text.
     * 
     * The text input has a max length.
     * If it is not defined,it would be set to the box with
     * without the borders.
     * If it exceed the box width, the prompted text would be scrolled
     * 
     * The prompt box has a border pattern.
     * Default is empty.
     * 
     * 
     */
    public class PromptBox
    {
        private byte _maxTextLength;
        private Rectangle _box;
        private char _borderPattern;

        public PromptBox(byte maxTextLength, Point point1, char borderPattern)
        {
            _maxTextLength = maxTextLength;
            _borderPattern = borderPattern;
            Point point2 = new Point(point1.X + MaxTextLength + 2, point1.Y + 2);
            _box = new Rectangle(point1, point2);

            CheckBoundaries();
        }

        public PromptBox(byte maxTextLength, Point point1)
        {
            _maxTextLength = maxTextLength;
            _borderPattern = ' ';

            Point point2 = new Point(point1.X + MaxTextLength + 2, point1.Y + 2);
            _box = new Rectangle(point1, point2);

            CheckBoundaries();
        }


        /**
         * This function allow to prompt a text.
         * 
         * Next it return the text
         * prompted by the user
         */
        public string Prompt()
        {
            Display();
            Point promptStart = new Point(Box.Left + 1, Box.Top + 1);
            Point promptPoint = promptStart;
            string promptedString = "";
            ConsoleKeyInfo buffer = new ConsoleKeyInfo();

            Console.SetCursorPosition(promptStart.X, promptStart.Y);

            do
            {
                buffer = Console.ReadKey();

                // Enter key to finish the action
                if (buffer.Key == ConsoleKey.Enter)
                {
                    break;
                }

                // these keys has no effects
                if (buffer.Key == ConsoleKey.Delete
                    || buffer.Key == ConsoleKey.DownArrow
                    || buffer.Key == ConsoleKey.UpArrow
                    || buffer.Key == ConsoleKey.LeftArrow
                    || buffer.Key == ConsoleKey.RightArrow)
                {
                    Console.CursorLeft--;
                    continue;
                }


                if (buffer.Key == ConsoleKey.Backspace && promptedString.Length <= 0)
                {
                    Console.CursorLeft = promptStart.X;
                    continue;
                }

                // Backspace to remove a character
                if (buffer.Key == ConsoleKey.Backspace && promptedString.Length > 0)
                {
                    Console.Write('_');
                    Console.CursorLeft--;
                    promptPoint.X--;
                    promptedString = promptedString.Substring(0, promptedString.Length - 1);
                    continue;
                }

                if (promptedString.Length >= MaxTextLength)
                {
                    Console.CursorLeft--;
                    Console.Write(BorderPattern);
                    Console.CursorLeft--;
                    continue;
                }


                //if everything is normal
                promptedString += buffer.KeyChar;
                promptPoint.X++;

            } while (buffer.Key != ConsoleKey.Enter);


            return promptedString;
        }

        /**
         * This function display the prompting
         * box / area to the screen
         * 
         * if there is no border pattern defined,
         * only the characters inputs placements "_"
         * would be displayed
         */
        private void Display()
        {
            if (BorderPattern != ' ')
            {
                Box.Draw(BorderPattern);
            }

            string inputCharsPlacements = "";
            for (int placement = 1; placement <= MaxTextLength; placement++)
            {
                inputCharsPlacements += '_';
            }

            Console.SetCursorPosition(Box.Left + 1, Box.Top + 1);
            Console.WriteLine(inputCharsPlacements);
        }

        /**
         * This method check if the 
         * prompt box is displayable.
         */
        private void CheckBoundaries()
        {
            if (!Box.InConsoleBoundaries())
            {
                throw new Exception("PromptBox out of boundaries");
            }
        }

        public byte MaxTextLength { get => _maxTextLength; }
        public Rectangle Box { get => _box; }
        public char BorderPattern { get => _borderPattern; }
    }
}
