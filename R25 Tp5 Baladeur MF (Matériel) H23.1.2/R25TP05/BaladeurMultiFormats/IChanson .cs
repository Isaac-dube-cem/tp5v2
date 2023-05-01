using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormatsTests
{
    interface IChanson
    {
        int Annee { get; }
        string Artiste { get; }
        string Format { get; }
        string NomFichier { get; }
        string Paroles { get; }
        string Titre { get; }

        void Ecrire(string pParoles);

        void EcrireEntete(StreamReader pobjFichier);

        void EcrireParoles(StreamReader pobjFichier, string pParoles);

        void LireEntete();

        void SauterEntete(StreamReader pobjFichier);
    }
}
