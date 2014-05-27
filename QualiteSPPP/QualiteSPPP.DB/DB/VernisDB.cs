using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    class VernisDB
    {
        public static List<Vernis> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, Reference, Min, Moy, Max FROM Vernis";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Vernis> list = new List<Vernis>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Vernis vernis = new Vernis();
                vernis.Identifiant = dataReader.GetInt32(0);
                vernis.Reference = dataReader.GetString(1);
                vernis.Min = dataReader.GetFloat(2);
                vernis.Moy = dataReader.GetFloat(3);
                vernis.Max = dataReader.GetFloat(4);


                //2 - Ajouter ce vernis à la list de vernis
                list.Add(vernis);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une vernis à partir d'un Identifiant de vernis
        /// </summary>
        /// <param name="Identifiant">Identifant de vernis</param>
        /// <returns>Un vernis</returns>
        public static Vernis Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Reference, Min, Moy, Max FROM Vernis
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la vernis
            Vernis vernis = new Vernis();

            vernis.Identifiant = dataReader.GetInt32(0);
            vernis.Reference = dataReader.GetString(1);
            vernis.Min = dataReader.GetFloat(2);
            vernis.Moy = dataReader.GetFloat(3);
            vernis.Max = dataReader.GetFloat(4);

            dataReader.Close();
            connection.Close();

            return vernis;
        }





        public static void Insert(Vernis vernis)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Vernis(Reference, Min, Moy, Max) VALUES(@Reference, @Min, @Moy, @Max) SELECT SCOPE_IDENTITY() ";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Reference", vernis.Reference);
            commande.Parameters.AddWithValue("Min", vernis.Min);
            commande.Parameters.AddWithValue("Moy", vernis.Moy);
            commande.Parameters.AddWithValue("Max", vernis.Max);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Vernis appret)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Vernis  
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


            String requete = @"DELETE FROM Vernis 
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
