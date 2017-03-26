namespace jeu
{
	internal class statistix
    {
        //attributs a sauvegarder
        private int taptaptap;
        private long temps_de_jeu;
        private int money;
        private int vie_max_joueur;
        private string nom_joueur = "nameless";
        public void Ecriture_Sauvegarde()
        {
            string pathString = @"C: \Users\Public\SAVE_CMD_adventure";
            System.IO.Directory.CreateDirectory(pathString);
            string[] lines = {taptaptap.ToString(), temps_de_jeu.ToString(), money.ToString(), vie_max_joueur.ToString(),nom_joueur.ToString()};
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
                lines[4] = nom_joueur;
            }
            else
            {
                System.Console.WriteLine("Sauvegarde inexistante.");
                System.Threading.Thread.Sleep(500);
            }                
        }
        //attribut sans sauvegarde
        public int vie_joueur;
        public bool fin_du_jeu;
        public string onglet = "onglet par defaut";


        #region accesseurs
        public int Taptaptap { get => taptaptap; set => taptaptap = value; }
        public long Temps_de_jeu { get => temps_de_jeu; set => temps_de_jeu = value; }
        public int Money { get => money; set => money = value; }
        public int Vie_max_joueur { get => vie_max_joueur; set => vie_max_joueur = value; }
        public string Nom_joueur { get => nom_joueur; set => nom_joueur = value; }
        #endregion accesseurs
    }
}