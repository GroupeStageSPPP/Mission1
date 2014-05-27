using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QualiteSPPP.DB
{
    public static class DataBase
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=PC-PORTABLE_JB;Initial Catalog=QualiteSPPP;Integrated Security=True");
    }
}
