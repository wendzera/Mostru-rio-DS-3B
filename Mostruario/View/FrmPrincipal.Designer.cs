namespace Mostruario.View
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCabecalho;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblInstrucao;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnTipos;
        private System.Windows.Forms.Label lblRodape;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCabecalho = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInstrucao = new System.Windows.Forms.Label();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnTipos = new System.Windows.Forms.Button();
            this.lblRodape = new System.Windows.Forms.Label();
            this.pnlCabecalho.SuspendLayout();
            this.SuspendLayout();
            this.pnlCabecalho.BackColor = System.Drawing.Color.FromArgb(18, 73, 82);
            this.pnlCabecalho.Controls.Add(this.lblSubtitulo);
            this.pnlCabecalho.Controls.Add(this.lblTitulo);
            this.pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecalho.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecalho.Name = "pnlCabecalho";
            this.pnlCabecalho.Size = new System.Drawing.Size(744, 108);
            this.pnlCabecalho.TabIndex = 0;
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(201, 224, 226);
            this.lblSubtitulo.Location = new System.Drawing.Point(34, 65);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(299, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Roupas e produtos organizados em um só lugar";
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(306, 42);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mostruário escolar";
            this.lblInstrucao.AutoSize = true;
            this.lblInstrucao.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblInstrucao.ForeColor = System.Drawing.Color.FromArgb(45, 62, 65);
            this.lblInstrucao.Location = new System.Drawing.Point(34, 139);
            this.lblInstrucao.Name = "lblInstrucao";
            this.lblInstrucao.Size = new System.Drawing.Size(203, 20);
            this.lblInstrucao.TabIndex = 1;
            this.lblInstrucao.Text = "O que você deseja gerenciar?";
            this.btnProdutos.BackColor = System.Drawing.Color.FromArgb(33, 117, 130);
            this.btnProdutos.FlatAppearance.BorderSize = 0;
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnProdutos.ForeColor = System.Drawing.Color.White;
            this.btnProdutos.Location = new System.Drawing.Point(38, 184);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(210, 100);
            this.btnProdutos.TabIndex = 2;
            this.btnProdutos.Text = "PRODUTOS\r\nCadastrar e consultar";
            this.btnProdutos.UseVisualStyleBackColor = false;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            this.btnMarcas.BackColor = System.Drawing.Color.FromArgb(47, 97, 134);
            this.btnMarcas.FlatAppearance.BorderSize = 0;
            this.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnMarcas.ForeColor = System.Drawing.Color.White;
            this.btnMarcas.Location = new System.Drawing.Point(267, 184);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(210, 100);
            this.btnMarcas.TabIndex = 3;
            this.btnMarcas.Text = "MARCAS\r\nCadastrar e consultar";
            this.btnMarcas.UseVisualStyleBackColor = false;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            this.btnTipos.BackColor = System.Drawing.Color.FromArgb(96, 83, 135);
            this.btnTipos.FlatAppearance.BorderSize = 0;
            this.btnTipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnTipos.ForeColor = System.Drawing.Color.White;
            this.btnTipos.Location = new System.Drawing.Point(496, 184);
            this.btnTipos.Name = "btnTipos";
            this.btnTipos.Size = new System.Drawing.Size(210, 100);
            this.btnTipos.TabIndex = 4;
            this.btnTipos.Text = "TIPOS DE PRODUTO\r\nOrganizar categorias";
            this.btnTipos.UseVisualStyleBackColor = false;
            this.btnTipos.Click += new System.EventHandler(this.btnTipos_Click);
            this.lblRodape.AutoSize = true;
            this.lblRodape.ForeColor = System.Drawing.Color.FromArgb(92, 105, 108);
            this.lblRodape.Location = new System.Drawing.Point(35, 326);
            this.lblRodape.Name = "lblRodape";
            this.lblRodape.Size = new System.Drawing.Size(410, 15);
            this.lblRodape.TabIndex = 5;
            this.lblRodape.Text = "Selecione uma opção. Cada tela permite pesquisar, incluir, editar e excluir.";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 248);
            this.ClientSize = new System.Drawing.Size(744, 381);
            this.Controls.Add(this.lblRodape);
            this.Controls.Add(this.btnTipos);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.lblInstrucao);
            this.Controls.Add(this.pnlCabecalho);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mostruário escolar";
            this.pnlCabecalho.ResumeLayout(false);
            this.pnlCabecalho.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
