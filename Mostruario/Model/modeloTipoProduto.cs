using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mostruario.Model
{
    class modeloTipoProduto
    {
        private int codigo;
        private string nome_tipo;

        #region codigo
        public int getCodigo()
        {
            return this.codigo;
        }
        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        #endregion

        #region nome_tipo
        public string getNome_tipo()
        {
            return this.nome_tipo;
        }
        public void setNome_tipo(string nome_tipo)
        {
            this.nome_tipo = nome_tipo;
        }
        #endregion
    }
}
