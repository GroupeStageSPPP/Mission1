using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public static class VernisDB
    {
        public static String champs = "Reference,Min,Norme,Max";
        public static String select = "SELECT Identifiant," + champs + " FROM Vernis";


        public static List<Vernis> List()
        {
            List<Vernis> listeVernis = new List<Vernis>();

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
                    Vernis vernis = new Vernis();
                    vernis.Identifiant = dataReader.GetInt32(0);
                    vernis.Reference = dataReader.GetString(1);
                    vernis.Min = dataReader.GetInt32(2);
                    vernis.Norme = dataReader.GetInt32(3);
                    vernis.Max = dataReader.GetInt32(4);
                    listeVernis.Add(vernis);
                }

                dataReader.Close();

                return listeVernis;
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

        public static Vernis Get(Int32 Identifiant)
        {
            Vernis vernis = new Vernis();

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
                vernis.Identifiant = dataReader.GetInt32(0);
                vernis.Reference = dataReader.GetString(1);
                vernis.Min = dataReader.GetInt32(2);
                vernis.Norme = dataReader.GetInt32(3);
                vernis.Max = dataReader.GetInt32(4);
                dataReader.Close();

                return vernis;
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

        public static Boolean Insert(Vernis vernis)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"INSERT INTO Vernis (" + champs + ") VALUES (@Reference,@Min,@Norme,@Max);";


            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Reference", vernis.Reference);
            commande.Parameters.AddWithValue("Min", vernis.Min);
            commande.Parameters.AddWithValue("Norme", vernis.Norme);
            commande.Parameters.AddWithValue("Max", vernis.Max);

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

        public static Boolean Update(Vernis vernis)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Vernis
                               SET Reference=@Reference,Min=@Min,Norme=@Norme,Max=@Max
                               WHERE Identifiant=@Identifiant ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("Identifiant", vernis.Identifiant);
            commande.Parameters.AddWithValue("Reference", vernis.Reference);
            commande.Parameters.AddWithValue("Min", vernis.Min);
            commande.Parameters.AddWithValue("Norme", vernis.Norme);
            commande.Parameters.AddWithValue("Max", vernis.Max);

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
            String requete = @"DELETE Vernis
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
            String requete = @"SELECT  MAX(Identifiant) FROM Vernis;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);
            //Execution
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
