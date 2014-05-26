using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Test_Peinture_PieceDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la color de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Test_Peinture_Piece> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, Min, Moy, Max, Norme FROM Test_Peinture_Piece";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Test_Peinture_Piece> list = new List<Test_Peinture_Piece>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Test_Peinture_Piece test_peinture_piece = new Test_Peinture_Piece();
                test_peinture_piece.Identifiant = dataReader.GetInt32(0);
                test_peinture_piece.Min = dataReader.GetInt32(1);
                test_peinture_piece.Moy = dataReader.GetInt32(1);
                test_peinture_piece.Max = dataReader.GetInt32(1);
                test_peinture_piece.Norme = dataReader.GetString(1);

                //2 - Ajouter cette civilité à la list de civilité
                list.Add(test_peinture_piece);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une catégorie à partir d'un Identifiant de catégorie
        /// </summary>
        /// <param name="Identifiant">Identifant de catégorie</param>
        /// <returns>Une catégorie</returns>
        public static Test_Peinture_Piece Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Min, Moy, Max, Norme FROM Test_Peinture_Piece
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Test_Peinture_Piece test_peinture_piece = new Test_Peinture_Piece();

            test_peinture_piece.Identifiant = dataReader.GetInt32(0);
            test_peinture_piece.Min = dataReader.GetInt32(1);
            test_peinture_piece.Moy = dataReader.GetInt32(1);
            test_peinture_piece.Max = dataReader.GetInt32(1);
            test_peinture_piece.Norme = dataReader.GetString(1);

            dataReader.Close();
            connection.Close();

            return test_peinture_piece;
        }





        public static void Insert(Test_Peinture_Piece test_peinture_piece)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Test_Peinture_Piece(Min, Moy, Max, Norme) VALUES(@Identifiant, @Min, @Moy, @Max, @Norme)";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Min", test_peinture_piece.Min);
            commande.Parameters.AddWithValue("Moy", test_peinture_piece.Moy);
            commande.Parameters.AddWithValue("Max", test_peinture_piece.Max);
            commande.Parameters.AddWithValue("Norme", test_peinture_piece.Norme);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Test_Peinture_Piece test_peinture_piece)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Test_Peinture_Piece  
                               SET Min=@Min, Moy=@Moy, Max=@Max, Norme=@Norme 
                               WHERE Identifiant=@Identifiant;";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", test_peinture_piece.Identifiant);
            commande.Parameters.AddWithValue("Min", test_peinture_piece.Min);
            commande.Parameters.AddWithValue("Moy", test_peinture_piece.Moy);
            commande.Parameters.AddWithValue("Max", test_peinture_piece.Max);
            commande.Parameters.AddWithValue("Norme", test_peinture_piece.Norme);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Test_Peinture_Piece 
                               WHERE Identifiant=@Identifiant";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}

