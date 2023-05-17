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

        /// <summary>
        /// initialise une instance, prend le nom du fichier et lit l'entete
        /// </summary>
        /// <param name="pNomFichier">Chanson passé en paramètre</param>
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRépertoire">répertoire ou se trouve les chansons</param>
        /// <param name="pArtiste">Nom de l'artiste</param>
        /// <param name="pTitre">Nom de la chanson</param>
        /// <param name="pAnnée">Année de la publication de la chanson</param>
        public Chanson(string pRépertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_nomFichier = pRépertoire + "\\" + Titre + "." + Format;
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

        /// <summary>
        /// Méthode définis dans les classes dérivé
        /// </summary>
        /// <param name="pobjFichier">Fichier de la chanson courante</param>
        public abstract void EcrireEntete(StreamWriter pobjFichier);

        /// <summary>
        /// Méthode définis dans les classes drivé
        /// </summary>
        /// <param name="pobjFichier">Fichier de la chanson courante</param>
        /// <param name="pParoles">paroles de la chanson courante</param>
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        /// <summary>
        /// Méthode défnis dans les classes dérivé
        /// </summary>
        public abstract void LireEntete();

        /// <summary>
        /// Méthode définis dan les classes dérivé
        /// </summary>
        /// <param name="pobjFichier">fichier de la chanson courante</param>
        /// <returns></returns>
        public abstract string LireParoles(StreamReader pobjFichier);

        /// <summary>
        /// lit une ligne du fichier pour sauter l'entete
        /// </summary>
        /// <param name="pobjFichier">fichier de la chanson courante</param>
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }
    }
}
