﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class CategorieDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la color de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Categorie> List()
        {
            
            SqlConnection connection = DataBase.Connection;
            
            String requete = "SELECT Identifiant, Libelle FROM Categorie";
            
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete, connection);
            
            
            SqlDataReader dataReader = commande.ExecuteReader();

            List<Categorie> list = new List<Categorie>();
            
            while (dataReader.Read())
            {
                
                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Categorie categorie = new Categorie();
                categorie.Identifiant = dataReader.GetInt32(0);
                categorie.Libelle = dataReader.GetString(1);


                //2 - Ajouter cette civilité à la list de civilité
                list.Add(categorie);
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
        public static Categorie Get(Int32 Identifiant)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            String requete = @"SELECT Identifiant, Libelle FROM Categorie
                                WHERE Identifiant=@Identifiant";
            
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Categorie categorie = new Categorie();

            categorie.Identifiant = dataReader.GetInt32(0);
            categorie.Libelle = dataReader.GetString(1);
            
            dataReader.Close();
            connection.Close();
            
            return categorie;
        }





        public static void Insert(Categorie categorie)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            String requete = @"INSERT INTO Categorie(Libelle) VALUES(@Libelle)";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Libelle", categorie.Libelle);

             
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Categorie categorie)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            String requete = @"UPDATE Categorie  
                               SETLibelle=@Libelle  
                               WHERE Identifiant=@Identifiant;";
           
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", categorie.Identifiant);
            commande.Parameters.AddWithValue("Libelle", categorie.Libelle);
            
            commande.ExecuteNonQuery();

            connection.Close();
        }
        
        public static void Delete(Int32 Identifiant)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            
            String requete = @"DELETE FROM Categorie 
                               WHERE Identifiant=@Identifiant";
            
            connection.Open();
            
             
            SqlCommand commande = new SqlCommand(requete, connection);
            
            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}