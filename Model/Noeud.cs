using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1_INF1008.Data;

namespace TP1_INF1008.Model
{
    public partial class Noeud : IComparable<Noeud>
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
            return $"(posX: {posX}, posY:{posY})";
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
            int hash = labyrinthe.GetHashCode() * 31 + posX;
            hash = hash * 31 + posY;
            return hash;
        }

        
        public enum Direction
        {
            HAUT = 0,
            DROITE = 1,
            BAS = 2,
            GAUCHE = 3,
        }

        public static class EnumDirection
        {
            public static IEnumerable<Direction> GetValues<Direction>()
            {
                return Enum.GetValues(typeof(Direction)).Cast<Direction>();
            }
        }

        /**
         * Methode permetant de Vérifier si le voisin existe
         * 
         */
        public void siVoisinExiste(Direction direction)
        {
            switch (direction)
            {
                case Direction.HAUT:
                    if (posY == 0)
                        throw new ArgumentNullException("Cette case n'a pas de voisin en HAUT");
                    break;
                case Direction.DROITE:
                    if (posX == labyrinthe.GetMap().GetLongueur - 1)
                        throw new ArgumentNullException("Cette case n'a pas de voisin a DROITE");
                    break;
                case Direction.BAS:
                    if (posY == labyrinthe.GetMap().GetLargeur - 1)
                        throw new ArgumentNullException("Cette case n'a pas de voisin en BAS");
                    break;
                case Direction.GAUCHE:
                    if (posX == 0)
                        throw new ArgumentNullException("Cette case n'a pas de voisin a GAUCHE");
                    break;
            }
        }


        /*
         * Retourne la Liaison entre l'instance est le Noeud voisin 
         */
        public Liaison getLiaison(Direction direction)
        {
            siVoisinExiste(direction);
            //Map map = labyrinthe.getMap();

            return new Liaison(this, GetNoeudVoisin(direction), GetPoidsLiaison(direction));
        }


        /*
         * Methode qui retourne le poids de la Liaison entre l'instance et le Noeud voisin passée en paramètre
         */
        public int GetPoidsLiaison(Direction direction)
        {
            siVoisinExiste(direction);
            Map map = labyrinthe.GetMap();

            switch (direction)
            {
                case Direction.HAUT:
                    return map.GetPoidsLiaison(posX, posY - 1, false);
                case Direction.DROITE:
                    return map.GetPoidsLiaison(posX, posY, true);
                case Direction.BAS:
                    return map.GetPoidsLiaison(posX, posY, false);
                case Direction.GAUCHE:
                    return map.GetPoidsLiaison(posX - 1, posY, true);
                default:
                    throw new ArgumentException("Direction pas correct");
            }
        }

        /*  Cette Methode retourne un Noeud par rapport à une certaine direction
         */
        public Noeud GetNoeudVoisin(Direction direction)
        {
            siVoisinExiste(direction);

            switch (direction)
            {
                case Direction.HAUT:
                    return labyrinthe.GetNoeud(posX, posY - 1);
                case Direction.DROITE:
                    return labyrinthe.GetNoeud(posX + 1, posY);
                case Direction.BAS:
                    return labyrinthe.GetNoeud(posX, posY + 1);
                case Direction.GAUCHE:
                    return labyrinthe.GetNoeud(posX - 1, posY);
                default:
                    throw new ArgumentException("Direction inconnue.");
            }
        }
    }
}
