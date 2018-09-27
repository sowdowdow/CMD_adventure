using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class Loader
    {
        readonly Point _location;
        readonly uint _loadTime;
        readonly uint _stepTime;

        /**
         * The loader class is displaying a loader for a given duration
         * 
         * Default loadTime = 1sec
         * Default step = 0,2sec
         * 
         * It is auto-displaying at creation
         */
        public Loader(int X, int Y, uint loadTime = 1000, uint stepTime = 200)
        {

            _location = new Point(X, Y);
            if (!_location.IsInConsole)
            {
                throw new Exception("Loader out of boundaries");
            }
            if (stepTime > loadTime)
            {
                throw new Exception("StepTime exceed LoadTime");
            }
            _loadTime = loadTime;
            _stepTime = stepTime;

            Display();
        }

        private void Display()
        {
            uint loading = 0;
            string[] cursorSteps = { @"-", @"\", @"|", @"/" };
            Console.CursorVisible = false;
            do
            {
                for (int nextstep = 0; nextstep < cursorSteps.Length; nextstep++)
                {
                    Step(cursorSteps[nextstep]);
                    if (loading > LoadTime)
                    {
                        break;
                    }
                }


                void Step(string cursorStep)
                {
                    Console.SetCursorPosition(Location.X, Location.Y);
                    Console.Write(cursorStep);
                    System.Threading.Thread.Sleep((int)_stepTime);
                    loading += _stepTime;
                }

            } while (loading < LoadTime);
            Console.CursorVisible = true;
        }

        ~Loader()
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(" ");
        }

        public Point Location { get => _location; }
        public uint LoadTime { get => _loadTime;}
        public uint StepTime { get => _stepTime;}
    }
}
