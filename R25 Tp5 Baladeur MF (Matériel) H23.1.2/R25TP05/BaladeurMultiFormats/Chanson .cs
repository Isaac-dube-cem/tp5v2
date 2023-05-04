using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormatsTests
{
    public abstract class Chanson : IChanson
    {
        #region Champs
        private int m_annee;

        private string m_artiste;

        private string m_nomFichier;

        private string m_titre;
        #endregion

        #region Propriétés
        public int Annee { get; }

        public string Artiste { get; }

        public abstract string Format { get; }

        public string NomFichier { get; }

        public string Paroles { get; }

        public string Titre { get; }
        #endregion

        public Chanson(string pNomFichier)
        {
            NomFichier = pNomFichier;
            LireEntete();
        }
        public Chanson(string pRepertoire, string pArtiste, string pTitre)
        {
            NomFichier = pRepertoire + Format;
            Artiste = pArtiste;
            Titre = pTitre;
        }

        public void Ecrire(string pParoles)
        {
            StreamWriter Fichier = new StreamWriter(NomFichier);

            EcrireEntete(Fichier);
            Fichier.WriteLine(pParoles);
            Fichier.Close();
        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);

        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        public abstract void LireEntete();

        public abstract string LireParoles(StreamReader pobjFichier);

        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }
    }
}
