using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaladeurMultiFormatsTests
{
    [TestClass]
    public class UnitTestHistoriqueTODOs
    {

        #region Tests de la méthode NbConsultationDepuisXSecondes
        // TODO Test E : HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest
        // Compléter la méthode pour tester le cas où la valeur du délai passé en paramètre est négative
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest()
        {
            // Arrange : Instancier un objet Historique
            // À compléter...
            Historique consultations = new Historique();
            // Act : Appeler la méthode NbConsultationsDepuisXSecondes
            // À compléter...
            consultations.NbConsultationsDepuisXSecondes(-1);
            
            // Assert : Vérifier si la méthode lève une exception IndexOutOfRangeException
            // À compléter...
            
        }


        // TODO Test F : HistoriqueTestNbConsultationDepuisXSecondesValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod()]
        public void HistoriqueTestNbConsultationDepuisXSecondesValideTest()
        {
            // Arrange : Instancier un objet Historique et y ajouter trois consultations d'une même chansonAAC
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // À compléter...
            Historique historique = new Historique();

            ChansonAAC chansonAAC = new ChansonAAC("Chansons/Blame it On Me.aac");


            DateTime dateTime = DateTime.Now.AddSeconds(-100);
            Consultation consultation = new Consultation(dateTime, chansonAAC);
            historique.Add(consultation);


            DateTime dateTime2 = DateTime.Now.AddSeconds(-150);
            Consultation consultation2 = new Consultation(dateTime2, chansonAAC);
            historique.Add(consultation2);


            DateTime dateTime3 = DateTime.Now.AddSeconds(-300);
            Consultation consultation3 = new Consultation(dateTime3, chansonAAC);
            historique.Add(consultation3);

            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de chansons consultées depuis 200 secondes.
            // À compléter...
            historique.NbConsultationsDepuisXSecondes(200);
            // Assert : Vérifier si la méthode retourne le bon nombre de consultations qui est 2 !
            // À compléter...
            Assert.AreEqual(2, historique.NbConsultationsDepuisXSecondes(200));

        }
        #endregion

        #region Tests de la méthode NbConsultationsPourUneChanson
        // TODO Test G : HistoriqueTestNbConsultationsPourUneChansonParamNullTest
        // Compléter la méthode pour tester le cas où la chanson passée en paramètre est à null
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HistoriqueTestNbConsultationsPourUneChansonParamNullTest()
        {
            // Arrange : Instancier un objet Historique
            // À compléter...
            Historique Historique = new Historique();

            // Act : Appeler la méthode NbConsultationsDepuisXSecondes en lui passant la valeur null
            // À compléter...
            Historique.NbConsultationsPourUneChanson(null);

            // Assert : Vérifier si la méthode lève une exception ArgumentNullException
            // À compléter...
        }

        // TODO Test H : HistoriqueTestNbConsultationsPourUneChansonValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod()]
        public void HistoriqueTestNbConsultationsPourUneChansonValideTest()
        {
            // Arrange : Instancier un objet Historique et un objet ChansonAAC
            // Ajouter quatre consultations de cette même chansonAAC dans l'objet Historique
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // La quatrième consultation depuis 350 secondes (DateTime.AddSeconds(-350))
            // À compléter...
            Historique historique = new Historique();
            ChansonAAC chansonAAC = new ChansonAAC("Chansons/Blame it On Me.aac");


            DateTime dateTime = DateTime.Now.AddSeconds(-100);
            Consultation consultation = new Consultation(dateTime, chansonAAC);
            historique.Add(consultation);

            DateTime dateTime2 = DateTime.Now.AddSeconds(-150);
            Consultation consultation2 = new Consultation(dateTime2, chansonAAC);
            historique.Add(consultation2);

            DateTime dateTime3 = DateTime.Now.AddSeconds(-300);
            Consultation consultation3 = new Consultation(dateTime3, chansonAAC);
            historique.Add(consultation3);

            DateTime dateTime4 = DateTime.Now.AddSeconds(-350);
            Consultation consultation4 = new Consultation(dateTime4, chansonAAC);
            historique.Add(consultation4);

            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de fois que la chansonAAC a été consultée.
            // À compléter...
            historique.NbConsultationsPourUneChanson(chansonAAC);

            // Assert : Vérifier si la méthode retourne la bon nombre de consultations qui est 4
            // À compléter...
            Assert.AreEqual(4, historique.NbConsultationsPourUneChanson(chansonAAC));


        }


        #endregion
    }
}
