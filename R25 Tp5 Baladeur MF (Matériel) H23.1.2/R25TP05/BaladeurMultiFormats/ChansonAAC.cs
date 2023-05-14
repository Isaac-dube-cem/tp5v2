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
        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {
            
        }
        public ChansonAAC(string pRépertoire, string pArtiste, string pTitre, int pAnnée) : base(pRépertoire, pArtiste, pTitre, pAnnée)
        {
            

        }
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine("TITRE = " + Titre + " : " + "ARTISTE = " + Artiste + " : " + "ANNÉE = " + Annee);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string ecrire = OutilsFormats.EncoderAAC(pParoles);
            pobjFichier.WriteLine(ecrire);
        }

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

        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string infos = pobjFichier.ReadToEnd();
            OutilsFormats.DecoderAAC(infos);
            return infos;
        }
        #endregion
    }
}
