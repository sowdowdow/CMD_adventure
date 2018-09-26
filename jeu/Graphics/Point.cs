using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics
{
    /**
     * This class allow you to use a simple point
     * With an abscissa and an ordinate
     */
    public class Point
    {
        private int abscissa;
        private int ordinate;

        public Point()
        {
            abscissa = 0;
            ordinate = 0;
        }

        public Point(int abscissa, int ordinate)
        {
            X = abscissa;
            Y = ordinate;
        }

        public bool IsInConsole
        {
            get
            {
                if (abscissa >= 0 
                    && abscissa <= Console.WindowWidth
                    && ordinate >= 4 
                    && ordinate <= Console.WindowHeight
                    )
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public int X { get => abscissa; set => abscissa = value; }
        public int Y { get => ordinate; set => ordinate = value; }
    }
}