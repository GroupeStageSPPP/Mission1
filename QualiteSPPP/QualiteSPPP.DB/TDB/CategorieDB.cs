using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class CategorieDB
    {	    
	    public static String champs = "Nom";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Categorie";
	            

	    public static List<Categorie> List()
	    {
	        List<Categorie> listeCategorie = new List<Categorie>();
	   
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

               Categorie categorie = new Categorie(); 
	           categorie.Identifiant = dataReader.GetInt32(0);
               categorie.Nom         = dataReader.GetString(1);
	           listeCategorie.Add(categorie);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                listeCategorie = null;
            }
            finally
            {
                connection.Close();
            }

	        return listeCategorie;
	    }

        public static Categorie Get(Int32 Identifiant)
	    {
	        Categorie categorie = new Categorie();
	   
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

                    categorie.Identifiant = dataReader.GetInt32(0);
                    categorie.Nom = dataReader.GetString(1);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                categorie = null;
            }
            finally
            {
                connection.Close();
            }

	        return categorie;
	    }

        public static Boolean Insert(Categorie categorie)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Categorie ("+champs+") VALUES (@Nom);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", categorie.Nom);
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

        public static Boolean Update(Categorie categorie)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Categorie
                               SET Nom=@Nom
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",categorie.Identifiant);
            commande.Parameters.AddWithValue("Nom",categorie.Nom );
            
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
            String requete = @"DELETE Categorie
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
            String requete = @"SELECT  MAX(Identifiant) FROM Categorie;";

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


   
