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

            String requete = "SELECT IdentifiantEchantillon, DateAlerte, Message, Type, IdentifiantTest_Echantillon FROM Alerte;";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Alerte> list = new List<Alerte>();

            while (dataReader.Read())
            {

                Alerte alerte = new Alerte();
                alerte.IdentifiantEchantillon = dataReader.GetInt32(0);
                alerte.DateAlerte = dataReader.GetDateTime(1);
                alerte.Message = dataReader.GetString(2);
                alerte.Type = dataReader.GetChar(3);

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

            String requete = @"SELECT IdentifiantEchantillon, DateAlerte, Message, Type, IdentifiantTest_Echantillon FROM Alerte
                                WHERE IdentifiantEchantillon=@IdentifiantEchantillon;";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("IdentifiantEchantillon", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            Alerte alerte = new Alerte();

            alerte.IdentifiantEchantillon = dataReader.GetInt32(0);
            alerte.DateAlerte                = dataReader.GetDateTime(1);
            alerte.Message                   = dataReader.GetString(2);
            alerte.Type                      = dataReader.GetChar(3);

            dataReader.Close();
            connection.Close();

            return alerte;
        }





        public static void Insert(Alerte alerte)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Alerte(IdentifiantEchantillon, DateAlerte, Message, Type, IdentifiantTest_Echantillon) 
                               VALUES(@DateAlerte, @Message, @Type, @IdentifiantTest_Echantillon) SELECT SCOPE_IDENTITY() ;";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);
            commande.Parameters.AddWithValue("IdentifiantEchantillon", alerte.IdentifiantEchantillon);
            commande.Parameters.AddWithValue("DateAlerte", alerte.DateAlerte);
            commande.Parameters.AddWithValue("Message", alerte.Message);
            commande.Parameters.AddWithValue("Type", alerte.Type);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Alerte alerte)
        {
            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Alerte 
                               SET(DateAlerte=@DateAlerte, Message=@Message, Type=@Type, IdentifiantTest_Echantillon=@IdentifiantTest_Echantillon) 
                               WHERE IdentifiantEchantillon=@IdentifiantEchantillon;";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);
            commande.Parameters.AddWithValue("IdentifiantEchantillon", alerte.IdentifiantEchantillon);
            commande.Parameters.AddWithValue("DateAlerte", alerte.DateAlerte);
            commande.Parameters.AddWithValue("Message", alerte.Message);
            commande.Parameters.AddWithValue("Type", alerte.Type);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Alerte 
                               WHERE IdentifiantEchantillon=@IdentifiantEchantillon;";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("IdentifiantEchantillon", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
