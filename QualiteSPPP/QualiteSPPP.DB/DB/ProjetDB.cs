using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QualiteSPPP.DB
{
    public static class ProjetDB
    {
        /// <summary>
        /// Récupère une liste de Projet à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Projet> List()
        {

            

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, IdentifiantPos_GD, IdentifiantPos_AvAr, FrequenceTest, IdentifiantPiece, IdentifiantPeinture 
                              FROM Projet;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Projet> list = new List<Projet>();
            while (dataReader.Read())
            {

                //1 - Créer un Projet à partir des donner de la ligne du dataReader
                Projet projet = new Projet();
                projet.Identifiant = dataReader.GetInt32(0);
                projet.pos_AvAr.Identifiant = dataReader.GetInt32(1);
                projet.pos_Gd.Identifiant = dataReader.GetInt32(2);
                projet.FrequenceTest = dataReader.GetInt32(3);
                projet.piece.Identifiant = dataReader.GetInt32(4);
                projet.peinture.Identifiant = dataReader.GetInt32(5);


                //2 - Ajouter ce Projet à la list de client
                list.Add(projet);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Projet à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Projet</param>
        /// <returns>Un Projet </returns>
        public static Projet Get(Int32 Identifiant)
        {
            

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, IdentifiantPos_GD, IdentifiantPos_AvAr, FrequenceTest, IdentifiantPiece, IdentifiantPeinture FROM Projet
                                WHERE Identifiant = @Identifiant;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Projet
            Projet projet = new Projet();

            projet.Identifiant = dataReader.GetInt32(0);
            projet.pos_AvAr.Identifiant = dataReader.GetInt32(1);
            projet.pos_Gd.Identifiant = dataReader.GetInt32(2);
            projet.FrequenceTest = dataReader.GetInt32(3);
            projet.piece.Identifiant = dataReader.GetInt32(4);
            projet.peinture.Identifiant = dataReader.GetInt32(5);
            dataReader.Close();
            connection.Close();
            return projet;
        }



        public static void Delete(Int32 Identifiant)
        {
             

           SqlConnection connection = DataBase.Connection;
           String requete = @"DELETE Projet WHERE Identifiant = @Identifiant;";

           connection.Open();

           SqlCommand commande = new SqlCommand(requete,connection);

           commande.Parameters.AddWithValue("Identifiant", Identifiant);

           commande.ExecuteNonQuery();
            
            connection.Close();
        }


        public static void Insert(Projet Projet)
        {
            
            SqlConnection connection = DataBase.Connection;
            String requete = @"INSERT INTO Projet(IdentifiantPos_GD, IdentifiantPos_AvAr, FrequenceTest, IdentifiantPiece, IdentifiantPeinture) VALUES(@PositionGD, @PositionAVAR ,@IdentifiantPiece ,@IdentifiantPeinture) SELECT SCOPE_IDENTITY() ;";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("IdentifiantPos_GD ", Projet.pos_Gd.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPos_AvAr", Projet.pos_AvAr.Identifiant);
            commande.Parameters.AddWithValue("FrequenceTest", Projet.FrequenceTest);
            commande.Parameters.AddWithValue("IdentifiantPiece", Projet.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", Projet.peinture.Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Projet Projet)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Projet  
                               SET IdentifiantPos_GD=@IdentifiantPos_GD, IdentifiantPos_AvAr=@IdentifiantPos_AvAr, FrequenceTest = @FrequenceTest, IdentifiantPiece=@IdentifiantPiece ,IdentifiantPeinture=@IdentifiantPeinture  
                               WHERE Identifiant=@Identifiant;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", Projet.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPos_GD ", Projet.pos_Gd.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPos_AvAr", Projet.pos_AvAr.Identifiant);
            commande.Parameters.AddWithValue("FrequenceTest", Projet.FrequenceTest);
            commande.Parameters.AddWithValue("IdentifiantPiece", Projet.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", Projet.peinture.Identifiant);
            
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
