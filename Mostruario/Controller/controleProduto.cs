using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Mostruario.Model;

namespace Mostruario.Controller
{
    class controleProduto
    {
        public string cadastraProduto(modeloProduto mProduto)
        {
            string sql = "insert into produto(nome_produto, preco_custo," +
                "preco_venda, quantidade, descricao, unidade, validade, " +
                "cod_marca, cod_tipo) values (@nome_produto, @preco_custo," +
                "@preco_venda, @quantidade, @descricao, @unidade, @validade, " +
                "@cod_marca, @cod_tipo);";

            conexaoPG con = new conexaoPG();
            NpgsqlConnection conn = con.conecta();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nome_produto", mProduto.getNomeProduto());
                comm.Parameters.AddWithValue("@preco_custo", mProduto.getCusto());
                comm.Parameters.AddWithValue("@preco_venda", mProduto.getVenda());
                comm.Parameters.AddWithValue("@quantidade", mProduto.getQuantidade());
                comm.Parameters.AddWithValue("@descricao", mProduto.getDescricao());
                comm.Parameters.AddWithValue("@unidade", mProduto.getUnidade());
                comm.Parameters.AddWithValue("@validade", mProduto.getValidade());
                comm.Parameters.AddWithValue("@cod_marca", mProduto.getCodMarca());
                comm.Parameters.AddWithValue("@cod_tipo", mProduto.getCodTipo());

                comm.ExecuteNonQuery();
                return "Produto cadastrado!";
            }
            catch(NpgsqlException ex)
            {
                //return ex.ToString();
                return "Erro ao cadastrar!";
            }
        }

        public NpgsqlDataReader pesquisaProduto(string nome)
        {
            string sql = "select p.codigo, p.nome_produto, " +
                "p.preco_venda, p.quantidade, p.validade, " +
                "p.descricao, m.nome_marca, tp.nome_tipo from " + 
                "produto p inner join marca m on p.cod_marca = " +
                "m.codigo inner join tipo_produto tp on " +
               "p.cod_tipo = tp.codigo where p.nome_produto like '"+nome+"%';";

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

        public string atualizaProduto(modeloProduto mProduto)
        {
            string sql = "update produto set nome_produto = @nome_produto," +
                "cod_marca = @cod_marca, quantidade = @quantidade, " +
                "preco_venda = @preco_venda, cod_tipo = @cod_tipo, validade = @validade," +
                "descricao = @descricao where codigo = @codigo;";

            conexaoPG con = new conexaoPG();
            NpgsqlConnection conn = con.conecta();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nome_produto", mProduto.getNomeProduto());
                comm.Parameters.AddWithValue("@preco_venda", mProduto.getVenda());
                comm.Parameters.AddWithValue("@quantidade", mProduto.getQuantidade());
                comm.Parameters.AddWithValue("@descricao", mProduto.getDescricao());
                comm.Parameters.AddWithValue("@validade", mProduto.getValidade());
                comm.Parameters.AddWithValue("@cod_marca", mProduto.getCodMarca());
                comm.Parameters.AddWithValue("@cod_tipo", mProduto.getCodTipo());
                comm.Parameters.AddWithValue("@codigo", mProduto.getCodigo());

                comm.ExecuteNonQuery();
                return "Produto atualizado!";
            }
            catch (NpgsqlException ex)
            {
                //return ex.ToString();
                return "Erro ao cadastrar!";
            }


        }

    }
}
