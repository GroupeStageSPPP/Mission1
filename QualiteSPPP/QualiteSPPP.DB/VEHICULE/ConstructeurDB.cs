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
    public static class ConstructeurDB
    {
        /// <summary>
        /// Récupère une liste de constructeur à partir de la base de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Constructeur> List()
        {
            //Récupération de la chaine de connexion
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = "SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse  FROM Constructeur";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            //execution

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Constructeur> list = new List<Constructeur>();
            while (dataReader.Read())
            {

                //1 - Créer un constructeur à partir des donner de la ligne du dataReader
                Constructeur constructeur = new Constructeur();
                constructeur.Identifiant = dataReader.GetInt32(0);
                constructeur.Libelle = dataReader.GetString(1);
                constructeur.Mail = dataReader.GetString(2);
                constructeur.Telephone = dataReader.GetString(3);
                constructeur.Responsable = dataReader.GetString(4);
                constructeur.Adresse = dataReader.GetString(5);



                //2 - Ajouter ce constructeur à la list de client
                list.Add(constructeur);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une constructeur à partir d'un identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de constructeur</param>
        /// <returns>Un constructeur </returns>
        public static Constructeur Get(Int32 identifiant)
        {
            //Connection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LaboSPPPConnectionString"];
            SqlConnection connection = new SqlConnection(connectionStringSettings.ToString());
            //Commande
            String requete = @"SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse FROM Constructeur
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            //Paramètres
            commande.Parameters.AddWithValue("Identifiant", identifiant);

            //Execution
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du constructeur
            Constructeur constructeur = new Constructeur();

            constructeur.Identifiant = dataReader.GetInt32(0);
            constructeur.Libelle = dataReader.GetString(1);
            constructeur.Mail = dataReader.GetString(2);
            constructeur.Telephone = dataReader.GetString(3);
            constructeur.Responsable = dataReader.GetString(4);
            constructeur.Adresse = dataReader.GetString(5);
            dataReader.Close();
            connection.Close();
            return constructeur;
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

            String requete = "DELETE Constructeur WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", identifiant);
            //Fournir la requete à la commande

            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(Constructeur constructeur)
        {
            //Connexion
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            //Commande
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            commande.CommandText = "INSERT INTO Constructeur(Libelle, Mail, Telephone, Responsable, Adresse) VALUES(@Libelle, @Mail, @Telephone, @Responsable, @Adresse)";
            commande.Parameters.AddWithValue("Libelle", constructeur.Libelle);
            commande.Parameters.AddWithValue("Mail", constructeur.Mail);
            commande.Parameters.AddWithValue("Telephone", constructeur.Telephone);
            commande.Parameters.AddWithValue("Responsable", constructeur.Responsable);
            commande.Parameters.AddWithValue("Adresse", constructeur.Adresse);

            //Execution de la commande
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Constructeur constructeur)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "LaboSPPPConnectionString";
            connection.Open();
            SqlCommand commande = new SqlCommand();
            commande.Connection = connection;
            string requete = "UPDATE Constructeur  SET Libelle=@Libelle, Mail=@Mail, Telephone=@Telephone, Responsable=@Responsable, Adresse=@Adresse WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("identifiant", constructeur.Identifiant);
            commande.Parameters.AddWithValue("Libelle", constructeur.Libelle);
            commande.Parameters.AddWithValue("Mail", constructeur.Mail);
            commande.Parameters.AddWithValue("Telephone", constructeur.Telephone);
            commande.Parameters.AddWithValue("Responsable", constructeur.Responsable);
            commande.Parameters.AddWithValue("Adresse", constructeur.Adresse);
            commande.CommandText = requete;
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
