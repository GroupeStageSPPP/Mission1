using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class Ech_ResultatDB
    {
        public static String champs = "Resultat,ID_Echantillon,ID_Test,ID_Constructeur,ID_Teinte";
        public static String select = "SELECT Identifiant," + champs + " FROM Ech_Resultat";


        public static List<Ech_Resultat> List()
        {
            List<Ech_Resultat> listeEch_Resultat = new List<Ech_Resultat>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + ";";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {
                Ech_Resultat ech_resultat = new Ech_Resultat();
                ech_resultat.Identifiant = dataReader.GetInt32(0);
                ech_resultat.Resultat = dataReader.GetDouble(1);
                ech_resultat.ID_Echantillon = dataReader.GetInt32(2);
                ech_resultat.ID_Test = dataReader.GetInt32(3);
                ech_resultat.ID_Constructeur = dataReader.GetInt32(4);
                ech_resultat.ID_Teinte = dataReader.GetInt32(5);
                listeEch_Resultat.Add(ech_resultat);
            }

            dataReader.Close();
            connection.Close();

            return listeEch_Resultat;
        }

        public static Ech_Resultat Get(Int32 Identifiant)
        {
            Ech_Resultat ech_resultat = new Ech_Resultat();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE Identifiant = @Identifiant;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();

            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();
            ech_resultat.Identifiant = dataReader.GetInt32(0);
            ech_resultat.Resultat = dataReader.GetDouble(1);
            ech_resultat.ID_Echantillon = dataReader.GetInt32(2);
            ech_resultat.ID_Test = dataReader.GetInt32(3);
            ech_resultat.ID_Constructeur = dataReader.GetInt32(4);
            ech_resultat.ID_Teinte = dataReader.GetInt32(5);
            dataReader.Close();
            connection.Close();

            return ech_resultat;
        }

        public static Boolean Insert(Ech_Resultat ech_resultat)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Ech_Resultat (" + champs + ") VALUES (@Resultat,@ID_Echantillon,@ID_Test,@ID_Constructeur,@ID_Teinte);";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Resultat", ech_resultat.Resultat);
            commande.Parameters.AddWithValue("ID_Echantillon", ech_resultat.ID_Echantillon);
            commande.Parameters.AddWithValue("ID_Test", ech_resultat.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", ech_resultat.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Teinte", ech_resultat.ID_Teinte);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Ech_Resultat ech_resultat)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Ech_Resultat
                               SET Resultat=@Resultat,ID_Echantillon=@ID_Echantillon,ID_Test=@ID_Test,ID_Constructeur=@ID_Constructeur,ID_Teinte=@ID_Teinte
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", ech_resultat.Identifiant);
            commande.Parameters.AddWithValue("Resultat", ech_resultat.Resultat);
            commande.Parameters.AddWithValue("ID_Echantillon", ech_resultat.ID_Echantillon);
            commande.Parameters.AddWithValue("ID_Test", ech_resultat.ID_Test);
            commande.Parameters.AddWithValue("ID_Constructeur", ech_resultat.ID_Constructeur);
            commande.Parameters.AddWithValue("ID_Teinte", ech_resultat.ID_Teinte);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public static Boolean Delete(Int32 Identifiant)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"DELETE Ech_Resultat
                               WHERE Identifiant=@Identifiant ;";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}