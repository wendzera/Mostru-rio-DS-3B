namespace Mostruario
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.cadProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.cadMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.cadTipoProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.pESQUISASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mARCAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aTUALIZAÇÃOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUTOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuCadastro
            // 
            this.menuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadProduto,
            this.cadMarca,
            this.cadTipoProduto});
            this.menuCadastro.Name = "menuCadastro";
            this.menuCadastro.Size = new System.Drawing.Size(146, 33);
            this.menuCadastro.Text = "&CADASTROS";
            // 
            // cadProduto
            // 
            this.cadProduto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadProduto.Image = ((System.Drawing.Image)(resources.GetObject("cadProduto.Image")));
            this.cadProduto.Name = "cadProduto";
            this.cadProduto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.cadProduto.Size = new System.Drawing.Size(265, 34);
            this.cadProduto.Text = "PRODUTO";
            this.cadProduto.Click += new System.EventHandler(this.novoProduto);
            // 
            // cadMarca
            // 
            this.cadMarca.Name = "cadMarca";
            this.cadMarca.Size = new System.Drawing.Size(265, 34);
            this.cadMarca.Text = "MARCA";
            this.cadMarca.Click += new System.EventHandler(this.frmMarca);
            // 
            // cadTipoProduto
            // 
            this.cadTipoProduto.Name = "cadTipoProduto";
            this.cadTipoProduto.Size = new System.Drawing.Size(265, 34);
            this.cadTipoProduto.Text = "TIPO DE PRODUTO";
            this.cadTipoProduto.Click += new System.EventHandler(this.frmTipo);
            // 
            // pESQUISASToolStripMenuItem
            // 
            this.pESQUISASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pRODUTOToolStripMenuItem,
            this.mARCAToolStripMenuItem});
            this.pESQUISASToolStripMenuItem.Name = "pESQUISASToolStripMenuItem";
            this.pESQUISASToolStripMenuItem.Size = new System.Drawing.Size(137, 33);
            this.pESQUISASToolStripMenuItem.Text = "PESQUISAS";
            // 
            // pRODUTOToolStripMenuItem
            // 
            this.pRODUTOToolStripMenuItem.Name = "pRODUTOToolStripMenuItem";
            this.pRODUTOToolStripMenuItem.Size = new System.Drawing.Size(183, 34);
            this.pRODUTOToolStripMenuItem.Text = "PRODUTO";
            this.pRODUTOToolStripMenuItem.Click += new System.EventHandler(this.pesqProduto);
            // 
            // mARCAToolStripMenuItem
            // 
            this.mARCAToolStripMenuItem.Name = "mARCAToolStripMenuItem";
            this.mARCAToolStripMenuItem.Size = new System.Drawing.Size(183, 34);
            this.mARCAToolStripMenuItem.Text = "MARCA";
            this.mARCAToolStripMenuItem.Click += new System.EventHandler(this.frmPesqmarca);
            // 
            // aTUALIZAÇÃOToolStripMenuItem
            // 
            this.aTUALIZAÇÃOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pRODUTOToolStripMenuItem1});
            this.aTUALIZAÇÃOToolStripMenuItem.Name = "aTUALIZAÇÃOToolStripMenuItem";
            this.aTUALIZAÇÃOToolStripMenuItem.Size = new System.Drawing.Size(160, 33);
            this.aTUALIZAÇÃOToolStripMenuItem.Text = "ATUALIZAÇÃO";
            // 
            // pRODUTOToolStripMenuItem1
            // 
            this.pRODUTOToolStripMenuItem1.Name = "pRODUTOToolStripMenuItem1";
            this.pRODUTOToolStripMenuItem1.Size = new System.Drawing.Size(183, 34);
            this.pRODUTOToolStripMenuItem1.Text = "PRODUTO";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastro,
            this.pESQUISASToolStripMenuItem,
            this.aTUALIZAÇÃOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menuCadastro;
        private System.Windows.Forms.ToolStripMenuItem cadProduto;
        private System.Windows.Forms.ToolStripMenuItem cadMarca;
        private System.Windows.Forms.ToolStripMenuItem cadTipoProduto;
        private System.Windows.Forms.ToolStripMenuItem pESQUISASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRODUTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mARCAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aTUALIZAÇÃOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRODUTOToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

