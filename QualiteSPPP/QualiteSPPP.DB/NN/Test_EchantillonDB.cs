using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Test_EchantillonDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la color de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Test_Echantillon> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, Resultat, ISconforme, IdentifiantTest, IdentifiantEchantillon FROM Test_Echantillon";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Test_Echantillon> list = new List<Test_Echantillon>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Test_Echantillon test_echantillon = new Test_Echantillon();
                test_echantillon.Identifiant = dataReader.GetInt32(0);
                test_echantillon.Resultat = dataReader.GetString(1);
                test_echantillon.ISconforme = dataReader.GetChar(2);
                test_echantillon.test.Identifiant = dataReader.GetInt32(3);
                test_echantillon.echantillon.Identifiant = dataReader.GetInt32(4);
                //2 - Ajouter cette civilité à la list de civilité
                list.Add(test_echantillon);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une catégorie à partir d'un Identifiant de catégorie
        /// </summary>
        /// <param name="Identifiant">Identifant de catégorie</param>
        /// <returns>Une catégorie</returns>
        public static Test_Echantillon Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Resultat, ISconforme, IdentifiantTest, IdentifiantEchantillon FROM Test_Echantillon FROM Test_Echantillon
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Test_Echantillon test_echantillon = new Test_Echantillon();

            test_echantillon.Identifiant = dataReader.GetInt32(0);
            test_echantillon.Resultat = dataReader.GetString(1);
            test_echantillon.ISconforme = dataReader.GetChar(2);
            test_echantillon.test.Identifiant = dataReader.GetInt32(3);
            test_echantillon.echantillon.Identifiant = dataReader.GetInt32(4);

            dataReader.Close();
            connection.Close();

            return test_echantillon;
        }

        public static void Insert(Test_Echantillon test_echantillon)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Test_Echantillon(Resultat, ISconforme, IdentifiantTest, IdentifiantEchantillon) VALUES(@Resultat, @ISconforme, @IdentifiantTest, @IdentifiantEchantillon) SELECT SCOPE_IDENTITY() ";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Resultat", test_echantillon.Resultat);
            commande.Parameters.AddWithValue("ISconforme", test_echantillon.ISconforme);
            commande.Parameters.AddWithValue("IdentifiantTest", test_echantillon.test.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantEchantillon", test_echantillon.echantillon.Identifiant);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Test_Echantillon test_echantillon)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Test_Echantillon
                               SET Resultat=@Resultat, ISconforme=@ISconforme, IdentifiantTest=@IdentifiantTest, IdentifiantEchantillon=@IdentifiantEchantillon 
                               WHERE Identifiant=@Identifiant;";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Resultat", test_echantillon.Resultat);
            commande.Parameters.AddWithValue("ISconforme", test_echantillon.ISconforme);
            commande.Parameters.AddWithValue("IdentifiantTest", test_echantillon.test.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantEchantillon", test_echantillon.echantillon.Identifiant);
            commande.Parameters.AddWithValue("Identifiant", test_echantillon.Identifiant);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Test_Echantillon 
                               WHERE Identifiant=@Identifiant";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
