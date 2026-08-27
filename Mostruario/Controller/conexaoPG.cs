using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Mostruario.Controller
{
    class conexaoPG
    {
        //dados sobre o servidor (conexão)
        static string serverName = "127.0.0.1";
        static string port = "15432";
        static string user = "postgres";
        static string passwd = "POST";
        static string dataBase = "produto";

        //objetos necessários para comunicação com o BD
        NpgsqlConnection conn = null;

        string connString = "Server=" + serverName + ";Port=" + port +
        ";UserID=" + user + ";password=" + passwd + ";Database=" + dataBase + ";";

        //método de conexão com o banco de dados
        public NpgsqlConnection conecta()
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                return conn;
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
        }

        //método para desconectar do banco de dados
        public NpgsqlConnection desconecta()
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Close();
                return conn;
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
        }
    }
}
