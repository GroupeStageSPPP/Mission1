using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class TeinteDB
    {	    
	    public static String champs = "Nom,RisqueTeinte,ReferenceBase,L,A,B,Min,Norme,Max,ID_Constructeur,ID_Appret,ID_Vernis";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Teinte";
	            

	    public static List<Teinte> List()
	    {
	        List<Teinte> listeTeinte = new List<Teinte>();
	   
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
                Teinte teinte = new Teinte(); 
	            teinte.Identifiant = dataReader.GetInt32(0);
                teinte.Nom = dataReader.GetString(1);
                teinte.RisqueTeinte = dataReader.GetString(2);
                teinte.ReferenceBase = dataReader.GetString(3);
                teinte.L = dataReader.GetInt32(4);
                teinte.A = dataReader.GetInt32(5);
                teinte.B = dataReader.GetInt32(6);
                teinte.Min = dataReader.GetFloat(7);
                teinte.Norm = dataReader.GetFloat(8);
                teinte.Max = dataReader.GetFloat(9);
                teinte.ID_Constructeur = dataReader.GetInt32(10);
                teinte.ID_Appret = dataReader.GetInt32(11);
                teinte.ID_Vernis = dataReader.GetInt32(12);
	            listeTeinte.Add(teinte);
            }

            dataReader.Close();
            connection.Close();

	        return listeTeinte;
	    }

        public static Teinte Get(Int32 Identifiant)
	    {
	        Teinte teinte = new Teinte();
	   
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
            teinte.Identifiant      = dataReader.GetInt32(0);
            teinte.Nom              = dataReader.GetString(1);
            teinte.RisqueTeinte     = dataReader.GetString(2);
            teinte.ReferenceBase    = dataReader.GetString(3);
            teinte.L                = dataReader.GetInt32(4);
            teinte.A                = dataReader.GetInt32(5);
            teinte.B                = dataReader.GetInt32(6);
            teinte.Min              = dataReader.GetFloat(7);
            teinte.Norm             = dataReader.GetFloat(8);
            teinte.Max              = dataReader.GetFloat(9);
            teinte.ID_Constructeur  = dataReader.GetInt32(10);
            teinte.ID_Appret        = dataReader.GetInt32(11);
            teinte.ID_Vernis        = dataReader.GetInt32(12);
            dataReader.Close();
            connection.Close();

	        return teinte;
	    }

        public static Boolean Insert(Teinte teinte)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"INSERT INTO Teinte ("+champs+") VALUES (@Nom,@RisqueTeinte,@ReferenceBase,@L,@A,@B,@Min,@Norme,@Max,@ID_Constructeur,@ID_Appret,@ID_Vernis);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom",teinte.Nom);
            commande.Parameters.AddWithValue("RisqueTeinte",teinte.RisqueTeinte);
            commande.Parameters.AddWithValue("ReferenceBase",teinte.ReferenceBase);
            commande.Parameters.AddWithValue("L",teinte.L);
            commande.Parameters.AddWithValue("A",teinte.A);
            commande.Parameters.AddWithValue("B",teinte.B);
            commande.Parameters.AddWithValue("Min",teinte.Min);
            commande.Parameters.AddWithValue("Norm",teinte.Norm);
            commande.Parameters.AddWithValue("Max",teinte.Max);
            commande.Parameters.AddWithValue("ID_Constructeur",teinte.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Appret",teinte.ID_Appret);
            commande.Parameters.AddWithValue("ID_Vernis",teinte.ID_Vernis);     
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Teinte teinte)
        {
            //Connection
            SqlConnection connection = DataBase.Connection;

            //Requete
            String requete = @"UPDATE Teinte
                               SET Nom=@Nom,RisqueTeinte=@RisqueTeinte,ReferenceBase=@ReferenceBase,
                                   L=@L,A=@A,B=@B,
                                   Min=@Min,Norme=@Norme,Max=@Max,
                                   ID_Constructeur=@ID_Constructeur,ID_Appret=@ID_Appret,ID_Vernis=@ID_Vernis
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",teinte.Identifiant);
            commande.Parameters.AddWithValue("Nom",teinte.Nom);
            commande.Parameters.AddWithValue("RisqueTeinte",teinte.RisqueTeinte);
            commande.Parameters.AddWithValue("ReferenceBase",teinte.ReferenceBase);
            commande.Parameters.AddWithValue("L",teinte.L);
            commande.Parameters.AddWithValue("A",teinte.A);
            commande.Parameters.AddWithValue("B",teinte.B);
            commande.Parameters.AddWithValue("Min",teinte.Min);
            commande.Parameters.AddWithValue("Norm",teinte.Norm);
            commande.Parameters.AddWithValue("Max",teinte.Max);
            commande.Parameters.AddWithValue("ID_Constructeur",teinte.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Appret",teinte.ID_Appret);
            commande.Parameters.AddWithValue("ID_Vernis",teinte.ID_Vernis);  
            
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
            String requete = @"DELETE Teinte
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
            String requete = @"SELECT  MAX(Identifiant) FROM Teinte;";

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



