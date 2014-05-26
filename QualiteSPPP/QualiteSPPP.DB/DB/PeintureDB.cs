using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class PeintureDB
    {
        /// <summary>
        /// Récupère une liste de Peinture à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Peinture> List()
        {



            SqlConnection connection = Datacolor.Connection;

            String requete = @"SELECT Identifiant, Nom, RisqueTeinte, IdentifiantAppret, IdentifiantColor, IdentifiantVernis 
                               FROM Peinture";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Peinture> list = new List<Peinture>();
            while (dataReader.Read())
            {

                //1 - Créer une Peinture à partir des donner de la ligne du dataReader
                Peinture peinture = new Peinture();
                peinture.Identifiant = dataReader.GetInt32(0);
                peinture.Nom = dataReader.GetString(1);
                peinture.RisqueTeinte = dataReader.GetString(2);
                peinture.appret.Identifiant = dataReader.GetInt32(3);
                peinture.color.Identifiant = dataReader.GetInt32(4);
                peinture.vernis.Identifiant = dataReader.GetInt32(5);
                //2 - Ajouter ce Peinture à la list de client
                list.Add(peinture);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Peinture à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifiant de Peinture</param>
        /// <returns>Un Peinture </returns>
        public static Peinture Get(Int32 Identifiant)
        {


            SqlConnection connection = Datacolor.Connection;

            String requete = @"SELECT Identifiant, Nom, RisqueTeinte, IdentifiantAppret, IdentifiantColor, IdentifiantVernis 
                               FROM Peinture WHERE Identifiant=@Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Peinture
            Peinture peinture = new Peinture();

            peinture.Identifiant = dataReader.GetInt32(0);
            peinture.Nom = dataReader.GetString(1);
            peinture.RisqueTeinte = dataReader.GetString(2);
            peinture.appret.Identifiant = dataReader.GetInt32(3);
            peinture.color.Identifiant = dataReader.GetInt32(4);
            peinture.vernis.Identifiant = dataReader.GetInt32(5);

            dataReader.Close();
            connection.Close();
            return peinture;
        }


        public static void Delete(Int32 Identifiant)
        {


            SqlConnection connection = Datacolor.Connection;

            connection.Open();
            String requete = "DELETE Peinture WHERE Identifiant = @Identifiant";


            SqlCommand commande = new SqlCommand(requete, connection);





            commande.Parameters.AddWithValue("Identifiant", Identifiant);




            commande.ExecuteNonQuery();
            connection.Close();
        }


        public static void Insert(Peinture peinture)
        {

            SqlConnection connection = Datacolor.Connection;
            String requete = @"INSERT INTO Peinture(Nom, RisqueTeinte, IdentifiantAppret, IdentifiantColor, IdentifiantVernis)   
                               VALUES(@Nom, @RisqueTeinte, @IdentifiantAppret, @IdentifiantColor, @IdentifiantVernis);";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Nom", peinture.Nom);
            commande.Parameters.AddWithValue("RisqueTeinte", peinture.RisqueTeinte);
            commande.Parameters.AddWithValue("IdentifiantAppret", peinture.appret.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantColor", peinture.color.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantVernis", peinture.vernis.Identifiant);


            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Peinture peinture)
        {
            SqlConnection connection = Datacolor.Connection;
            String requete = @"UPDATE Peinture
                               SET Nom=@Nom, RisqueTeinte=@RisqueTeinte, IdentifiantAppret=@IdentifiantAppret, IdentifiantColor=@IdentifiantColor, IdentifiantVernis=@IdentifiantVernis
                               WHERE Identifiant=@Identifiant;";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);
            commande.Parameters.AddWithValue("Identifiant", peinture.Identifiant);
            commande.Parameters.AddWithValue("Nom", peinture.Nom);
            commande.Parameters.AddWithValue("RisqueTeinte", peinture.RisqueTeinte);
            commande.Parameters.AddWithValue("IdentifiantAppret", peinture.appret.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantColor", peinture.color.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantVernis", peinture.vernis.Identifiant);


            commande.ExecuteNonQuery();

            connection.Close();
            

        }
    }
}