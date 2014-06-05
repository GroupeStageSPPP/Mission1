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
	    public static String champs = "ReferenceTeinte,RisqueTeinte,L,A,B,Min,Norme,Max,ID_Constructeur,ID_Appret,ID_Vernis";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Teinte";


        public static List<Teinte> List(Int32 ID_Constructeur)
	    {
	        List<Teinte> listeTeinte = new List<Teinte>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
            String requete = select + " WHERE ID_Constructeur = @ID_Constructeur;";
	   
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
                    Teinte teinte = new Teinte(); 
	                teinte.Identifiant = dataReader.GetInt32(0);
                    teinte.ReferenceTeinte = dataReader.GetString(1);
                    teinte.RisqueTeinte = dataReader.GetString(2);
                    teinte.L = dataReader.GetInt32(3);
                    teinte.A = dataReader.GetInt32(4);
                    teinte.B = dataReader.GetInt32(5);
                    teinte.Min =   dataReader.GetInt32(6);
                    teinte.Norme = dataReader.GetInt32(7);
                    teinte.Max =   dataReader.GetInt32(8);
                    teinte.ID_Constructeur = dataReader.GetInt32(9);
                    teinte.ID_Appret = dataReader.GetInt32(10);
                    teinte.ID_Vernis = dataReader.GetInt32(11);
	                listeTeinte.Add(teinte);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                listeTeinte = null;
            }
            finally
            {
                connection.Close();
            }
	            return listeTeinte;
	    }

        public static Teinte Get(Int32 Identifiant)
	    {
	        Teinte teinte = new Teinte();
	   
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
                dataReader.Read();
                teinte.Identifiant = dataReader.GetInt32(0);
                teinte.Identifiant = dataReader.GetInt32(0);
                teinte.ReferenceTeinte = dataReader.GetString(1);
                teinte.RisqueTeinte = dataReader.GetString(2);
                teinte.L = dataReader.GetInt32(3);
                teinte.A = dataReader.GetInt32(4);
                teinte.B = dataReader.GetInt32(5);
                teinte.Min = dataReader.GetInt32(6);
                teinte.Norme = dataReader.GetInt32(7);
                teinte.Max = dataReader.GetInt32(8);
                teinte.ID_Constructeur = dataReader.GetInt32(9);
                teinte.ID_Appret = dataReader.GetInt32(10);
                teinte.ID_Vernis = dataReader.GetInt32(11);
                dataReader.Close();


            }
            catch (Exception)
            {
                teinte = null;
            }
            finally
            {
                connection.Close();
            }
	            return teinte;
	    }

        public static Boolean Insert(Teinte teinte)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Teinte (" + champs + ") VALUES (@ReferenceTeinte,@RisqueTeinte,@L,@A,@B,@Min,@Norme,@Max,@ID_Constructeur,@ID_Appret,@ID_Vernis);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ReferenceTeinte",teinte.ReferenceTeinte);
            commande.Parameters.AddWithValue("RisqueTeinte",teinte.RisqueTeinte);
            commande.Parameters.AddWithValue("L",teinte.L);
            commande.Parameters.AddWithValue("A",teinte.A);
            commande.Parameters.AddWithValue("B",teinte.B);
            commande.Parameters.AddWithValue("Min",teinte.Min);
            commande.Parameters.AddWithValue("Norme",teinte.Norme);
            commande.Parameters.AddWithValue("Max",teinte.Max);
            commande.Parameters.AddWithValue("ID_Constructeur",teinte.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Appret",teinte.ID_Appret);
            commande.Parameters.AddWithValue("ID_Vernis",teinte.ID_Vernis);     
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

        public static Boolean Update(Teinte teinte)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Teinte
                               SET ReferenceTeinte=@ReferenceTeinte,RisqueTeinte=@RisqueTeinte,
                                   L=@L,A=@A,B=@B,
                                   Min=@Min,Norme=@Norme,Max=@Max,
                                   ID_Constructeur=@ID_Constructeur,ID_Appret=@ID_Appret,ID_Vernis=@ID_Vernis
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",teinte.Identifiant);
            commande.Parameters.AddWithValue("ReferenceTeinte",teinte.ReferenceTeinte);
            commande.Parameters.AddWithValue("RisqueTeinte",teinte.RisqueTeinte);
            commande.Parameters.AddWithValue("L",teinte.L);
            commande.Parameters.AddWithValue("A",teinte.A);
            commande.Parameters.AddWithValue("B",teinte.B);
            commande.Parameters.AddWithValue("Min",teinte.Min);
            commande.Parameters.AddWithValue("Norme",teinte.Norme);
            commande.Parameters.AddWithValue("Max",teinte.Max);
            commande.Parameters.AddWithValue("ID_Constructeur",teinte.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Appret",teinte.ID_Appret);
            commande.Parameters.AddWithValue("ID_Vernis",teinte.ID_Vernis);  
            
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
            String requete = @"DELETE Teinte
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
            String requete = @"SELECT  MAX(Identifiant) FROM Teinte;";

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



