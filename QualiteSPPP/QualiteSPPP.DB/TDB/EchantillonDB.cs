using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class EchantillonDB
    {	    
	    public static String champs = "NumLot,DatePeinture,ISconforme,ID_Produit";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Echantillon";

        public static List<Echantillon> List()
        {
            List<Echantillon> listeEchantillon = new List<Echantillon>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + ";";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Echantillon echantillon = new Echantillon();
                echantillon.Identifiant = dataReader.GetInt32(0);
                echantillon.NumLot = dataReader.GetString(1);
                echantillon.DatePeinture = dataReader.GetDateTime(2);
                echantillon.ISconforme = dataReader.GetInt16(3);
                echantillon.ID_Produit = dataReader.GetInt32(4);
                listeEchantillon.Add(echantillon);
            }

            dataReader.Close();
            connection.Close();

            return listeEchantillon;
        }

	    public static List<Echantillon> List(Int16 Conforme)
	    {
	        List<Echantillon> listeEchantillon = new List<Echantillon>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
	        String requete = select+" WHERE ISconforme =@Conforme;";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Conforme", Conforme);

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
	    
	        while (dataReader.Read())
            {
               Echantillon echantillon = new Echantillon(); 
	       echantillon.Identifiant = dataReader.GetInt32(0);
	       echantillon.NumLot = dataReader.GetString(1);
           echantillon.DatePeinture = dataReader.GetDateTime(2);
           echantillon.ISconforme = dataReader.GetInt16(3);
           echantillon.ID_Produit = dataReader.GetInt32(4);
	       listeEchantillon.Add(echantillon);
            }

            dataReader.Close();
            connection.Close();

	        return listeEchantillon;
	    }

        public static Echantillon Get(Int32 Identifiant)
	    {
	        Echantillon echantillon = new Echantillon();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
	        String requete = select+" WHERE Identifiant = @Identifiant;";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();
            echantillon.Identifiant  = dataReader.GetInt32(0);
            echantillon.NumLot       = dataReader.GetString(1);
            echantillon.DatePeinture = dataReader.GetDateTime(2);
            echantillon.ISconforme   = dataReader.GetInt16(3);
            echantillon.ID_Produit   = dataReader.GetInt32(4);

            dataReader.Close();
            connection.Close();

	        return echantillon;
	    }

        public static Boolean Insert(Echantillon echantillon)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Echantillon (" + champs + ") VALUES (@NumLot,@DatePeinture,@ISconforme,@ID_Produit);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("NumLot", echantillon.NumLot);
            commande.Parameters.AddWithValue("DatePeinture", echantillon.DatePeinture);
            commande.Parameters.AddWithValue("ISconforme", echantillon.ISconforme);
            commande.Parameters.AddWithValue("ID_Produit", echantillon.ID_Produit);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Echantillon echantillon)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Echantillon
                               SET NumLot=@NumLot,DatePeinture=@DatePeinture,ISconforme=@ISconforme,ID_Produit=@ID_Produit
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",echantillon.Identifiant);
            commande.Parameters.AddWithValue("NumLot", echantillon.NumLot);
            commande.Parameters.AddWithValue("DatePeinture", echantillon.DatePeinture);
            commande.Parameters.AddWithValue("ISconforme", echantillon.ISconforme);
            commande.Parameters.AddWithValue("ID_Produit", echantillon.ID_Produit);
            
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public static Boolean Delete(Int32 Identifiant)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"DELETE Echantillon
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
            SqlConnection connection = DataBase.Connection();
            //Requete
            String requete = @"SELECT  MAX(Identifiant) FROM Echantillon;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);
	    
	    connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
        dataReader.Read();
	    Identifiant = dataReader.GetInt32(0);
            connection.Close();
	    return Identifiant; 
	}    
    }
}
