using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class PieceDB
    {
        /// <summary>
        /// Récupère une liste de Piece à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Piece> List()
        {

            

            SqlConnection connection = DataBase.Connection;
            
            String requete = "SELECT Identifiant, IdentifiantVehicule, IdentifiantSousCat FROM Piece";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Piece> list = new List<Piece>();
            while (dataReader.Read())
            {

                //1 - Créer un Piece à partir des donner de la ligne du dataReader
                Piece piece = new Piece();
                piece.Identifiant = dataReader.GetInt32(0);
                piece.vehicule.Identifiant = dataReader.GetInt32(1);
                piece.sousCat.Identifiant = dataReader.GetInt32(2);



                //2 - Ajouter ce Piece à la list de client
                list.Add(piece);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Piece à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Piece</param>
        /// <returns>Un Piece </returns>
        public static Piece Get(Int32 Identifiant)
        {
            

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, IdentifiantVehicule, IdentifiantSousCat FROM Piece
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Piece
            Piece piece = new Piece();

            piece.Identifiant = dataReader.GetInt32(0);
            piece.vehicule.Identifiant = dataReader.GetInt32(1);
            piece.sousCat.Identifiant = dataReader.GetInt32(2);

            dataReader.Close();
            connection.Close();
            return piece;
        }




        public static void Insert(Piece piece)
        {
            
            SqlConnection connection = DataBase.Connection;
            String requete = @"INSERT INTO Piece(IdentifiantVehicule , IdentifiantSousCat )
                               VALUES (@IdentifiantVehicule, @IdentifiantSousCat);";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("IdentifiantVehicule", piece.vehicule.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantSousCat", piece.sousCat.Identifiant);
             
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Piece piece)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Piece
                               SET IdentifiantVehicule=@IdentifiantVehicule, IdentifiantSousCat=@IdentifiantSousCat
                               WHERE Identifiant=@Identifiant;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("IdentifiantVehicule", piece.vehicule.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantSousCat", piece.sousCat.Identifiant);
            commande.Parameters.AddWithValue("Identifiant", piece.Identifiant);
            commande.ExecuteNonQuery();

            connection.Close();
        }        
        
        public static void Delete(Int32 Identifiant)
        {
             

            SqlConnection connection = DataBase.Connection;
            String requete = @"DELETE Piece WHERE Identifiant = @Identifiant;";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
