using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    interface IBaladeur
    {
        #region Propriétés
        int NbChansons { get; }
        #endregion

        #region Méthodes
        void AfficherLesChansons(ListView pListView);

        Chanson ChansonAt(int pIndex);

        void ConstruireLaListeDesChansons();

        void ConvertirVersAAC(int pIndex);

        void ConvertirVersMP3(int pIndex);

        void ConvertirVersWMA(int pIndex);
        #endregion
    }
}
