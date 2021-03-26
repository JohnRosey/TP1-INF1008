using System;
using System.Threading;
using System.Windows.Forms;
using TP1_INF1008.Data;
using static TP1_INF1008.Utils.Utils;

/* Choix.cs  ***********************************************************************************************
 **********     @Authors :                                             Date : 01 Avril 2020       **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Gansonre                                                     **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 **********                 * Edgard Koffi                                                        **********
 ***********************************************************************************************************/
/*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
 * Choix.cs
 * ========
 *      Cette Classe Permet l'interactivité avec les Utilisateurs via le Menu
 *      
 *░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░*/

namespace TP1_INF1008
{
    public partial class Choix : Form
    {

        private Map map;
        private Labyrinthe labyrinthe = new Labyrinthe();
        private int MIN = 1;
        private int longueur;
        private int largeur;
        private int max;

        public Choix()
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
                  "\n\t3. Lancer l'algorithme de Prim" +
                   "\n\t4. Afficher à la Console le Labyrinthe" +
                   "\n\t5. Quitter\n");
                Console.Write("Selectionner l'Option : ");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        map = CreationMapAleatoire();
                        labyrinthe.SetMap(map);
                        Console.WriteLine($"Nombre d'opération Initialisation : {map.GetNbreOperation()}");
                        Console.WriteLine($"information dimension : {map}");
                        break;

                    case 2:
                        map = CreationMap();
                        labyrinthe.SetMap(map);
                        Console.WriteLine($"Nombre d'opération : {map.GetNbreOperation()}");
                        Console.WriteLine($"information dimension : {map}");
                        break;

                    case 3:
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
                        Console.WriteLine($"\n\t\t\t===\tNombre Opération Prim : {labyrinthe.GetNbreOperationPrim()}       ===");
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        break;

                    case 4:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\t\t\t===  Afficher à la Console le Labyrinthe  ===");
                        Console.ResetColor();
                        Console.WriteLine(labyrinthe.AffichageLabyrinthe());
                        break;

                    case 5:
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PannelDraggable_MouseDown(object sender, MouseEventArgs e)
        {
            DragMe(Handle);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            DragMe(Handle);
        }
    }
}
