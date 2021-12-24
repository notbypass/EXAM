using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Makarrrrrrrrrrrrrr
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection() //Подлючение к самой бд
        {
            string host = "192.168.4.9";
            int port = 3311;
            string database = "user6_db";
            string username = "user6";
            string password = "1234";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
