using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Piece_TestDB
    {
                /// <summary>
        /// Récupère une liste de Piece_Test à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Piece_Test> List()
        {

            

            SqlConnection connection = DataBase.Connection;
            
            String requete = "SELECT Identifiant, IdentifiantPiece, IdentifiantTest, Min, Max, Moy FROM Piece_Test";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Piece_Test> list = new List<Piece_Test>();
            while (dataReader.Read())
            {

                //1 - Créer un Piece_Test à partir des donner de la ligne du dataReader
                Piece_Test pieceTest = new Piece_Test();
                pieceTest.Identifiant = dataReader.GetInt32(0);
                pieceTest.piece.Identifiant = dataReader.GetInt32(1);
                pieceTest.test.Identifiant = dataReader.GetInt32(2);
                pieceTest.Min = dataReader.GetString(3);
                pieceTest.Max = dataReader.GetString(4);
                pieceTest.Moy = dataReader.GetString(5);

                //2 - Ajouter ce Piece_Test à la list de client
                list.Add(pieceTest);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Piece_Test à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Piece_Test</param>
        /// <returns>Un Piece_Test </returns>
        public static Piece_Test Get(Int32 Identifiant)
        {
            

            SqlConnection connection = DataBase.Connection;
            
            String requete = @"SELECT Identifiant, IdentifiantPiece, IdentifiantTest, Min, Moy, Max FROM Piece_Test
                                WHERE Identifiant=@Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création du Piece_Test
            Piece_Test pieceTest = new Piece_Test();

            pieceTest.Identifiant = dataReader.GetInt32(0);
            pieceTest.piece.Identifiant = dataReader.GetInt32(1);
            pieceTest.test.Identifiant = dataReader.GetInt32(2);
            pieceTest.Min = dataReader.GetString(3);
            pieceTest.Max = dataReader.GetString(4);
            pieceTest.Moy = dataReader.GetString(5);

            dataReader.Close();
            connection.Close();
            return pieceTest;
        }


        public static void Delete(Int32 Identifiant)
        {
             

            SqlConnection connection = DataBase.Connection;
            String requete = "DELETE Piece_Test WHERE Identifiant=@Identifiant";
            connection.Open();

             

            SqlCommand commande = new SqlCommand(requete,connection);
            

            

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);
            

            
            commande.ExecuteNonQuery();

            connection.Close();
        }


        public static void Insert(Piece_Test pieceTest)
        {
            
            SqlConnection connection = DataBase.Connection;
            
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);
            
             = "INSERT INTO Piece_Test(IdentifiantPiece, IdentifiantTest, Min, Moy, Max) VALUES(@IdentifiantPiece, @IdentifiantTest, @Min, @Moy, @Max)";
            commande.Parameters.AddWithValue("IdentifiantPiece", pieceTest.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantTest", pieceTest.test.Identifiant);
            commande.Parameters.AddWithValue("Min", pieceTest.Min);
            commande.Parameters.AddWithValue("Moy", pieceTest.Moy);
            commande.Parameters.AddWithValue("Max", pieceTest.Max);
             
            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Piece_Test pieceTest)
        {

            SqlConnection connection = DataBase.Connection;
            
            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
             "UPDATE Piece_Test  SET IdentifiantPiece=@IdentifiantPiece, IdentifiantTest=@IdentifiantTest, Min=@Min, Moy=@Moy, Max=@Max  WHERE Identifiant=@Identifiant";
            commande.Parameters.AddWithValue("Identifiant", pieceTest.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPiece", pieceTest.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantTest", pieceTest.test.Identifiant);
            commande.Parameters.AddWithValue("Min", pieceTest.Min);
            commande.Parameters.AddWithValue("Moy", pieceTest.Moy);
            commande.Parameters.AddWithValue("Max", pieceTest.Max);
            
            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
