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
        public static String champs = "Resultat,ID_Echantillon,ID_Test,ID_Constructeur,ID_Teinte,ISconforme";
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
            try
            {
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
                    ech_resultat.ISconforme = dataReader.GetInt16(6);
                    listeEch_Resultat.Add(ech_resultat);
                }

                dataReader.Close();
               

                return listeEch_Resultat;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
               
            }

        }

        public static List<Ech_Resultat> List(Int16 Conforme)
        {
            List<Ech_Resultat> listeEch_Resultat = new List<Ech_Resultat>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE ISconforme=@Conforme;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);
            commande.Parameters.AddWithValue("Conforme", Conforme);
            //Parametres

            //Execution
            try
            {
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
                    ech_resultat.ISconforme = dataReader.GetInt16(6);
                    listeEch_Resultat.Add(ech_resultat);
                }

                dataReader.Close();            
                return listeEch_Resultat;
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

        public static List<Ech_Resultat> List(Int32 ID_Echantillon, Int32 ID_Test)
        {
            List<Ech_Resultat> listeEch_Resultat = new List<Ech_Resultat>();

            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete  
            String requete = select + " WHERE ID_Echantillon=@ID_Echantillon AND ID_Test=@ID_Test ;";

            //Commande
            SqlCommand commande = new SqlCommand(requete, connection);

            //Parametres
            commande.Parameters.AddWithValue("ID_Echantillon", ID_Echantillon);
            commande.Parameters.AddWithValue("ID_Test", ID_Test);

            //Execution
            try
            {
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
                    ech_resultat.ISconforme = dataReader.GetInt16(6);
                    listeEch_Resultat.Add(ech_resultat);
                }

                dataReader.Close();
                ;

                return listeEch_Resultat;
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
            try
            {
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                dataReader.Read();
                ech_resultat.Identifiant = dataReader.GetInt32(0);
                ech_resultat.Resultat = dataReader.GetDouble(1);
                ech_resultat.ID_Echantillon = dataReader.GetInt32(2);
                ech_resultat.ID_Test = dataReader.GetInt32(3);
                ech_resultat.ID_Constructeur = dataReader.GetInt32(4);
                ech_resultat.ID_Teinte = dataReader.GetInt32(5);
                ech_resultat.ISconforme = dataReader.GetInt16(6);
                dataReader.Close();

                return ech_resultat;
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
            commande.Parameters.AddWithValue("ISconforme", ech_resultat.ISconforme);
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

        public static Boolean Update(Ech_Resultat ech_resultat)
        {
            //Connection
            SqlConnection connection = DataBase.Connection();

            //Requete
            String requete = @"UPDATE Ech_Resultat
                               SET Resultat=@Resultat,ID_Echantillon=@ID_Echantillon,ID_Test=@ID_Test,ID_Constructeur=@ID_Constructeur,ID_Teinte=@ID_Teinte,ISconforme=@ISconforme
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
            commande.Parameters.AddWithValue("ISconforme", ech_resultat.ISconforme);
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
            String requete = @"DELETE Ech_Resultat
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
    }
}