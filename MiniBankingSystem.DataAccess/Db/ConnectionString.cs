using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.DataAccess.Db
{
    internal class ConnectionString
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new()
        {
            DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS",
            InitialCatalog = "MiniBankingSystem",
            UserID = "sa",
            Password = "root",
            TrustServerCertificate = true,
        };
    }
}
