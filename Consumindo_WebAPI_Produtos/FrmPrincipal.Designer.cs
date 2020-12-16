
namespace Consumindo_WebAPI_Produtos
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbURI = new System.Windows.Forms.Label();
            this.TbURI = new System.Windows.Forms.TextBox();
            this.BtnAutenticar = new System.Windows.Forms.Button();
            this.DataGridViewProdutos = new System.Windows.Forms.DataGridView();
            this.BtnRetomarProdutos = new System.Windows.Forms.Button();
            this.BtnObterProdutosPorID = new System.Windows.Forms.Button();
            this.BtnIncluirProduto = new System.Windows.Forms.Button();
            this.BtnAtualizarProduto = new System.Windows.Forms.Button();
            this.BtnDeletarProduto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // LbURI
            // 
            this.LbURI.AutoSize = true;
            this.LbURI.Location = new System.Drawing.Point(13, 16);
            this.LbURI.Name = "LbURI";
            this.LbURI.Size = new System.Drawing.Size(84, 13);
            this.LbURI.TabIndex = 0;
            this.LbURI.Text = "URI - Web API :";
            // 
            // TbURI
            // 
            this.TbURI.Location = new System.Drawing.Point(104, 13);
            this.TbURI.Name = "TbURI";
            this.TbURI.Size = new System.Drawing.Size(534, 20);
            this.TbURI.TabIndex = 1;
            this.TbURI.Text = "https://localhost:44335/api/produtos";
            // 
            // BtnAutenticar
            // 
            this.BtnAutenticar.Location = new System.Drawing.Point(644, 5);
            this.BtnAutenticar.Name = "BtnAutenticar";
            this.BtnAutenticar.Size = new System.Drawing.Size(91, 33);
            this.BtnAutenticar.TabIndex = 2;
            this.BtnAutenticar.Text = "Autenticar";
            this.BtnAutenticar.UseVisualStyleBackColor = true;
            // 
            // DataGridViewProdutos
            // 
            this.DataGridViewProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewProdutos.Location = new System.Drawing.Point(16, 44);
            this.DataGridViewProdutos.Name = "DataGridViewProdutos";
            this.DataGridViewProdutos.Size = new System.Drawing.Size(719, 264);
            this.DataGridViewProdutos.TabIndex = 3;
            // 
            // BtnRetomarProdutos
            // 
            this.BtnRetomarProdutos.Location = new System.Drawing.Point(16, 314);
            this.BtnRetomarProdutos.Name = "BtnRetomarProdutos";
            this.BtnRetomarProdutos.Size = new System.Drawing.Size(139, 45);
            this.BtnRetomarProdutos.TabIndex = 4;
            this.BtnRetomarProdutos.Text = "Retomar Produtos";
            this.BtnRetomarProdutos.UseVisualStyleBackColor = true;
            // 
            // BtnObterProdutosPorID
            // 
            this.BtnObterProdutosPorID.Location = new System.Drawing.Point(161, 314);
            this.BtnObterProdutosPorID.Name = "BtnObterProdutosPorID";
            this.BtnObterProdutosPorID.Size = new System.Drawing.Size(139, 45);
            this.BtnObterProdutosPorID.TabIndex = 5;
            this.BtnObterProdutosPorID.Text = "Obter Produtos Por ID";
            this.BtnObterProdutosPorID.UseVisualStyleBackColor = true;
            // 
            // BtnIncluirProduto
            // 
            this.BtnIncluirProduto.Location = new System.Drawing.Point(306, 314);
            this.BtnIncluirProduto.Name = "BtnIncluirProduto";
            this.BtnIncluirProduto.Size = new System.Drawing.Size(139, 45);
            this.BtnIncluirProduto.TabIndex = 6;
            this.BtnIncluirProduto.Text = "Incluir Produto";
            this.BtnIncluirProduto.UseVisualStyleBackColor = true;
            // 
            // BtnAtualizarProduto
            // 
            this.BtnAtualizarProduto.Location = new System.Drawing.Point(451, 314);
            this.BtnAtualizarProduto.Name = "BtnAtualizarProduto";
            this.BtnAtualizarProduto.Size = new System.Drawing.Size(139, 45);
            this.BtnAtualizarProduto.TabIndex = 7;
            this.BtnAtualizarProduto.Text = "Atualizar Produto";
            this.BtnAtualizarProduto.UseVisualStyleBackColor = true;
            // 
            // BtnDeletarProduto
            // 
            this.BtnDeletarProduto.Location = new System.Drawing.Point(596, 314);
            this.BtnDeletarProduto.Name = "BtnDeletarProduto";
            this.BtnDeletarProduto.Size = new System.Drawing.Size(139, 45);
            this.BtnDeletarProduto.TabIndex = 8;
            this.BtnDeletarProduto.Text = "Deletar Produto";
            this.BtnDeletarProduto.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(751, 369);
            this.Controls.Add(this.BtnDeletarProduto);
            this.Controls.Add(this.BtnAtualizarProduto);
            this.Controls.Add(this.BtnIncluirProduto);
            this.Controls.Add(this.BtnObterProdutosPorID);
            this.Controls.Add(this.BtnRetomarProdutos);
            this.Controls.Add(this.DataGridViewProdutos);
            this.Controls.Add(this.BtnAutenticar);
            this.Controls.Add(this.TbURI);
            this.Controls.Add(this.LbURI);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Consumindo Web API";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbURI;
        private System.Windows.Forms.TextBox TbURI;
        private System.Windows.Forms.Button BtnAutenticar;
        private System.Windows.Forms.DataGridView DataGridViewProdutos;
        private System.Windows.Forms.Button BtnRetomarProdutos;
        private System.Windows.Forms.Button BtnObterProdutosPorID;
        private System.Windows.Forms.Button BtnIncluirProduto;
        private System.Windows.Forms.Button BtnAtualizarProduto;
        private System.Windows.Forms.Button BtnDeletarProduto;
    }
}

