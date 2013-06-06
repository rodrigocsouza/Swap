using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwapMobile;
using System.IO;
using HumanAPIClient.Service;
using HumanAPIClient.Model;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;

namespace SwapMobileWWW
{
    public partial class SMS_Individual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txbMensagem.Attributes.Add("onkeypress", "return tbLimit();");
            txbMensagem.Attributes.Add("onkeyup", "return tbCount(" + lblContador.ClientID + ");");
            txbMensagem.Attributes.Add("maxLength", "150");

            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    Cliente cliente = (Cliente)Session["Empresa"];
                    lblUsuario.Text = string.Format("{0} {1}", usuario.Nome, usuario.Sobrenome);
                    lblEmpresa.Text = string.Format("{0} - {1}", cliente.RazaoSocial, cliente.CNPJ);
                }
            }
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

                message.To = string.Format("55{0}{1}", txbDDD.Text, txbTelefone.Text);
                message.Message = HumanHelper.RemoverAcentos(txbMensagem.Text);
                contador++;
                message.Id = contador.ToString("0000");
                List<String> response = sms.send(message);

                lblMsg.Text = "SMS enviado com sucesso!";
                btnEnviar.Enabled = false;
            }
            catch (Exception exx)
            {
                lblMsg.Text = "Ocorreu um erro no envio: " + exx.Message;
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            lblMsg.Text = string.Empty;
            btnEnviar.Enabled = true;
        }

        private void LimparCampos()
        {
            txbDDD.Text = "";
            txbTelefone.Text = "";
            txbMensagem.Text = string.Empty;
            lblContador.Text = "150";
        }
    }
}