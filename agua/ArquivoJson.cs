using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agua
{
    
    // classe para mexer no arquivo json
    internal class ArquivoJson
    {
        // contato aux para usar quando edito um contato
        public Contato contato { get; set; }

        // salva contatos la lista de contatos
        public void SalvarDados(List<Contato> listaDeContatos, string nome, string email, DataGridView numerosCelular, DataGridView numerosTelefone)
        {

            // Se ambos os dados forem válidos, salva-os
            List<string> listCelular = new List<string>();
            foreach (DataGridViewRow row in numerosCelular.Rows)
            {
                if (!row.IsNewRow)
                {
                    string celular = Convert.ToString(row.Cells[0].Value);
                    listCelular.Add(celular);
                }
            }

            List<string> listTelefone = new List<string>();
            foreach (DataGridViewRow row in numerosTelefone.Rows)
            {
                if (!row.IsNewRow)
                {
                    string telefone = Convert.ToString(row.Cells[0].Value);
                    listTelefone.Add(telefone);
                }
            }

            string emailx = email.Trim().Equals("") ? null : email;
            Contato novoContato = new Contato(nome, emailx, listTelefone, listCelular);

            listaDeContatos.Add(novoContato);

            contato = novoContato;

            string path = "..\\..\\..\\contatos.json";
            string json = JsonConvert.SerializeObject(listaDeContatos, Formatting.Indented);

            File.WriteAllText(path, json);

        }

        // apaga um contato pelo seu nome e reescreve o arquivo
        public void ApagarContatoPorNome(List<Contato> listaDeContatos,string nome)
        {

            listaDeContatos.RemoveAll(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            string path = "..\\..\\..\\contatos.json";
            string json = JsonConvert.SerializeObject(listaDeContatos, Formatting.Indented);

            File.WriteAllText(path, json);

        }
    }



}
