using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agua
{
    internal class Validacao
    {

        private Regex regex = new Regex(@"^[A-Za-z0-9_@.-]+$");


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






        public bool NomeJaExiste(List<Contato> contatos, string nome)
        {

            return contatos.Any(c => c.Nome != null && c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }


        public bool EmailJaExiste(List<Contato> contatos, string email)
        {
            return contatos.Any(c => c.Email != null && c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool TelefoneJaExiste(List<Contato> contatos, string telefone)
        {
            return contatos.Any(c => c.Telefones.Contains(telefone));
        }

        public bool CelularJaExiste(List<Contato> contatos, string celular)
        {
            return contatos.Any(c => c.Celulares.Contains(celular));
        }




    }








}






