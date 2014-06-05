using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Test_Ctor_PieceDB
    {	    
	    public static String champs = "ID_Test,ID_Constructeur,ID_Piece";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Test_Ctor_Piece";
	            

	    public static List<Test_Ctor_Piece> List()
	    {
	        List<Test_Ctor_Piece> listeTest_Ctor_Piece = new List<Test_Ctor_Piece>();
	   
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
                    Test_Ctor_Piece test_ctor_piece = new Test_Ctor_Piece(); 
	                test_ctor_piece.Identifiant = dataReader.GetInt32(0);
                    test_ctor_piece.ID_Test = dataReader.GetInt32(1);
                    test_ctor_piece.ID_Constructeur = dataReader.GetInt32(2);
                    test_ctor_piece.ID_Piece = dataReader.GetInt32(3);
	                listeTest_Ctor_Piece.Add(test_ctor_piece);
                }

                dataReader.Close();
                connection.Close();

	            
            }
            catch (Exception)
            {
                listeTest_Ctor_Piece =  null;
            }
            finally
            {
                connection.Close();
            }
            return listeTest_Ctor_Piece;

	    }

        public static List<Test_Ctor_Piece> List(Int32 ID_Piece)
        {
            List<Test_Ctor_Piece> listeTest_Ctor_Piece = new List<Test_Ctor_Piece>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE ID_Piece=@ID_Piece;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Piece", ID_Piece);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Test_Ctor_Piece test_ctor_piece = new Test_Ctor_Piece();
                    test_ctor_piece.Identifiant = dataReader.GetInt32(0);
                    test_ctor_piece.ID_Test = dataReader.GetInt32(1);
                    test_ctor_piece.ID_Constructeur = dataReader.GetInt32(2);
                    test_ctor_piece.ID_Piece = dataReader.GetInt32(3);
                    test_ctor_piece.Nom = PieceDB.Get(test_ctor_piece.ID_Piece) + " " + TestDB.Get(test_ctor_piece.ID_Test);
                    listeTest_Ctor_Piece.Add(test_ctor_piece);
                }

                dataReader.Close();
                connection.Close();

                
            }
            catch (Exception)
            {
                listeTest_Ctor_Piece = null;
            }
            finally
            {
                connection.Close();
            }
            return listeTest_Ctor_Piece;

        }

        public static Test_Ctor_Piece Get(Int32 Identifiant)
	    {
	        Test_Ctor_Piece test_ctor_piece = new Test_Ctor_Piece();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
            String requete = select + " WHERE Identifiant = @Identifiant;";
	   
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
                test_ctor_piece.Identifiant = dataReader.GetInt32(0);
                test_ctor_piece.ID_Test = dataReader.GetInt32(1);
                test_ctor_piece.ID_Constructeur = dataReader.GetInt32(2);
                test_ctor_piece.ID_Piece = dataReader.GetInt32(3);
                dataReader.Close();
                connection.Close();

	            
            }
            catch (Exception)
            {
                test_ctor_piece =  null;
            }
            finally
            {
                connection.Close();
            }
            return test_ctor_piece;

	    }

        public static Boolean Insert(Test_Ctor_Piece test_ctor_piece)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Test_Ctor_Piece ("+champs+") VALUES (@ID_Test,@ID_Constructeur,@ID_Piece);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Test", test_ctor_piece.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", test_ctor_piece.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Piece", test_ctor_piece.ID_Piece);
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

        public static Boolean Update(Test_Ctor_Piece test_ctor_piece)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Test_Ctor_Piece
                               SET ID_Test=@ID_Test,ID_Constructeur=@ID_Constructeur,ID_Piece=@ID_Piece
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",test_ctor_piece.Identifiant);
            commande.Parameters.AddWithValue("ID_Test", test_ctor_piece.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", test_ctor_piece.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Piece", test_ctor_piece.ID_Piece);
            
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
            String requete = @"DELETE Test_Ctor_Piece
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