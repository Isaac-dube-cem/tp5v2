using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        #region Champs
        private const string NOM_RÉPERTOIRE = "Chansons";
        private List<Chanson> m_colChansons;
        #endregion

        #region Propriétés
        public int NbChansons { get { return m_colChansons.Count; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// va afficher la liste des chansons dans la listview en paramèetres
        /// </summary>
        /// <param name="pListView">listview dans laquel écrire les informations</param>
        public void AfficherLesChansons(ListView pListView)
        {   
            foreach (Chanson chanson in m_colChansons)
            {
                ListViewItem item = new ListViewItem(chanson.Artiste);
                item.SubItems.Add(chanson.Titre);
                item.SubItems.Add(chanson.Annee.ToString());
                item.SubItems.Add(chanson.Format.ToUpper());
                pListView.Items.Add(item);
            }
        }

        /// <summary>
        /// initialise une instance de la classe et la liste des chansons
        /// </summary>
        public Baladeur()
        {
            m_colChansons = new List<Chanson>();
        }

        /// <summary>
        /// retourne la chanson selon l'index passé en paramètre
        /// </summary>
        /// <param name="pIndex"></param>
        /// <returns></returns>
        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        /// <summary>
        /// vérifie si le répertoire "Chansons" existe et parcours chaque fichier pour vérifier son format
        ///  et instancie une nouvelle chanson selon le format et l'ajoute dans la collection m_colChansons
        /// </summary>
        public void ConstruireLaListeDesChansons()
        {
            string[] filelist = Directory.GetFiles(NOM_RÉPERTOIRE);
            if (Directory.Exists(NOM_RÉPERTOIRE))
            {
                foreach (var file in filelist)
                {
                    string[] infos = file.Split('.');

                    if (infos[1] == "aac")
                    {
                        ChansonAAC chansonAAC = new ChansonAAC(file);
                        m_colChansons.Add(chansonAAC);
                    }
                    else if(infos[1] == "mp3")
                    {
                        ChansonMP3 chansonMP3 = new ChansonMP3(file);
                        m_colChansons.Add(chansonMP3);
                    }
                    else
                    {
                        ChansonWMA chansonWMA = new ChansonWMA(file);
                        m_colChansons.Add(chansonWMA);
                    }
                }
            }
        }

        /// <summary>
        /// instancie une nouvelle chanson AAC à partir de list de chansons m_colChansons à l'index pIndex, écrit les paroles dans le fichier et les encodes
        /// puis supprime le fichier du répertoire
        /// </summary>
        /// <param name="pIndex">l'index de la chanson dans m_colChansons</param>
        public void ConvertirVersAAC(int pIndex)
        {
            ChansonAAC chansonAAC = new ChansonAAC(NOM_RÉPERTOIRE, m_colChansons[pIndex].Artiste, m_colChansons[pIndex].Titre, m_colChansons[pIndex].Annee);

            chansonAAC.Ecrire(m_colChansons[pIndex].Paroles);
            
            File.Delete(m_colChansons[pIndex].NomFichier);
        }

        /// <summary>
        /// instancie une nouvelle chanson MP3 à partir de list de chansons m_colChansons à l'index pIndex, écrit les paroles dans le fichier et les encodes
        /// puis supprime le fichier du répertoire
        /// </summary>
        /// <param name="pIndex">l'index de la chanson dans m_colChansons</param>
        public void ConvertirVersMP3(int pIndex)
        {
            ChansonMP3 chansonMP3 = new ChansonMP3(NOM_RÉPERTOIRE, m_colChansons[pIndex].Artiste, m_colChansons[pIndex].Titre, m_colChansons[pIndex].Annee);

            chansonMP3.Ecrire(m_colChansons[pIndex].Paroles);

            File.Delete(m_colChansons[pIndex].NomFichier);
        }

        /// <summary>
        /// instancie une nouvelle chanson WMA à partir de list de chansons m_colChansons à l'index pIndex, écrit les paroles dans le fichier et les encodes
        /// puis supprime le fichier du répertoire
        /// </summary>
        /// <param name="pIndex">l'index de la chanson dans m_colChansons</param>
        public void ConvertirVersWMA(int pIndex)
        {
            ChansonWMA chansonWMA = new ChansonWMA(NOM_RÉPERTOIRE, m_colChansons[pIndex].Artiste, m_colChansons[pIndex].Titre, m_colChansons[pIndex].Annee);

            chansonWMA.Ecrire(m_colChansons[pIndex].Paroles);

            File.Delete(m_colChansons[pIndex].NomFichier);
        }
        #endregion
    }
}
