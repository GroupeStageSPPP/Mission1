using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class ConstructeurDB
    {	    
	    public static String champs = "Nom";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Constructeur";
	            

	    public static List<Constructeur> List()
	    {
	        List<Constructeur> listeConstructeur = new List<Constructeur>();
	   
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

                    Constructeur constructeur = new Constructeur();
                    constructeur.Identifiant = dataReader.GetInt32(0);
                    constructeur.Nom = dataReader.GetString(1);
                    listeConstructeur.Add(constructeur);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                listeConstructeur = null;
            }
            finally
            {
                connection.Close();
            }

	        return listeConstructeur;
	    }

        public static Constructeur Get(Int32 Identifiant)
	    {
	        Constructeur constructeur = new Constructeur();
	   
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
                    constructeur.Identifiant = dataReader.GetInt32(0);
                    constructeur.Nom = dataReader.GetString(1);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                constructeur = null;
            }
            finally
            {
                connection.Close();
            }
	        return constructeur;
	    }

        public static Boolean Insert(Constructeur constructeur)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Constructeur ("+champs+") VALUES (@Nom);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", constructeur.Nom);
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

        public static Boolean Update(Constructeur constructeur)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Constructeur
                               SET Nom=@Nom
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",constructeur.Identifiant);
            commande.Parameters.AddWithValue("Nom",constructeur.Nom );
            
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
            String requete = @"DELETE Constructeur
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
	        Int32 Identifiant;
	        //Connection
            SqlConnection connection = DataBase.Connection();
            //Requete
            String requete = @"SELECT Max(Identifiant) FROM Constructeur";

            //Commande
	        SqlCommand commande = new SqlCommand(requete, connection);
	        connection.Open();

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


   
