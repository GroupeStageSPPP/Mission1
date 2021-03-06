﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class AppretDB
    {	    
	    public static String champs = "Reference,Min,Norme,Max";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Appret";
	            

	    public static List<Appret> List()
	    {
	        List<Appret> listeAppret = new List<Appret>();
	   
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
                    Appret appret = new Appret();
                    appret.Identifiant = dataReader.GetInt32(0);
                    appret.Reference = dataReader.GetString(1);
                    appret.Min = dataReader.GetInt32(2);
                    appret.Norme = dataReader.GetInt32(3);
                    appret.Max = dataReader.GetInt32(4);
                    listeAppret.Add(appret);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                listeAppret = null;
            }
            finally
            {
                connection.Close();
            }

	        return listeAppret;
	    }

        public static Appret Get(Int32 Identifiant)
	    {
	        Appret appret = new Appret();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
	        String requete = select+" WHERE Identifiant = @Identifiant;";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    appret.Identifiant = dataReader.GetInt32(0);
                    appret.Reference = dataReader.GetString(1);
                    appret.Min = dataReader.GetInt32(2);
                    appret.Norme = dataReader.GetInt32(3);
                    appret.Max = dataReader.GetInt32(4);
                }

                dataReader.Close();



            }
            catch (Exception)
            {
                appret = null;
            }
            finally
            {
                connection.Close();
            }
	        return appret;
	    }

        public static Boolean Insert(Appret appret)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Appret (" + champs + ") VALUES (@Reference,@Min,@Norme,@Max);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Reference", appret.Reference);
            commande.Parameters.AddWithValue("Min", appret.Min);
            commande.Parameters.AddWithValue("Norme", appret.Norme);
            commande.Parameters.AddWithValue("Max", appret.Max);

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

        public static Boolean Update(Appret appret)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Appret
                               SET Reference=@Reference,Min=@Min,Norme=@Norme,Max=@Max
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",appret.Identifiant);
            commande.Parameters.AddWithValue("Reference", appret.Reference);
            commande.Parameters.AddWithValue("Min", appret.Min);
            commande.Parameters.AddWithValue("Norme", appret.Norme);
            commande.Parameters.AddWithValue("Max", appret.Max);

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
            String requete = @"DELETE Appret
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
	
	public static Int32 LastID()
	{
	    Int32 Identifiant = 0;
	    //Connection
            SqlConnection connection = DataBase.Connection();
            //Requete
            String requete = @"SELECT  MAX(Identifiant) FROM Appret;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            try
            {
                connection.Open();
                SqlDataReader dataReader = commande.ExecuteReader();
                dataReader.Read();
                Identifiant = dataReader.GetInt32(0);
                connection.Close();
                return Identifiant;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }

	}    
    }
}
