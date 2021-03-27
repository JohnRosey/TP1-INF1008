using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP1_INF1008.Data;
using TP1_INF1008.Model;
using static TP1_INF1008.Model.Noeud;
using static TP1_INF1008.Utils.Utils;


/* Labyrinthe.cs  ******************************************************************************************
 **********     @Authors :                                             Date : 01 Avril 2020       **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Gansonre                                                     **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 **********                 * Edgard Koffi                                                        ********** 
 ***********************************************************************************************************/
/*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
 * Labyrinthe.cs
 * =============
 *      Cette Classe permet de d'instancier la map en la donnant les valeurs (Poids) aléatoires, afin de 
 *      générer un Labyrinthe, ensuite demarre la fonction de Prim pour trouver le chemin le plus court.
 *      et enfin, il sauvegarde les resultats des opérations dans lae fichier .txt destinés
 *      
 *░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░*/

namespace TP1_INF1008
{
    public partial class Labyrinthe : Form
    {

        private Map map;
        private int largeur;
        private int longueur;
        private static readonly int MIN = 1;
        private int max;
        public static Labyrinthe UserInterface;
        private static int nbOperationLabyrinthe;
        private HashSet<Liaison> liaisonsFinales = null;
        private int coupPinceau = 0;

        public Labyrinthe()
        {
            InitializeComponent();
            UserInterface = this;
        }


        //Getter de la Solution Finale
        public HashSet<Liaison> LiaisonFinale
        {
            get { return liaisonsFinales; }
        }

