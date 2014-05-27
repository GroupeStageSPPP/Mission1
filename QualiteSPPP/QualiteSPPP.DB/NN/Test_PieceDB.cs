using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Test_PieceDB
    {
        /// <summary>
        /// Récupère une liste de Test_Piece à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Test_Piece> List()
        {



            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, IdentifiantTest, IdentifiantPiece FROM Test_Piece";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Test_Piece> list = new List<Test_Piece>();
            while (dataReader.Read())
            {

                //1 - Créer un Test_Piece à partir des donner de la ligne du dataReader
                Test_Piece test_piece = new Test_Piece();
                test_piece.Identifiant = dataReader.GetInt32(0);
                test_piece.test.Identifiant = dataReader.GetInt32(1);
                test_piece.piece.Identifiant = dataReader.GetInt32(2);
                //2 - Ajouter ce Test_Piece à la list de client
                list.Add(test_piece);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Test_Piece à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Test_Piece</param>
        /// <returns>Un Test_Piece </returns>
        public static Test_Piece Get(Int32 Identifiant)
        {


            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, IdentifiantTest, IdentifiantPiece FROM Test_Piece
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Test_Piece
            Test_Piece test_piece = new Test_Piece();
            test_piece.Identifiant = dataReader.GetInt32(0);
            test_piece.test.Identifiant = dataReader.GetInt32(1);
            test_piece.piece.Identifiant = dataReader.GetInt32(2);

            dataReader.Close();
            connection.Close();
            return test_piece;
        }


        public static void Delete(Int32 Identifiant)
        {


            SqlConnection connection = DataBase.Connection;
            String requete = "DELETE Test_Piece WHERE Identifiant = @Identifiant";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            SqlDataReader dataReader = commande.ExecuteReader();
            connection.Close();
        }


        public static void Insert(Test_Piece test_piece)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = "INSERT INTO Test_Piece( IdentifiantTest, IdentifiantPiece) VALUES( @IdentifiantTest, IdentifiantPiece)";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("IdentifiantTest", test_piece.test.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPiece", test_piece.piece.Identifiant);
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(Test_Piece test_piece)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Test_Piece 
                               SET(IdentifiantTest=@IdentifiantTest, IdentifiantPiece=@IdentifiantPiece )                                    WHERE Identifiant=@Identifiant";

            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", test_piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantTest", test_piece.test.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPiece", test_piece.piece.Identifiant);

            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
