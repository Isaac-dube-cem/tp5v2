using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        #region Propriétés
        public override string Format { get { return "aac"; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// initialise une instance et retourne le fichier à la classe de base Chanson
        /// </summary>
        /// <param name="pNomFichier">Fichier de la chanson courante</param>
        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {
            
        }
        /// <summary>
        /// initialise une instance et retourne tous les valeurs dans les paramètres à la classe de base Chanson
        /// </summary>
        /// <param name="pRépertoire">répertoire ou se trouve tous les chansons</param>
        /// <param name="pArtiste">Nom de l'artiste</param>
        /// <param name="pTitre">Nom de la chanson</param>
        /// <param name="pAnnée">Année de la publication de la chanson</param>
        public ChansonAAC(string pRépertoire, string pArtiste, string pTitre, int pAnnée) : base(pRépertoire, pArtiste, pTitre, pAnnée)
        {
            

        }
        /// <summary>
        /// écrit une ligne avec les informations sur la chanson dans le fichier en paramètres avec le format AAC
        /// </summary>
        /// <param name="pobjFichier">Fichier de la chanson courante à écrire l'entete</param>
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine("TITRE = " + Titre + " : " + "ARTISTE = " + Artiste + " : " + "ANNÉE = " + Annee);
        }

        /// <summary>
        /// encode les paroles recu en paramètres dans le format AAC, puis les écrits dans le fichier de la chanson
        /// </summary>
        /// <param name="pobjFichier">fichier de la chanson</param>
        /// <param name="pParoles">paroles de la chanson à écrire</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string AAC = OutilsFormats.EncoderAAC(pParoles);
            pobjFichier.WriteLine(AAC);
        }

        /// <summary>
        /// lit une ligne dans le fichier de la chanson pour aller récupérer les informations et les mettres dans les champs de la chanson
        /// </summary>
        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(m_nomFichier);
            string infos = fichier.ReadLine();
            
            string [] points = infos.Split(':');
            string [] titre = points[0].Split('=');
            string [] artiste = points[1].Split('=');
            string[] annee = points[2].Split('=');

            m_titre = titre[1].Trim();
            m_artiste = artiste[1].Trim();
            m_annee = int.Parse(annee[1].Trim());

            fichier.Close(); 
        }

        /// <summary>
        /// lit les paroles de la chanson, les décodes dans le format AAC et les retournes 
        /// </summary>
        /// <param name="pobjFichier"></param>
        /// <returns>les paroles de la chanson décodé</returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string infos = pobjFichier.ReadToEnd();
            string paroles = OutilsFormats.DecoderAAC(infos);
            return paroles;
        }
        #endregion
    }
}
