using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Shop_Тепляков.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=127.0.0.1;port=3306;database=Shop;uid=root;";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection newConnection = new MySqlConnection(ConnectionData);
            newConnection.Open();
            return newConnection;
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand newCommand = new MySqlCommand(Query, Connection);
            return newCommand.ExecuteReader();
        }

        public static void MySqlClose(MySqlConnection Connection)
        {
            Connection.Close();
        }
    }
}
