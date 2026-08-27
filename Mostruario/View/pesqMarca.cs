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
    public partial class pesqMarca : Form
    {
        public pesqMarca()
        {
            InitializeComponent();
        }

        private void listaMarcas(object sender, EventArgs e)
        {
            controleMarca cMarca = new controleMarca();
            NpgsqlDataReader marcas = cMarca.pesquisaMarca(textBox1.Text);

            
            //apaga as colunas da datagridview
            dataGridView1.Columns.Clear();

            //definindo a quant. de colunas que a grid terá
            dataGridView1.ColumnCount = marcas.FieldCount; 

            //definindo os cabeçalhos das colunas
            for(int i = 0; i < marcas.FieldCount; i++)
            {
                dataGridView1.Columns[i].Name = marcas.GetName(i);
            }

            //Aqui criamos um vetor para representar uma linha 
            //da consulta(registro)
            string[] linha = new string[marcas.FieldCount];

            //copia os dados do DataReader para a DataGrid
            while (marcas.Read())
            {
                for (int i = 0; i < marcas.FieldCount; i++)
                {
                    linha[i] = marcas.GetValue(i).ToString();
                }

                dataGridView1.Rows.Add(linha);
            }
            
        }
    }
}
