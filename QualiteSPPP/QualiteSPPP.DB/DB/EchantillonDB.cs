﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class EchantillonDB
    {
        /// <summary>
        /// Récupère une liste de Echantillon à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Echantillon> List()
        {

            
            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, NumLot, DatePeinture, NumSerie, ISconforme, IdentifiantProjet FROM Echantillon";
           
            connection.Open();
            
            
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Echantillon> list = new List<Echantillon>();
            while (dataReader.Read())
            {

                Echantillon echantillon = new Echantillon();
                echantillon.Identifiant = dataReader.GetInt32(0);
                echantillon.NumLot = dataReader.GetString(1);
                echantillon.DatePeinture = dataReader.GetDateTime(2);
                echantillon.NumSerie = dataReader.GetInt16(3);
                echantillon.ISconforme = dataReader.GetChar(4);
                echantillon.projet.Identifiant = dataReader.GetInt32(5);
                echantillon.peinture.Identifiant = dataReader.GetInt32(6);

                list.Add(echantillon);
            }

            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Echantillon à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Echantillon</param>
        /// <returns>Un Echantillon </returns>
        public static Echantillon Get(Int32 Identifiant)
        {
            

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, NumLot, DatePeinture, NumSerie, ISconforme, IdentifiantProjet FROM Echantillon
                                WHERE Identifiant = @Identifiant";
            
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Echantillon
            Echantillon echantillon = new Echantillon();
            echantillon.Identifiant = dataReader.GetInt32(0);
            echantillon.NumLot = dataReader.GetString(1);
            echantillon.DatePeinture = dataReader.GetDateTime(2);
            echantillon.NumSerie = dataReader.GetInt16(3);
            echantillon.ISconforme = dataReader.GetChar(4);
            echantillon.projet.Identifiant = dataReader.GetInt32(5);
            echantillon.peinture.Identifiant = dataReader.GetInt32(6);
            dataReader.Close();
            connection.Close();
            return echantillon;
        }

        public static void Insert(Echantillon echantillon)
        {

            
            SqlConnection connection = DataBase.Connection;
            String requete = @"INSERT INTO Echantillon( NumLot, DatePeinture, NumSerie, ISconforme, IdentifiantProjet, IdentifiantPeinture) 
                              VALUES(@NumLot, @DatePeinture, NumSerie, @IdentifiantProjet, @IdentifiantPeinture) SELECT SCOPE_IDENTITY() ;";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("", echantillon.NumLot);
            commande.Parameters.AddWithValue("DatePeinture", echantillon.DatePeinture);
            commande.Parameters.AddWithValue("NumSerie", echantillon.NumSerie);
            commande.Parameters.AddWithValue("ISconforme", echantillon.ISconforme);
            commande.Parameters.AddWithValue("IdentifiantProjet", echantillon.projet.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", echantillon.peinture.Identifiant); 
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Echantillon echantillon)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Echantillon  
                               SET NumLot=@NumLot, DatePeinture=@DatePeinture, NumSerie=@NumSerie, ISconforme=@ISconforme, IdentifiantProjet=@IdentifiantProjet, IdentifiantPeinture=@IdentifiantPeinture 
                               WHERE Identifiant=@Identifiant;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", echantillon.Identifiant);
            commande.Parameters.AddWithValue("", echantillon.NumLot);
            commande.Parameters.AddWithValue("DatePeinture", echantillon.DatePeinture);
            commande.Parameters.AddWithValue("NumSerie", echantillon.NumSerie);
            commande.Parameters.AddWithValue("ISconforme", echantillon.ISconforme);
            commande.Parameters.AddWithValue("IdentifiantProjet", echantillon.projet.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", echantillon.peinture.Identifiant);
            
            commande.ExecuteNonQuery();

            connection.Close();
        }       
        
        public static void Delete(Int32 Identifiant)
        {
             

            SqlConnection connection = DataBase.Connection;
            
            String requete = @"DELETE Echantillon WHERE Identifiant=@Identifiant;";

            connection.Open();             

            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("Identifiant", Identifiant);
            
            commande.ExecuteNonQuery();

            
            connection.Close();
        }

    }
}
