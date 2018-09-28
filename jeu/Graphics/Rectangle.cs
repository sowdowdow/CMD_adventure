using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics
{
    public class Rectangle
    {
        private Point point1;
        private Point point2;

        public Rectangle()
        {
            this.point1 = new Point();
            this.point2 = new Point();
        }

        public Rectangle(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public Rectangle(int Left, int Top, int Width, int Height)
        {
            if (Left < 0 || Top < 0)
            {
                throw new Exception("A value is negative, positive expected");
            }
            this.point1 = new Point(Left, Top);
            this.point2 = new Point(Left + Width, Top + Height);
        }

        /**
         * Return the width of the rectangle
         */
        public int Width
        {
            get
            {
                if (point2.X >= point1.X)
                {
                    return point2.X - point1.X;
                }
                else
                {
                    return point1.X - point2.X;
                }
            }

            set
            {
                if (point2.X >= point1.X)
                {
                    point2.X = point1.X + value;
                }
                else
                {
                    point1.X = point2.X + value;
                }
            }
        }

        /**
         * Return the height of the rectangle
         */
        public int Height
        {
            get
            {
                if (point2.Y >= point1.Y)
                {
                    return point2.Y - point1.Y;
                }
                else
                {
                    return point1.Y - point2.Y;
                }
            }

            set
            {
                if (point2.Y >= point1.Y)
                {
                    point2.Y = point1.Y + value;
                }
                else
                {
                    point1.Y = point2.Y + value;
                }
            }
        }

        /**
         * Return the top position of the rectangle
         */
        public int Top
        {
            get
            {
                if (point2.Y >= point1.Y)
                {
                    return point1.Y;
                }
                else
                {
                    return point2.Y;
                }
            }

            set
            {
                if (point2.Y >= point1.Y)
                {
                    point1.Y = value;
                }
                else
                {
                    point2.Y = value;
                }
            }
        }

        /**
         * Return the top position of the rectangle
         */
        public int Left
        {
            get
            {
                if (point2.X >= point1.X)
                {
                    return point1.X;
                }
                else
                {
                    return point2.X;
                }
            }

            set
            {
                if (point2.X >= point1.X)
                {
                    point1.X = value;
                }
                else
                {
                    point2.X = value;
                }
            }
        }

        public override string ToString()
        {
            return "Left : " + Left + ",Top : " + Top + ", Width: " + Width + ", Height : " + Height;
        }

        public bool InConsoleBoundaries()
        {
            //negation tests
            if (Left < 0 || Left > Console.WindowWidth)
            {
                return false;
            }
            if (Top < 0 || Top > Console.WindowHeight)
            {
                return false;
            }

            //if all tests passed, it's true
            return true;
        }

        public void Clear()
        {
            string lineCleaner = "";
            for (int width = 0; width <= Width; width++)
            {
                lineCleaner += " ";
            }
            
            for (int top = Top; top <= Top + Height; top++)
            {
                Console.SetCursorPosition(Left, top);
                Console.CursorVisible = false;
                Console.Write(lineCleaner);
                Console.CursorVisible = true;
            }
        }

        /**
* This function return the free area 
* of the rectangle in pixel square.
*/
        public int Area
        {
            get
            {
                return Height * Width;
            }
        }

        public void Draw(char borderChar)
        {
            //concatenate for display optimization
            string horizontalBorder = "";
            for (int borderSize = 0; borderSize < Width; borderSize++)
            {
                horizontalBorder += borderChar;
            }

            // Draw the two horizontal borders
            Console.SetCursorPosition(Left, Top);
            Console.Write(horizontalBorder);
            Console.SetCursorPosition(Left, Top + Height);
            Console.Write(horizontalBorder);


            // Draw the two vertical borders
            for (int verticalBorder = Top + 1; verticalBorder < Top + Height; verticalBorder++)
            {
                Console.SetCursorPosition(Left, verticalBorder);
                Console.Write(borderChar);
                Console.SetCursorPosition(Left + Width - 1, verticalBorder);
                Console.Write(borderChar);
            }

        }
    }
}