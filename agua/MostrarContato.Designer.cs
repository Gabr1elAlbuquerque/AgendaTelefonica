namespace ProjetoAgendaTelefonica
{
    partial class MostrarContato
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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            btnEditar = new Button();
            btnSalvar = new Button();
            btnApagar = new Button();
            btnDescartarAlteracoes = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(252, 175);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(240, 150);
            dataGridView2.TabIndex = 4;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 60);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(577, 23);
            txtNome.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 136);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(577, 23);
            txtEmail.TabIndex = 2;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(331, 379);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(103, 23);
            btnEditar.TabIndex = 0;
            btnEditar.Text = "Editar Contato";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(12, 379);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click_1;
            // 
            // btnApagar
            // 
            btnApagar.Location = new Point(224, 379);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(101, 23);
            btnApagar.TabIndex = 7;
            btnApagar.Text = "Excluir contato";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            // 
            // btnDescartarAlteracoes
            // 
            btnDescartarAlteracoes.Location = new Point(93, 379);
            btnDescartarAlteracoes.Name = "btnDescartarAlteracoes";
            btnDescartarAlteracoes.Size = new Size(125, 23);
            btnDescartarAlteracoes.TabIndex = 6;
            btnDescartarAlteracoes.Text = "Descartar alterações";
            btnDescartarAlteracoes.UseVisualStyleBackColor = true;
            btnDescartarAlteracoes.Click += btnDescartarAlteracoes_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 8;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 118);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 9;
            label2.Text = "E-mail:";
            // 
            // MostrarContato
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDescartarAlteracoes);
            Controls.Add(btnApagar);
            Controls.Add(btnSalvar);
            Controls.Add(btnEditar);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "MostrarContato";
            Text = "MostrarContato";
            FormClosed += MostrarContato_FormClosed;
            Load += MostrarContato_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private TextBox txtNome;
        private TextBox txtEmail;
        private Button btnEditar;
        private Button btnSalvar;
        private Button btnApagar;
        private Button btnDescartarAlteracoes;
        private Label label1;
        private Label label2;
    }
}