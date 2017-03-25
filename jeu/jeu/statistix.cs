namespace jeu
{
	internal class statistix
    {
        //attributs a sauvegarder
        public int taptaptap;
        public long temps_de_jeu;
        public int money;
        public int vie_max_joueur;
        public void Ecriture_Sauvegarde()
        {
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = {taptaptap.ToString(), temps_de_jeu.ToString(), money.ToString(), vie_max_joueur.ToString()};
            System.IO.File.WriteAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.txt", lines);
            /*lines = System.IO.File.ReadAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.txt");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                System.Console.WriteLine("\t" + line);
            }*/
        }
        public void Lecture_Sauvegarde()
        {
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = null;
            if(System.IO.File.Exists(@"C: \Users\Public\SAVE_CMD_adventure")){
                lines = System.IO.File.ReadAllLines(@"C:\Users\Public\SAVE_CMD_adventure\save.txt");
                int.TryParse(lines[0], out taptaptap);
                long.TryParse(lines[1], out temps_de_jeu);
                int.TryParse(lines[2], out money);
                int.TryParse(lines[3], out vie_max_joueur);
            }
            else
            {
                System.Console.WriteLine("Sauvegarde inexistante.");
            }                
        }
        //attribut sans sauvegarde
        public int vie_joueur;
    }
}