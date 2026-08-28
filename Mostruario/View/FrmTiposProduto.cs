using System;
using System.Data;
using System.Windows.Forms;
using Mostruario.Controller;
using Mostruario.Model;

namespace Mostruario.View
{
    /// <summary>
    /// Reúne as operações usadas para organizar os tipos de produto.
    /// </summary>
    public partial class FrmTiposProduto : Form
    {
        private readonly ControleTipoProduto controle = new ControleTipoProduto();
        private int codigoEmEdicao;

        public FrmTiposProduto()
        {
            InitializeComponent();
        }

        // Lista os tipos assim que a janela é apresentada.
        private void FrmTiposProduto_Load(object sender, EventArgs e)
        {
            Pesquisar();
            LimparCampos();
        }

        // Filtra a grade pelo texto digitado.
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        // Prepara um cadastro novo sem alterar o banco.
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Copia o tipo selecionado para o campo de edição.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ExisteLinhaSelecionada())
            {
                return;
            }

            codigoEmEdicao = Convert.ToInt32(gridTipos.CurrentRow.Cells["codigo"].Value);
            txtNome.Text = Convert.ToString(gridTipos.CurrentRow.Cells["nome_tipo"].Value);
            lblModo.Text = "Editando o tipo selecionado";
            txtNome.Focus();
        }

        // O duplo clique oferece um atalho simples para editar a linha.
        private void gridTipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, EventArgs.Empty);
            }
        }

        // Cadastra ou atualiza conforme o modo indicado pelo código em edição.
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            ModeloTipoProduto tipo = new ModeloTipoProduto
            {
                Codigo = codigoEmEdicao,
                Nome = txtNome.Text.Trim()
            };

            string mensagem;
            bool sucesso = codigoEmEdicao == 0
                ? controle.Cadastrar(tipo, out mensagem)
                : controle.Atualizar(tipo, out mensagem);

            MessageBox.Show(
                mensagem,
                "Tipos de produto",
                MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (sucesso)
            {
                Pesquisar();
                LimparCampos();
            }
        }

        // Exclui somente após o usuário confirmar a operação.
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!ExisteLinhaSelecionada())
            {
                return;
            }

            string nome = Convert.ToString(gridTipos.CurrentRow.Cells["nome_tipo"].Value);
            DialogResult resposta = MessageBox.Show(
                "Deseja excluir o tipo \"" + nome + "\"?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            int codigo = Convert.ToInt32(gridTipos.CurrentRow.Cells["codigo"].Value);
            string mensagem;
            bool sucesso = controle.Excluir(codigo, out mensagem);
            MessageBox.Show(
                mensagem,
                "Tipos de produto",
                MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (sucesso)
            {
                Pesquisar();
                LimparCampos();
            }
        }

        // Descarta apenas o que foi digitado na tela.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Consulta o controlador e atualiza a apresentação da grade.
        /// </summary>
        private void Pesquisar()
        {
            string mensagem;
            DataTable tipos = controle.Pesquisar(txtPesquisa.Text, out mensagem);
            gridTipos.DataSource = tipos;

            if (!string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show(mensagem, "Tipos de produto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (gridTipos.Columns.Contains("codigo"))
            {
                gridTipos.Columns["codigo"].Visible = false;
                gridTipos.Columns["nome_tipo"].HeaderText = "Tipo de produto";
                gridTipos.Columns["nome_tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Evita que o primeiro registro pareça escolhido sem ação do usuário.
            gridTipos.ClearSelection();
            lblQuantidade.Text = tipos.Rows.Count + " tipo(s) encontrado(s)";
        }

        /// <summary>
        /// Impede que um tipo sem nome chegue ao banco de dados.
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do tipo de produto.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            return true;
        }

        private bool ExisteLinhaSelecionada()
        {
            if (gridTipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um tipo na lista.", "Tipos de produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        // Reinicia o formulário no modo de inclusão.
        private void LimparCampos()
        {
            codigoEmEdicao = 0;
            txtNome.Clear();
            lblModo.Text = "Novo tipo de produto";
            txtNome.Focus();
        }
    }
}
