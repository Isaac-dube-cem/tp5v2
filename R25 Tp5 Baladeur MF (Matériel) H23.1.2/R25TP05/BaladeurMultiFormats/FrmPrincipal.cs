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
            //Baladeur.AfficherLesChansons(lsvChansons);
            //lblNbChansons.Text = Baladeur.NbChansons.ToString();
            int SelectedIndex = -1;
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                SelectedIndex = lsvChansons.SelectedIndices[0];
                //switch (switch_on)
                //{
                //    default:
                //}
            }
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            
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
                MettreAJourSelonContexte();
            }
            
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
