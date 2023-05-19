using System;
using System.Windows.Forms;
using System.IO;


namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChasonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "2163623";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }

        public Chanson ChansonCourante { get; }

        public Baladeur Baladeur { get; }

        
        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            // À COMPLÉTER...
            Baladeur = new Baladeur();
            
            Baladeur.ConstruireLaListeDesChansons();
            Baladeur.AfficherLesChansons(lsvChansons);

            lblNbChansons.Text = Baladeur.NbChansons.ToString();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
            int SelectedIndex = -1;
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                SelectedIndex = lsvChansons.SelectedIndices[0];
                switch (Baladeur.ChansonAt(SelectedIndex).Format)
                {
                    case "aac":
                        MnuFormatConvertirVersAAC.Enabled = false;
                        MnuFormatConvertirVersMP3.Enabled = true;
                        MnuFormatConvertirVersWMA.Enabled = true;
                        break;
                    case "mp3":
                        MnuFormatConvertirVersAAC.Enabled = true;
                        MnuFormatConvertirVersMP3.Enabled = false;
                        MnuFormatConvertirVersWMA.Enabled = true;
                        break;
                    case "wma":
                        MnuFormatConvertirVersAAC.Enabled = true;
                        MnuFormatConvertirVersMP3.Enabled = true;
                        MnuFormatConvertirVersWMA.Enabled = false;
                        break;
                }
            }
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            int SelectedIndex = -1;

            SelectedIndex = lsvChansons.SelectedItems[0].Index;

            if (SelectedIndex > 0)
            {
                switch (Baladeur.ChansonAt(SelectedIndex).Format)
                {
                    case "aac":
                        ChansonAAC chansonAAC = new ChansonAAC(Baladeur.ChansonAt(SelectedIndex).NomFichier);
                        StreamReader fichierAAC = new StreamReader(Baladeur.ChansonAt(SelectedIndex).NomFichier);
                        txtParoles.Text = chansonAAC.LireParoles(fichierAAC);

                        fichierAAC.Close();
                        break;
                    case "mp3":
                        ChansonMP3 chansonMP3 = new ChansonMP3(Baladeur.ChansonAt(SelectedIndex).NomFichier);
                        StreamReader fichierMP3 = new StreamReader(Baladeur.ChansonAt(SelectedIndex).NomFichier);
                        txtParoles.Text = chansonMP3.LireParoles(fichierMP3);
                        fichierMP3.Close();
                        break;
                    case "wma":
                        ChansonWMA chansonWMA = new ChansonWMA(Baladeur.ChansonAt(SelectedIndex).NomFichier);
                        StreamReader fichierWMA = new StreamReader(Baladeur.ChansonAt(SelectedIndex).NomFichier);
                        txtParoles.Text = chansonWMA.LireParoles(fichierWMA);
                        fichierWMA.Close();
                        break;

                }
            }
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            int selectedIndex = -1;
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                selectedIndex = lsvChansons.SelectedIndices[0];
                Baladeur.ConvertirVersAAC(selectedIndex);
                
            }
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            int selectedIndex = -1;
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                selectedIndex = lsvChansons.SelectedIndices[0];
                Baladeur.ConvertirVersMP3(selectedIndex);
                MettreAJourSelonContexte();
            }
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            int selectedIndex = -1;
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                selectedIndex = lsvChansons.SelectedIndices[0];
                Baladeur.ConvertirVersWMA(selectedIndex);
                MettreAJourSelonContexte();
            }
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
         //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
