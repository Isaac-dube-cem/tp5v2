using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
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

        void EcrireEntete(StreamWriter pobjFichier);

        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        void LireEntete();

        string LireParoles(StreamReader pobjFichier);

        void SauterEntete(StreamReader pobjFichier);
    }
}
