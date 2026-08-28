using System;

namespace Mostruario.Model
{
    /// <summary>
    /// Reúne os dados de um produto transferidos entre a tela e o banco.
    /// </summary>
    internal class ModeloProduto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }

        // O ponto de interrogação permite cadastrar roupas sem validade.
        public DateTime? Validade { get; set; }

        public int CodigoMarca { get; set; }
        public int CodigoTipo { get; set; }
    }
}
