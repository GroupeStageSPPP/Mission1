using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class SousCatDB
    {
        /// <summary>
        /// Récupère une liste de Type à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<SousCat> List()
        {

            

            SqlConnection connection = Datacolor.Connection;
            
            String requete = "SELECT Identifiant, Libelle, IdentifiantCategorie FROM Type";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<SousCat> list = new List<SousCat>();
            while (dataReader.Read())
            {

                //1 - Créer un Type à partir des donner de la ligne du dataReader
                SousCat type = new SousCat();
                type.Identifiant = dataReader.GetInt32(0);
                type.Libelle = dataReader.GetString(1);
                type.categorie.Identifiant = dataReader.GetInt32(2);


                //2 - Ajouter ce Type à la list de client
                list.Add(type);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Type à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Type</param>
        /// <returns>Un Type </returns>
        public static SousCat Get(Int32 Identifiant)
        {
            

            SqlConnection connection = Datacolor.Connection;
            
            String requete = @"SELECT Identifiant, Libelle, IdentifiantCategorie FROM Type
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Type
            SousCat type = new SousCat();

            type.Identifiant = dataReader.GetInt32(0);
            type.Libelle = dataReader.GetString(1);
            type.categorie.Identifiant = dataReader.GetInt32(2);
            dataReader.Close();
            connection.Close();
            return type;
        }


        public static void Delete(Int32 Identifiant)
        {
             

            SqlConnection connection = Datacolor.Connection;
            String requete = "DELETE Type WHERE Identifiant = @Identifiant";
            
            connection.Open();

            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(SousCat type)
        {
            
            SqlConnection connection = Datacolor.Connection;
            String requete = @"INSERT INTO Type(Libelle, IdentifiantCategorie) 
                               VALUES(@Libelle, @IdentifiantCategorie);";
            
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("Libelle", type.Libelle);
            commande.Parameters.AddWithValue("IdentifiantCategorie", type.categorie.Identifiant);

             
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( SousCat type)
        {

            SqlConnection connection = Datacolor.Connection;
             String requete = @"UPDATE Type  
                                SET Libelle=@Libelle IdentifiantCategorie=@IdentifiantCategorie  
                                WHERE Identifiant = @Identifiant;";

            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
             
            commande.Parameters.AddWithValue("Identifiant", type.Identifiant);
            commande.Parameters.AddWithValue("Libelle", type.Libelle);
            commande.Parameters.AddWithValue("IdentifiantCategorie", type.categorie.Identifiant);
            
            commande.ExecuteNonQuery();
            connection.Close();
        }

    }
}
