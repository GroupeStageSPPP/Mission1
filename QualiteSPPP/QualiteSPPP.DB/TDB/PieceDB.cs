using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class PieceDB
    {
        public static String champs = "ID_Vehicule,ID_SousCat";
	    public static String select = "SELECT Identifiant,"+champs+" FROM Piece";
	            

	    public static List<Piece> List(Int32 ID_Vehicule)
	    {
	        List<Piece> listePiece = new List<Piece>();
	   
	        //Connection
            SqlConnection connection = DataBase.Connection();
	   
	        //Requete  
            String requete = select + " WHERE ID_Vehicule=@ID_Vehicule;";
	   
	        //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Vehicule", ID_Vehicule);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Piece piece = new Piece();
                    piece.Identifiant = dataReader.GetInt32(0);
                    piece.ID_Vehicule = dataReader.GetInt32(1);
                    piece.ID_SousCat = dataReader.GetInt32(2);
                    piece.Nom = SousCatDB.Get(piece.ID_SousCat).Nom;

                    listePiece.Add(piece);
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                listePiece = null;
            }
            finally
            {
                connection.Close();
            }
	        return listePiece;
	    }

        public static Piece Get(Int32 Identifiant)
	    {
	        Piece piece = new Piece();
	   
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
                    piece.Identifiant = dataReader.GetInt32(0);
                    piece.ID_Vehicule = dataReader.GetInt32(1);
                    piece.ID_SousCat = dataReader.GetInt32(2);
                    piece.Nom = SousCatDB.Get(piece.ID_SousCat).Nom;
                }

                dataReader.Close();


            }
            catch (Exception)
            {
                piece = null;
            }
            finally
            {
                connection.Close();
            }

	        return piece;
	    }

        public static Boolean Insert(Piece piece)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Piece (" + champs + ") VALUES (@ID_Vehicule,@ID_SousCat);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Vehicule", piece.ID_Vehicule);
            commande.Parameters.AddWithValue("ID_SousCat", piece.ID_SousCat);
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

        public static Boolean Update(Piece piece)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Piece
                               SET ID_Vehicule=@ID_Vehicule,ID_SousCat=@ID_SousCat
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant",piece.Identifiant);
            commande.Parameters.AddWithValue("ID_Vehicule", piece.ID_Vehicule);
            commande.Parameters.AddWithValue("ID_SousCat", piece.ID_SousCat);
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
            String requete = @"DELETE Piece
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
            String requete = @"SELECT  MAX(Identifiant) FROM Piece;";

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
