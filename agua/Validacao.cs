using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agua
{
    // classe responsavel pelas validações
    internal class Validacao
    {

        private Regex regex = new Regex(@"^[A-Za-z0-9_@.-]+$");

        // verifica o nome digitado é valido
        public bool ValidaNome(string nome)
        {
            bool valido = true;

            if (nome.Contains(" ") || nome.Trim().Equals(""))
            {
                valido = false;
            }
            else if (!char.IsLetter(nome[0]))
            {
                valido = false;
            }

            return valido;
        }

        // verifica se o número de celular é valido
        public bool VerificarNumeroCelular(DataGridView dataCelualr)
        {
            bool valido = true;
            foreach (DataGridViewRow row in dataCelualr.Rows)
            {


                if (!row.IsNewRow)
                {
                    string celular = Convert.ToString(row.Cells[0].Value);
                    if (celular.IndexOf("(00)") != -1)
                    {

                        valido = false;
                        MessageBox.Show($"{celular} não é um número válido.");
                        break;

                    }
                }
            }

            return valido;
        }

        // verifica se o número de celular é valido
        public bool VerificarNumeroTelefone(DataGridView dataTelefone)
        {

            bool valido = true;
            foreach (DataGridViewRow row in dataTelefone.Rows)
            {

                if (!row.IsNewRow)
                {
                    string telefone = Convert.ToString(row.Cells[0].Value);
                    if (telefone.IndexOf("(00)") != -1)
                    {

                        valido = false;
                        MessageBox.Show($"{telefone} não é um número válido.");
                        break;
                    }
                }
            }

            return valido;
        }

        // verifica o email é um email valido
        public bool VerificarEmail(string email)
        {

            if (!email.Trim().Equals(""))
            {

                int index = email.IndexOf(".com");
                int index2 = email.IndexOf("@");
                int index3 = email.IndexOf(" ");
                int index4 = email.IndexOf(" ");
                if (index != -1 && index2 != -1 && index3 == -1 && index4 == -1)
                {
                    if ((!regex.IsMatch(email) || email.Count(c => c == '@') > 1))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;

            }
            else
            {
                return true;
            }

        }


        // verifica se o nome já existena lista de contatos
        public bool NomeJaExiste(List<Contato> contatos, string nome)
        {

            return contatos.Any(c => c.Nome != null && c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        // verifica se o email já existena lista de contatos
        public bool EmailJaExiste(List<Contato> contatos, string email)
        {
            return contatos.Any(c => c.Email != null && c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // verifica se o telefone já existena lista de contatos
        public bool TelefoneJaExiste(List<Contato> contatos, string telefone)
        {
            return contatos.Any(c => c.Telefones.Contains(telefone));
        }

        // verifica se o celular já existena lista de contatos
        public bool CelularJaExiste(List<Contato> contatos, string celular)
        {
            return contatos.Any(c => c.Celulares.Contains(celular));
        }

    }

}






