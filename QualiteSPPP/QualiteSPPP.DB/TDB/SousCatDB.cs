using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class SousCatDB
    {	    
	    public static String champs = "Nom,ID_Categorie";
	    public static String select = "SELECT Identifiant,"+champs+" FROM SousCat";
	            

	    public static List<SousCat> List()
	    {
	        List<SousCat> listeSousCat = new List<SousCat>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection;
	   
	        //Requete  
	        String requete = select+";";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
	    
	        while (dataReader.Read())
            {
               SousCat sousCat = new SousCat(); 
	           sousCat.Identifiant = dataReader.GetInt32(0);
               sousCat.Nom         = dataReader.GetString(1);
               sousCat.ID_Categorie= dataReader.GetInt32(2);
	           listeSousCat.Add(sousCat);
            }

            dataReader.Close();
            connection.Close();

	        return listeSousCat;
	    }

        public static SousCat Get(Int32 Identifiant)
	    {
	        SousCat sousCat = new SousCat();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection;
	   
	        //Requete  
	        String requete = select+" WHERE Identifiant = @Identifiant;";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
            sousCat.Identifiant = dataReader.GetInt32(0);
            sousCat.Nom         = dataReader.GetString(1);
            sousCat.ID_Categorie = dataReader.GetInt32(2);

            dataReader.Close();
            connection.Close();

	        return sousCat;
	    }

        public static Boolean Insert(SousCat sousCat)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"INSERT INTO SousCat (" + champs + ") VALUES (@Nom,@ID_Categorie);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", sousCat.Nom);
            commande.Parameters.AddWithValue("ID_Categorie", sousCat.ID_Categorie);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(SousCat sousCat)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"UPDATE SousCat
                               SET Nom=@Nom,ID_Categorie=@ID_Categorie
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",sousCat.Identifiant);
            commande.Parameters.AddWithValue("Nom",sousCat.Nom );
            commande.Parameters.AddWithValue("ID_Categorie", sousCat.ID_Categorie);
            
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public static Boolean Delete(Int32 Identifiant)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"DELETE SousCat
                               WHERE Identifiant=@Identifiant ;";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }	
        public static Int32 LastID()
	    {
	        Int32 Identifiant = 0;
	        //Connection
            SqlConnection connection = DataBase.Connection;
            //Requete
            String requete = @"SELECT  MAX(Identifiant) FROM SousCat;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);
	    
	        connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
	        Identifiant = dataReader.GetInt32(0);
            connection.Close();
            return Identifiant; 
	    } 
    }
}


   
