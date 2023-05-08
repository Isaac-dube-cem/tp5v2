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
        #region Champs
        public override string Format { get; }
        #endregion

        #region Méthodes
        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {

        }
        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(Artiste + " | " + Annee + " | " + Titre);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.WriteLine(pParoles);
        }

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

        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string infos = pobjFichier.ReadToEnd();
            OutilsFormats.DecoderMP3(infos);
            return pobjFichier.ToString();
        }
        #endregion
    }
}
