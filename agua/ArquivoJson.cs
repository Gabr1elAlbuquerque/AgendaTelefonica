using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgendaTelefonica
{
    
    // classe para mexer no arquivo json
    internal abstract class ArquivoJson<T>
    {
        public ArquivoJson(string path) { this.path = path; }


        public string path {  get; set; }

        // salva contatos la lista de contatos
        public abstract void SalvarDados(List<T> lista, T dado);

        // apaga um contato pelo seu nome e reescreve o arquivo
        public abstract void ApagarDado(List<T> lista, string dado);
    }



}
