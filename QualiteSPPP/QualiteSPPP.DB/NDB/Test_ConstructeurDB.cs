﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Test_ConstructeurDB
    {	    
	    public static String champs = "Min,Norme,Max,ID_Test,ID_Constructeur";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Test_Constructeur";
	            

	    public static List<Test_Constructeur> List(Int32 ID_Constructeur)
	    {
	        List<Test_Constructeur> listeTest_Constructeur = new List<Test_Constructeur>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
	        String requete = select+" WHERE ID_Constructeur=@ID_Constructeur;";

	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Constructeur", ID_Constructeur);
            
            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
	    
	            while (dataReader.Read())
                {
                    Test_Constructeur test_constructeur = new Test_Constructeur(); 
	                test_constructeur.Identifiant     = dataReader.GetInt32(0);
                    test_constructeur.Min             = dataReader.GetDouble(1);
                    test_constructeur.Norme           = dataReader.GetDouble(2);
                    test_constructeur.Max             = dataReader.GetDouble(3);
                    test_constructeur.ID_Test         = dataReader.GetInt32(4);
                    test_constructeur.ID_Constructeur = dataReader.GetInt32(5);

	                test_constructeur.Nom = (TestDB.Get(test_constructeur.ID_Test)).Nom+" "+(ConstructeurDB.Get(test_constructeur.ID_Constructeur)).Nom;
                    listeTest_Constructeur.Add(test_constructeur);
                }

                dataReader.Close();
                connection.Close();

	            
            }
            catch (Exception)
            {
                listeTest_Constructeur = null;
            }
            finally
            {
                connection.Close();
            }
            return listeTest_Constructeur;
	    }

        public static Test_Constructeur Get(Int32 Identifiant)
	    {
	        Test_Constructeur test_constructeur = new Test_Constructeur();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
	        String requete = select+" WHERE Identifiant = @Identifiant;";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant );

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                dataReader.Read();
                test_constructeur.Identifiant     = dataReader.GetInt32(0);
                test_constructeur.Min             = dataReader.GetDouble(1);
                test_constructeur.Norme           = dataReader.GetDouble(2);
                test_constructeur.Max             = dataReader.GetDouble(3);
                test_constructeur.ID_Test         = dataReader.GetInt32(4);
                test_constructeur.ID_Constructeur = dataReader.GetInt32(5);
                dataReader.Close();
                connection.Close();

	           
            }
            catch (Exception)
            {
                test_constructeur =  null;
            }
            finally
            {
                connection.Close();
            }
            return test_constructeur;
	    }

        public static Boolean Insert(Test_Constructeur test_constructeur)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Test_Constructeur ("+champs+") VALUES (@Min,@Norme,@Max,@ID_Test,@ID_Constructeur);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres                        
            commande.Parameters.AddWithValue("Min", test_constructeur.Min);
            commande.Parameters.AddWithValue("Norme", test_constructeur.Norme);
            commande.Parameters.AddWithValue("Max", test_constructeur.Max);
            commande.Parameters.AddWithValue("ID_Test", test_constructeur.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", test_constructeur.ID_Constructeur);

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

        public static Boolean Update(Test_Constructeur test_constructeur)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Test_Constructeur
                               SET Min=@Min,Norme=@Norme,Max=@Max,ID_Test=@ID_Test,ID_Constructeur=@ID_Constructeur
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",test_constructeur.Identifiant);
            commande.Parameters.AddWithValue("Min", test_constructeur.Min);
            commande.Parameters.AddWithValue("Norme", test_constructeur.Norme);
            commande.Parameters.AddWithValue("Max", test_constructeur.Max);
            commande.Parameters.AddWithValue("ID_Test", test_constructeur.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", test_constructeur.ID_Constructeur);
            
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

        public static Boolean Delete(Int32 Identifiant)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"DELETE Test_Constructeur
                               WHERE Identifiant=@Identifiant ;";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

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
    }
}