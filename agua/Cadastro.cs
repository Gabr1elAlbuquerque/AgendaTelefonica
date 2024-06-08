using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetoAgendaTelefonica
{
    public partial class Cadastro : Form
    {

        //variavel aux que vai receber o form de inicio
        private Inicio inicioAux;

        // construtor
        public Cadastro(Inicio inicio)
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeDataGridView2();
            inicioAux = inicio;


        }

        // metodo responsavel por iniciar o grid2
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

        // evento que controla a a mudança de textos
        private void DataGridView2_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += TextBox2_TextChanged;
            }
        }
        //Evento responsável pelo controle  de alterar o texto no grid
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

        // metodo responsavel por iniciar o grid
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

        // evento que é chamado quando clico no botão excluir no dataGrid2
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        dataGridView1.Columns[e.ColumnIndex].HeaderText == "Excluir" && !(e.RowIndex == dataGridView1.RowCount - 1))
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        // evento que controla a a mudança de textos
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        //Evento responsável pelo controle  de alterar o texto no grid
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




        // evento que acontece ao clilcar no botão btnSalvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string novoNome = txtNome.Text.Trim();
            string novoEmail = txtEmail.Text.Trim();

            Validacao validacao = new Validacao();

            int quantCelulares = dataGridView1.RowCount - 1;
            int quantTelefones = dataGridView2.RowCount - 1;

            if (!validacao.ValidaNome(novoNome))
            {

                return;
            }

            if (quantTelefones < 1 && quantCelulares < 1)
            {
                MessageBox.Show("Digite pelo menos 1 celular ou 1 telefone", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                return;
            }

            if (validacao.NomeJaExiste(inicioAux.listaDeContatos, novoNome))
            {
                MessageBox.Show("Já existe um contato com esse nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Contato contatoEmail = validacao.EmailJaExiste(inicioAux.listaDeContatos, novoEmail);
            if (!string.IsNullOrEmpty(novoEmail) && !contatoEmail.Email.Equals("true"))
            {
                MessageBox.Show($"Já existe um contato com esse email no contato {contatoEmail.Nome}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string celular = Convert.ToString(row.Cells[0].Value);
                    Contato contatoCelular = validacao.CelularJaExiste(inicioAux.listaDeContatos, celular);
                    if (!contatoCelular.Celulares[0].Equals("true"))
                    {
                        MessageBox.Show($"Já existe  um contato com esse telefone no contato {contatoCelular.Nome}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }


            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    string telefone = Convert.ToString(row.Cells[0].Value);
                    Contato contatoTelefone = validacao.TelefoneJaExiste(inicioAux.listaDeContatos, telefone);
                    if (!contatoTelefone.Telefones[0].Equals("true"))
                    {
                        MessageBox.Show($"Já existe  um contato com esse telefone no contato {contatoTelefone.Nome}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            ContatosJson contatosJson = new ContatosJson("..\\..\\..\\contatos.json");
            Contato novoContato = contatosJson.PreparaContato(novoNome, novoEmail, dataGridView1, dataGridView2);
            contatosJson.SalvarDados(inicioAux.listaDeContatos, novoContato);
            inicioAux.AtualizarContatos();

            MessageBox.Show("Dados salvos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            this.Close();

        }

        // evento que é chamado quando clico no botão excluir no dataGrid2
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        dataGridView2.Columns[e.ColumnIndex].HeaderText == "Excluir" && !(e.RowIndex == dataGridView2.RowCount - 1))
            {
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }



        // evento que acontece ao clilcar no botão  btnLimpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();

        }

        private void Limpar()
        {

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            txtEmail.Text = "";
            txtNome.Text = "";
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        
    }

}