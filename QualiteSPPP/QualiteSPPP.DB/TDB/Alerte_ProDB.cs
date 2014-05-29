using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Alerte_ProDB
    {	    
	    public static String champs = "Message,Date,ID_Produit";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Alerte_Pro";
	            

	    public static List<Alerte_Pro> List()
	    {
	        List<Alerte_Pro> listeAlerte_Pro = new List<Alerte_Pro>();
	   
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
               Alerte_Pro alerte_Pro = new Alerte_Pro(); 
	       alerte_Pro.Identifiant = dataReader.GetInt32(0);
	       alerte_Pro.Message = dataReader.GetString(1);
           alerte_Pro.Date = dataReader.GetDateTime(2);
           alerte_Pro.ID_Produit = dataReader.GetInt32(3);
	       listeAlerte_Pro.Add(alerte_Pro);
            }

            dataReader.Close();
            connection.Close();

	        return listeAlerte_Pro;
	    }

        public static Alerte_Pro Get(Int32 Identifiant)
	    {
	        Alerte_Pro alerte_Pro = new Alerte_Pro();
	   
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
            alerte_Pro.Identifiant = dataReader.GetInt32(0);
            alerte_Pro.Message = dataReader.GetString(1);
            alerte_Pro.Date = dataReader.GetDateTime(2);
            alerte_Pro.ID_Produit = dataReader.GetInt32(3);
            dataReader.Close();
            connection.Close();

	        return alerte_Pro;
	    }

        public static Boolean Insert(Alerte_Pro alerte_Pro)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"INSERT INTO Alerte_Pro (" + champs + ") VALUES (Message,Date,ID_Produit);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Message", alerte_Pro.Message);
            commande.Parameters.AddWithValue("Date", alerte_Pro.Date);
            commande.Parameters.AddWithValue("ID_Produit", alerte_Pro.ID_Produit);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Alerte_Pro alerte_Pro)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"UPDATE Alerte_Pro
                               SET Message=@Message,Date=@Date,ID_Produit=@ID_Produit
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",alerte_Pro.Identifiant);
            commande.Parameters.AddWithValue("Message", alerte_Pro.Message);
            commande.Parameters.AddWithValue("Date", alerte_Pro.Date);
            commande.Parameters.AddWithValue("ID_Produit", alerte_Pro.ID_Produit);
            
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
            String requete = @"DELETE Alerte_Pro
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
            String requete = @"SELECT  MAX(Identifiant) FROM Alerte_Pro;";

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
