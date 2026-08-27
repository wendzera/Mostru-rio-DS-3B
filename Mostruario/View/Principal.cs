using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mostruario.Controller;
using Mostruario.View;


namespace Mostruario
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

         private void frmTipo(object sender, EventArgs e)
        {
            //criação de um objeto do formulário cadTipoProduto
            cadTipoProduto frm = new cadTipoProduto();
            frm.ShowDialog();
        }

        private void frmMarca(object sender, EventArgs e)
        {
            cadMarca frm = new cadMarca();
            frm.ShowDialog();
        }

        private void novoProduto(object sender, EventArgs e)
        {
            cadProduto frm = new cadProduto();
            frm.ShowDialog();
        }

        private void frmPesqmarca(object sender, EventArgs e)
        {
            pesqMarca frm = new pesqMarca();
            frm.ShowDialog();
        }

        private void pesqProduto(object sender, EventArgs e)
        {
            pesqProduto frm = new pesqProduto();
            frm.ShowDialog();
        }
    }
}
