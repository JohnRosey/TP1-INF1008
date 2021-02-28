using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1_INF1008.Enum;
using static TP1_INF1008.Enum.Direction;

namespace TP1_INF1008.Model
{
    class Noeud : IComparable<Noeud>
    {
        private int posX;
        private int posY;
        private Labyrinthe labyrinthe;

        // Le Noeud représente nos Cases du labyrinthe
        public Noeud(Labyrinthe labyrinthe, int posX, int posY)
        {
            this.labyrinthe = labyrinthe;
            this.posX = posX;
            this.posY = posY;
        }

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public override string ToString()
        {
            return $"({posX},{posY})";
        }


        // Case égale
        public override bool Equals(object obj)
        {
            // Vérifier si l'objet est une Case (instanceof Noeud)
            if (!(obj is Noeud))
                return false;

            Noeud node = (Noeud)obj;

            // Si les coordonnées en X et Y correspondent ou pas
            return this.posX == node.posX && this.posY == node.posY;
        }


        public int CompareTo(Noeud other)
        {
            if (this.Equals(other))
                return 0;
            else if (this.posY < other.posY || 
                (this.posY == other.posY && this.posX < other.posX))
            {
                return -1;
            }
            return 1;
        }


        public override int GetHashCode()
        {
            int hash = labyrinthe.hashCode() * 31 + x;
            hash = hash * 31 + y;
            return hash;
        }


        /**
         * Methode permetant de Vérifier si le voisin existe
         * @return bool
         */
        public void siVoisinExiste(Direction direction)
        {
            switch (direction)
            {
                case HAUT:
                    if (y == 0)
                        throw new ArgumentNullException("Cette case n'a pas de voisin en HAUT");
                    break;
                case DROITE:
                    if (x == labyrinthe.getMap().getLongueur() - 1)
                        throw new ArgumentNullException("Cette case n'a pas de voisin a DROITE");
                    break;
                case BAS:
                    if (y == labyrinthe.getMap().getLargeur() - 1)
                        throw new ArgumentNullException("Cette case n'a pas de voisin en BAS");
                    break;
                case GAUCHE:
                    if (x == 0)
                        throw new ArgumentNullException("Cette case n'a pas de voisin a GAUCHE");
                    break;
            }
        }


        public Liaison getLiaison(Direction direction)
        {
            siVoisinExiste(direction);
            //Map map = labyrinthe.getMap();

            return new Liaison(this, getVoisin(direction), getValeurLiaison(direction));
        }

        public enum Direction
        {
            HAUT = 0,
            DROITE = 1,
            BAS = 2,
            GAUCHE = 3
        }

        public Case getVoisin(Directions direction)
        {
            siVoisinExiste(direction);

            switch (direction)
            {
                case HAUT:
                    return labyrinthe.getCase(x, y - 1);
                case DROITE:
                    return labyrinthe.getCase(x + 1, y);
                case BAS:
                    return labyrinthe.getCase(x, y + 1);
                case GAUCHE:
                    return labyrinthe.getCase(x - 1, y);
                default:
                    throw new IllegalArgumentException("Direction inconnue.");
            }
        }

    }
}