        // Getter du nombre de coup de pinceau
        public int CoupPinceau
        {
            get { return coupPinceau; }
            set { coupPinceau = 0; }
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

        public void SetMap(Map newMap)
        {
            this.map = newMap;
        }

        /**
         * Sauvegarde sous un format visuel le labyrunthe avec comme mur, les liaisons données.
         */
        private void SaveToFile()
        {
            // Écrire dans le fichier "LabyrintheDessin.txt"
            File.WriteAllText(adresseLabyrinthe,
                $"\n\t\tLabyrinthe\n\t\t----------\n" +
                $"\n{AffichageLabyrinthe()}");

            // Écrire dans le fichier "LabyrintheCalcul.txt"
            File.WriteAllText(adresseCalcul,
                $"{lbl_infoDimension.Text}\n" +
                $"{lbl_operation_init.Text}\n" +
                $"{lbl_operation_prim.Text}\n" +
                $"{lbl_coup_pinceau.Text}\n" +
                $"{lbl_operation_total.Text}");
        }


        // Lorsqu'on clique sur le Bouton Générer
        private void btn_generer_Click(object sender, EventArgs e)
        {

            // Recuperation des informations necéssaires pour le Labyrinthe à générer
            longueur = Convert.ToInt32(txtBox_Longueur.Text.ToString());
            Console.WriteLine(" Voici le  Labyrinthe  generer avec PRIM:");
            longueur = Convert.ToInt32(txtBox_Longueur.Text.ToString());
            largeur = Convert.ToInt32(txtBox_Largeur.Text.ToString());
            max = Convert.ToInt32(txtBox_max.Text.ToString());

            // initialisation map
            map = new Map(longueur, largeur);

            // Réinitialiser les compteurs d'initialisation
            map.NbreOperation = 0;

            // Affectaction des poids aléatoires
            map.PoidsAleatoires(MIN, max);

            int nbOperationInitialisation = map.NbreOperation;

            // Lancement de la methode de Prim()
            Prim();

            // Réinitialiser le coup de Pinceau
            coupPinceau = 0;

            // Affichage de resultat sur la console
            Console.WriteLine(AffichageLabyrinthe());

            // informations de calcul
            lbl_operation_init.Text = $"Nombre d'opération Initialisation : {nbOperationInitialisation}";
            lbl_operation_prim.Text = $"Nombre d'opération Prim : {nbOperationLabyrinthe}";
            lbl_operation_total.Text = $"Nombre d'opération Total : {nbOperationLabyrinthe + nbOperationInitialisation + coupPinceau}";
            lbl_coup_pinceau.Text = $"Coup de Pinceau : {coupPinceau}";
            lbl_infoDimension.Text = $"information dimension : {map}";

            // Enregistrement des resultats (labyrinthe et calcul sur les fichiers destinés)
            SaveToFile();
        }


        /**
         * La Methode de Prim
         */
        public HashSet<Liaison> Prim()
        {
            nbOperationLabyrinthe = 0;

            HashSet<Liaison> liaisionDechues = new HashSet<Liaison>();
            HashSet<Liaison> liaisonPossible = new HashSet<Liaison>();
            liaisonsFinales = new HashSet<Liaison>();
            HashSet<Noeud> noeudFinale = new HashSet<Noeud>();

            Noeud noeudToAdd = GetNoeud(0, 0);

            // Tant que le nombre cases possibles est inferieur à la surface du map
            while (noeudFinale.Count < GetMap().GetLargeur * GetMap().GetLongueur)
            {
                noeudFinale.Add(noeudToAdd);

                var values = EnumDirection.GetValues<Direction>();

                Liaison liaisonTempo;
                foreach (Direction direction in values)
                {
                    // try si le noeud n'a pas de voisin dans la direction donnée
                    try
                    {
                        liaisonTempo = noeudToAdd.getLiaison(direction);

                        // si la liaison est déjà présente dans les liaisons possibles
                        if (liaisonPossible.Contains(liaisonTempo))
                        {
                            // on supprime la liaison des liaisons possibles
                            // et on l'ajoute dans les liaisons rejété
                            // (car elle connecte deux Case déjà solution)
                            liaisonPossible.Remove(liaisonTempo);
                            liaisionDechues.Add(liaisonTempo);
                        }
                        else if (!liaisionDechues.Contains(liaisonTempo) && !liaisonsFinales.Contains(liaisonTempo))
                        {
                            // on l'ajoute dans les liaisons possibles
                            liaisonPossible.Add(liaisonTempo);
                        }

                    }
                    catch (Exception)
                    {
                        // pass
                    }

                    nbOperationLabyrinthe += 1;
                }


                // S'il y a encore des liaisons possibles
                if (liaisonPossible.Count != 0)
                {
                    // Recherche la prochaine liaison potentielle
                    liaisonTempo = liaisonPossible.Min();

                    // on prend le noeud pas encore dans la solution
                    if (!noeudFinale.Contains(liaisonTempo.NodeDepart))
                        noeudToAdd = liaisonTempo.NodeDepart;
                    else
                        noeudToAdd = liaisonTempo.NodeArrive;

                    // on transfère la liaison de Possible à Solution Finale
                    liaisonPossible.Remove(liaisonTempo);
                    liaisonsFinales.Add(liaisonTempo);
                }
            }

            return liaisonsFinales;
        }


        public string AffichageLabyrinthe()
        {
            // Vérifier si la methode de prim a déjà été executée au préalable
            if (liaisonsFinales == null)
            {
                MessageBox.Show("Commencer par Lancer l'algorithme de PRIM !");
                return null;
            }


            StringBuilder str = new StringBuilder();

            Liaison[][] ecran = new Liaison[GetMap().GetLargeur * 2 - 1][];
            for (int y = 0; y < (GetMap().GetLargeur * 2) - 1; y++)
            {
                ecran[y] = new Liaison[(GetMap().GetLongueur * 2) - 1];
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

            for (int y = 0; y < GetMap().GetLargeur * 2 - 1; y++)
            {
                for (int x = 0; x < GetMap().GetLongueur * 2 - 1; x++)
                {

                    // Si c'est le Premier élément
                    if (x == 0 && y == 0)
                        str.Append("E");
                    else if (x == GetMap().GetLongueur * 2 - 2 && y == GetMap().GetLargeur * 2 - 2)
                        str.Append("S");
                    else if (x % 2 == 0 && y % 2 == 0)
                    {
                        str.Append(ProduireDirectionLiaison(
                            ElementExiste(x, y - 1, ecran),
                            ElementExiste(x + 1, y, ecran),
                            ElementExiste(x, y + 1, ecran),
                            ElementExiste(x - 1, y, ecran)
                            ));
                    }
                    else if (x % 2 == 1 && y % 2 == 0)
                    {
                        // liaison Horizontale
                        if (ElementExiste(x, y, ecran))
                            str.Append("═"); // Alt + 205
                        else
                            str.Append("■");
                    }
                    else if (x % 2 == 0)
                    {
                        // Liaison verticale
                        if (ElementExiste(x, y, ecran))
                            str.Append("║"); // Alt + 186
                        else
                            str.Append("■");
                    }
                    else
                    {
                        str.Append("■");
                    }
                    str.Append(" ");

                    coupPinceau++;
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
                // on l'ignore
            }
            return false;
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

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PannelDraggable_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DragMe(Handle);
        }

        public int GetNbreOperationPrim()
        {
            return nbOperationLabyrinthe;
        }

    }


}
