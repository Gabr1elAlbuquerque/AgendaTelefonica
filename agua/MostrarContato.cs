using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace agua
{
    public partial class MostrarContato : Form
    {

        private List<Contato> listaDeContatos;
        private Contato contatoAux = new Contato();
        private Inicio inicioAux;

        public MostrarContato(Contato contato, Inicio inicio)
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeDataGridView2();
            inicioAux = inicio;
            contatoAux = contato;

            listaDeContatos = CarregarContatos();

            txtNome.Text = contato.Nome;
            txtEmail.Text = contato.Email != null ? contato.Email : "";


            foreach (var telefone in contato.Celulares)
            {
                dataGridView1.Rows.Add(telefone);
            }
            // Popula o dataGridView2 com os números de celular do contato
            foreach (var celular in contato.Telefones)
            {
                dataGridView2.Rows.Add(celular);
            }

            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            btnApagar.Enabled = false;
            btnSalvar.Enabled = false;
        }

        public MostrarContato()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeDataGridView2();

            listaDeContatos = CarregarContatos();
        }

        private void InitializeDataGridView2()
        {
            dataGridView2.ColumnCount = 1;
            dataGridView2.Columns[0].Name = "Número de Telefone";


            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.EditingControlShowing += DataGridView2_EditingControlShowing;

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            deleteButtonColumn.HeaderText = "Excluir";
            deleteButtonColumn.Text = "Excluir";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(deleteButtonColumn);

            dataGridView2.CellContentClick += DataGridView2_CellContentClick;
        }

        private void DataGridView2_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += TextBox2_TextChanged;
            }
        }

        private void TextBox2_TextChanged(object? sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string Celular = textBox.Text;

                if (Celular.Length >= 18)
                {
                    return;
                }

                string numeroLimpo = new string(Array.FindAll(Celular.ToCharArray(), Char.IsDigit));

                if (!numeroLimpo.StartsWith("55"))
                {
                    numeroLimpo = "55" + numeroLimpo;
                }

                if (numeroLimpo.Length > 2)
                {
                    string codigoPais = numeroLimpo.Substring(0, 2);
                    string restoNumero = numeroLimpo.Substring(2);

                    string numeroFormatado = string.Format("{0:(00)0000-0000}", Convert.ToInt64(restoNumero));
                    if (numeroFormatado.Length <= 13)
                    {
                        textBox.Text = codigoPais + numeroFormatado;
                    }
                    else
                    {
                        textBox.Text = codigoPais + numeroFormatado.Remove(numeroFormatado.Length - 1);
                    }
                }
                else
                {
                    textBox.Text = numeroLimpo;
                }

                textBox.SelectionStart = textBox.Text.Length;
            }
        }

       



        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Número de Celular";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            deleteButtonColumn.HeaderText = "Excluir";
            deleteButtonColumn.Text = "Excluir";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        dataGridView1.Columns[e.ColumnIndex].HeaderText == "Excluir" && !(e.RowIndex == dataGridView1.RowCount - 1))
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string Celular = textBox.Text;

                if (Celular.Length >= 18)
                {
                    return;
                }

                string numeroLimpo = new string(Array.FindAll(Celular.ToCharArray(), Char.IsDigit));

                if (!numeroLimpo.StartsWith("55"))
                {
                    numeroLimpo = "55" + numeroLimpo;
                }

                if (numeroLimpo.Length > 2)
                {
                    string codigoPais = numeroLimpo.Substring(0, 2);
                    string restoNumero = numeroLimpo.Substring(2);

                    string numeroFormatado = string.Format("{0:(00)00000-0000}", Convert.ToInt64(restoNumero));
                    if (numeroFormatado.Length <= 14)
                    {
                        textBox.Text = codigoPais + numeroFormatado;
                    }
                    else
                    {
                        textBox.Text = codigoPais + numeroFormatado.Remove(numeroFormatado.Length - 1);
                    }
                }
                else
                {
                    textBox.Text = numeroLimpo;
                }

                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
       


        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        dataGridView2.Columns[e.ColumnIndex].HeaderText == "Excluir" && !(e.RowIndex == dataGridView2.RowCount - 1))
            {
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }


        private List<Contato> CarregarContatos()
        {
            string path = "..\\..\\..\\contatos.json";
            List<Contato> contatos = new List<Contato>();

            // Verifica se o arquivo existe
            if (File.Exists(path))
            {
                // Lê o conteúdo do arquivo
                string json = File.ReadAllText(path);

                // Desserializa o JSON para obter a lista de contatos
                contatos = JsonConvert.DeserializeObject<List<Contato>>(json);
            }

            return contatos;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {

            Validacao  validacao  = new Validacao ();

            string novoNome = txtNome.Text.Trim();
            string novoEmail = txtEmail.Text.Trim();
         

            int quantCelulares = dataGridView1.RowCount - 1;
            int quantTelefones = dataGridView2.RowCount - 1;



            if (quantTelefones < 1 && quantCelulares < 1)
            {
                MessageBox.Show("Digite pelo menos 1 celular ou 1 telefone", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validacao.ValidaNome(novoNome))
            {
                MessageBox.Show("Digite um nome válido");
                return;
            }





            if (!validacao.VerificarNumeroCelular(dataGridView1))
            {

                return;
            }
            if (!validacao.VerificarNumeroTelefone(dataGridView2))
            {

                return;
            }

           


            if (!validacao.VerificarEmail(novoEmail))
            {
                MessageBox.Show("Digite um e-mail valido agua");
                return;
            }



            if (validacao.NomeJaExiste(listaDeContatos, novoNome))
            {
                if (contatoAux.Nome != novoNome)
                {
                    MessageBox.Show("Já existe um contato com esse nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(novoEmail) && validacao.EmailJaExiste(listaDeContatos, novoEmail))
            {
                if (contatoAux.Email != novoEmail)
                {
                    MessageBox.Show("Já existe um contato com esse email.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {

                    string celular = Convert.ToString(row.Cells[0].Value);
                    if (!contatoAux.Celulares.Contains(celular))
                    {
                        if (validacao.CelularJaExiste(listaDeContatos,celular))
                        {
                            MessageBox.Show("Já existe um contato com esse celular.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }



            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {

                    string telefone = Convert.ToString(row.Cells[0].Value);
                    if (!contatoAux.Telefones.Contains(telefone))
                    {
                        if (validacao.TelefoneJaExiste(listaDeContatos,telefone))
                        {
                            MessageBox.Show("Já existe um contato com esse telefone.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            // Se não houver duplicatas, você pode salvar os dados





            ArquivoJson contatosJson = new ArquivoJson();

            listaDeContatos.RemoveAll(c => c.Nome.Equals(contatoAux.Nome, StringComparison.OrdinalIgnoreCase));
            //arrumar isso aqui


            contatosJson.SalvarDados(listaDeContatos, novoNome, novoEmail, dataGridView1, dataGridView2);
            
            inicioAux.AtualizarContatos();

         
            MessageBox.Show("Dados salvos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            txtNome.Enabled = !txtNome.Enabled;
            txtEmail.Enabled = !txtEmail.Enabled;
            btnSalvar.Enabled = !btnSalvar.Enabled;
            btnApagar.Enabled = !btnApagar.Enabled;
            dataGridView1.Enabled = !dataGridView1.Enabled;
            dataGridView2.Enabled = !dataGridView2.Enabled;
            btnEditar.Text = txtNome.Enabled ? "Cancelar edição" : "Editar dados";
        }


       

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ArquivoJson contatosJson = new ArquivoJson();

            contatosJson.ApagarContatoPorNome(listaDeContatos,contatoAux.Nome);
           
            inicioAux.AtualizarContatos();
            MessageBox.Show($"{contatoAux.Nome} foi deletado com sucesso");
            this.Close();
        }
    }

}