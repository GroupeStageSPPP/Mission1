using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    static class AlerteGen
    {

        // Fonction de verification en fonction d'un test sur un enchantillon et sur le test d'une piece


        public static void VerificationTest(Test_Echantillon testEchantillon, Test_Peinture_Piece testPeinturePiece)
        {
            Test test = new Test();
            test = TestDB.Get(testEchantillon.test.Identifiant);

            if (IsAlerte(testEchantillon, testPeinturePiece) == true)
                if (test.TypeTest == 'c')
                {
                    TestTypeC(testEchantillon);

                }
                else
                {
                    if (test.TypeTest == '1')
                    {
                        TestTypeOne(testEchantillon, testPeinturePiece);
                    }
                    else
                    {
                        if (test.TypeTest == '2')
                        {
                            TestTypeTwo(testEchantillon, testPeinturePiece);
                        }
                        else
                        {
                            if (test.TypeTest == '3')
                            {
                                TestTypeThree(testEchantillon, testPeinturePiece);

                            }

                        }
                    }
                }

        }

        // Fonction permettant de savoir si il faut generer une alerte
        public static Boolean IsAlerte(Test_Echantillon testEchantillon, Test_Peinture_Piece testPeinturePiece)
        {


            if (testEchantillon.ISconforme == 't')
            {
                return true;
            }
            else
            {
                VerificationTest(testEchantillon, testPeinturePiece);
                return false;
            }
        }


        // Fonction permettant  le retour d'une alerte si un test numérique de type 3( Min Moy Max) est faux 
        public static Alerte TestTypeThree(Test_Echantillon testEchantillon, Test_Peinture_Piece testPeinturePiece)
        {

            Alerte alerte = new Alerte();
            if (Convert.ToDouble(testEchantillon.Resultat) > testPeinturePiece.Max)
            {
                alerte.DateAlerte = DateTime.Now;
                alerte.Message = " Le resultat est supérieur au seuil maximum";
                alerte.Type = 'n';
                alerte.IdentifiantEchantillon = testEchantillon.Identifiant;


            }
            else
            {

                alerte.DateAlerte = DateTime.Now;
                alerte.Message = " Le resultat est inférieur au seuil minimum";
                alerte.Type = 'n';
                alerte.IdentifiantEchantillon = testEchantillon.Identifiant;
            }
            return alerte;
        }


            // Fonction permettant  le retour d'une alerte si un test de  type numérique 2 ( Min Moy) est faux

        public static Alerte TestTypeTwo(Test_Echantillon testEchantillon, Test_Peinture_Piece testPeinturePiece)
        {

                Alerte alerte = new Alerte();
                alerte.DateAlerte = DateTime.Now;
                alerte.Message = " Le resultat est inférieur au seuil minimum";
                alerte.Type = 'n';
                alerte.IdentifiantEchantillon = testEchantillon.Identifiant;
                return alerte;

        }

        public static Alerte TestTypeFour(Test_Echantillon testEchantillon, Test_Peinture_Piece testPeinturePiece)
        {


                Alerte alerte = new Alerte();
                alerte.DateAlerte = DateTime.Now;
                alerte.Message = " Le resultat est inférieur au seuil supérieur";
                alerte.Type = 'n';
                alerte.IdentifiantEchantillon = testEchantillon.Identifiant;
                return alerte;

        }

        // Fonction permettant  le retour d'une alerte si un test code est faux
            public static Alerte TestTypeC(Test_Echantillon testEchantillon)
            {

                Alerte alerte = new Alerte();
                                alerte.DateAlerte = DateTime.Now;
                alerte.Message = " Le resultat est hors des codes normaux";
                alerte.Type = 'c';
                alerte.IdentifiantEchantillon = testEchantillon.Identifiant;
                return alerte;

            }


         // Fonction permettant  le retour d'une alerte si un test code est faux
            public static Alerte TestTypeOne(Test_Echantillon testEchantillon, Test_Peinture_Piece testPeinturePiece)
            {
                Alerte alerte = new Alerte();
                                alerte.DateAlerte = DateTime.Now;
                alerte.Message = " Le resultat est trop loin de la moyenne";
                alerte.Type = 'c';
                alerte.IdentifiantEchantillon = testEchantillon.Identifiant;
                return alerte;

            }



        

    }
}
