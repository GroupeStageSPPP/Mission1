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
            
            String requete = @"SELECT Identifiant, PositionGD, PositionAVAR , IdentifiantPiece, IdentifiantPeinture 
                              FROM Projet;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Projet> list = new List<Projet>();
            while (dataReader.Read())
            {

                //1 - Créer un Projet à partir des donner de la ligne du dataReader
                Projet Projet = new Projet();
                Projet.Identifiant = dataReader.GetInt32(0);
                Projet.PositionGD = dataReader.GetString(1);
                Projet.PositionAVAR = dataReader.GetString(2);
                Projet.piece.Identifiant = dataReader.GetInt32(3);
                Projet.peinture.Identifiant = dataReader.GetInt32(4);


                //2 - Ajouter ce Projet à la list de client
                list.Add(Projet);
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
            
            String requete = @"SELECT Identifiant, PositionGD, PositionAVAR, IdentifiantPiece, IdentifiantPeinture FROM Projet
                                WHERE Identifiant = @Identifiant;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Projet
            Projet Projet = new Projet();

            Projet.Identifiant = dataReader.GetInt32(0);
            Projet.PositionGD = dataReader.GetString(1);
            Projet.PositionAVAR = dataReader.GetString(2);
            Projet.piece.Identifiant = dataReader.GetInt32(3);
            Projet.peinture.Identifiant = dataReader.GetInt32(4);
            dataReader.Close();
            connection.Close();
            return Projet;
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
            String requete = @"INSERT INTO Projet(PositionGD, PositionAVAR, IdentifiantPiece, IdentifiantPeinture) VALUES(@PositionGD, @PositionAVAR ,@IdentifiantPiece ,@IdentifiantPeinture);";
            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("PositionGD", Projet.PositionGD);
            commande.Parameters.AddWithValue("PositionAVAR", Projet.PositionAVAR);
            commande.Parameters.AddWithValue("IdentifiantPiece", Projet.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", Projet.peinture.Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update( Projet Projet)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Projet  
                               SET PositionGD=@PositionGD, PositionAVAR=@PositionAVAR ,IdentifiantPiece=@IdentifiantPiece ,IdentifiantPeinture=@IdentifiantPeinture  
                               WHERE Identifiant=@Identifiant;";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete,connection);
            
            commande.Parameters.AddWithValue("Identifiant", Projet.Identifiant);
            commande.Parameters.AddWithValue("PositionGD", Projet.PositionGD);
            commande.Parameters.AddWithValue("PositionAVAR", Projet.PositionAVAR);
            commande.Parameters.AddWithValue("IdentifiantPiece", Projet.piece.Identifiant);
            commande.Parameters.AddWithValue("IdentifiantPeinture", Projet.peinture.Identifiant);
            
            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
