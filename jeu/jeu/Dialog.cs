using geometry;
using System.Collections.Generic;

namespace jeu
{
    class Dialog
    {
        private Rectangle rectangle;
        private List<string> dialog;

        public Dialog(Rectangle rectangle, List<string> dialog)
        {
            this.rectangle = rectangle;
            this.dialog = dialog;
        }

        public Dialog(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.dialog = new List<string>();
        }

        public void AddSentence(string sentence)
        {
            if (sentence == "")
            {
                throw new System.Exception("The sentence must not be empty");
            }
            dialog.Add(sentence);
        }

        /**
         * This function display the dialog box
         * returns :
         * true if OK
         * false if an error has occured
         */
        public bool Display()
        {
            foreach (string sentence in dialog)
            {
                // Checking if the rectangle is inside
                // the Console area
                if (!rectangle.IsInConsoleBoundaries())
                {
                    return false;
                }
                // Checking if there is enough space
                // in the dialog box for displaying the sentence
                if (sentence.Length <= rectangle.Area)
                {
                    if (true)
                    {

                    }
                }
            }

            // all is OK
            return true;
        }
    }
}
