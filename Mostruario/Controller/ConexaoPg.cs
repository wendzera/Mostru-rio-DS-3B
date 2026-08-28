using System.Configuration;
using Npgsql;

namespace Mostruario.Controller
{
    /// <summary>
    /// Cria conexões usando a configuração definida no arquivo App.config.
    /// </summary>
    internal static class ConexaoPg
    {
        /// <summary>
        /// Devolve uma conexão fechada. Quem chama deve usar um bloco using
        /// para garantir que o recurso seja sempre liberado.
        /// </summary>
        public static NpgsqlConnection Criar()
        {
            ConnectionStringSettings configuracao =
                ConfigurationManager.ConnectionStrings["MostruarioDb"];

            if (configuracao == null || string.IsNullOrWhiteSpace(configuracao.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "A conexão 'MostruarioDb' não foi configurada no App.config.");
            }

            return new NpgsqlConnection(configuracao.ConnectionString);
        }
    }
}
