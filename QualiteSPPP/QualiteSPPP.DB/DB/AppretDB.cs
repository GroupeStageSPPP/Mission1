using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    class AppretDB
    {
        public static List<Appret> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, Reference, Min, Moy, Max FROM Appret";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Appret> list = new List<Appret>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Appret appret = new Appret();
                appret.Identifiant = dataReader.GetInt32(0);
                appret.Reference = dataReader.GetString(1);
                appret.Min = dataReader.GetFloat(2);
                appret.Moy = dataReader.GetFLoat(3);
                appret.Max = dataReader.GetFloat(4);


                //2 - Ajouter cet appret à la list d'appret
                list.Add(appret);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère un appret à partir d'un Identifiant de appret
        /// </summary>
        /// <param name="Identifiant">Identifant de l'appret</param>
        /// <returns>Un appret</returns>
        public static Appret Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Reference, Min, Moy, Max FROM Appret
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Appret appret = new Appret();

            appret.Identifiant = dataReader.GetInt32(0);
            appret.Reference = dataReader.GetString(1);
            appret.Min = dataReader.GetFloat(2);
            appret.Moy = dataReader.GetFLoat(3);
            appret.Max = dataReader.GetFloat(4);

            dataReader.Close();
            connection.Close();

            return appret;
        }





        public static void Insert(Appret appret)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Appret(Reference, Min, Moy, Max) VALUES(@Reference, @Min, @Moy, @Max)";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Reference", appret.Reference);
            commande.Parameters.AddWithValue("Min", appret.Min);
            commande.Parameters.AddWithValue("Moy", appret.Moy);
            commande.Parameters.AddWithValue("Max", appret.Max);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Appret appret)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Appret  
                               SET Reference = @Reference, Min = @Min, Moy = @Moy, Max = @Max  
                               WHERE Identifiant=@Identifiant;";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);
            //Parametres
            commande.Parameters.AddWithValue("Identifiant", appret.Identifiant);
            commande.Parameters.AddWithValue("Reference", appret.Reference);
            commande.Parameters.AddWithValue("Min", appret.Min);
            commande.Parameters.AddWithValue("Moy", appret.Moy);
            commande.Parameters.AddWithValue("Max", appret.Max);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Appret 
                               WHERE Identifiant=@Identifiant";

            connection.Open();
            

            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }



    }
}
