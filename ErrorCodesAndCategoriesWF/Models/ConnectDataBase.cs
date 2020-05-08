using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorCodesAndCategoriesWF.Models
{
    public class ConnectDataBase
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                                   Initial Catalog=ESGP;Integrated Security=True;
                                                   Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                                   ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string ConnectionString { get => connectionString; }
    }
}
