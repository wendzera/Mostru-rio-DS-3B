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
using Npgsql;

namespace Mostruario.View
{
    public partial class pesqProduto : Form
    {
        public pesqProduto()
        {
            InitializeComponent();
        }

        private void listaProdutos(object sender, EventArgs e)
        {
            //executa a pesquisa no banco e retorna os dados encontrados
            controleProduto cProduto = new controleProduto();
            NpgsqlDataReader produtos = cProduto.pesquisaProduto(textBox1.Text);

            //apaga as colunas da datagridview
            dataGridView1.Columns.Clear();

            //definindo a quant. de colunas que a grid terá
            dataGridView1.ColumnCount = produtos.FieldCount;

            //definindo os cabeçalhos das colunas
            for (int i = 0; i < produtos.FieldCount; i++)
            {
                dataGridView1.Columns[i].Name = produtos.GetName(i);
            }
            
            //Aqui criamos um vetor para representar uma linha 
            //da consulta(registro)
            string[] linha = new string[produtos.FieldCount];

            //copia os dados do DataReader para a DataGrid
            while (produtos.Read())
            {
                for (int i = 0; i < produtos.FieldCount; i++)
                {
                    linha[i] = produtos.GetValue(i).ToString();
                }

                dataGridView1.Rows.Add(linha);
            }
            

        }



        private void ListaMarcas(object sender, EventArgs e)
        {
            listaMarcas();
        }

        private void listaTipos(object sender, EventArgs e)
        {
            listaTipos();
        }

        private void Load_pesqProdutos(object sender, EventArgs e)
        {
            listaMarcas();
            listaTipos();
        }       

        private void atualiza_produto(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("Deseja atualizar este produto?", "Atualização de produto",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (res == DialogResult.OK)
                {
                    /*TODO: redefinir máscara de acordo com o preço de venda */

                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    numericUpDown1.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    richTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                    comboBox1.SelectedIndex = comboBox1.FindStringExact(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    tabControl1.SelectedTab = tabPage2;
                }
            }   

        }

        private void novoTipo(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadTipoProduto frm = new cadTipoProduto();
            frm.ShowDialog();
        }

        private void novaMarca(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadMarca frm = new cadMarca();
            frm.ShowDialog();
        }

        //----METODOS PARA AS COMBOBOX-------------------
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

    }
}
