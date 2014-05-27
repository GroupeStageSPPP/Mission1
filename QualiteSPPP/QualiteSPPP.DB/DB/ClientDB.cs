using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class ClientDB
    {
        /// <summary>
        /// Récupère une liste de client à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Client> List()
        {

            
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = "SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse FROM Client;";
            
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete, connection);
            
            
            SqlDataReader dataReader = commande.ExecuteReader();

            List<Client> list = new List<Client>();
            while (dataReader.Read())
            {

                //1 - Créer un client à partir des donner de la ligne du dataReader
                Client client = new Client();
                client.Identifiant = dataReader.GetInt32(0);
                client.Libelle = dataReader.GetString(1);
                client.Mail = dataReader.GetString(2);
                client.Telephone = dataReader.GetString(3);
                client.Responsable = dataReader.GetString(4);
                client.Adresse = dataReader.GetString(5);


                //2 - Ajouter ce client à la list de client
                list.Add(client);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une client à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de client</param>
        /// <returns>Un Client </returns>
        public static Client Get(Int32 Identifiant)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = @"SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse 
                               FROM Client
                               WHERE Identifiant = @Identifiant;";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du client
            Client client = new Client();

            client.Identifiant = dataReader.GetInt32(0);
            client.Libelle = dataReader.GetString(1);
            client.Mail = dataReader.GetString(2);
            client.Telephone = dataReader.GetString(3);
            client.Adresse = dataReader.GetString(4);
            dataReader.Close();
            connection.Close();
            return client;
        }

        public static void Insert(Client client)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = @"INSERT INTO Client(Libelle, Mail, Telephone, Responsable, Adresse) 
                               VALUES(@Libelle, @Mail, @Telephone, @Responsable, @Adresse) SELECT SCOPE_IDENTITY() ;";
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete,connection);
           
            
            commande.Parameters.AddWithValue("Libelle", client.Libelle);
            commande.Parameters.AddWithValue("Mail", client.Mail);
            commande.Parameters.AddWithValue("Telephone", client.Telephone);
            commande.Parameters.AddWithValue("Responsable", client.Responsable);
            commande.Parameters.AddWithValue("Adresse", client.Adresse);
            
             
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Client client)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            String requete = @"UPDATE Client  
                             SET Libelle=@Libelle, Mail=@Mail, Telephone=@Telephone, Responsable=@Responsable, Adresse=@Adresse                                  WHERE Identifiant=@Identifiant;";
            
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
            
            commande.Parameters.AddWithValue("Identifiant", client.Identifiant);
            commande.Parameters.AddWithValue("Libelle", client.Libelle);
            commande.Parameters.AddWithValue("Mail", client.Mail);
            commande.Parameters.AddWithValue("Telephone", client.Telephone);
            commande.Parameters.AddWithValue("Responsable", client.Responsable);
            commande.Parameters.AddWithValue("Adresse", client.Adresse);
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {
             
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = @"DELETE Client WHERE Identifiant=@Identifiant;";
            connection.Open();

             
            SqlCommand commande = new SqlCommand(requete,connection);
            commande.Parameters.AddWithValue("Identifiant", Identifiant);
            
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
