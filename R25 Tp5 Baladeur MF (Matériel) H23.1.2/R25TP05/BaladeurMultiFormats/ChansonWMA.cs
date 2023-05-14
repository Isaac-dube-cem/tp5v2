using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        #region Champs
        private int m_codage;
        #endregion

        #region Propriétés
        public override string Format { get { return "wma"; } }
        #endregion
        #region Méthodes
        public ChansonWMA(string pNomFichier) : base(pNomFichier)
        {

        }
        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(m_codage + "/" + Annee + "/" + Titre + "/" + Artiste);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string parolesWMA = OutilsFormats.EncoderWMA(pParoles, m_codage);
            pobjFichier.WriteLine(parolesWMA);
        }
        
        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(m_nomFichier);
            string infos = fichier.ReadLine();
            string[] slash = infos.Split('/');
            m_codage = int.Parse(slash[0].Trim());
            m_annee = int.Parse(slash[1].Trim());
            m_titre = slash[2].Trim();
            m_artiste = slash[3].Trim();
            fichier.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string infos = pobjFichier.ReadToEnd();
            OutilsFormats.DecoderWMA(infos, m_codage);
            return infos;
        }
        #endregion
    }
}
