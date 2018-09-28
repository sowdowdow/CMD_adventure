using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class TwoChoicesPromptBox
    {
        private Rectangle _box;
        private char _borderPattern;
        private string _option1, _option2;
        private bool _selectedOption;

        public TwoChoicesPromptBox(Point location, char borderPattern = ':', string choice1 = "OUI", string choice2 = "NON")
        {
            // 6 is the padding inside the rectangle
            // to clearly seperate the two choices
            if (choice1.Length + choice2.Length + 6 > Console.WindowWidth)
            {
                throw new Exception("The length of the PromptBox is overlaping the Console.");
            }

            _option1 = choice1;
            _option2 = choice2;
            _box = new Rectangle(
                location,
                new Point(location.X + 6 + TextLength, location.Y + 2));
            _borderPattern = borderPattern;
            _selectedOption = false;
        }

        public Rectangle Box { get => _box; }
        public char BorderPattern { get => _borderPattern;}
        public string Option1 { get => _option1; }
        public string Option2 { get => _option2; }

        private void Display()
        {
            Console.CursorVisible = false;
            if (BorderPattern != ' ')
            {
                Box.Draw(BorderPattern);
            }
            Console.SetCursorPosition(Box.Left + 1, Box.Top + 1);

            if (SelectedOption is true)
            {
                Console.Write(">{0}< {1} ", Option1, Option2);
            }
            else
            {
                Console.Write(" {0} >{1}<", Option1, Option2);
            }
            Console.CursorVisible = true;
        }

        public bool Prompt()
        {
            ConsoleKey buffer = new ConsoleKey();
            Display();

            do
            {
                Console.CursorVisible = false;
                buffer = Console.ReadKey().Key;

                switch (buffer)
                {
                    case ConsoleKey.LeftArrow:
                        if (SelectedOption is false)
                        {
                            SelectedOption = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (SelectedOption is true)
                        {
                            SelectedOption = false;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        buffer = ConsoleKey.Enter;
                        break;
                    default:
                        break;
                }
                Display();
            } while (buffer != ConsoleKey.Enter);

            Console.CursorVisible = true;
            Clear();
            return SelectedOption;
        }

        private void Clear()
        {
            Box.Clear();
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

        private int TextLength
        {
            get
            {
                return Option1.Length + Option2.Length;
            }
        }

        private bool SelectedOption { get => _selectedOption; set => _selectedOption = value; }
    }
}
