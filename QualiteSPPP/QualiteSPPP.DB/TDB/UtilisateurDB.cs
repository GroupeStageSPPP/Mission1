using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class UtilisateurDB
    {
        public static String champs = "Login,Password,Groupe";
        public static String select = "SELECT Identifiant," + champs + " FROM Utilisateur";


        public static List<Utilisateur> List()
        {
            List<Utilisateur> listeUtilisateur = new List<Utilisateur>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + ";";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.Identifiant = dataReader.GetInt32(0);
                    utilisateur.Login = dataReader.GetString(1);
                    utilisateur.Password = dataReader.GetString(2);
                    utilisateur.Groupe = dataReader.GetInt32(3);
                    listeUtilisateur.Add(utilisateur);
                }

                dataReader.Close();

                return listeUtilisateur;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public static List<Utilisateur> List(Int32 Groupe)
        {
            List<Utilisateur> listeUtilisateur = new List<Utilisateur>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE Groupe > @Groupe;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);
            
            //Parametres
            commande.Parameters.AddWithValue("Groupe", Groupe);
            
            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.Identifiant = dataReader.GetInt32(0);
                    utilisateur.Login = dataReader.GetString(1);
                    utilisateur.Password = dataReader.GetString(2);
                    utilisateur.Groupe = dataReader.GetInt32(3);
                    listeUtilisateur.Add(utilisateur);
                }

                dataReader.Close();

                return listeUtilisateur;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public static Utilisateur Get(Int32 Identifiant)
        {
            Utilisateur utilisateur = new Utilisateur();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE Identifiant = @Identifiant;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                dataReader.Read();
                utilisateur.Identifiant = dataReader.GetInt32(0);
                utilisateur.Identifiant = dataReader.GetInt32(0);
                utilisateur.Login = dataReader.GetString(1);
                utilisateur.Password = dataReader.GetString(2);
                utilisateur.Groupe = dataReader.GetInt32(3);

                dataReader.Close();

                return utilisateur;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public static Boolean Insert(Utilisateur utilisateur)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Utilisateur (" + champs + ") VALUES (@Login,@Password,@Groupe);";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Login", utilisateur.Login);
            commande.Parameters.AddWithValue("Password", utilisateur.Password);
            commande.Parameters.AddWithValue("Groupe", utilisateur.Groupe);
            //Execution
            try
            {
                connection.Open();
                commande.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Boolean Update(Utilisateur utilisateur)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Utilisateur
                               SET Login=@Login,Password=@Password,Groupe=@Groupe
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", utilisateur.Identifiant);
            commande.Parameters.AddWithValue("Login", utilisateur.Login);
            commande.Parameters.AddWithValue("Password", utilisateur.Password);
            commande.Parameters.AddWithValue("Groupe", utilisateur.Groupe);
            //Execution
            try
            {
                connection.Open();
                commande.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Boolean Delete(Int32 Identifiant)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"DELETE Utilisateur
                               WHERE Identifiant=@Identifiant ;";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            //Execution
            try
            {
                connection.Open();
                commande.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static Int32 LastID()
        {
            Int32 Identifiant = 0;
            //Connection
            SqlConnection connection = DataBase.Connection();
            //Requete
            String requete = @"SELECT  MAX(Identifiant) FROM Utilisateur;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            try
            {
                connection.Open();
                SqlDataReader dataReader = commande.ExecuteReader();
                dataReader.Read();
                Identifiant = dataReader.GetInt32(0);
                connection.Close();
                return Identifiant;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}



