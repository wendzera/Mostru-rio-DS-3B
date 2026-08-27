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
using Mostruario.Model;
using Npgsql;



namespace Mostruario.View
{
    public partial class cadProduto : Form
    {
        public cadProduto()
        {
            InitializeComponent();
        }

        private void novaMarca(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadMarca frm = new cadMarca();
            frm.ShowDialog();
        }

        private void novoTipo(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadTipoProduto frm = new cadTipoProduto();
            frm.ShowDialog();
        }

        private void cadProduto_Load(object sender, EventArgs e)
        {
            listaMarcas();
            listaTipos();
        }

                private void marcas_load(object sender, EventArgs e)
        {
            listaMarcas();            
        }

        private void tipos_load(object sender, EventArgs e)
        {
            listaTipos();
        }

        private void novoProduto(object sender, EventArgs e)
        {
            modeloProduto mProduto = new modeloProduto();
            controleProduto cProduto = new controleProduto();

            mProduto.setNomeProduto(textBox1.Text);
            mProduto.setCodMarca(Convert.ToInt32(comboBox1.SelectedValue));
            mProduto.setCodTipo(Convert.ToInt32(comboBox2.SelectedValue));
            mProduto.setCusto(Convert.ToDecimal(maskedTextBox1.Text));
            mProduto.setVenda(Convert.ToDecimal(maskedTextBox2.Text));
            mProduto.setQuantidade(Convert.ToInt32(numericUpDown1.Value));
            mProduto.setUnidade(textBox2.Text);
            mProduto.setValidade(Convert.ToDateTime(dateTimePicker1.Text));
            mProduto.setDescricao(richTextBox1.Text);

            string res = cProduto.cadastraProduto(mProduto);
            MessageBox.Show(res);

        }

        //------------METODOS--------------------//
        private void listaMarcas()
        {
            controleMarca cMarca = new controleMarca();
            NpgsqlDataReader dtMarca = cMarca.listaMarca();

            DataTable marcas = new DataTable();
            marcas.Load(dtMarca);

            comboBox1.DataSource = marcas;

            comboBox1.DisplayMember = "nome_marca";
            comboBox1.ValueMember = "codigo";
        }


        private void listaTipos()
        {
            controleTipoProduto cTipo = new controleTipoProduto();
            NpgsqlDataReader dtTipo = cTipo.listaTipo();

            DataTable tipos = new DataTable();
            tipos.Load(dtTipo);

            comboBox2.DataSource = tipos;

            comboBox2.DisplayMember = "nome_tipo";
            comboBox2.ValueMember = "codigo";
        }

        private void cadProduto_Load_1(object sender, EventArgs e)
        {
            listaMarcas();
        }
    }
}
