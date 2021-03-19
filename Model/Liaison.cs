using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Liaison.cs  *********************************************************************************************
 **********     @Authors :                                             Date : 01 Avril 2020       **********
 **********                 * Josue Lubaki                                                        **********
 **********                 * Ismael Gansonre                                                     **********
 **********                 * Jordan Kuibia                                                       **********
 **********                 * Jonathan Kanyinda                                                   **********
 ***********************************************************************************************************/

namespace TP1_INF1008.Model
{
    public partial class Liaison : IComparable<Liaison>
    {
        // Cette Classe permet la Liaison des differents Noeud dans le labyrinthe
        private Noeud nodeDepart;
        private Noeud nodeArrive;
        private int poids;

        public Liaison(Noeud nodeDepart, Noeud nodeArrive, int poids)
        {
            // Eviter de mettre en liaison le même Noeud avec lui-même
            if (nodeDepart.Equals(nodeArrive))
                throw new Exception("Ces cases ont la même position sur le Labyrinthe");

            this.poids = poids;

            // Essayer de mettre en ordre croissant les liaisons
            if (nodeDepart.CompareTo(nodeArrive) < 0)
            {
                this.nodeDepart = nodeDepart;
                this.nodeArrive = nodeArrive;
            }
            else
            {
                this.nodeDepart = nodeArrive;
                this.nodeArrive = nodeDepart;
            }
        }

        public Noeud NodeDepart
        {
            get { return nodeDepart; }
            set { nodeDepart = value; }
        }

        public Noeud NodeArrive
        {
            get { return nodeArrive; }
            set { nodeArrive = value; }
        }

        public int Poids
        {
            get { return poids; }
            set { poids = value; }
        }

        /**
         * Vérifier si la Liaison reçue en paramètre est pareille que l'instance
         * @return bool
         */
        public override bool Equals(object obj)
        {
            // Vérifier si c'est une Liaison
            if (!(obj is Liaison))
                return false;

            Liaison link = (Liaison)obj;

            return this.nodeDepart.Equals(link.nodeDepart) &&
                this.nodeArrive.Equals(link.nodeArrive) &&
                this.poids == link.poids;
        }


        public int CompareTo(Liaison other)
        {
            int tempo;

            // Si le poids de deux Liaisons sont égales
            if(this.poids == other.poids)
            {
                tempo = this.nodeArrive.CompareTo(other.nodeArrive);
                if (tempo != 0)
                    return tempo;
                else
                    return this.nodeDepart.CompareTo(other.nodeDepart);
            }

            return (this.poids < other.poids) ? -1 : 1;
        }

        public override int GetHashCode()
        {
            int hash = nodeDepart.PosX * 31 + nodeArrive.PosY;
            hash = hash * 31 + nodeArrive.PosX;
            hash = hash * 31 + nodeArrive.PosX;
            hash = hash * 31 + poids;

            return hash;
        }

        /**
        * Retourne la coordonnée x de la liaison si elle était plassée dans une grille.
        * Exemple: Si cette {@link Liaison} relie deux {@link Case} (0,0) et (1,0).
        * Elle aurait les coordonées (2,0).
        * case - liaison - case
        *
        * Par rapport aux {@link Case} avec des coordonées côte à côte,
        * ici elle on leurs coordonées multipliées par deux.
        *
        * @return La coordonée x de la liaison.
        */
        public int GetCoordX()
        {
            return NodeDepart.PosX*2 + (NodeArrive.PosX - NodeDepart.PosX);
        }

        /**
         * Retourne la coordonnée y de la liaison si elle était plassée dans une grille.
         * Exemple: Si cette {@link Liaison} relie deux {@link Case} (0,0) et (1,0).
         * Elle aurai les coordonées (2,0).
         * case - liaison - case
         *
         * Par rapport aux {@link Case} avec des coordonées côte à côte,
         * ici elle on leurs coordonées multipliées par deux.
         *
         * @return La coordonée y de la liaison.
         */
        public int getCoordY()
        {
            return NodeDepart.PosY * 2 + (NodeArrive.PosY - NodeDepart.PosY);
        }

        public override string ToString()
        {
            return $"NodeDepart: {nodeDepart}, NodeArrive: {NodeArrive}, Poids: {poids}";
        }
    }
}
