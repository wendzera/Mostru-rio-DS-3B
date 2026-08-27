using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mostruario.Model;//adiciona pasta com as classes modelo
using Npgsql;  //pacote de manipulação do banco de dados

namespace Mostruario.Controller
{
    class controleTipoProduto
    {
        public string cadastraTipo(modeloTipoProduto mTipo)
        {
            //código SQL que o método de cadastro vai executar
            string sql = "insert into tipo_produto(nome_tipo) values(@nome_tipo);";

            //criar os objetos necessários para a conexão:
            //objeto da classe conexaoPG
            conexaoPG con = new conexaoPG();

            //objeto npgsqlConnection - mantém o software conectado ao banco
            NpgsqlConnection conn = con.conecta();

            //objeto NpgsqlCommand - executa os comandos SQL no banco de dados
            NpgsqlCommand comm = new NpgsqlCommand(sql,conn);

            //passar valores para o banco:
            try
            {
                //lê o valor do atributo e passa para o banco de dados
                comm.Parameters.AddWithValue("@nome_tipo",mTipo.getNome_tipo());
               
                //executar o comando para gravar no BD
                comm.ExecuteNonQuery();

                //retorno positivo para o formulario
                return "Tipo cadastrado com sucesso!";
            }
            catch(NpgsqlException ex)
            {
                return "Erro ao cadastrar tipo!";
            }
        }

        public NpgsqlDataReader listaTipo()
        {
            string sql = "select codigo, nome_tipo from tipo_produto;";

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
