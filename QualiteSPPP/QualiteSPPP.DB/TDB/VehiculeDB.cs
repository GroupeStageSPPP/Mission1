using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class VehiculeDB
    {	    
	    public static String champs = "Nom,ID_Constructeur";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Vehicule";
	            

	    public static List<Vehicule> List()
	    {
	        List<Vehicule> listeVehicule = new List<Vehicule>();
	   
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
               Vehicule vehicule = new Vehicule(); 
	           vehicule.Identifiant = dataReader.GetInt32(0);
               vehicule.Nom         = dataReader.GetString(1);
               vehicule.ID_Constructeur= dataReader.GetInt32(2);
	           listeVehicule.Add(vehicule);
            }

            dataReader.Close();
            connection.Close();

	        return listeVehicule;
	    }

        public static Vehicule Get(Int32 Identifiant)
	    {
	        Vehicule vehicule = new Vehicule();
	   
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
            vehicule.Identifiant = dataReader.GetInt32(0);
            vehicule.Nom         = dataReader.GetString(1);
            vehicule.ID_Constructeur = dataReader.GetInt32(2);

            dataReader.Close();
            connection.Close();

	        return vehicule;
	    }

        public static Boolean Insert(Vehicule vehicule)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Vehicule (" + champs + ") VALUES (@Nom,@ID_Constructeur);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", vehicule.Nom);
            commande.Parameters.AddWithValue("ID_Constructeur", vehicule.ID_Constructeur);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Vehicule vehicule)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Vehicule
                               SET Nom=@Nom,ID_Constructeur=@ID_Constructeur
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",vehicule.Identifiant);
            commande.Parameters.AddWithValue("Nom",vehicule.Nom );
            commande.Parameters.AddWithValue("ID_Constructeur", vehicule.ID_Constructeur);
            
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
            String requete = @"DELETE Vehicule
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
            String requete = @"SELECT  MAX(Identifiant) FROM Vehicule;";

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


   
