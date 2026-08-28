using System;
using System.Data;
using Mostruario.Model;
using Npgsql;

namespace Mostruario.Controller
{
    /// <summary>
    /// Executa as quatro operações básicas dos tipos de produto.
    /// </summary>
    internal class ControleTipoProduto
    {
        /// <summary>
        /// Pesquisa tipos pelo nome e lista todos quando o termo está vazio.
        /// </summary>
        public DataTable Pesquisar(string termo, out string mensagem)
        {
            const string sql = @"
                SELECT codigo, nome_tipo
                FROM tipo_produto
                WHERE nome_tipo ILIKE @termo
                ORDER BY nome_tipo;";

            return Consultar(sql, "%" + (termo ?? string.Empty).Trim() + "%", out mensagem);
        }

        /// <summary>
        /// Devolve código e nome para preencher a seleção de tipos dos produtos.
        /// </summary>
        public DataTable Listar(out string mensagem)
        {
            const string sql = "SELECT codigo, nome_tipo FROM tipo_produto ORDER BY nome_tipo;";
            return Consultar(sql, null, out mensagem);
        }

        /// <summary>
        /// Cadastra um novo tipo de produto.
        /// </summary>
        public bool Cadastrar(ModeloTipoProduto tipo, out string mensagem)
        {
            const string sql = "INSERT INTO tipo_produto (nome_tipo) VALUES (@nome);";
            return Salvar(sql, tipo, "Tipo de produto cadastrado com sucesso!", out mensagem);
        }

        /// <summary>
        /// Atualiza o nome de um tipo já cadastrado.
        /// </summary>
        public bool Atualizar(ModeloTipoProduto tipo, out string mensagem)
        {
            const string sql = @"
                UPDATE tipo_produto SET nome_tipo = @nome WHERE codigo = @codigo;";

            return Salvar(sql, tipo, "Tipo de produto atualizado com sucesso!", out mensagem);
        }

        /// <summary>
        /// Exclui um tipo desde que ele não esteja sendo usado por produtos.
        /// </summary>
        public bool Excluir(int codigo, out string mensagem)
        {
            const string sql = "DELETE FROM tipo_produto WHERE codigo = @codigo;";

            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    conexao.Open();
                    bool excluiu = comando.ExecuteNonQuery() > 0;
                    mensagem = excluiu ? "Tipo de produto excluído com sucesso!" : "O tipo não foi encontrado.";
                    return excluiu;
                }
            }
            catch (PostgresException erro)
            {
                mensagem = erro.SqlState == "23503"
                    ? "Este tipo está sendo usado por um produto e não pode ser excluído."
                    : "Não foi possível excluir o tipo. Confira os dados informados.";
                return false;
            }
            catch (Exception)
            {
                mensagem = "Não foi possível excluir o tipo. Verifique a conexão com o banco.";
                return false;
            }
        }

        // A consulta devolve uma tabela pronta para ser ligada à grade ou ComboBox.
        private DataTable Consultar(string sql, string termo, out string mensagem)
        {
            mensagem = string.Empty;
            DataTable tabela = new DataTable();

            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    if (termo != null)
                    {
                        comando.Parameters.AddWithValue("@termo", termo);
                    }

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
                    ? "Não foi possível consultar os tipos. Verifique se o PostgreSQL está ativo."
                    : "Não foi possível ler os tipos. Verifique a configuração do banco.";
            }

            return tabela;
        }

        // Este método é usado tanto pelo cadastro quanto pela atualização.
        private bool Salvar(string sql, ModeloTipoProduto tipo, string sucesso, out string mensagem)
        {
            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", tipo.Nome.Trim());

                    if (sql.Contains("@codigo"))
                    {
                        comando.Parameters.AddWithValue("@codigo", tipo.Codigo);
                    }

                    conexao.Open();
                    bool alterou = comando.ExecuteNonQuery() > 0;
                    mensagem = alterou ? sucesso : "O tipo de produto não foi encontrado.";
                    return alterou;
                }
            }
            catch (PostgresException erro)
            {
                mensagem = erro.SqlState == "23505"
                    ? "Já existe um tipo de produto com esse nome."
                    : "Não foi possível salvar o tipo. Confira os dados informados.";
                return false;
            }
            catch (Exception)
            {
                mensagem = "Não foi possível salvar o tipo. Verifique a conexão com o banco.";
                return false;
            }
        }
    }
}
