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
    public partial class cadMarca : Form
    {
        public cadMarca()
        {
            InitializeComponent();
        }      

        private void novaMarca(object sender, EventArgs e)
        {
            modeloMarca mMarca = new modeloMarca();
            controleMarca cMarca = new controleMarca();

            mMarca.setNomeMarca(textBox1.Text);
            mMarca.setDescricao(richTextBox1.Text);

            string res = cMarca.cadastraMarca(mMarca);
            MessageBox.Show(res);
        }
    }
}
