﻿using System;
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
                item.SubItems.Add(chanson.Format);
                item.SubItems.Add(chanson.Annee.ToString());
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
        /// 
        /// </summary>
        /// <param name="pIndex"></param>
        public void ConvertirVersAAC(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
