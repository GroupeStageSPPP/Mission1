using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Pos_AvArDB
    {	    
	    public static String champs = "Position";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Pos_AvAr";
	            

	    public static List<Pos_AvAr> List()
	    {
	        List<Pos_AvAr> listePos_AvAr = new List<Pos_AvAr>();
	   
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
               Pos_AvAr pos_AvAr = new Pos_AvAr(); 
	           pos_AvAr.Identifiant = dataReader.GetInt32(0);
               pos_AvAr.Position         = dataReader.GetString(1);
	           listePos_AvAr.Add(pos_AvAr);
            }

            dataReader.Close();
            connection.Close();

	        return listePos_AvAr;
	    }

        public static Pos_AvAr Get(Int32 Identifiant)
	    {
	        Pos_AvAr pos_AvAr = new Pos_AvAr();
	   
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
            pos_AvAr.Identifiant = dataReader.GetInt32(0);
            pos_AvAr.Position         = dataReader.GetString(1);

            dataReader.Close();
            connection.Close();

	        return pos_AvAr;
	    }

        public static Boolean Insert(Pos_AvAr pos_AvAr)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Pos_AvAr ("+champs+") VALUES (@Position);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Position", pos_AvAr.Position);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Pos_AvAr pos_AvAr)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Pos_AvAr
                               SET Position=@Position
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",pos_AvAr.Identifiant);
            commande.Parameters.AddWithValue("Position",pos_AvAr.Position );
            
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
            String requete = @"DELETE Pos_AvAr
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
            String requete = @"SELECT  MAX(Identifiant) FROM Pos_AvAr;";

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


   
