using System;
using System.Windows.Forms;

namespace Mostruario.View
{
    /// <summary>
    /// Tela inicial que direciona o usuário aos três cadastros do sistema.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // Abre o cadastro completo de produtos como uma janela modal.
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            using (FrmProdutos formulario = new FrmProdutos())
            {
                formulario.ShowDialog(this);
            }
        }

        // Abre o cadastro completo de marcas.
        private void btnMarcas_Click(object sender, EventArgs e)
        {
            using (FrmMarcas formulario = new FrmMarcas())
            {
                formulario.ShowDialog(this);
            }
        }

        // Abre o cadastro completo dos tipos de produto.
        private void btnTipos_Click(object sender, EventArgs e)
        {
            using (FrmTiposProduto formulario = new FrmTiposProduto())
            {
                formulario.ShowDialog(this);
            }
        }
    }
}
