using System;
using System.Data;
using Mostruario.Model;
using Npgsql;

namespace Mostruario.Controller
{
    /// <summary>
    /// Executa cadastro, pesquisa, atualização e exclusão de produtos.
    /// </summary>
    internal class ControleProduto
    {
        /// <summary>
        /// Pesquisa pelo nome e traz também os nomes da marca e do tipo.
        /// </summary>
        public DataTable Pesquisar(string termo, out string mensagem)
        {
            const string sql = @"
                SELECT p.codigo,
                       p.nome_produto,
                       p.preco_custo,
                       p.preco_venda,
                       p.quantidade,
                       p.unidade,
                       p.validade,
                       p.descricao,
                       p.cod_marca,
                       m.nome_marca,
                       p.cod_tipo,
                       tp.nome_tipo
                FROM produto p
                INNER JOIN marca m ON m.codigo = p.cod_marca
                INNER JOIN tipo_produto tp ON tp.codigo = p.cod_tipo
                WHERE p.nome_produto ILIKE @termo
                ORDER BY p.nome_produto;";

            mensagem = string.Empty;
            DataTable tabela = new DataTable();

            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    // O parâmetro aceita apóstrofos com segurança e evita injeção de SQL.
                    comando.Parameters.AddWithValue(
                        "@termo",
                        "%" + (termo ?? string.Empty).Trim() + "%");

                    conexao.Open();
                    using (NpgsqlDataReader leitor = comando.ExecuteReader())
                    {
                        tabela.Load(leitor);
                    }
                }
            }
            catch (Exception erro)
            {
                mensagem = erro is NpgsqlException
                    ? "Não foi possível consultar os produtos. Verifique se o PostgreSQL está ativo."
                    : "Não foi possível ler os produtos. Verifique a configuração do banco.";
            }

            return tabela;
        }

        /// <summary>
        /// Insere no banco um produto já validado pela tela.
        /// </summary>
        public bool Cadastrar(ModeloProduto produto, out string mensagem)
        {
            const string sql = @"
                INSERT INTO produto
                    (nome_produto, preco_custo, preco_venda, quantidade,
                     descricao, unidade, validade, cod_marca, cod_tipo)
                VALUES
                    (@nome, @custo, @venda, @quantidade,
                     @descricao, @unidade, @validade, @marca, @tipo);";

            return Salvar(sql, produto, "Produto cadastrado com sucesso!", out mensagem);
        }

        /// <summary>
        /// Atualiza todos os campos do produto selecionado.
        /// </summary>
        public bool Atualizar(ModeloProduto produto, out string mensagem)
        {
            const string sql = @"
                UPDATE produto
                SET nome_produto = @nome,
                    preco_custo = @custo,
                    preco_venda = @venda,
                    quantidade = @quantidade,
                    descricao = @descricao,
                    unidade = @unidade,
                    validade = @validade,
                    cod_marca = @marca,
                    cod_tipo = @tipo
                WHERE codigo = @codigo;";

            return Salvar(sql, produto, "Produto atualizado com sucesso!", out mensagem);
        }

        /// <summary>
        /// Exclui o produto indicado pela grade após a confirmação do usuário.
        /// </summary>
        public bool Excluir(int codigo, out string mensagem)
        {
            const string sql = "DELETE FROM produto WHERE codigo = @codigo;";

            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    conexao.Open();
                    bool excluiu = comando.ExecuteNonQuery() > 0;
                    mensagem = excluiu ? "Produto excluído com sucesso!" : "O produto não foi encontrado.";
                    return excluiu;
                }
            }
            catch (Exception)
            {
                mensagem = "Não foi possível excluir o produto. Verifique a conexão com o banco.";
                return false;
            }
        }

        // Os parâmetros abaixo são iguais no cadastro e na atualização.
        private bool Salvar(string sql, ModeloProduto produto, string sucesso, out string mensagem)
        {
            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", produto.Nome.Trim());
                    comando.Parameters.AddWithValue("@custo", produto.PrecoCusto);
                    comando.Parameters.AddWithValue("@venda", produto.PrecoVenda);
                    comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                    comando.Parameters.AddWithValue("@descricao", produto.Descricao.Trim());
                    comando.Parameters.AddWithValue("@unidade", produto.Unidade.Trim());

                    // DBNull representa corretamente uma validade não informada no PostgreSQL.
                    comando.Parameters.AddWithValue(
                        "@validade",
                        produto.Validade.HasValue
                            ? (object)produto.Validade.Value.Date
                            : DBNull.Value);

                    comando.Parameters.AddWithValue("@marca", produto.CodigoMarca);
                    comando.Parameters.AddWithValue("@tipo", produto.CodigoTipo);

                    if (sql.Contains("@codigo"))
                    {
                        comando.Parameters.AddWithValue("@codigo", produto.Codigo);
                    }

                    conexao.Open();
                    bool alterou = comando.ExecuteNonQuery() > 0;
                    mensagem = alterou ? sucesso : "O produto não foi encontrado.";
                    return alterou;
                }
            }
            catch (PostgresException erro)
            {
                mensagem = erro.SqlState == "23503"
                    ? "A marca ou o tipo selecionado não existe mais. Atualize as opções."
                    : "Não foi possível salvar o produto. Confira os dados informados.";
                return false;
            }
            catch (Exception)
            {
                mensagem = "Não foi possível salvar o produto. Verifique a conexão com o banco.";
                return false;
            }
        }
    }
}
