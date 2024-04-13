using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace agua
{
    public partial class Inicio : Form
    {
       // lista de contatos
       public List<Contato> listaDeContatos; 

        // construtor do arquivo
        public Inicio()
        {
            InitializeComponent();
            CarregarContatosDoJson(); 
            CarregaLista();
        }

        //carrega a lisat com os dados do arquivo
        public void CarregarContatosDoJson()
        {
            string filePath = "..\\..\\..\\contatos.json";

            if (File.Exists(filePath))
            {
             
                string json = File.ReadAllText(filePath);


                listaDeContatos = JsonConvert.DeserializeObject<List<Contato>>(json);
            }
            else
            {
                MessageBox.Show("O arquivo de contatos não foi encontrado!");
            }
        }

        //carrega a lista de contatos
        public void CarregaLista()
        {

            if (listaDeContatos == null || listaDeContatos.Count == 0)
            {
                MessageBox.Show("Não há contatos para carregar!");
                return;
            }

            var grupos = listaDeContatos
                .Select(c => c.Nome)
                .OrderBy(nome => nome)
                .GroupBy(nome => char.ToUpper(nome[0]));
            foreach (var grupo in grupos)
            {
                listBox1.Items.Add($"-- {grupo.Key} --"); // Adiciona a letra maiúscula como cabeçalho

                // Adiciona os nomes ordenados ao grupo
                foreach (var nome in grupo.OrderBy(nome => nome))
                {
                    listBox1.Items.Add(nome);

                }
            }
        }

        // evento que dispara quando da dois cliques em um dado na lista
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Obtém o nome selecionado na ListBox
                string nomeSelecionado = listBox1.SelectedItem.ToString();

                // Procura na lista de contatos pelo nome correspondente
                Contato contato = listaDeContatos.Find(c => c.Nome == nomeSelecionado);

                // Se o contato for encontrado, exibe seus dados em um MessageBox
                if (contato != null)
                {

                    new MostrarContato(contato,this).Show();

                }
                else
                {
                    
                }
            }
        }

        // evento que acontece ao clilcar no botão btnCadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new Form1(this).Show();
        }

        // atualiza os contatos json e atualiza eles na tela
        public void AtualizarContatos()
        {
            listBox1.Items.Clear();
            CarregarContatosDoJson(); 
            CarregaLista(); 
        }
    }
}
