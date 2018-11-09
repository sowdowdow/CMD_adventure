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
                Console.Clear();
                Console.Write("The sprite is not in console boundaries, window resized" +
                    "\n press any key...");
                Console.SetWindowSize(120, 30);
                return;
            }


            Console.SetCursorPosition(Coordinates.X, Coordinates.Y);
            foreach (var line in Sprite)
            {
                Console.Write(line);
                Console.SetCursorPosition(Coordinates.X, Console.CursorTop + 1);
            }
            new GraphicTools().Cursor_StandBy();
        }

        public bool IsInWindowBoundaries(bool checkInDisplayZone = false)
        {
            int width = Width;
            int height = Height;

            if (!Coordinates.IsInConsole)
            {
                return false;
            }
            if (MaxLeft > Console.WindowWidth)
            {
                return false;
            }
            if (checkInDisplayZone)
            {
                if (MaxHeight > Console.WindowHeight - 4)
                {
                    return false;
                }
            }
            else
            {
                if (MaxHeight > Console.WindowHeight)
                {
                    return false;
                }
            }


            return true;
        }

        public int Width
        {
            get
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
        }
        public int MaxLeft
        {
            get
            {
                return Coordinates.X + Width;
            }
        }

        public int Height => Sprite.Length;
        public int MaxHeight
        {
            get
            {
                return Coordinates.Y + Height;
            }
        }

        public string[] Sprite { get => _Sprite; }
        public Point Coordinates { get => _Coordinates; set => _Coordinates = value; }
    }
}
