using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoAgendaTelefonica
{

    // classe para mexer no arquivo json
    internal class ContatosJson  : ArquivoJson<Contato>
    {
        // contato aux para usar quando edito um contato
        public Contato contato { get; set; }

        public ContatosJson(string path_):base(path_)
        {
            
        }

        // salva contatos la lista de contatos
        public override void SalvarDados(List<Contato> listaDeContatos, Contato novoContato)
        {

            

            listaDeContatos.Add(novoContato);

            contato = novoContato;


            string json = JsonConvert.SerializeObject(listaDeContatos, Formatting.Indented);

            File.WriteAllText(path, json);

        }

        public Contato PreparaContato(string nome, string email, DataGridView numerosCelular, DataGridView numerosTelefone)
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
            return novoContato;
        }

        // apaga um contato pelo seu nome e reescreve o arquivo
        public override void ApagarDado(List<Contato> listaDeContatos, string nome)
        {

            listaDeContatos.RemoveAll(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));


            string json = JsonConvert.SerializeObject(listaDeContatos, Formatting.Indented);

            File.WriteAllText(path, json);

        }

    }
}





