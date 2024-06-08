using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoAgendaTelefonica
{
    public partial class Inicio : Form
    {
        // lista de contatos
        public List<Contato> listaDeContatos;
        public List<string> contatosAbetos = new List<string>();

        // construtor do arquivo
        public Inicio()
        {
            InitializeComponent();
            CarregarContatosDoJson();
            CarregaLista();
        }

        //carrega a lisat com os dados do arquivo
        private void CarregarContatosDoJson()
        {
            string filePath = "..\\..\\..\\contatos.json";

            if (File.Exists(filePath))
            {

                string json = File.ReadAllText(filePath);


                listaDeContatos = JsonConvert.DeserializeObject<List<Contato>>(json);
            }
            else
            {
                // parte nova
                List<Contato> listaVazia = new List<Contato>();
                string json = JsonConvert.SerializeObject(listaVazia);
                File.WriteAllText(filePath, json);
            }
        }

        //carrega a lista de contatos
        private void CarregaLista()
        {

            if (listaDeContatos == null || listaDeContatos.Count == 0)
            {

                listBox1.Items.Add("Não há contatos para carregar!");
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

                string nomeSelecionado = listBox1.SelectedItem.ToString();

                if (!contatosAbetos.Contains(nomeSelecionado))
                {

                    Contato contato = listaDeContatos.Find(c => c.Nome == nomeSelecionado);

                    if (contato != null)
                    {

                        new MostrarContato(contato, this).Show();
                        contatosAbetos.Add(nomeSelecionado);
                    }

                }
                else
                {
                    MessageBox.Show($"O contato {nomeSelecionado} já está aberto.");
                }
            }
        }

        // evento que acontece ao clilcar no botão btnCadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new Cadastro(this).Show();
        }

        // atualiza os contatos json e atualiza eles na tela
        public void AtualizarContatos()
        {
            listBox1.Items.Clear();
            CarregarContatosDoJson();
            CarregaLista();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
