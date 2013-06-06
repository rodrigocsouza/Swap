using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HumanAPIClient.Enum;
using HumanAPIClient.Model;
using HumanAPIClient.Service;
using System.IO;
using SwapMobile;

namespace SwapMobileWWW
{
    public partial class SMS_Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    hfIdCliente.Value = cliente.IdCliente.ToString();
                    CarregaModelos(cliente.IdCliente);
                }
            }
        }

        private void CarregaModelos(int p)
        {
            ClienteModelo CliMod = new ClienteModelo();
            CliMod.Where.IdCliente.Value = p;
            CliMod.Where.IdCliente.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            CliMod.Query.Load();
            string listModelos = string.Empty;
            Modelo modelo = new Modelo();
            if (CliMod.RowCount > 0)
            {
                listModelos = CliMod.IdModelo.ToString() + ",";
                while (CliMod.MoveNext())
                {
                    listModelos += CliMod.IdModelo.ToString() + ",";
                }
                listModelos = listModelos.Remove(listModelos.LastIndexOf(","));
                modelo.Where.IdModelo.Value = listModelos;
                modelo.Where.IdModelo.Operator = MyGeneration.dOOdads.WhereParameter.Operand.In;
                modelo.Query.Load();
            }

            ddlModelos.DataSource = modelo.DefaultView;
            ddlModelos.DataBind();
        }

        protected void btnEnviarArquivo_Click(object sender, EventArgs e)
        {
            string strFileNameOnServer = "upload_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            string strBaseLocation = Server.MapPath("/Upload")+"\\";// "c:\\inetpub\\wwwroot\\SwapTools\\Upload\\";

            if (null != fupArquivoEnvio.PostedFile)
            {
                try
                {
                    fupArquivoEnvio.PostedFile.SaveAs(strBaseLocation + strFileNameOnServer);
                    lblResultado.Text = "Arquivo <b>" +
                      strBaseLocation + strFileNameOnServer + "</b> carregado com sucesso!";
                    Session["ListaSMS"] = null;
                    LerArquivo(strBaseLocation + strFileNameOnServer);
                }
                catch (Exception exx)
                {
                    lblResultado.Text = "Erro ao salvar o arquivo <b>" +
                      strBaseLocation + strFileNameOnServer + "</b><br>" + exx.ToString();
                }
            }
        }

        private void LerArquivo(string p)
        {
            int counter = 0;
            string line;
            int idModelo = Convert.ToInt32(ddlModelos.SelectedValue);
            int idClienteModelo = Convert.ToInt32(hfIdClienteModelo.Value);
            int idCliente = Convert.ToInt32(hfIdCliente.Value);
            string Corpo = obtemCorpoModelo(idModelo);
            
            List<SMS> lista = new List<SMS>();
            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(p);
            while ((line = file.ReadLine()) != null)
            {
                string[] colunas = line.Split(';');
                if (colunas.Count() > 1)
                {
                    SMS sms = new SMS();// { Msisdn = colunas[0], Nome = colunas[1], Sobrenome = colunas[2], Mensagem = colunas[3] };
                    sms.Msisdn = colunas[0];
                    sms.Mensagem = Corpo;
                    for (int i = 1; i <= colunas.Length-1; i++)
                    {
                        sms.Mensagem = sms.Mensagem.Replace((string.Format("[{0}]",i.ToString())),colunas[i]);
                    }
                    //System.Console.WriteLine(line);
                    lista.Add(sms);
                    counter++;
                }
            }
            file.Close();
            GridView1.DataSource = lista;
            GridView1.DataBind();
            Session["ListaSMS"] = lista;
        }

        private string obtemCorpoModelo(int idModelo)
        {
            Modelo mod = new Modelo();
            mod.LoadByPrimaryKey(idModelo);
            return mod.CorpoModelo;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            String account = "swap";

            String code = "zJmLTF7JvU";

            int contador = 0;
            try
            {
                if (Session["ListaSMS"] != null)
                {
                    List<SMS> listaSms = (List<SMS>)Session["ListaSMS"];
                    contador = HumanHelper.ObterUltimoID();
                    foreach (var item in listaSms)
                    {
                        SimpleSending sms = new SimpleSending(account, code);

                        SimpleMessage message = new SimpleMessage();

                        message.To = item.Msisdn;
                        message.Message = item.Mensagem;
                        contador++;
                        message.Id = contador.ToString("0000");
                        List<String> response = sms.send(message);
                    }
                    lblResultado.Text = "Lote de SMS enviado com sucesso!";
                }
            }
            catch (Exception exx)
            {
                lblResultado.Text = "Ocorreu um erro no envio: " + exx.Message;
            }

        }

        protected void ddlModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModelos.SelectedValue!="Selecione...")
            {
                int idModelo = Convert.ToInt32(ddlModelos.SelectedValue);
                int idCliente = Convert.ToInt32(hfIdCliente.Value);
                Modelo mod = new Modelo();
                mod.LoadByPrimaryKey(idModelo);
                lblCorpo.Text = mod.CorpoModelo;

                ClienteModelo cm = new ClienteModelo();
                cm.Where.IdCliente.Value = idCliente;
                cm.Where.IdCliente.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
                cm.Where.IdModelo.Value = idModelo;
                cm.Where.IdModelo.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
                cm.Query.Load();
                hfIdClienteModelo.Value = cm.IdClienteModelo.ToString();
            }
        }
    }
}