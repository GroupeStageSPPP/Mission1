using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class TestDB
    {
        /// <summary>
        /// Récupère une liste de Test à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Test> List()
        {

            

            SqlConnection connection = DataBase.Connection;
            
            String requete = "SELECT Identifiant, Libelle, Description, TypeTest FROM Test";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Test> list = new List<Test>();
            while (dataReader.Read())
            {

                //1 - Créer un Test à partir des donner de la ligne du dataReader

                Test test = new Test();
                test.Identifiant = dataReader.GetInt32(0);
                test.Libelle = dataReader.GetString(1);
                test.Description = dataReader.GetString(2);
                test.TypeTest = dataReader.GetChar(3);


                //2 - Ajouter ce Test à la list de client
                list.Add(test);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Test à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Test</param>
        /// <returns>Un Test </returns>
        public static Test Get(Int32 Identifiant)
        {
            

            SqlConnection connection = DataBase.Connection;

            String requete = @"SELECT Identifiant, Libelle, Description, TypeTest FROM Test
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Test
            Test test = new Test();

            test.Identifiant = dataReader.GetInt32(0);
            test.Libelle = dataReader.GetString(1);
            test.Description = dataReader.GetString(2);
            test.TypeTest = dataReader.GetChar(3);


            dataReader.Close();
            connection.Close();
            return test;
        }


        public static void Delete(Int32 Identifiant)
        {
             

            SqlConnection connection = DataBase.Connection;
            String requete = "DELETE Test WHERE Identifiant=@Identifiant";
            
            connection.Open();

             

            SqlCommand commande = new SqlCommand(requete,connection);
            

            

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);
            

            
            commande.ExecuteNonQuery();
            connection.Close();
        }


        public static void Insert(Test test)
        {
            
            SqlConnection connection = DataBase.Connection;
            String requete = @"INSERT INTO Test( Libelle, Description, TypeTest ) 
                               VALUES(@Libelle, @Description, @TypeTest )";

            connection.Open();
            
            SqlCommand commande = new SqlCommand(requete,connection);

            commande.Parameters.AddWithValue("Libelle", test.Libelle);
            commande.Parameters.AddWithValue("Description", test.Description);
            commande.Parameters.AddWithValue("TypeTest", test.TypeTest);       
            commande.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update( Test test)
        {

            SqlConnection connection = DataBase.Connection;
            String requete = @"UPDATE Test
                               SET Libelle=@Libelle, Description=@Description, TypeTest=@TypeTest
                               WHERE Identifiant = @Identifiant;";

            connection.Open();

            SqlCommand commande = new SqlCommand(requete, connection);


            commande.Parameters.AddWithValue("Libelle", test.Libelle);
            commande.Parameters.AddWithValue("Description", test.Description);
            commande.Parameters.AddWithValue("TypeTest", test.TypeTest);
            commande.Parameters.AddWithValue("Identifiant", test.Identifiant);

            commande.ExecuteNonQuery();
            connection.Close();
        }
    }
}
