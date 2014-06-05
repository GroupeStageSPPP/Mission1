using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Alerte_EchDB
    {	    
	    public static String champs = "Message,Date,ID_Echantillon";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Alerte_Ech";
	            

	    public static List<Alerte_Ech> List()
	    {
	        List<Alerte_Ech> listeAlerte_Ech = new List<Alerte_Ech>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
	        String requete = select+";";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
	    
	            while (dataReader.Read())
                {
                   Alerte_Ech alerte_Ech = new Alerte_Ech(); 
	           alerte_Ech.Identifiant = dataReader.GetInt32(0);
	           alerte_Ech.Message = dataReader.GetString(1);
               alerte_Ech.Date = dataReader.GetDateTime(2);
               alerte_Ech.ID_Echantillon = dataReader.GetInt32(3);
	           listeAlerte_Ech.Add(alerte_Ech);
                }

                dataReader.Close();

	            return listeAlerte_Ech;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            

	    }

        public static Alerte_Ech Get(Int32 Identifiant)
	    {
	        Alerte_Ech alerte_Ech = new Alerte_Ech();
	   
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
            alerte_Ech.Identifiant = dataReader.GetInt32(0);
            alerte_Ech.Message = dataReader.GetString(1);
            alerte_Ech.Date = dataReader.GetDateTime(2);
            alerte_Ech.ID_Echantillon = dataReader.GetInt32(3);
            dataReader.Close();
            connection.Close();

	        return alerte_Ech;
	    }

        public static Boolean Insert(Alerte_Ech alerte_Ech)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Alerte_Ech (" + champs + ") VALUES (Message,Date,ID_Echantillon);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Message", alerte_Ech.Message);
            commande.Parameters.AddWithValue("Date", alerte_Ech.Date);
            commande.Parameters.AddWithValue("ID_Echantillon", alerte_Ech.ID_Echantillon);
            //Execution
            try
            {
                connection.Open();
                commande.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Boolean Update(Alerte_Ech alerte_Ech)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Alerte_Ech
                               SET Message=@Message,Date=@Date,ID_Echantillon=@ID_Echantillon
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",alerte_Ech.Identifiant);
            commande.Parameters.AddWithValue("Message", alerte_Ech.Message);
            commande.Parameters.AddWithValue("Date", alerte_Ech.Date);
            commande.Parameters.AddWithValue("ID_Echantillon", alerte_Ech.ID_Echantillon);
            
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
            String requete = @"DELETE Alerte_Ech
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
            String requete = @"SELECT  MAX(Identifiant) FROM Alerte_Ech;";

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
