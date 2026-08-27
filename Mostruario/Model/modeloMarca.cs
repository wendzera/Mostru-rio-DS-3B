using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mostruario.Model
{
    class modeloMarca{

        private int codigo;
        private string nome_marca;
        private string descricao;

        public int getCodigo()
        {
            return this.codigo;
        }

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public string getNomeMarca()
        {
            return this.nome_marca;
        }

        public void setNomeMarca(string nome_marca)
        {
            this.nome_marca = nome_marca;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }


    }
}
