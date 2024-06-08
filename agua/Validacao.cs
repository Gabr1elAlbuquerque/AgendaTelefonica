using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoAgendaTelefonica
{
    // classe responsavel pelas validações
    internal class Validacao
    {

       

        // verifica o nome digitado é valido
        public bool ValidaNome(string nome)
        {
            bool valido = true;

            if (nome.Contains(" ") || nome.Trim().Equals(""))
            {
                MessageBox.Show("Digite um nome válido.\n O nome não pode ser vazio .", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = false;
            }
            else if (!char.IsLetter(nome[0]))
            {
                MessageBox.Show("Digite um nome válido.\n O nome deve começar com uma letra.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = false;
            }

            return valido;
        }

        // verifica se o número de celular é valido
        public bool VerificarNumeroCelular(DataGridView dataCelualr)
        {
            string padrao = @"^55\(\d{2}\)\d{5}-\d{4}$";
            bool valido = true;
            foreach (DataGridViewRow row in dataCelualr.Rows)
            {


                if (!row.IsNewRow)
                {

                    string celular = Convert.ToString(row.Cells[0].Value);

                    if (!VerificaMascara(celular, padrao))
                    {
                        MessageBox.Show($"{celular} não é um número válido. \nPadrão a ser usado 55(99)99999-9999");
                        valido = false;
                        break;
                    }
                    if (celular.IndexOf("(00)") != -1)
                    {


                        valido = false;
                        MessageBox.Show($"{celular} não é um número válido. \n Os dois digitos do DD não podem ser 0");
                        break;

                    }
                }
            }

            return valido;
        }

        // verifica se o número de celular é valido
        public bool VerificarNumeroTelefone(DataGridView dataTelefone)
        {
            string padrao = @"^55\(\d{2}\)\d{4}-\d{4}$";
            bool valido = true;
            foreach (DataGridViewRow row in dataTelefone.Rows)
            {

                if (!row.IsNewRow)
                {
                    string telefone = Convert.ToString(row.Cells[0].Value);
                    if (!VerificaMascara(telefone, padrao))
                    {
                        MessageBox.Show($"{telefone} não é um número válido. \nPadrão a ser usado 55(99)9999-9999");
                        valido = false;
                        break;
                    }
                    if (telefone.IndexOf("(00)") != -1)
                    {

                        valido = false;
                        MessageBox.Show($"{telefone} não é um número válido.\n Os dois digitos do DD não podem ser 0");
                        break;
                    }
                }
            }

            return valido;
        }

        // verifica o email é um email valido
        public bool VerificarEmail(string email)
        {
            Regex regexEmail = new Regex(@"^[A-Za-z0-9_@.-]+$");


            if (!email.Trim().Equals(""))
            {

                int index = email.IndexOf(".com");
                int index2 = email.IndexOf("@");
                int index3 = email.IndexOf(" ");
                int index4 = email.IndexOf(" ");
                if (index != -1 && index2 != -1 && index3 == -1 && index4 == -1)
                {
                    if ((!regexEmail.IsMatch(email) || email.Count(c => c == '@') > 1))
                    {
                        MessageBox.Show("Digite um e-mail valido. \nExemplo de email válido: \nexemplo@gmail.com, exemplo@hotmail.com,etc.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                MessageBox.Show("Digite um e-mail valido. \nExemplo de email válido: \nexemplo@gmail.com, exemplo@hotmail.com,etc.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public Contato EmailJaExiste(List<Contato> contatos, string email)
        {
            if (contatos.Any(c => c.Email != null && c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Contato contato = contatos.Find(c => c.Email == email);
                return contato;
            }
            else
            {
                Contato c = new Contato();
                c.Email = "true";
                return c;
            }

           
        }

        // verifica se o telefone já existena lista de contatos
        public Contato TelefoneJaExiste(List<Contato> contatos, string telefone)
        {
            if( contatos.Any(c => c.Telefones.Contains(telefone)))
            {
                Contato contato = contatos.Find(c => c.Telefones.Contains(telefone));
                return contato;
            }
            else
            {
                Contato c = new Contato();

                c.Telefones.Add("true");
                c.Telefones[0] = "true";
                return c;
            }
        }

        // verifica se o celular já existena lista de contatos
        public Contato CelularJaExiste(List<Contato> contatos, string celular)
        {
            if (contatos.Any(c => c.Celulares.Contains(celular)))
            {
                Contato contato = contatos.Find(c => c.Celulares.Contains(celular));
                return contato;
            }
            else
            {
                Contato c = new Contato();

                c.Celulares.Add("true");
                c.Celulares[0] = "true";
                return c;
            }
        }

        static bool VerificaMascara(string texto, string padrao)
        {
            
            return Regex.IsMatch(texto, padrao);
        }

    }

}






