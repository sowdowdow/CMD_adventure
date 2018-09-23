using System;

namespace Graphics
{
    /**
     * This class represent a visual entity
     * of a sprite.
     */
    public class SpriteEntity
    {
        string[] _Sprite;
        Point _Coordinates;

        public SpriteEntity(string[] Sprite, Point Coordinates)
        {
            _Sprite = Sprite;
            _Coordinates = Coordinates;
        }

        public SpriteEntity(string[] Sprite, int X, int Y)
        {
            _Sprite = Sprite;
            _Coordinates = new Point(X, Y);
        }

        //Display the spriteEntity on his coordinates
        public void Display()
        {
            if (!IsInWindowBoundaries())
            {
                Console.SetCursorPosition(0,0);
                Console.Write("The sprite is not in console boundaries" +
                    "\nwindow resized");
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                return;
            }
            Console.SetCursorPosition(Coordinates.Abscissa, Coordinates.Ordinate);
            foreach (var line in Sprite)
            {
                Console.Write(line);
                Console.SetCursorPosition(Coordinates.Abscissa, Console.CursorTop + 1);
            }
            new GraphicTools().Cursor_StandBy();
        }

        private bool IsInWindowBoundaries()
        {
            int width = GetWidth();
            int height = GetHeight();

            if (!Coordinates.IsInConsole)
            {
                return false;
            }
            if (Coordinates.Abscissa + width > Console.WindowWidth)
            {
                return false;
            }
            if (Coordinates.Ordinate + height > Console.WindowHeight)
            {
                return false;
            }


            return true;
        }

        private int GetWidth()
        {
            int width = 0;
            foreach (string line in Sprite)
            {
                if (line.Length > width)
                {
                    width = line.Length;
                }
            }
            return width;
        }

        private int GetHeight()
        {
            return Sprite.Length;
        }

        public string[] Sprite { get => _Sprite; }
        public Point Coordinates { get => _Coordinates; set => _Coordinates = value; }
    }
}
