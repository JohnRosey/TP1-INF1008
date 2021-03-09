using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP1_INF1008.Data;
using TP1_INF1008.Model;

namespace TP1_INF1008
{
    public partial class Labyrinthe : Form
    {

        private Map map;
        private static string adresse = "output.txt";
        //private HashSet<Liaison> liaisonFinale = null;
        private int largeur;
        private int longueur;
        private static int MIN = 1;
        private int max;
        public static Labyrinthe UserInterface;
        private static int nbOperationLabyrinthe;
        private HashSet<Liaison> liaisonsFinales = null;

        public Labyrinthe()
        {
            InitializeComponent();
            UserInterface = this;
        }

        /* Methode qui permet d'aller chercher un Noeud sur la Map */
        public Noeud GetNoeud(int posX, int posY)
        {
            map.isValideXY(posX, posY);
            return new Noeud(this, posX, posY);
        }

        public Map GetMap()
        {
            return map;
        }

        /**
         * Sauvegarde sous un format visuel le labyrunthe avec comme mur, les liaisons données.
         */
        // TODO : Chercher une meilleure methode
        public void saveToFile()
        {
            File.WriteAllText(adresse, $"{lbl_infoDimension.Text} \n{lbl_operation.Text}\n\t\tLabyrinthe" +
                $"\n{this.ToString()}");
        }


        private void Labyrinthe_Load(object sender, EventArgs e)
        {

        }

        // Lorsqu'on clique sur le Bouton Générer
        private void btn_generer_Click(object sender, EventArgs e)
        {
            // Binding Data with User Interface
            longueur = Convert.ToInt32(txtBox_Longueur.Text.ToString());
            largeur = Convert.ToInt32(txtBox_Largeur.Text.ToString());
            max = Convert.ToInt32(txtBox_max.Text.ToString());

            map = new Map(longueur, largeur);
            map.PoidsAleatoires(MIN, max);
            nbOperationLabyrinthe += map.GetNbreOperation();
            lbl_operation.Text = $"Nombre d'opération : {nbOperationLabyrinthe}";
            lbl_infoDimension.Text = $"information dimension : {map.ToString()}";
            saveToFile();
            
        }


        public override string ToString()
        {
            // Vérifier si la methode de prim a déjà été executée au préalable
            if (liaisonsFinales == null)
            {
                Console.WriteLine("Commencer par Lancer l'algorithme de PRIM !");
                MessageBox.Show("Commencer par Lancer l'algorithme de PRIM !");
                return null;
            }
                

            StringBuilder str = new StringBuilder();

            Liaison[][] ecran = new Liaison[GetMap().GetLargeur * 2 - 1][];
            for (int y = 0; y < (GetMap().GetLargeur * 2) - 1; y++)
            {
                ecran[y] = new Liaison[GetMap().GetLongueur * 2 - 1];
            }

            // parcourir les liaisons pour les ajouter dans le Tableau
            Liaison tmp;
            foreach (Liaison item in liaisonsFinales)
            {
                tmp = item;
                int tmp_y = tmp.getCoordY();
                int tmp_x = tmp.GetCoordX();
                ecran[tmp_y][tmp_x] = tmp;
            }

            for (int y = 0; y < GetMap().GetLongueur * 2 - 1; y++)
            {
                for (int x = 0; x < GetMap().GetLargeur * 2 - 1; x++)
                {

                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        str.Append(ProduireDirectionLiaison(
                            ElementExiste(x, y - 1, ecran),
                            ElementExiste(x + 1, y, ecran),
                            ElementExiste(x, y + 1, ecran),
                            ElementExiste(x - 1, y, ecran)
                            ));
                    }
                    else if(x % 2 == 1 && y % 2 == 0)
                    {
                        // liaison Horizontale
                        if (ElementExiste(x, y, ecran))
                            str.Append("═"); // Alt + 205
                        else
                            str.Append(" ");
                    }
                    else if (x % 2 == 0)
                    {
                        // Liaison verticale
                        if (ElementExiste(x, y, ecran))
                            str.Append("║"); // Alt + 186
                        else
                            str.Append(" ");
                    }
                    else
                    {
                        str.Append(" ");
                    }
                    str.Append(" ");
                }
                str.Append("\n");
            }

            return str.ToString();
        }


        /** Fonction assez Générique qui vérifie un élément au coordinnée x et y existe dans le tableau ou pas
         * return bool
         */
        private bool ElementExiste(int x, int y, Object[][] table)
        {
            try
            {
                return table[y][x] != null; 
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException($"la valeur {x} et {y} fournis ne sont pas valides");
            }
        }


        // Représentation des murs
        private string ProduireDirectionLiaison(bool haut, bool droite, bool bas, bool gauche)
        {
            // 1___
            if (haut) 
            {
                return 
                    droite ?
                        #region 11__
                            (bas ?

                                #region 111_
                                    (gauche ?
                                        "╬" : // 1111 (Alt + 206)
                                        "╠" // 1110 (Alt + 204)
                                    ) :
                                #endregion

                                #region 110_
                                    (gauche ?
                                        "╩" : // 1101 (Alt + 202)
                                        "╚" // 1100 (Alt + 200)
                                    ) 
                                #endregion
                            ) :
                        #endregion

                        #region 10__
                            (bas ?

                                #region 101_
                                    (gauche ?
                                        "╣" : // 1011(Alt + 185)
                                        "║" // 1010(Alt + 186)
                                    ) :
                                #endregion

                                #region 100_
                                    (gauche ?
                                        "╝" : // 1001 (Alt + 188)
                                        "║" // 1000 (Alt + 186)
                                    ) 
                                #endregion

                            ); 
                        #endregion
            }
            else
            {
                return
                    droite ?
                        #region 01__
                            (bas ?

                                #region 011_
                                    (gauche ?
                                        "╦" : // 0111 (Alt + 203)
                                        "╔" // 0110 (Alt + 201)
                                    ) :
                                #endregion

                                #region 010_
                                    (gauche ?
                                        "═" : // 0101 (Alt + 205)
                                        "═" // 0100 (Alt + 205) //TODO : doute
                                    )
                                #endregion
                            ) :
                        #endregion

                        #region 00__
                            (bas ?

                                #region 001_
                                    (gauche ?
                                        "╗" : // 0011(Alt + 187)
                                        "║" // 0010(Alt + 186)
                                    ) :
                                #endregion

                                #region 000_
                                    (gauche ?
                                        "═" : // 0001 (Alt + 205)
                                        "?" // Impossible
                                    )
                                #endregion

                            );
                        #endregion
            }
        }


    }
}
