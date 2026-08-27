using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mostruario.Model;
using Mostruario.Controller;


namespace Mostruario.View
{
    public partial class cadTipoProduto : Form
    {
        public cadTipoProduto()
        {
            InitializeComponent();
        }

        private void novoTipo(object sender, EventArgs e)
        {
            modeloTipoProduto mTipo = new modeloTipoProduto();
            controleTipoProduto cTipo = new controleTipoProduto();

            //salvar os valores do formulario nos atributos(modelo)
            mTipo.setNome_tipo(textBox1.Text);

            //executa o cadastro no banco de dados e 
            //armazena na variavel res o resultado
            string res = cTipo.cadastraTipo(mTipo);

            MessageBox.Show(res);          
        }
    }
}
