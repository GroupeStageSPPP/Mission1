using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class ProduitDB
    {
        public static String champs = "Nom,ISconforme,SuiteConforme,ISactif,ID_Piece,ID_Teinte,ID_PosAvAr,ID_PosGD";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Produit";
	            

	    public static List<Produit> List()
	    {
	        List<Produit> listeProduit = new List<Produit>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
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
               Produit produit = new Produit(); 
	           produit.Identifiant   = dataReader.GetInt32(0);
	           produit.Nom           = dataReader.GetString(1);
               produit.ISconforme    = dataReader.GetInt16(2);
               produit.SuiteConforme = dataReader.GetInt32(3);
               produit.ISactif       = dataReader.GetInt16(4);
               produit.ID_Piece      = dataReader.GetInt32(5);
               produit.ID_Teinte     = dataReader.GetInt32(6);
               produit.ID_PosAvAr    = dataReader.GetInt32(7);
               produit.ID_PosGD      = dataReader.GetInt32(8);
	           listeProduit.Add(produit);
            }

            dataReader.Close();
            connection.Close();

	        return listeProduit;
	    }

        public static List<Produit> List(Int32 ID_Piece, Int32 ID_Teinte)
        {
            List<Produit> listeProduit = new List<Produit>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE ID_Piece=@ID_Piece, ID_Teinte=@ID_Teinte;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Piece", ID_Piece);
            commande.Parameters.AddWithValue("ID_Teinte", ID_Teinte);

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Produit produit = new Produit();
                produit.Identifiant = dataReader.GetInt32(0);
                produit.Nom = dataReader.GetString(1);
                produit.ISconforme = dataReader.GetInt16(2);
                produit.SuiteConforme = dataReader.GetInt32(3);
                produit.ISactif = dataReader.GetInt16(4);
                produit.ID_Piece = dataReader.GetInt32(5);
                produit.ID_Teinte = dataReader.GetInt32(6);
                produit.ID_PosAvAr = dataReader.GetInt32(7);
                produit.ID_PosGD = dataReader.GetInt32(8);
                listeProduit.Add(produit);
            }

            dataReader.Close();
            connection.Close();

            return listeProduit;
        }

        public static Produit Get(Int32 Identifiant)
	    {
	        Produit produit = new Produit();
	   
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
            produit.Identifiant = dataReader.GetInt32(0);
            produit.Nom = dataReader.GetString(1);
            produit.ISconforme = dataReader.GetInt16(2);
            produit.SuiteConforme = dataReader.GetInt32(3);
            produit.ISactif = dataReader.GetInt16(4);
            produit.ID_Piece = dataReader.GetInt32(5);
            produit.ID_Teinte = dataReader.GetInt32(6);
            produit.ID_PosAvAr = dataReader.GetInt32(7);
            produit.ID_PosGD = dataReader.GetInt32(8);
            dataReader.Close();
            connection.Close();

	        return produit;
	    }

        public static Boolean Insert(Produit produit)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Produit (" + champs + ") VALUES (@Nom,@ISconforme,@SuiteConforme,@ISactif,@ID_Piece,@ID_Teinte,@ID_PosAvAr,@ID_PosGD);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", produit.Nom);
            commande.Parameters.AddWithValue("ISconforme", produit.ISconforme);
            commande.Parameters.AddWithValue("SuiteConforme", produit.SuiteConforme);
            commande.Parameters.AddWithValue("ISactif", produit.ISactif);
            commande.Parameters.AddWithValue("ID_Piece", produit.ID_Piece);
            commande.Parameters.AddWithValue("ID_Teinte", produit.ID_Teinte);
            commande.Parameters.AddWithValue("ID_PosAvAr", produit.ID_PosAvAr);
            commande.Parameters.AddWithValue("ID_PosGD", produit.ID_PosGD);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Produit produit)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Produit
                               SET Nom=@Nom,ISconforme=@ISconforme,SuiteConforme=@SuiteConforme,ISactif=@ISactif,ID_Piece=@ID_Piece,ID_Teinte=@ID_Teinte,ID_PosAvAr=@ID_PosAvAr,ID_PosGD=@ID_PosGD
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",produit.Identifiant);
            commande.Parameters.AddWithValue("Nom", produit.Nom);
            commande.Parameters.AddWithValue("ISconforme", produit.ISconforme);
            commande.Parameters.AddWithValue("SuiteConforme", produit.SuiteConforme);
            commande.Parameters.AddWithValue("ISactif", produit.ISactif);
            commande.Parameters.AddWithValue("ID_Piece", produit.ID_Piece);
            commande.Parameters.AddWithValue("ID_Teinte", produit.ID_Teinte);
            commande.Parameters.AddWithValue("ID_PosAvAr", produit.ID_PosAvAr);
            commande.Parameters.AddWithValue("ID_PosGD", produit.ID_PosGD);
            
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
            String requete = @"DELETE Produit
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
                String requete = @"SELECT  MAX(Identifiant) FROM Produit;";

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
