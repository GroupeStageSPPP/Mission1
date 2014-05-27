using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Peinture_PieceDB
    {
        /// <summary>
        /// Récupère une liste de Peinture_Piece à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Peinture_Piece> List()
        {



            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, IdentifiantPeinture, IdentifiantPiece FROM Peinture_Piece";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Peinture_Piece> list = new List<Peinture_Piece>();
            while (dataReader.Read())
            {

                //1 - Créer un Peinture_Piece à partir des donner de la ligne du dataReader
                Peinture_Piece peinture_piece = new Peinture_Piece();
                peinture_piece.Identifiant = dataReader.GetInt32(0);
                peinture_piece.peinture.Identifiant = dataReader.GetInt32(1);
                peinture_piece.piece.Identifiant = dataReader.GetInt32(2);
                //2 - Ajouter ce Peinture_Piece à la list de client
                list.Add(peinture_piece);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Peinture_Piece à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Peinture_Piece</param>
        /// <returns>Un Peinture_Piece </returns>
        public static Peinture_Piece Get(Int32 Identifiant)
        {


            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, IdentifiantPeinture, IdentifiantPiece FROM Peinture_Piece
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Peinture_Piece
            Peinture_Piece peinture_piece = new Peinture_Piece();
            peinture_piece.Identifiant = dataReader.GetInt32(0);
            peinture_piece.peinture.Identifiant = dataReader.GetInt32(1);
            peinture_piece.piece.Identifiant = dataReader.GetInt32(2);

            dataReader.Close();
            connection.Close();
            return peinture_piece;
        }


        public static void Delete(Int32 Identifiant)
        {


            SqlConnection connection = DataBase.Connection;
            String requete = "DELETE Peinture_Piece WHERE Identifiant = @Identifiant";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            SqlDataReader dataReader = commande.ExecuteReader();
            connection.Close();
        }


        public static void Insert(Peinture_Piece peinture_piece)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = "INSERT INTO Peinture_Piece( IdentifiantPeinture, IdentifiantPiece) VALUES( @IdentifiantPeinture, IdentifiantPiece) SELECT SCOPE_IDENTITY() ";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("IdentifiantPeinture", peinture_piece.peinture.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPiece", peinture_piece.piece.Identifiant);
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Peinture_Piece peinture_piece)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Peinture_Piece 
                               SET(IdentifiantPeinture=@IdentifiantPeinture, IdentifiantPiece=@IdentifiantPiece )                                    WHERE Identifiant=@Identifiant";

            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", peinture_piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", peinture_piece.peinture.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPiece", peinture_piece.piece.Identifiant);

            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
