using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Helpers;

namespace ToDoApp.DataAccess.Concrete.Dapper.Connection
{
    public class DapperConnection
    {
        public static IDbConnection DapperDbConnection()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            string useEncryption = CommonHelper.GetUseEncryptionFromRegistery();
            string toDoConnectionString = "";
            if (useEncryption == "1" || useEncryption == "2")
            {
                toDoConnectionString = CryptologyHelper.DecryptAES256(configuration.GetConnectionString("ToDoConnection"));
            }
            if (useEncryption == "0")
            {
                toDoConnectionString = configuration.GetConnectionString("ToDoConnection");
            }

            IDbConnection dapperDbConnection = new SqlConnection(toDoConnectionString);
            return dapperDbConnection;
        }
    }
}
