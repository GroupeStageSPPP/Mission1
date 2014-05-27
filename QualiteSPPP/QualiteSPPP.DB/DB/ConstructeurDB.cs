using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class ConstructeurDB
    {
        /// <summary>
        /// Récupère une liste de constructeur à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Constructeur> List()
        {

            
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = "SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse  FROM Constructeur";
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete, connection);
            
            
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
        /// Récupère une constructeur à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de constructeur</param>
        /// <returns>Un constructeur </returns>
        public static Constructeur Get(Int32 Identifiant)
        {
            
            SqlConnection connection = DataBase.Connection;
  
            
            String requete = @"SELECT Identifiant, Libelle, Mail, Telephone, Responsable, Adresse FROM Constructeur
                                WHERE Identifiant = @Identifiant";
            
            
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
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





        public static void Insert(Constructeur constructeur)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = @"INSERT INTO Constructeur(Libelle, Mail, Telephone, Responsable, Adresse) 
                               VALUES(@Libelle, @Mail, @Telephone, @Responsable, @Adresse) SELECT SCOPE_IDENTITY() ";
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
             
            commande.Parameters.AddWithValue("Libelle", constructeur.Libelle);
            commande.Parameters.AddWithValue("Mail", constructeur.Mail);
            commande.Parameters.AddWithValue("Telephone", constructeur.Telephone);
            commande.Parameters.AddWithValue("Responsable", constructeur.Responsable);
            commande.Parameters.AddWithValue("Adresse", constructeur.Adresse);

             
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Constructeur constructeur)
        {
            
            SqlConnection connection = DataBase.Connection;
           
            
            String requete = @"UPDATE Constructeur  
                               SET Libelle=@Libelle, Mail=@Mail, Telephone=@Telephone, Responsable=@Responsable, Adresse=@Adresse 
                               WHERE Identifiant=@Identifiant;";
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", constructeur.Identifiant);
            commande.Parameters.AddWithValue("Libelle", constructeur.Libelle);
            commande.Parameters.AddWithValue("Mail", constructeur.Mail);
            commande.Parameters.AddWithValue("Telephone", constructeur.Telephone);
            commande.Parameters.AddWithValue("Responsable", constructeur.Responsable);
            commande.Parameters.AddWithValue("Adresse", constructeur.Adresse);
            
            commande.ExecuteNonQuery();

            connection.Close();
        }        
        
        public static void Delete(Int32 Identifiant)
        {
             
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = @"DELETE Constructeur WHERE Identifiant=@Identifiant;";
            
            connection.Open();

             
            SqlCommand commande = new SqlCommand(requete,connection);
            
            //Parametre
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
