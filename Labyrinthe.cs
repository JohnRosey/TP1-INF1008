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
        private HashSet<Liaison> liaisonFinale = null;
        private int largeur;
        private int longueur;
        public static Labyrinthe UserInterface;

        public Labyrinthe()
        {
            InitializeComponent();
            UserInterface = this;
            Labyrinthe(15, 15, 1, 5);
            saveToFile();
        }

        /**
         * Crée une instance de {@link Labyrinthe} de dimension {@code longueur}
         * et {@code largeur}.
         * Les liaisons entre les cases sont générées à partire de valeurs aléatoire
         * bornées entre {@code min} et {@code max}.
         *
         * @param longueur La longueur du nouveau {@link Labyrinthe}.
         * @param largeur  la largeur du nouveau {@link Labyrinthe}.
         * @param min      Le minimum des valeurs aléatoires pour les liaison (inclue).
         * @param max      Le maximum des valeurs aléatoires pour les liaison (exclue).
         * @throws IllegalArgumentException Si la longeur ou la largeur est inférieure ou égale à zéro.
         */
        public Labyrinthe(int longueur, int largeur, int min, int max)
        {
            map = new Map(longueur, largeur);
            map.metDesValeursAleatoires(min, max);
            nbOperationLabyrinthe += map.getNbOperationMap();
        }

        /**
         * Sauvegarde sous un format visuel le labyrunthe avec comme mur, les liaisons données.
         */
        public void saveToFile()
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath("C:\\Users\\josue\\Desktop\\GitHub\\TP1-INF1008");
            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "solution.txt"), true))
            {
                outputFile.WriteLine(Liaison.ToString() + "\nelle fonctionne !");
            }
            
        }
    }
}
