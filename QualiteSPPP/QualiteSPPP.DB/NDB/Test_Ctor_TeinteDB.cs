using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Test_Ctor_TeinteDB
    {
        public static String champs = "Min,Norme,Max,ID_Test,ID_Constructeur,ID_Teinte";
        public static String select = "SELECT Identifiant," + champs + " FROM Test_Ctor_Teinte";


        public static List<Test_Ctor_Teinte> List()
        {
            List<Test_Ctor_Teinte> listeTest_Ctor_Teinte = new List<Test_Ctor_Teinte>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + ";";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            while (dataReader.Read())
            {
                Test_Ctor_Teinte test_ctor_teinte = new Test_Ctor_Teinte();
                test_ctor_teinte.Identifiant = dataReader.GetInt32(0);
                test_ctor_teinte.Min = dataReader.GetDouble(1);
                test_ctor_teinte.Norme = dataReader.GetDouble(2);
                test_ctor_teinte.Max = dataReader.GetDouble(3);
                test_ctor_teinte.ID_Test = dataReader.GetInt32(4);
                test_ctor_teinte.ID_Constructeur = dataReader.GetInt32(5);
                test_ctor_teinte.ID_Teinte = dataReader.GetInt32(6);
                listeTest_Ctor_Teinte.Add(test_ctor_teinte);
            }

            dataReader.Close();
            connection.Close();

            return listeTest_Ctor_Teinte;
        }

        public static Test_Ctor_Teinte Get(Int32 Identifiant)
        {
            Test_Ctor_Teinte test_ctor_teinte = new Test_Ctor_Teinte();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE Identifiant = @Identifiant;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();
            test_ctor_teinte.Identifiant = dataReader.GetInt32(0);
            test_ctor_teinte.Min = dataReader.GetDouble(1);
            test_ctor_teinte.Norme = dataReader.GetDouble(2);
            test_ctor_teinte.Max = dataReader.GetDouble(3);
            test_ctor_teinte.ID_Test = dataReader.GetInt32(4);
            test_ctor_teinte.ID_Constructeur = dataReader.GetInt32(5);
            test_ctor_teinte.ID_Teinte = dataReader.GetInt32(6);
            dataReader.Close();
            connection.Close();

            return test_ctor_teinte;
        }

        public static Boolean Insert(Test_Ctor_Teinte test_ctor_teinte)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Test_Ctor_Teinte (" + champs + ") VALUES (@Min,@Norme,@Max,@ID_Test,@ID_Constructeur,@ID_Teinte);";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Min", test_ctor_teinte.Min);
            commande.Parameters.AddWithValue("Norme", test_ctor_teinte.Norme);
            commande.Parameters.AddWithValue("Max", test_ctor_teinte.Max);
            commande.Parameters.AddWithValue("ID_Test", test_ctor_teinte.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", test_ctor_teinte.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Teinte", test_ctor_teinte.ID_Teinte);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Test_Ctor_Teinte test_ctor_teinte)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Test_Ctor_Teinte
                               SET Min=@Min,Norme=@Norme,Max=@Max,ID_Test=@ID_Test,ID_Constructeur=@ID_Constructeur,ID_Teinte=@ID_Teinte
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", test_ctor_teinte.Identifiant);
            commande.Parameters.AddWithValue("Min", test_ctor_teinte.Min);
            commande.Parameters.AddWithValue("Norme", test_ctor_teinte.Norme);
            commande.Parameters.AddWithValue("Max", test_ctor_teinte.Max);
            commande.Parameters.AddWithValue("ID_Test", test_ctor_teinte.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", test_ctor_teinte.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Teinte", test_ctor_teinte.ID_Teinte);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public static Boolean Delete(Int32 Identifiant)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"DELETE Test_Ctor_Teinte
                               WHERE Identifiant=@Identifiant ;";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}