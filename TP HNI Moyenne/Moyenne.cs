using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    //Création de la classe Classe
    public class Classe
    {
        public string nomClasse { get; }
        public List<Eleve> eleves { get; } = new List<Eleve>();
        public List<string> matieres { get; } = new List<string>();


        //Constructeur de la classe Classe
        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
        }

        //Ajout d'un élève à la classe
        public void ajouterEleve(string prenom, string nom)
        {
            eleves.Add(new Eleve(prenom, nom));
        }

        //Ajout d'une matière à la classe
        public void ajouterMatiere(string matiere)
        {
            matieres.Add(matiere);
        }

        //Moyenne de classe par matière
        public float moyenneMatiere(int mat)
        {
            int nbr_note = 0;
            float somme_note = 0;


            for (int i = 0; i < eleves.Count; i++)
            {
                somme_note += eleves[i].moyenneMatiere(mat);
                nbr_note++;
            }
            return (float)Math.Round(somme_note / nbr_note, 2);

        }

        //Moyenne générale de la classe
        public float moyenneGeneral()
        {
            float moyenne = 0;
            int nbr_note = 0;
            float somme_note = 0;

            for (int i = 0; i < eleves.Count; i++)
            {
                for (int j = 0; j < matieres.Count; j++)
                {
                    somme_note += eleves[i].moyenneMatiere(j);
                    nbr_note++;
                }
            }
            moyenne = somme_note / nbr_note;
            return (float)Math.Round(moyenne, 2);
        }


    }

    //Création de la classe Eleve
    public class Eleve
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public List<Note> notes { get; set; } = new List<Note>();


        //Constructeur de la classe Eleve
        public Eleve(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        //Ajout d'une note à l'élève
        public void ajouterNote(Note note)
        {
            notes.Add(note);
        }

        //Moyenne de l'eleve par matière 
        public float moyenneMatiere(int mat)
        {
            float somme_note = 0;
            int nbr_note = 0;
            float moyenne = 0;
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == mat)
                {
                    somme_note += notes[i].note;
                    nbr_note++;
                }
                moyenne = somme_note / nbr_note;
            }
            return (float)Math.Round(moyenne, 2);

        }
        //Moyenne générale de l'élève
        public float moyenneGeneral()
        {
            float moyenne = 0;
            float somme_moy = 0;
            for (int i = 0; i < notes.Count; i++)

            {
                somme_moy += notes[i].note;
            }
            moyenne = somme_moy / notes.Count;
            return (float)Math.Round(moyenne, 2);

        }

    }

}
