using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class Pos_GdDB
    {
        /// <summary>
        /// Récupère une liste de catégorie à partir de la color de données
        /// </summary>
        /// <returns>Une liste de catégorie</returns>
        public static List<Pos_Gd> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = "SELECT Identifiant, Position FROM Pos_Gd";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Pos_Gd> list = new List<Pos_Gd>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Pos_Gd pos_Gd = new Pos_Gd();
                pos_Gd.Identifiant = dataReader.GetInt32(0);
                pos_Gd.Position = dataReader.GetString(1);


                //2 - Ajouter cette civilité à la list de civilité
                list.Add(pos_Gd);
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
        public static Pos_Gd Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Position FROM Pos_Gd
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Pos_Gd pos_Gd = new Pos_Gd();

            pos_Gd.Identifiant = dataReader.GetInt32(0);
            pos_Gd.Position = dataReader.GetString(1);

            dataReader.Close();
            connection.Close();

            return pos_Gd;
        }





        public static void Insert(Pos_Gd pos_Gd)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Pos_Gd(Position) VALUES(@Position) SELECT SCOPE_IDENTITY() ";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Position", pos_Gd.Position);


            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Pos_Gd pos_Gd)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Pos_Gd  
                               SETLibelle=@Position  
                               WHERE Identifiant=@Identifiant;";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Identifiant", pos_Gd.Identifiant);
            commande.Parameters.AddWithValue("Position", pos_Gd.Position);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Pos_Gd 
                               WHERE Identifiant=@Identifiant";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }
    }
}
