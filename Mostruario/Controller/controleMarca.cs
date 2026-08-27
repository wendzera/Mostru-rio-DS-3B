using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Mostruario.Model;

namespace Mostruario.Controller
{
    class controleMarca
    {
        public string cadastraMarca(modeloMarca mMarca)
        {
            string sql = "insert into marca(nome_marca, descricao) " +
                "values(@nome_marca, @descricao);";

            conexaoPG con = new conexaoPG();
            NpgsqlConnection conn = con.conecta();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nome_marca",mMarca.getNomeMarca());
                comm.Parameters.AddWithValue("@descricao", mMarca.getDescricao());

                comm.ExecuteNonQuery();
                return "Marca cadastrada com sucesso!";      
            }
            catch(NpgsqlException ex)
            {
                return "Erro ao cadastrar!";
            }
        }

        public NpgsqlDataReader listaMarca()
        {
            string sql = "select codigo, nome_marca from marca" ;

            conexaoPG con = new conexaoPG();
            NpgsqlConnection conn = con.conecta();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                return comm.ExecuteReader();
            }
            catch(NpgsqlException ex)
            {
                return null;
            }
        }

        public NpgsqlDataReader pesquisaMarca(string marca)
        {
            string sql = "select nome_marca, descricao" +
                " from marca where nome_marca like '"+marca+"%';";

            conexaoPG con = new conexaoPG();
            NpgsqlConnection conn = con.conecta();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                return comm.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
        }

    }
}
