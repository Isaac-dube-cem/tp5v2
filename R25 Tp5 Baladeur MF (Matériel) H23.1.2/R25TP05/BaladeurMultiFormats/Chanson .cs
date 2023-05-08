using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        #region Champs
        protected int m_annee;

        protected string m_artiste;

        protected string m_nomFichier;

        protected string m_titre;
        #endregion

        #region Propriétés
        public int Annee { get { return m_annee; } }

        public string Artiste { get { return m_artiste; } }

        public abstract string Format { get; }

        public string NomFichier { get { return m_nomFichier; } }

        public string Paroles { get; }

        public string Titre { get { return m_titre; } }
        #endregion

        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
            
        }
        public Chanson(string pRépertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_nomFichier = pRépertoire + "\\" + Titre + '.' + Format;
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnée;
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
