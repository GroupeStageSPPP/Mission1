using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Pos_GdDB
    {	    
	    public static String champs = "Position";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Pos_Gd";
	            

	    public static List<Pos_Gd> List()
	    {
	        List<Pos_Gd> listePos_Gd = new List<Pos_Gd>();
	   
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
               Pos_Gd pos_Gd = new Pos_Gd(); 
	           pos_Gd.Identifiant = dataReader.GetInt32(0);
               pos_Gd.Position         = dataReader.GetString(1);
	           listePos_Gd.Add(pos_Gd);
            }

            dataReader.Close();
            connection.Close();

	        return listePos_Gd;
	    }

        public static Pos_Gd Get(Int32 Identifiant)
	    {
	        Pos_Gd pos_Gd = new Pos_Gd();
	   
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
            pos_Gd.Identifiant = dataReader.GetInt32(0);
            pos_Gd.Position         = dataReader.GetString(1);

            dataReader.Close();
            connection.Close();

	        return pos_Gd;
	    }

        public static Boolean Insert(Pos_Gd pos_Gd)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Pos_Gd ("+champs+") VALUES (@Position);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Position", pos_Gd.Position);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Pos_Gd pos_Gd)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Pos_Gd
                               SET Position=@Position
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",pos_Gd.Identifiant);
            commande.Parameters.AddWithValue("Position",pos_Gd.Position );
            
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
            String requete = @"DELETE Pos_Gd
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
            String requete = @"SELECT  MAX(Identifiant) FROM Pos_Gd;";

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


   
