using System;
using System.Data;
using Mostruario.Model;
using Npgsql;

namespace Mostruario.Controller
{
    /// <summary>
    /// Executa no PostgreSQL as operações de cadastro e pesquisa de marcas.
    /// </summary>
    internal class ControleMarca
    {
        /// <summary>
        /// Pesquisa pelo nome. Um texto vazio devolve todas as marcas.
        /// </summary>
        public DataTable Pesquisar(string termo, out string mensagem)
        {
            const string sql = @"
                SELECT codigo, nome_marca, descricao
                FROM marca
                WHERE nome_marca ILIKE @termo
                ORDER BY nome_marca;";

            return Consultar(sql, "%" + (termo ?? string.Empty).Trim() + "%", out mensagem);
        }

        /// <summary>
        /// Devolve código e nome para preencher a seleção de marcas dos produtos.
        /// </summary>
        public DataTable Listar(out string mensagem)
        {
            const string sql = "SELECT codigo, nome_marca FROM marca ORDER BY nome_marca;";
            return Consultar(sql, null, out mensagem);
        }

        /// <summary>
        /// Insere uma nova marca e informa o resultado para a tela.
        /// </summary>
        public bool Cadastrar(ModeloMarca marca, out string mensagem)
        {
            const string sql = @"
                INSERT INTO marca (nome_marca, descricao)
                VALUES (@nome, @descricao);";

            return Salvar(sql, marca, "Marca cadastrada com sucesso!", out mensagem);
        }

        /// <summary>
        /// Atualiza a marca identificada pelo código recebido.
        /// </summary>
        public bool Atualizar(ModeloMarca marca, out string mensagem)
        {
            const string sql = @"
                UPDATE marca
                SET nome_marca = @nome, descricao = @descricao
                WHERE codigo = @codigo;";

            return Salvar(sql, marca, "Marca atualizada com sucesso!", out mensagem);
        }

        /// <summary>
        /// Exclui uma marca que não esteja ligada a produtos.
        /// </summary>
        public bool Excluir(int codigo, out string mensagem)
        {
            const string sql = "DELETE FROM marca WHERE codigo = @codigo;";

            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    conexao.Open();
                    bool excluiu = comando.ExecuteNonQuery() > 0;
                    mensagem = excluiu ? "Marca excluída com sucesso!" : "A marca não foi encontrada.";
                    return excluiu;
                }
            }
            catch (PostgresException erro)
            {
                mensagem = erro.SqlState == "23503"
                    ? "Esta marca está sendo usada por um produto e não pode ser excluída."
                    : "Não foi possível excluir a marca. Confira os dados informados.";
                return false;
            }
            catch (Exception)
            {
                mensagem = "Não foi possível excluir a marca. Verifique a conexão com o banco.";
                return false;
            }
        }

        // Este método concentra a leitura e sempre fecha os recursos utilizados.
        private DataTable Consultar(string sql, string termo, out string mensagem)
        {
            mensagem = string.Empty;
            DataTable tabela = new DataTable();

            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    // O parâmetro impede que o texto pesquisado seja interpretado como SQL.
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
                    ? "Não foi possível consultar as marcas. Verifique se o PostgreSQL está ativo."
                    : "Não foi possível ler as marcas. Verifique a configuração do banco.";
            }

            return tabela;
        }

        // Cadastro e atualização compartilham os mesmos campos e parâmetros.
        private bool Salvar(string sql, ModeloMarca marca, string sucesso, out string mensagem)
        {
            try
            {
                using (NpgsqlConnection conexao = ConexaoPg.Criar())
                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", marca.Nome.Trim());
                    comando.Parameters.AddWithValue(
                        "@descricao",
                        string.IsNullOrWhiteSpace(marca.Descricao)
                            ? (object)DBNull.Value
                            : marca.Descricao.Trim());

                    if (sql.Contains("@codigo"))
                    {
                        comando.Parameters.AddWithValue("@codigo", marca.Codigo);
                    }

                    conexao.Open();
                    bool alterou = comando.ExecuteNonQuery() > 0;
                    mensagem = alterou ? sucesso : "A marca não foi encontrada.";
                    return alterou;
                }
            }
            catch (PostgresException erro)
            {
                mensagem = erro.SqlState == "23505"
                    ? "Já existe uma marca com esse nome."
                    : "Não foi possível salvar a marca. Confira os dados informados.";
                return false;
            }
            catch (Exception)
            {
                mensagem = "Não foi possível salvar a marca. Verifique a conexão com o banco.";
                return false;
            }
        }
    }
}
