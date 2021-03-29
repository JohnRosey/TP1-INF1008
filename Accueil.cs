using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TP1_INF1008.Data;
using static TP1_INF1008.Utils.Utils;

/* Accueil.cs  ***********************************************************************************************
 **********     @Authors :                                             Date : 01 Avril 2020       **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Gansonre                                                     **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 **********                 * Edgard Koffi                                                        **********
 ***********************************************************************************************************/
/*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
 * Accueil.cs
 * ========
 *      Cette Classe Permet l'interactivité avec les Utilisateurs via le Menu
 *      
 *░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░*/

namespace TP1_INF1008
{
    public partial class Accueil : Form
    {

        private Map map;
        private Labyrinthe labyrinthe = new Labyrinthe();
        private int MIN = 1;
        private int longueur;
        private int largeur;
        private int max;

        public Accueil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Labyrinthe().Show();
            this.Hide();
        }

        /**
         * Ma Methode Menu permettant de lancer le Menu principal de la Console ayant 4 Options
         * 1. Générer le Labyrinthe
         * 2. Lancer l'algorithme de Prim
         * 3. Afficher à la Console le Labyrinthe
         * 4. Quitter
         */
        void Menus()
        {
            this.Hide();
            bool flag = true;
            int menu;

            while (flag)
            {

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(
                    "\n\n\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■" +
                    "\n\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ MENU PRINCIPAL ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■" +
                    "\n\t\t\t■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■");
                Console.ResetColor();

                Console.WriteLine("\nVoici les Options disponibles :" +
                  "\n\t1. Générer le Labyrinthe Aléatoire" +
                  "\n\t2. Générer le Labyrinthe Manuellement" +
                  "\n\t3. Générer le Labyrinthe Avec les données de l'Enoncée" +
                  "\n\t4. Lancer l'algorithme de Prim" +
                   "\n\t5. Afficher à la Console le Labyrinthe" +
                   "\n\t6. Quitter\n");
                Console.Write("Selectionner l'Option : ");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        map = CreationMapAleatoire();
                        labyrinthe.SetMap(map);
                        Console.WriteLine($"Nombre d'opération Initialisation : {map.NbreOperation}");
                        Console.WriteLine($"information dimension : {map}");
                        break;

                    case 2:
                        map = CreationMap();
                        labyrinthe.SetMap(map);
                        Console.WriteLine($"Nombre d'opération : {map.NbreOperation}");
                        Console.WriteLine($"information dimension : {map}");
                        break;

                    case 3:
                        map = PreRemplissage();
                        labyrinthe.SetMap(map);
                        Console.WriteLine($"Nombre d'opération : {map.NbreOperation}");
                        Console.WriteLine($"information dimension : {map}");
                        break;

                    case 4:
                        RunAlgoPrim();
                        break;

                    case 5:
                        RunAffichageLabyrinthe();
                        ReinitialisationCompteur(); // Réinitialisation compteurs après Affichage
                        break;

                    case 6:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        flag = false;
                        Console.WriteLine("\n\t\t\tCopyright 2021 - Toute Reproduction Interdite\n\t\t\t\t\t\tMerci !");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Application.Exit();
                        break;

                    default:
                        Console.WriteLine("Saisir quelque chose de correct please");
                        break;
                }
            }

        }


        /**
         * Methode qui permet de Réinitialiser les compteurs 
         */
        private void ReinitialisationCompteur()
        {
            map.NbreOperation = 0;
            labyrinthe.CoupPinceau = 0;
        }


        /**
        * Methode qui demande le démarrage de l'affichage du labyrinthe
        * Verifie si la map a été au préalale initialiser et que l'algorithme de Prim a été lancé
        */
        private void RunAffichageLabyrinthe()
        {
            if (map != null && labyrinthe.LiaisonFinale != null)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t\t\t===  Afficher à la Console le Labyrinthe  ===");
                Console.ResetColor();
                Console.WriteLine(labyrinthe.AffichageLabyrinthe());
                SaveToFile();
            }
            else if (map != null && labyrinthe.LiaisonFinale == null)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tCommencer par Lancer l'algorithme de PRIM !");
                Console.ResetColor();
                Console.WriteLine("\n");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tCommencer par Initialiser votre Labyrinthe (option 1, 2 ou 3)");
                Console.ResetColor();
                Console.WriteLine("\n");
            }

        }


        /**
         * Methode qui demande le démarrage de l'Algorithme de Prim
         * Verifie si la map a été au préalale initialiser avant de pouvoir lancer l'algorithme
         */
        private void RunAlgoPrim()
        {
            if(map != null)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t\t\t===\tLancer l'algorithme de Prim     ===");
                Console.WriteLine("\n\t\t\t\tPrim en cours d'exécution...");
                Console.ResetColor();
                // execution de l'algorithme de Prim
                labyrinthe.Prim();
                Thread.Sleep(500);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\t\t===  Lancement l'algorithme de Prim réussi  ===");
                Console.WriteLine($"\n\t\t\t===\tNombre Opération Prim : {labyrinthe.GetNbreOperationPrim()}\t===");
                Console.ResetColor();
                Console.WriteLine("\n");
                
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\tCommencer par Initialiser votre Labyrinthe (option 1, 2 ou 3)");
                Console.ResetColor();
                Console.WriteLine("\n");
            }
           
        }

        /**
         * Methode qui permet de sauvergarder les données de calcul et le Labyrinthe dans un fichier .txt 
         * depuis la Console 
         */
        private void SaveToFile()
        {
            // Écrire dans le fichier "LabyrintheDessin.txt"
            File.WriteAllText(adresseLabyrinthe,
                $"\n\t\tLabyrinthe\n\t\t----------\n" +
                $"\n{labyrinthe.AffichageLabyrinthe()}");

            // Écrire dans le fichier "LabyrintheCalcul.txt"
            File.WriteAllText(adresseCalcul,
                $"information dimension : {map}\n" +
                $"Nombre d'opération Initialisation : {map.NbreOperation}\n" +
                $"Nombre d'opération Prim : {labyrinthe.GetNbreOperationPrim()}\n" +
                $"Coup de Pinceau : {labyrinthe.CoupPinceau}\n"+
                $"Nombre d'opération Total : {labyrinthe.GetNbreOperationPrim() + map.NbreOperation + labyrinthe.CoupPinceau}");
        }


        /**
         * CreationMapAleatoire : Methode permettant de créer une map à l'aide des informations reçu de l'Utilisateur
         * @param longueur : La longueur du Labyrinthe
         * @param largeur : La Largueur du Labyrinthe
         * @param max : Le poid maximum entre les Cases
         */
        private Map CreationMapAleatoire()
        {

            AskInfoMap();

            Console.WriteLine(" Entrer le poids maximum");
            max = Convert.ToInt32(Console.ReadLine());
            map = new Map(longueur, largeur);

            if (max <= MIN)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrer un poids positif");
                Console.ResetColor();
                return null;
            }

            return map.PoidsAleatoires(MIN, max);
        }

        /**
        * CreationMap : Methode permettant de créer d'initialiser une map à l'aide des informations reçu de l'Utilisateur
        * C'est à L'Utilisateur de donner le poids pour chacune de Liaison
        * @param longueur : La longueur du Labyrinthe
        * @param largeur : La Largueur du Labyrinthe
        * @param max : Le poid maximum entre les Cases
        */
        private Map CreationMap()
        {
            int poids_Droite;
            int poids_Bas;
            AskInfoMap();

            for (int i = 0; i < longueur * largeur; i++)
            {
                do
                {
                    Console.WriteLine("Entrer la poids pour map[{0}]- vers droite : ", i);
                    poids_Droite = Convert.ToInt32(Console.ReadLine());

                    if (poids_Droite <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrer un poids positif (Superieur à 0)");
                        Console.ResetColor();
                    }
                } while (poids_Droite <= 0);

                do
                {
                    Console.WriteLine("Entrer la poids pour map[{0}] - vers Bas : ", i);
                    poids_Bas = Convert.ToInt32(Console.ReadLine());
                    if (poids_Bas <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrer un poids positif (Superieur à 0)");
                        Console.ResetColor();
                    }
                } while (poids_Bas <= 0);

                // Affectactions des Poids dans la Map
                map.AffectationPoids(i, poids_Droite, true);
                map.AffectationPoids(i, poids_Bas, false);
            }

            return map;
        }


        /**
         * Methode qui demande à l'Utilisateur les informations de la Map à générer
         * Permet de recueillir les informations sur la Taille du Map
         */
        private void AskInfoMap()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t\t\t===  Génération du Labyrinthe  === ");
            Console.ResetColor();

            Console.WriteLine(" Entrer la longueur du Labyrinthe (Horizontal)");
            longueur = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" Entrer la largeur du Labyrinthe (Vertical)");
            largeur = Convert.ToInt32(Console.ReadLine());
        }


        /**
         * Methode qui permet de remplir la map avec les données fourni sur l'Énoncée du travail
         * @return Map
         */
        public Map PreRemplissage() {

            // initialisation de la map
            map = new Map(6, 4);

            // Remplissage des poids
            map.AffectationPoids(0, 5, true);
            map.AffectationPoids(0, 2, false);
            map.AffectationPoids(1, 4, true);
            map.AffectationPoids(1, 3, false);
            map.AffectationPoids(2, 5, true);
            map.AffectationPoids(2, 8, false);
            map.AffectationPoids(3, 10, true);
            map.AffectationPoids(3, 1, false);
            map.AffectationPoids(4, 7, true);
            map.AffectationPoids(4, 3, false);
            map.AffectationPoids(5, 0, true);
            map.AffectationPoids(5, 4, false);

            map.AffectationPoids(6, 3, true);
            map.AffectationPoids(6, 4, false);
            map.AffectationPoids(7, 8, true);
            map.AffectationPoids(7, 9, false);
            map.AffectationPoids(8, 2, true);
            map.AffectationPoids(8, 4, false);
            map.AffectationPoids(9, 1, true);
            map.AffectationPoids(9, 7, false);
            map.AffectationPoids(10, 5, true);
            map.AffectationPoids(10, 2, false);
            map.AffectationPoids(11, 0, true);
            map.AffectationPoids(11, 3, false);

            map.AffectationPoids(12, 2, true);
            map.AffectationPoids(12, 2, false);
            map.AffectationPoids(13, 8, true);
            map.AffectationPoids(13, 1, false);
            map.AffectationPoids(14, 6, true);
            map.AffectationPoids(14, 9, false);
            map.AffectationPoids(15, 2, true);
            map.AffectationPoids(15, 10, false);
            map.AffectationPoids(16, 3, true);
            map.AffectationPoids(16, 6, false);
            map.AffectationPoids(17, 0, true);
            map.AffectationPoids(17, 7, false);

            map.AffectationPoids(18, 8, true);
            map.AffectationPoids(18, 0, false);
            map.AffectationPoids(19, 9, true);
            map.AffectationPoids(19, 0, false);
            map.AffectationPoids(20, 3, true);
            map.AffectationPoids(20, 0, false);
            map.AffectationPoids(21, 4, true);
            map.AffectationPoids(21, 0, false);
            map.AffectationPoids(22, 5, true);
            map.AffectationPoids(22, 0, false);
            map.AffectationPoids(23, 0, true);
            map.AffectationPoids(23, 0, false);

            return map;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * Permet à la Fenetre de se deplacer (Draggable)
         */
        private void PannelDraggable_MouseDown(object sender, MouseEventArgs e)
        {
            DragMe(Handle);
        }

        /**
         * Permet à la Fenetre de se deplacer (Draggable)
         */
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            DragMe(Handle);
        }
    }
}
