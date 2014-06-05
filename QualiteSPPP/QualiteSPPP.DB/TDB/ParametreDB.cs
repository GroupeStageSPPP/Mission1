using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class ParametreDB
    {
        public static String champs = "Nom,Valeur";
        public static String select = "SELECT Identifiant," + champs + " FROM Parametre";


        public static List<Parametre> List()
        {
            List<Parametre> listeParametre = new List<Parametre>();

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
                Parametre parametre = new Parametre();
                parametre.Identifiant = dataReader.GetInt32(0);
                parametre.Nom = dataReader.GetString(1);
                parametre.Valeur = dataReader.GetString(2);
                listeParametre.Add(parametre);
            }

            dataReader.Close();
            connection.Close();

            return listeParametre;
        }

        public static Parametre Get(Int32 Identifiant)
        {
            Parametre parametre = new Parametre();

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
            parametre.Identifiant = dataReader.GetInt32(0);
            parametre.Identifiant = dataReader.GetInt32(0);
            parametre.Nom = dataReader.GetString(1);
            parametre.Valeur = dataReader.GetString(2);

            dataReader.Close();
            connection.Close();

            return parametre;
        }

        public static Boolean Insert(Parametre parametre)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Parametre (" + champs + ") VALUES (@Nom,@Valeur);";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Nom", parametre.Nom);
            commande.Parameters.AddWithValue("Valeur", parametre.Valeur);
            //Execution
            connection.Open();
            commande.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public static Boolean Update(Parametre parametre)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Parametre
                               SET Nom=@Nom,Valeur=@Valeur
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", parametre.Identifiant);
            commande.Parameters.AddWithValue("Nom", parametre.Nom);
            commande.Parameters.AddWithValue("Valeur", parametre.Valeur);

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
            String requete = @"DELETE Parametre
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
        public static Int32 LastID()
        {
            Int32 Identifiant = 0;
            //Connection
            SqlConnection connection = DataBase.Connection();
            //Requete
            String requete = @"SELECT  MAX(Identifiant) FROM Parametre;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();
            dataReader.Read();
            Identifiant = dataReader.GetInt32(0);
            connection.Close();
            return Identifiant;
        }
    }
}



