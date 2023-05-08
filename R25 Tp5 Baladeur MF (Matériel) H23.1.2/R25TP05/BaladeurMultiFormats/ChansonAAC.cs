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
        #region Champs
        public override string Format { get; }
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
            OutilsFormats.EncoderAAC(pParoles);
            pobjFichier.WriteLine(pParoles);
        }

        public override void LireEntete()
        {
            StreamReader Fichier = new StreamReader(m_nomFichier);
            string infos = Fichier.ReadLine();
            
            string [] points = infos.Split(':');
            string [] titre = points[0].Split('=');
            string [] artiste = points[1].Split('=');
            string[] annee = points[2].Split('=');

            m_titre = titre[1].Trim();
            m_artiste = artiste[1].Trim();
            m_annee = int.Parse(annee[1].Trim());

            Fichier.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            OutilsFormats.DecoderAAC(pobjFichier.ToString());
            return pobjFichier.ToString();
        }
        #endregion
    }
}
