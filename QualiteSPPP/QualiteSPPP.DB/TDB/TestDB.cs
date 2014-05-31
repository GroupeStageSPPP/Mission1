using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class TestDB
    {	    
	    public static String champs = "Nom,Description,TypeTest";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Test";
	            

	    public static List<Test> List()
	    {
	        List<Test> listeTest = new List<Test>();
	   
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
               Test test = new Test();
               test.Identifiant = dataReader.GetInt32(0);
               test.Nom = dataReader.GetString(1);
               test.Description = dataReader.GetString(2);
               test.TypeTest = dataReader.GetInt16(3);
	           listeTest.Add(test);
            }

            dataReader.Close();
            connection.Close();

	        return listeTest;
	    }

        public static Test Get(Int32 Identifiant)
	    {
	        Test test = new Test();
	   
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
            test.Identifiant = dataReader.GetInt32(0);
            test.Nom         = dataReader.GetString(1);
            test.Description = dataReader.GetString(2);
            test.TypeTest    = dataReader.GetInt16(3);
            dataReader.Close();
            connection.Close();

	        return test;
	    }

        public static Boolean Insert(Test test)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Test ("+champs+") VALUES (@Nom,@Description,@TypeTest);"; 
                                                                     
                                                                        
            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", test.Nom);
            commande.Parameters.AddWithValue("Description", test.Description);
            commande.Parameters.AddWithValue("TypeTest", test.TypeTest);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Test test)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Test
                               SET Nom=@Nom,Description=@Description,TypeTest=@TypeTest
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",test.Identifiant);
            commande.Parameters.AddWithValue("Nom", test.Nom);
            commande.Parameters.AddWithValue("Description", test.Description);
            commande.Parameters.AddWithValue("TypeTest", test.TypeTest);
            
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
            String requete = @"DELETE Test
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
                String requete = @"SELECT  MAX(Identifiant) FROM Test;";

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
