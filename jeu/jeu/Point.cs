using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geometry
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
            Abscissa = abscissa;
            Ordinate = ordinate;
        }

        public int Abscissa { get => abscissa; set => abscissa = value; }
        public int Ordinate { get => ordinate; set => ordinate = value; }
    }
}