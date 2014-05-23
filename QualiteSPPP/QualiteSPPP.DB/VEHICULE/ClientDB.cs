using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualiteSPPP.Library;

namespace QualiteSPPP.DB
{
    public static class ClientDB
    {
        /// <summary>
        /// Récupère une liste de client à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Client> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse FROM Client";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

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
        /// Récupère une client à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de client</param>
        /// <returns>Un Client </returns>
        public static Client Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse FROM Client
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
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


        public static void Delete(Int32 identifiant)
        {
            //Connexion 

            SqlConnection connection = new SqlConnection("LaboSPPPConnectionString");

            connection.Open();

            //Commande 

            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;

            //Création d'une chaine de caractère contenant la requete a executer;

            String requete = "DELETE Client WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(Client client)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Client(Libelle, Mail, Telephone, Responsable, Adresse) VALUES(@Libelle, @Mail, @Telephone, @Responsable, @Adresse)";
            commande.Parameters.AddWithValue("Libelle", client.Libelle);
            commande.Parameters.AddWithValue("Mail", client.Mail);
            commande.Parameters.AddWithValue("Telephone", client.Telephone);
            commande.Parameters.AddWithValue("Responsable", client.Responsable);
            commande.Parameters.AddWithValue("Adresse", client.Adresse);
            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Client client)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Client  SET Libelle=@Libelle, Mail=@Mail, Telephone=@Telephone, Responsable=@Responsable, Adresse=@Adresse  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", client.Identifiant);
            commande.Parameters.AddWithValue("Libelle", client.Libelle);
            commande.Parameters.AddWithValue("Mail", client.Mail);
            commande.Parameters.AddWithValue("Telephone", client.Telephone);
            commande.Parameters.AddWithValue("Responsable", client.Responsable);
            commande.Parameters.AddWithValue("Adresse", client.Adresse);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
