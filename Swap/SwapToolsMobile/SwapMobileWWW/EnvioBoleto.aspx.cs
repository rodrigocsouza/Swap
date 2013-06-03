using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using HumanAPIClient.Service;
using HumanAPIClient.Model;
using System.Text;
using System.Globalization;

namespace SwapMobileWWW
{
    public partial class EnvioBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            String account = "swap";

            String code = "zJmLTF7JvU";

            int contador = 0;
            try
            {
                contador = ObterUltimoID() + 1;

                SimpleSending sms = new SimpleSending(account, code);

                SimpleMessage message = new SimpleMessage();

                message.To = string.Format("55{0}{1}", txbDDD.Text, txbCelular.Text);
                string msg = "Prezado Cliente, o seu boleto encontra-se disponível no link ";
                EncurtadorURL encurtador = new EncurtadorURL();
                string urlReduzida = encurtador.LengthenUrl(ConfigurationManager.AppSettings["URLBOLETO"].ToString() + "?sacado=" + txbNome.Text + "&endereco=" + txbEndereco.Text + "&cpf=" + txbCPF.Text + "&cidade=" + txbCidade.Text + "&uf=" + txbUF.Text + "&bairro=" + txbBairro.Text + "&cep=" + txbCEP.Text);// "http://localhost:1057/BoletoBB.aspx");
                msg += urlReduzida;
                message.Message = RemoverAcentos(msg);
                contador++;
                message.Id = contador.ToString("0000");
                List<String> response = sms.send(message);

                lblResultado.Text = "SMS com boleto enviado com sucesso!";
                SalvarUltimoID(contador);
                btnEnviar.Enabled = false;
            }
            catch (Exception exx)
            {
                lblResultado.Text = "Ocorreu um erro no envio: " + exx.Message;
            }

            //EncurtadorURL encurtador = new EncurtadorURL();
            //string urlReduzida = encurtador.LengthenUrl(ConfigurationManager.AppSettings["URLBOLETO"].ToString()+"?sacado="+txbNome.Text+"&endereco="+txbEndereco.Text+"&cpf="+txbCPF.Text+"&cidade="+txbCidade.Text+"&uf="+txbUF.Text+"&bairro="+txbBairro.Text+"&cep="+txbCEP.Text);// "http://localhost:1057/BoletoBB.aspx");


        }

        private int ObterUltimoID()
        {
            String line;
            int idHuman = 0;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(Server.MapPath("/") + "idHuman.txt");

                //Read the first line of text
                line = sr.ReadLine();
                idHuman = Convert.ToInt32(line);

                //Continue to read until you reach end of file
                //while (line != null)
                //{
                //write the lie to console window
                //Console.WriteLine(line);
                //Read the next line
                //line = sr.ReadLine();
                //}

                //close the file
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
            return idHuman;


        }

        private void SalvarUltimoID(int p)
        {
            try
            {
                File.Delete(Server.MapPath("/")+"\\idHuman.txt");
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(Server.MapPath("/") + "\\idHuman.txt");

                //Write a line of text
                sw.WriteLine(p.ToString());

                //Write a second line of text
                //sw.WriteLine("From the StreamWriter class");

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        private string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }
    }
}