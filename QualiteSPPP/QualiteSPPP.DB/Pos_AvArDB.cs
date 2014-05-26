using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Pos_AvArDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la color de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Pos_AvAr> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, Position FROM Pos_AvAr";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Pos_AvAr> list = new List<Pos_AvAr>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Pos_AvAr pos_AvAr = new Pos_AvAr();
                pos_AvAr.Identifiant = dataReader.GetInt32(0);
                pos_AvAr.Position = dataReader.GetString(1);


                //2 - Ajouter cette civilité à la list de civilité
                list.Add(pos_AvAr);
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
        public static Pos_AvAr Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Position FROM Pos_AvAr
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Pos_AvAr pos_AvAr = new Pos_AvAr();

            pos_AvAr.Identifiant = dataReader.GetInt32(0);
            pos_AvAr.Position = dataReader.GetString(1);

            dataReader.Close();
            connection.Close();

            return pos_AvAr;
        }





        public static void Insert(Pos_AvAr pos_AvAr)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Pos_AvAr(Position) VALUES(@Position)";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Position", pos_AvAr.Position);


            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Pos_AvAr pos_AvAr)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Pos_AvAr  
                               SETLibelle=@Position  
                               WHERE Identifiant=@Identifiant;";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", pos_AvAr.Identifiant);
            commande.Parameters.AddWithValue("Position", pos_AvAr.Position);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Pos_AvAr 
                               WHERE Identifiant=@Identifiant";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
