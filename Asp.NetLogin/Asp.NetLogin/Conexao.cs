using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.NetLogin
{
    public class Conexao
    { 
        private static string Server = "localhost";
        private static string Database = "web_session";
        private static string User = "root";
        private static string Password = "0000";

        private static string connectionString = $@"Server={Server};Database={Database};
                                                    Uid={User};Pwd={Password};SslMode=none; Charset=utf8;";

        public static MySqlConnection Connection = new MySqlConnection(connectionString);

        public static void Conecctar()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public static void Desconectar()
        {
            if(Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }



    }
}