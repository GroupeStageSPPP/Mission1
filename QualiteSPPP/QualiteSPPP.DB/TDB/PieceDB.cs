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
	            

	    public static List<Piece> List()
	    {
	        List<Piece> listePiece = new List<Piece>();
	   
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
               Piece piece = new Piece(); 
	           piece.Identifiant = dataReader.GetInt32(0);
	           piece.ID_Vehicule = dataReader.GetInt32(1);
               piece.ID_SousCat = dataReader.GetInt32(2);
	           listePiece.Add(piece);
            }

            dataReader.Close();
            connection.Close();

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
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();
            piece.Identifiant = dataReader.GetInt32(0);
            piece.ID_Vehicule = dataReader.GetInt32(1);
            piece.ID_SousCat = dataReader.GetInt32(2);
            dataReader.Close();
            connection.Close();

	        return piece;
	    }

        public static Boolean Insert(Piece piece)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Piece ("+champs+") VALUES (@ID_Vehicule,@ID_SousCat);"; 


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Vehicule", piece.ID_Vehicule);
            commande.Parameters.AddWithValue("ID_SousCat", piece.ID_SousCat);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
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
            String requete = @"DELETE Piece
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
            String requete = @"SELECT  MAX(Identifiant) FROM Piece;";

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
