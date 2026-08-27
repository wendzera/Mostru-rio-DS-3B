using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mostruario.Model
{
    class modeloProduto
    {
        private int codigo;
        private string nome_produto;
        private Decimal preco_custo;  //money
        private Decimal preco_venda;  //money
        private int quantidade;
        private string descricao;
        private string unidade;
        private DateTime validade;
        private int cod_marca;
        private int cod_tipo;

        public int getCodigo()
        {
            return this.codigo;
        }
        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public string getNomeProduto()
        {
            return this.nome_produto;
        }
        public void setNomeProduto(string nome_produto)
        {
            this.nome_produto = nome_produto;
        }

        public Decimal getCusto()
        {
            return this.preco_custo;
        }
        public void setCusto(Decimal preco_custo)
        {
            this.preco_custo = preco_custo;
        }

        public Decimal getVenda()
        {
            return this.preco_venda;
        }
        public void setVenda(Decimal preco_venda)
        {
            this.preco_venda = preco_venda;
        }

        public int getQuantidade()
        {
            return this.quantidade;
        }
        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
        public string getDescricao()
        {
            return this.descricao;
        }
        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public string getUnidade()
        {
            return this.unidade;
        }
        public void setUnidade(string unidade)
        {
            this.unidade = unidade;
        }

        public DateTime getValidade()
        {
            return this.validade;
        }
        public void setValidade(DateTime validade)
        {
            this.validade = validade;
        }
        public int getCodMarca()
        {
            return this.cod_marca;
        }
        public void setCodMarca(int cod_marca)
        {
            this.cod_marca = cod_marca;
        }
        public int getCodTipo()
        {
            return this.cod_tipo;
        }
        public void setCodTipo(int cod_tipo)
        {
            this.cod_tipo = cod_tipo;
        }
    }
}
