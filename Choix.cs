using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP1_INF1008.Data;
using TP1_INF1008.Model;
using static TP1_INF1008.Data.Map;
using static TP1_INF1008.Model.Noeud;

namespace TP1_INF1008
{
    public partial class Choix : Form
    { private static Map map;
        private static Labyrinthe labyrinthe = new Labyrinthe();
        public Choix()
        {
            InitializeComponent();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            Menu();
            this.Hide();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Labyrinthe().Show();
            this.Hide();
        }
       
        static void Menu()
        {
           /* *********************MENU * *******************/
             int  MIN = 1;
           
            bool conti = true;
            int menu;
            int longueur;
            int largeur;
            int max;
            int nbOperationLabyrinthe =0;
            while (conti)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine("SAISIR VOTRE CHOIX ");
                Console.WriteLine("===================================================");
                Console.WriteLine("1.Generer le Labyrinthe ");
                Console.WriteLine("2.Lancer l'algorithme de Prim");
                Console.WriteLine("3.Afficher à la Console le Labyrinthe");
                Console.WriteLine("4.Afficher dans une fenetre  le Labyrinthe");
                Console.WriteLine("5.Enregister Solution");
                Console.WriteLine("6. Quiter");

                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("1.===  Generer le Labyrinthe ");

                        Console.WriteLine(" Entrer longeur");
                        longueur = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(" Entrer largeur");
                        largeur = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(" Entrer max");
                        max = Convert.ToInt32(Console.ReadLine());
                        map = new Map(longueur, largeur);
                        labyrinthe.SetMap(map);
                        map.PoidsAleatoires(MIN, max);


                        nbOperationLabyrinthe += map.GetNbreOperation();
                        Console.WriteLine($"Nombre d'opération : {nbOperationLabyrinthe}"); 
                        Console.WriteLine($"information dimension : {map}"); 
                        break;

                    case 2:
                        Console.WriteLine("2.Lancer l'algorithme de Prim");
                        // execution de l'algorithme de Prim
                        labyrinthe.Prim();
                        break;

                    case 3:
                        Console.WriteLine("3.Afficher à la Console le Labyrinthe");
                        Console.WriteLine(labyrinthe.AffichageLabyrinthe());
                        //statement 
                        break;

                    case 4:
                        Console.WriteLine("4.Afficher dans une fenetre  le Labyrinthe");
                        break;

                    case 5:
                        Console.WriteLine("Enregistrer la solution");
                        Console.WriteLine("================");


                        Boolean botemp = true;
                        while (botemp)
                        {
                            Console.WriteLine("===================================================");
                            Console.WriteLine("SAISIR VOTRE CHOIX ");
                            Console.WriteLine("===================================================");
                            Console.WriteLine("l.Enregistrer le Layrinthe sur un fichier (Labyrinthe.txt)");
                            Console.WriteLine("i.Enregistrer les informations de Calcul (infoCalcul.txt)");
                            Console.WriteLine(" .Autre chose pour Anuller");
                            string sousmenu = Console.ReadLine();
                            switch (sousmenu)
                            {
                                case "l":
                                    Console.WriteLine("l.Enregistrer le Layrinthe sur un fichier (Labyrinthe.txt)");
                                    //statement 
                                    break;

                                case "i":
                                    //statement 
                                    Console.WriteLine("i.Enregistrer les informations de Calcul (infoCalcul.txt)");
                                    break;


                                default:
                                    Console.WriteLine("Annulation Reussi");
                                    botemp = false;
                                    break;
                            }
                        }


                        break;


                    case 6:
                        Console.WriteLine("AU REVOIR MERCI");

                        Console.WriteLine("================");
                        conti = false;
                        break;

                    default:

                        Console.WriteLine("Saisir quelque chose de correct please");

                        break;

                }
            }


            // Enregistrement du Labyrinthe produit au fichier .txt
            //**  saveToFile();
        }
    }
}
