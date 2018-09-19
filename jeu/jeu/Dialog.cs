using game;
using geometry;
using System;
using System.Collections.Generic;

namespace jeu
{
    /**
     * A Dialog correspond a List of Sentences
     * and each sentence can be divided in lines
     * for display purposes
     */
    class Dialog
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

        public void AddSentence(string sentence)
        {
            if (sentence == "")
            {
                throw new System.Exception("The sentence must not be empty");
            }
            _sentences.Add(sentence);
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
            if (!_rectangle.IsInConsoleBoundaries())
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
                    Console.Write(line);
                    Console.CursorTop++;
                }
                _drawer.Cursor_StandBy();
            }




            return true;
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
                DisplaySentence(sentence);
                _drawer.Cursor_StandBy();
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
                Console.CursorLeft = 0;
                Console.CursorTop++;
            }
        }
    }
}
