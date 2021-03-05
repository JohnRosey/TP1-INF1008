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
            File.WriteAllText(adresse, $"{lbl_infoDimension.Text} \n{lbl_operation.Text}");
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

    }
}
