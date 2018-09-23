using System;
using System.Collections.Generic;

namespace Graphics
{
    /**
     * A Dialog correspond a List of Sentences
     * and each sentence can be divided in lines
     * for display purposes
     */
    public class Dialog
    {
        private Rectangle _rectangle;
        private List<string> _sentences;
        private GraphicTools _drawer = new GraphicTools();

        public Dialog(Rectangle rectangle, List<string> dialog)
        {
            this._rectangle = rectangle;
            this._sentences = dialog;
        }

        public Dialog(Rectangle rectangle)
        {
            this._rectangle = rectangle;
            this._sentences = new List<string>();
        }

        public Dialog(int Left, int Top, int Width, int Height)
        {
            this._rectangle = new Rectangle(Left, Top, Width, Height);
            this._sentences = new List<string>();
        }

        public void AddSentence(string sentence)
        {
            if (sentence == "")
            {
                throw new System.Exception("The sentence must not be empty");
            }
            _sentences.Add(sentence);
        }

        public void AddSentences(string[] sentences)
        {
            foreach (string sentence in sentences)
            {
                AddSentence(sentence);
            }
        }

        /**
         * This function return a List of lines
         * corresponding to a sentence of the dialog
         */
        private List<string> LinesOfSentence(string sentence)
        {
            //Step 1 : cutting the sentence in a queue (french "file") of words
            Queue<string> words = new Queue<string>(sentence.Split(' '));
            //Step 2 : transform the list of words in a list of lines
            List<string> lines = new List<string>();

            // while there is still words to display
            // we add lines
            while (words.Count != 0)
            {
                string buffer = words.Dequeue();

                // +1 is for space blank
                while (words.Count != 0 && buffer.Length + 1 + words.ToArray()[0].Length <= _rectangle.Width)
                {
                    buffer += " " + words.Dequeue();
                }
                lines.Add(buffer);
            }

            //Here return lines
            return lines;
        }

        private int NumberOfLines(string sentence)
        {
            return LinesOfSentence(sentence).Count;
        }

        private bool DisplaySentence(string sentence)
        {
            // Checking if the rectangle is inside
            // the Console area
            if (!_rectangle.InConsoleBoundaries())
            {
                return false;
            }


            List<string> lines = this.LinesOfSentence(sentence);
            double numberOfLines = lines.Count;
            double availableVerticalSpace = _rectangle.Top;

            int iterations = (int)Math.Ceiling(numberOfLines / availableVerticalSpace);

            for (int iteration = 0; iteration < iterations; iteration++)
            {
                Console.SetCursorPosition(_rectangle.Left, _rectangle.Top);
                foreach (string line in lines)
                {
                    if (Console.CursorTop >= (_rectangle.Top + _rectangle.Height))
                    {
                        _drawer.Cursor_StandBy();
                        Console.ReadKey();
                        this.Clear();
                        Console.SetCursorPosition(_rectangle.Left, _rectangle.Top);
                    }
                    Console.Write(line);
                    Console.SetCursorPosition(_rectangle.Left, Console.CursorTop + 1);
                }
                _drawer.Cursor_StandBy();
            }




            return true;
        }

        /**
         * This function is used
         * to clear the dialog interface
         * by printing white spaces
         */
        public void Clear()
        {
            string lineCleaner = "";
            for (int character = 0; character < _rectangle.Width; character++)
            {
                lineCleaner += " ";
            }

            for (int line = 0; line < _rectangle.Height; line++)
            {
                Console.SetCursorPosition(_rectangle.Left, _rectangle.Top + line);
                _drawer.Write(lineCleaner);
            }
        }

        /**
         * This function display the dialog box
         * returns :
         * true if OK
         * false if an error has occured
         */
        public bool Display()
        {
            foreach (string sentence in _sentences)
            {
                this.Clear();
                DisplaySentence(sentence);
                _drawer.Cursor_StandBy();
                Console.ReadKey();
            }

            // all is OK
            return true;
        }

        public void Debug()
        {
            Console.SetCursorPosition(0, 0);
            foreach (string sentence in _sentences)
            {
                _drawer.Write(sentence);
                Console.SetCursorPosition(0, Console.CursorTop + 1);
            }
        }
    }
}
