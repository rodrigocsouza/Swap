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
                contador = HumanHelper.ObterUltimoID();

                SimpleSending sms = new SimpleSending(account, code);

                SimpleMessage message = new SimpleMessage();

                message.To = string.Format("55{0}{1}", txbDDD.Text, txbCelular.Text);
                string msg = txbMensagem.Text+" ";
                EncurtadorURL encurtador = new EncurtadorURL();
                string url = ConfigurationManager.AppSettings["URLBOLETO"].ToString() + "?banco="+ddlBanco.SelectedValue+"&sacado=" + txbNome.Text + "&endereco=" + txbEndereco.Text + "&cpf=" + txbCPF.Text + "&cidade=" + txbCidade.Text + "&uf=" + txbUF.Text + "&bairro=" + txbBairro.Text + "&cep=" + txbCEP.Text+"&valor="+txbValor.Text.Replace('.',',');
                string urlReduzida = encurtador.LengthenUrl(url);
                msg += urlReduzida;
                message.Message = HumanHelper.RemoverAcentos(msg);
                contador++;
                message.Id = contador.ToString("0000");
                lblMsgEnviada.Text = message.Message;
                hlLink.NavigateUrl = url;
                hlLink.Text = url;

                hlLinkReduzida.NavigateUrl = urlReduzida;
                hlLinkReduzida.Text = urlReduzida;
                List<String> response = sms.send(message);

                lblResultado.Text = "SMS com boleto enviado com sucesso!";
                btnEnviar.Enabled = false;
                btnLimpar.Enabled = true;
            }
            catch (Exception exx)
            {
                lblResultado.Text = "Ocorreu um erro no envio: " + exx.Message;
            }

            //EncurtadorURL encurtador = new EncurtadorURL();
            //string urlReduzida = encurtador.LengthenUrl(ConfigurationManager.AppSettings["URLBOLETO"].ToString()+"?sacado="+txbNome.Text+"&endereco="+txbEndereco.Text+"&cpf="+txbCPF.Text+"&cidade="+txbCidade.Text+"&uf="+txbUF.Text+"&bairro="+txbBairro.Text+"&cep="+txbCEP.Text);// "http://localhost:1057/BoletoBB.aspx");


        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = true;
            btnLimpar.Enabled = false;
        }
    }
}