using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class AlerteDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la color de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Alerte> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, DateAlerte, Message, Type, IdentifiantTest_Echantillon FROM Alerte";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Alerte> list = new List<Alerte>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Alerte alerte = new Alerte();
                alerte.Identifiant = dataReader.GetInt32(0);
                alerte.DateAlerte = dataReader.GetDateTime(1);
                alerte.Message = dataReader.GetString(2);
                alerte.Type = dataReader.GetChar(3);
                alerte.test_echantillon.Identifiant = dataReader.GetInt32(4);

                //2 - Ajouter cette civilité à la list de civilité
                list.Add(alerte);
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
        public static Alerte Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, DateAlerte, Message, Type, IdentifiantTest_Echantillon FROM Alerte
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Alerte alerte = new Alerte();

            alerte.Identifiant               = dataReader.GetInt32(0);
            alerte.DateAlerte                = dataReader.GetDateTime(1);
            alerte.Message                   = dataReader.GetString(2);
            alerte.Type                      = dataReader.GetChar(3);
            alerte.test_echantillon.Identifiant   = dataReader.GetInt32(4);

            dataReader.Close();
            connection.Close();

            return alerte;
        }





        public static void Insert(Alerte alerte)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Alerte(DateAlerte, Message, Type, IdentifiantTest_Echantillon) 
                               VALUES(@DateAlerte, @Message, @Type, @IdentifiantTest_Echantillon)";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);           
            commande.Parameters.AddWithValue("DateAlerte", alerte.DateAlerte             );
            commande.Parameters.AddWithValue("Message", alerte.Message                );
            commande.Parameters.AddWithValue("Type", alerte.Type                   );
            commande.Parameters.AddWithValue("IdentifiantTest_Echantillon", alerte.test_echantillon.Identifiant);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Alerte alerte)
        {
            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Alerte 
                               SET(DateAlerte=@DateAlerte, Message=@Message, Type=@Type, IdentifiantTest_Echantillon=@IdentifiantTest_Echantillon) 
                               WHERE Identifiant=@Identifiant,";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);
            commande.Parameters.AddWithValue("DateAlerte", alerte.DateAlerte);
            commande.Parameters.AddWithValue("Message", alerte.Message);
            commande.Parameters.AddWithValue("Type", alerte.Type);
            commande.Parameters.AddWithValue("IdentifiantTest_Echantillon", alerte.test_echantillon.Identifiant);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Alerte 
                               WHERE Identifiant=@Identifiant";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
