using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualiteSPPP.DB
{
    public static class ParametreDB
    {
        /// <summary>
        /// Récupère une liste de Parametre à partir de la color de données
        /// </summary>
        /// <returns>Une liste de client</returns>
        public static List<Parametre> List()
        {

            

            SqlConnection connection = Datacolor.Connection;
            
            String requete = "SELECT Identifiant FROM Parametre";
            connection.Open();
            SqlCommand commande = new SqlCommand(requete, connection);
            

            SqlDataReader dataReader = commande.ExecuteReader();

            List<Parametre> list = new List<Parametre>();
            while (dataReader.Read())
            {

                //1 - Créer un Parametre à partir des donner de la ligne du dataReader
                Parametre parametre = new Parametre();
                parametre.Identifiant = dataReader.GetInt32(0);


                //2 - Ajouter ce Parametre à la list de client
                list.Add(parametre);
            }
            dataReader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// Récupère une Parametre à partir d'un Identifiant de client
        /// </summary>
        /// <param name="Identifiant">Identifant de Parametre</param>
        /// <returns>Un Parametre </returns>
        public static Parametre Get(Int32 Identifiant)
        {
            

            SqlConnection connection = Datacolor.Connection;
            
            String requete = @"SELECT Identifiant FROM Parametre
                                WHERE Identifiant = @Identifiant";
            SqlCommand commande = new SqlCommand(requete, connection);

            
            commande.Parameters.AddWithValue("Identifiant", Identifiant);

            
            connection.Open();
            SqlDataReader dataReader = commande.ExecuteReader();

            dataReader.Read();

            //1 - Création du Parametre
            Parametre parametre = new Parametre();

            parametre.Identifiant = dataReader.GetInt32(0);
            dataReader.Close();
            connection.Close();
            return parametre;
        }
    }
}
