using System;
using System.Data;
using System.Windows.Forms;
using Mostruario.Controller;
using Mostruario.Model;

namespace Mostruario.View
{
    /// <summary>
    /// Reúne pesquisa, cadastro, alteração e exclusão de marcas.
    /// </summary>
    public partial class FrmMarcas : Form
    {
        private readonly ControleMarca controle = new ControleMarca();
        private int codigoEmEdicao;

        public FrmMarcas()
        {
            InitializeComponent();
        }

        // Assim que a tela abre, todas as marcas cadastradas são apresentadas.
        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            Pesquisar();
            LimparCampos();
        }

        // Executa a pesquisa usando o texto informado pelo usuário.
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        // Prepara os campos para incluir um novo registro.
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Carrega nos campos a linha escolhida para que ela possa ser alterada.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ExisteLinhaSelecionada())
            {
                return;
            }

            DataGridViewRow linha = gridMarcas.CurrentRow;
            codigoEmEdicao = Convert.ToInt32(linha.Cells["codigo"].Value);
            txtNome.Text = Convert.ToString(linha.Cells["nome_marca"].Value);
            txtDescricao.Text = linha.Cells["descricao"].Value == DBNull.Value
                ? string.Empty
                : Convert.ToString(linha.Cells["descricao"].Value);

            lblModo.Text = "Editando a marca selecionada";
            txtNome.Focus();
        }

        // Um duplo clique é um atalho para o mesmo comportamento do botão Editar.
        private void gridMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, EventArgs.Empty);
            }
        }

        // Valida os campos e decide entre cadastrar ou atualizar.
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            ModeloMarca marca = new ModeloMarca
            {
                Codigo = codigoEmEdicao,
                Nome = txtNome.Text.Trim(),
                Descricao = txtDescricao.Text.Trim()
            };

            string mensagem;
            bool sucesso = codigoEmEdicao == 0
                ? controle.Cadastrar(marca, out mensagem)
                : controle.Atualizar(marca, out mensagem);

            MessageBox.Show(
                mensagem,
                "Marcas",
                MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (sucesso)
            {
                Pesquisar();
                LimparCampos();
            }
        }

        // Solicita confirmação antes de apagar definitivamente a linha escolhida.
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!ExisteLinhaSelecionada())
            {
                return;
            }

            string nome = Convert.ToString(gridMarcas.CurrentRow.Cells["nome_marca"].Value);
            DialogResult resposta = MessageBox.Show(
                "Deseja excluir a marca \"" + nome + "\"?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            int codigo = Convert.ToInt32(gridMarcas.CurrentRow.Cells["codigo"].Value);
            string mensagem;
            bool sucesso = controle.Excluir(codigo, out mensagem);
            MessageBox.Show(
                mensagem,
                "Marcas",
                MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (sucesso)
            {
                Pesquisar();
                LimparCampos();
            }
        }

        // Cancela a edição sem modificar dados no banco.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Atualiza a grade e aplica nomes de colunas fáceis de entender.
        /// </summary>
        private void Pesquisar()
        {
            string mensagem;
            DataTable marcas = controle.Pesquisar(txtPesquisa.Text, out mensagem);
            gridMarcas.DataSource = marcas;

            if (!string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show(mensagem, "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (gridMarcas.Columns.Contains("codigo"))
            {
                gridMarcas.Columns["codigo"].Visible = false;
                gridMarcas.Columns["nome_marca"].HeaderText = "Marca";
                gridMarcas.Columns["descricao"].HeaderText = "Descrição";
                gridMarcas.Columns["nome_marca"].Width = 220;
                gridMarcas.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Nenhuma linha fica escolhida automaticamente após atualizar a lista.
            gridMarcas.ClearSelection();
            lblQuantidade.Text = marcas.Rows.Count + " marca(s) encontrada(s)";
        }

        /// <summary>
        /// Garante que os dados obrigatórios sejam preenchidos antes do banco.
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome da marca.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            return true;
        }

        // Evita executar edição ou exclusão sem uma linha selecionada.
        private bool ExisteLinhaSelecionada()
        {
            if (gridMarcas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma marca na lista.", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        // Volta a tela ao modo de inclusão e posiciona o cursor no primeiro campo.
        private void LimparCampos()
        {
            codigoEmEdicao = 0;
            txtNome.Clear();
            txtDescricao.Clear();
            lblModo.Text = "Nova marca";
            txtNome.Focus();
        }
    }
}
