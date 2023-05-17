using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        #region Propriétés
        public override string Format { get { return "mp3"; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// initialise une instance et retourne le fichier à la classe de base Chanson
        /// </summary>
        /// <param name="pNomFichier">Fichier de la chanson courante</param>
        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {

        }
        /// <summary>
        /// initialise une instance et retourne tous les valeurs dans les paramètres à la classe de base Chanson
        /// </summary>
        /// <param name="pRepertoire">répertoire ou se trouve tous les chansons</param>
        /// <param name="pArtiste">Nom de l'artiste</param>
        /// <param name="pTitre">Nom de la chanson</param>
        /// <param name="pAnnée">Année de la publication de la chanson</param>
        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }

        /// <summary>
        /// écrit une ligne avec les informations sur la chanson dans le fichier en paramètres avec le format MP3
        /// </summary>
        /// <param name="pobjFichier">Fichier de la chanson courante à écrire l'entete</param>
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(Artiste + " | " + Annee + " | " + Titre);
        }

        /// <summary>
        /// encode les paroles recu en paramètres dans le format MP3, puis les écrits dans le fichier de la chanson
        /// </summary>
        /// <param name="pobjFichier">fichier de la chanson</param>
        /// <param name="pParoles">paroles de la chanson à écrire</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string ecrire = OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.WriteLine(ecrire);
        }

        /// <summary>
        /// lit une ligne dans le fichier de la chanson pour aller récupérer les informations et les mettres dans les champs de la chanson
        /// </summary>
        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(m_nomFichier);
            string infos = fichier.ReadLine();
            string[] barre = infos.Split('|');
            
            m_artiste = barre[0].Trim();
            m_annee = int.Parse(barre[1].Trim());
            m_titre = barre[2].Trim();

            fichier.Close();
        }

        /// <summary>
        /// lit les paroles de la chanson, les décodes dans le format MP3 et les retournes 
        /// </summary>
        /// <param name="pobjFichier"></param>
        /// <returns>les paroles de la chanson décodé</returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string infos = pobjFichier.ReadToEnd();
            OutilsFormats.DecoderMP3(infos);
            return infos;
        }
        #endregion
    }
}
