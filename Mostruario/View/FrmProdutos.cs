using System;
using System.Data;
using System.Windows.Forms;
using Mostruario.Controller;
using Mostruario.Model;

namespace Mostruario.View
{
    /// <summary>
    /// Tela principal de manutenção dos produtos exibidos no mostruário.
    /// </summary>
    public partial class FrmProdutos : Form
    {
        private readonly ControleProduto controle = new ControleProduto();
        private readonly ControleMarca controleMarca = new ControleMarca();
        private readonly ControleTipoProduto controleTipo = new ControleTipoProduto();
        private int codigoEmEdicao;

        public FrmProdutos()
        {
            InitializeComponent();
        }

        // Carrega primeiro as opções dos campos e depois apresenta os produtos.
        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            CarregarOpcoes();
            Pesquisar();
            LimparCampos();
        }

        // Filtra a lista pelo nome informado.
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        // Volta ao modo de inclusão de um produto novo.
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Transfere os dados da linha selecionada para os campos de edição.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ExisteLinhaSelecionada())
            {
                return;
            }

            DataGridViewRow linha = gridProdutos.CurrentRow;
            codigoEmEdicao = Convert.ToInt32(linha.Cells["codigo"].Value);
            txtNome.Text = Convert.ToString(linha.Cells["nome_produto"].Value);
            numPrecoCusto.Value = Convert.ToDecimal(linha.Cells["preco_custo"].Value);
            numPrecoVenda.Value = Convert.ToDecimal(linha.Cells["preco_venda"].Value);
            numQuantidade.Value = Convert.ToDecimal(linha.Cells["quantidade"].Value);
            txtUnidade.Text = Convert.ToString(linha.Cells["unidade"].Value);
            txtDescricao.Text = Convert.ToString(linha.Cells["descricao"].Value);
            cboMarca.SelectedValue = Convert.ToInt32(linha.Cells["cod_marca"].Value);
            cboTipo.SelectedValue = Convert.ToInt32(linha.Cells["cod_tipo"].Value);

            // A caixa marcada indica que uma data será gravada no banco.
            if (linha.Cells["validade"].Value == DBNull.Value)
            {
                dtpValidade.Checked = false;
                dtpValidade.Value = DateTime.Today;
            }
            else
            {
                dtpValidade.Checked = true;
                dtpValidade.Value = Convert.ToDateTime(linha.Cells["validade"].Value);
            }

            lblModo.Text = "Editando o produto selecionado";
            txtNome.Focus();
        }

        // Um duplo clique oferece acesso rápido ao modo de edição.
        private void gridProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, EventArgs.Empty);
            }
        }

        // Valida, monta o modelo e decide se deve cadastrar ou atualizar.
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            ModeloProduto produto = new ModeloProduto
            {
                Codigo = codigoEmEdicao,
                Nome = txtNome.Text.Trim(),
                PrecoCusto = numPrecoCusto.Value,
                PrecoVenda = numPrecoVenda.Value,
                Quantidade = Convert.ToInt32(numQuantidade.Value),
                Unidade = txtUnidade.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Validade = dtpValidade.Checked ? (DateTime?)dtpValidade.Value.Date : null,
                CodigoMarca = Convert.ToInt32(cboMarca.SelectedValue),
                CodigoTipo = Convert.ToInt32(cboTipo.SelectedValue)
            };

            string mensagem;
            bool sucesso = codigoEmEdicao == 0
                ? controle.Cadastrar(produto, out mensagem)
                : controle.Atualizar(produto, out mensagem);

            MessageBox.Show(
                mensagem,
                "Produtos",
                MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (sucesso)
            {
                Pesquisar();
                LimparCampos();
            }
        }

        // Exclui somente depois de confirmar qual produto será removido.
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!ExisteLinhaSelecionada())
            {
                return;
            }

            string nome = Convert.ToString(gridProdutos.CurrentRow.Cells["nome_produto"].Value);
            DialogResult resposta = MessageBox.Show(
                "Deseja excluir o produto \"" + nome + "\"?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            int codigo = Convert.ToInt32(gridProdutos.CurrentRow.Cells["codigo"].Value);
            string mensagem;
            bool sucesso = controle.Excluir(codigo, out mensagem);
            MessageBox.Show(
                mensagem,
                "Produtos",
                MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (sucesso)
            {
                Pesquisar();
                LimparCampos();
            }
        }

        // Descarta a edição atual sem modificar o banco.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Atualiza a grade e deixa visíveis apenas as colunas úteis ao usuário.
        /// </summary>
        private void Pesquisar()
        {
            string mensagem;
            DataTable produtos = controle.Pesquisar(txtPesquisa.Text, out mensagem);
            gridProdutos.DataSource = produtos;

            if (!string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show(mensagem, "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (gridProdutos.Columns.Contains("codigo"))
            {
                gridProdutos.Columns["codigo"].Visible = false;
                gridProdutos.Columns["preco_custo"].Visible = false;
                gridProdutos.Columns["descricao"].Visible = false;
                gridProdutos.Columns["cod_marca"].Visible = false;
                gridProdutos.Columns["cod_tipo"].Visible = false;
                gridProdutos.Columns["nome_produto"].HeaderText = "Produto";
                gridProdutos.Columns["preco_venda"].HeaderText = "Preço de venda";
                gridProdutos.Columns["quantidade"].HeaderText = "Quantidade";
                gridProdutos.Columns["unidade"].HeaderText = "Unidade";
                gridProdutos.Columns["validade"].HeaderText = "Validade";
                gridProdutos.Columns["nome_marca"].HeaderText = "Marca";
                gridProdutos.Columns["nome_tipo"].HeaderText = "Tipo";
                gridProdutos.Columns["preco_venda"].DefaultCellStyle.Format = "N2";
                gridProdutos.Columns["validade"].DefaultCellStyle.Format = "d";
                gridProdutos.Columns["nome_produto"].Width = 190;
                gridProdutos.Columns["nome_marca"].Width = 130;
                gridProdutos.Columns["nome_tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // A lista é exibida sem selecionar silenciosamente o primeiro produto.
            gridProdutos.ClearSelection();
            lblQuantidadeRegistros.Text = produtos.Rows.Count + " produto(s) encontrado(s)";
        }

        /// <summary>
        /// Carrega marcas e tipos já cadastrados nas listas do formulário.
        /// </summary>
        private void CarregarOpcoes()
        {
            string mensagemMarcas;
            string mensagemTipos;
            DataTable marcas = controleMarca.Listar(out mensagemMarcas);
            DataTable tipos = controleTipo.Listar(out mensagemTipos);

            cboMarca.DataSource = marcas;
            cboMarca.DisplayMember = "nome_marca";
            cboMarca.ValueMember = "codigo";
            cboMarca.SelectedIndex = -1;

            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "nome_tipo";
            cboTipo.ValueMember = "codigo";
            cboTipo.SelectedIndex = -1;

            string mensagem = !string.IsNullOrEmpty(mensagemMarcas) ? mensagemMarcas : mensagemTipos;
            if (!string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show(mensagem, "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Impede que dados incompletos ou incompatíveis cheguem ao controlador.
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                return AvisarCampo("Informe o nome do produto.", txtNome);
            }

            if (cboMarca.SelectedValue == null)
            {
                return AvisarCampo("Selecione uma marca. Cadastre uma marca antes, se necessário.", cboMarca);
            }

            if (cboTipo.SelectedValue == null)
            {
                return AvisarCampo("Selecione um tipo de produto. Cadastre um tipo antes, se necessário.", cboTipo);
            }

            if (string.IsNullOrWhiteSpace(txtUnidade.Text))
            {
                return AvisarCampo("Informe a unidade, por exemplo: un, par ou kg.", txtUnidade);
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                return AvisarCampo("Informe uma descrição do produto.", txtDescricao);
            }

            return true;
        }

        // Mostra a orientação, posiciona o cursor e informa que a validação falhou.
        private bool AvisarCampo(string mensagem, Control campo)
        {
            MessageBox.Show(mensagem, "Confira os dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
            return false;
        }

        private bool ExisteLinhaSelecionada()
        {
            if (gridProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto na lista.", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        // Limpa todos os campos e volta a tela ao modo de cadastro.
        private void LimparCampos()
        {
            codigoEmEdicao = 0;
            txtNome.Clear();
            cboMarca.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            numPrecoCusto.Value = 0;
            numPrecoVenda.Value = 0;
            numQuantidade.Value = 0;
            txtUnidade.Clear();
            dtpValidade.Value = DateTime.Today;
            dtpValidade.Checked = false;
            txtDescricao.Clear();
            lblModo.Text = "Novo produto";
            txtNome.Focus();
        }
    }
}
