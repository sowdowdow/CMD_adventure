using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geometry
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
                if (point2.Abscissa >= point1.Abscissa)
                {
                    return point2.Abscissa - point1.Abscissa;
                }
                else
                {
                    return point1.Abscissa - point2.Abscissa;
                }
            }

            set
            {
                if (point2.Abscissa >= point1.Abscissa)
                {
                    point2.Abscissa = point1.Abscissa + value;
                }
                else
                {
                    point1.Abscissa = point2.Abscissa + value;
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
                if (point2.Ordinate >= point1.Ordinate)
                {
                    return point2.Ordinate - point1.Ordinate;
                }
                else
                {
                    return point1.Ordinate - point2.Ordinate;
                }
            }

            set
            {
                if (point2.Ordinate >= point1.Ordinate)
                {
                    point2.Ordinate = point1.Ordinate + value;
                }
                else
                {
                    point1.Ordinate = point2.Ordinate + value;
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
                if (point2.Ordinate >= point1.Ordinate)
                {
                    return point1.Ordinate;
                }
                else
                {
                    return point2.Ordinate;
                }
            }

            set
            {
                if (point2.Ordinate >= point1.Ordinate)
                {
                    point1.Ordinate = value;
                }
                else
                {
                    point2.Ordinate = value;
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
                if (point2.Abscissa >= point1.Abscissa)
                {
                    return point1.Abscissa;
                }
                else
                {
                    return point2.Abscissa;
                }
            }

            set
            {
                if (point2.Abscissa >= point1.Abscissa)
                {
                    point1.Abscissa = value;
                }
                else
                {
                    point2.Abscissa = value;
                }
            }
        }

        public override string ToString()
        {
            return "Left : " + Left + ",Top : " + Top + ", Width: " + Width + ", Height : " + Height;
        }

        public void Draw(char borderChar)
        {
            //concatenate for display optimization
            string horizontalBorder = "";
            for (int borderSize = 0; borderSize < Width; borderSize++)
            {
                horizontalBorder += borderChar; ;
            }

            // Draw the two horizontal borders
            Console.SetCursorPosition(Left, Top);
            Console.Write(horizontalBorder);
            Console.SetCursorPosition(Left, Top + Width - 1);
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