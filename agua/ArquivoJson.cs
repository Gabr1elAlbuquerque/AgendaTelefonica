using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agua
{
    

    internal class ArquivoJson
    {
        public Contato contato {  get; set; }
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



            // Adiciona o novo contato à lista de contatos
            listaDeContatos.Add(novoContato);

            // Serializa a lista atualizada de contatos de volta para JSON
            string path = "..\\..\\..\\contatos.json";
            string json = JsonConvert.SerializeObject(listaDeContatos, Formatting.Indented);

            // Salva o JSON no arquivo
            File.WriteAllText(path, json);

            contato = novoContato;  

        }

        public void ApagarContatoPorNome(List<Contato> listaDeContatos,string nome)
        {

            listaDeContatos.RemoveAll(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            // Serializa a lista atualizada de contatos de volta para JSON
            string path = "..\\..\\..\\contatos.json";
            string json = JsonConvert.SerializeObject(listaDeContatos, Formatting.Indented);

            // Salva o JSON no arquivo
            File.WriteAllText(path, json);

        }
    }



}
