using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class ColorDB
    {
        public static List<Color> List()
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Reference, L, A, B, Min, Moy, Max 
                                FROM Color";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            SqlDataReader dataReader = commande.ExecuteReader();

            List<Color> list = new List<Color>();

            while (dataReader.Read())
            {

                //1 - Créer un groupe à partir des donner de la ligne du dataReader
                Color color = new Color();
                color.Identifiant = dataReader.GetInt32(0);
                color.Reference = dataReader.GetString(1);
                color.L = dataReader.GetInt16(2);
                color.A = dataReader.GetInt16(3);
                color.B = dataReader.GetInt16(4);
                color.Min = dataReader.GetFloat(5);
                color.Moy = dataReader.GetFloat(6);
                color.Max = dataReader.GetFloat(7);


                //2 - Ajouter cette color à la list de color
                list.Add(color);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une color à partir d'un Identifiant de color
        /// </summary>
        /// <param name="Identifiant">Identifant de color</param>
        /// <returns>Une color</returns>
        public static Color Get(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Reference, L, A, B, Min, Moy, Max 
                                FROM Color
                                WHERE Identifiant=@Identifiant";

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Identifiant", Identifiant);


            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();

            //1 - Création de la civilite
            Color color = new Color();

            color.Identifiant = dataReader.GetInt32(0);
            color.Reference = dataReader.GetString(1);
            color.L = dataReader.GetInt16(2);
            color.A = dataReader.GetInt16(3);
            color.B = dataReader.GetInt16(4);
            color.Min = dataReader.GetFloat(5);
            color.Moy = dataReader.GetFloat(6);
            color.Max = dataReader.GetFloat(7);

            dataReader.Close();
            connection.Close();

            return color;
        }





        public static void Insert(Color color)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"INSERT INTO Color(Reference, Min, Moy, Max) 
                                VALUES(@Reference, @Min, @Moy, @Max)";
            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);

            commande.Parameters.AddWithValue("Reference", color.Reference);
            commande.Parameters.AddWithValue("L", color.L);
            commande.Parameters.AddWithValue("A", color.A);
            commande.Parameters.AddWithValue("B", color.B);
            commande.Parameters.AddWithValue("Min", color.Min);
            commande.Parameters.AddWithValue("Moy", color.Moy);
            commande.Parameters.AddWithValue("Max", color.Max);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(Color color)
        {

            SqlConnection connection = DataBase.Connection;

            String requete = @"UPDATE Color  
                               SET Reference = @Reference, Min = @Min, Moy = @Moy, Max = @Max  
                               WHERE Identifiant=@Identifiant;";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);
            //Parametres
            commande.Parameters.AddWithValue("Identifiant", color.Identifiant);
            commande.Parameters.AddWithValue("Reference", color.Reference);
            commande.Parameters.AddWithValue("L", color.L);
            commande.Parameters.AddWithValue("A", color.A);
            commande.Parameters.AddWithValue("B", color.B);
            commande.Parameters.AddWithValue("Min", color.Min);
            commande.Parameters.AddWithValue("Moy", color.Moy);
            commande.Parameters.AddWithValue("Max", color.Max);

            commande.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(Int32 Identifiant)
        {

            SqlConnection connection = DataBase.Connection;


            String requete = @"DELETE FROM Color 
                               WHERE Identifiant=@Identifiant";

            connection.Open();


            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            commande.ExecuteNonQuery();

            connection.Close();
        }


    }
}
