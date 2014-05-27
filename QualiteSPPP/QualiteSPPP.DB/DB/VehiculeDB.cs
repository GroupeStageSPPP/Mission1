using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class VehiculeDB
    {
        /// <summary>
        /// Récupère une liste de Vehicule à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Vehicule> List()
        {

            

            SqlConnection connection = DataBase.Connection;
            
            String requete = "SELECT Identifiant, Libelle, Version, IdentifiantConstructeur FROM Vehicule";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Vehicule> list = new List<Vehicule>();
            while (dataReader.Read())
            {

                //1 - Créer un Vehicule à partir des donner de la ligne du dataReader
                Vehicule vehicule = new Vehicule();
                vehicule.Identifiant = dataReader.GetInt32(0);
                vehicule.Libelle = dataReader.GetString(1);
                vehicule.Version = dataReader.GetString(2);
                vehicule.constructeur.Identifiant = dataReader.GetInt32(3);
                //2 - Ajouter ce Vehicule à la list de client
                list.Add(vehicule);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Vehicule à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Vehicule</param>
        /// <returns>Un Vehicule </returns>
        public static Vehicule Get(Int32 Identifiant)
        {
            

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Libelle, Version, IdentifiantConstructeur FROM Vehicule
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Vehicule
            Vehicule vehicule = new Vehicule();

            vehicule.Identifiant = dataReader.GetInt32(0);
            vehicule.Libelle = dataReader.GetString(1);
            vehicule.Version = dataReader.GetString(2);
            vehicule.constructeur.Identifiant = dataReader.GetInt32(3);

            dataReader.Close();
            connection.Close();
            return vehicule;
        }


        public static void Delete(Int32 Identifiant)
        {
             

            SqlConnection connection = DataBase.Connection;
            String requete = "DELETE Vehicule WHERE Identifiant = @Identifiant";
            
            connection.Open();

            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            SqlDataReader dataReader = commande.ExecuteReader();
            connection.Close();
        }


        public static void Insert(Vehicule vehicule)
        {
            
            SqlConnection connection = DataBase.Connection;
            String requete = "INSERT INTO Vehicule(Libelle, Version, IdentifiantConstructeur) VALUES(@Libelle, @Version, @IdentifiantConstructeur)";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
             
            commande.Parameters.AddWithValue("Libelle", vehicule.Libelle);
            commande.Parameters.AddWithValue("Version", vehicule.Version);
            commande.Parameters.AddWithValue("IdentifiantConstructeur", vehicule.constructeur.Identifiant);
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Vehicule vehicule)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Vehicule 
                               SET(Libelle=@Libelle, Version=@Version, IdentifiantConstructeur=@IdentifiantConstructeur)                                    WHERE Identifiant=@Identifiant";
            
            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", vehicule.Identifiant);
            commande.Parameters.AddWithValue("Libelle", vehicule.Libelle);
            commande.Parameters.AddWithValue("Version", vehicule.Version);
            commande.Parameters.AddWithValue("IdentifiantConstructeur", vehicule.constructeur.Identifiant);
            
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
