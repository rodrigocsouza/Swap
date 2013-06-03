using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dotnetraptors.Brazil.Boleto;

namespace SwapMobileWWW
{
    public partial class BoletoBB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gerarBoletoBB();
        }

        private void gerarBoletoBB()
        {
            BoletoBrasil bolBB = new BoletoBrasil();

            bolBB.Aceite = false;// System.Web.Profile.DadosCedente("Aceite")
            bolBB.CedenteAgencia = "001";// Profile.DadosCedente("AgenciaCedente")
            bolBB.CedenteConta = "0012345-0";// Profile.DadosCedente("ContaCedente")
            bolBB.CedenteContaDV = "99";// Profile.DadosCedente("DVContaCedente")
            bolBB.CedenteNome = "Swap Informática";// Profile.DadosCedente("NomeCedente")
            bolBB.Carteira = 32; //Int32.Parse(Profile.DadosCedente("Carteira"))
            bolBB.Instrucao1 = "Pagar ainda hoje de preferência";// Profile.DadosCedente("instrucao")

            bolBB.Sequencial = 1;//Convert.ToInt32(Profile.DadosDocumento("Sequencial"))
            bolBB.Documento = "112345";//Profile.DadosDocumento("NumeroDocumento")
            bolBB.DtDocumento = Convert.ToDateTime(DateTime.Now);//  .DadosDocumento("DataDocumento"))
            bolBB.DtEmissao = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataEmissao"))
            bolBB.DtProcessamento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataProcessamento"))
            bolBB.DtVencimento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataVencimento"))
            bolBB.Valor = 100.98f;// CSng( Convert.ToDouble(Profile.DadosDocumento("Valor")))

            bolBB.SacadoNome = Request.QueryString["sacado"].ToString();// Luciano Gay";// Profile.DadosCliente("NomeSacado")
            bolBB.SacadoEndereco = Request.QueryString["endereco"].ToString();// "Rua das dores";// Profile.DadosCliente("EnderecoSacado")
            bolBB.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();// "05.599.090/0001-99";// Profile.DadosCliente("CPF_CNPJSacado")
            bolBB.SacadoCidade = Request.QueryString["cidade"].ToString();// "Juiz de Fora";// Profile.DadosCliente("Cidade")
            bolBB.SacadoUF = Request.QueryString["uf"].ToString(); //"MG";// Profile.DadosCliente("Estado")
            bolBB.SacadoBairro = Request.QueryString["bairro"].ToString();// "Centro";//Profile.DadosCliente("Bairro")
            bolBB.SacadoCEP = Request.QueryString["cep"].ToString(); //"98989-000";// Profile.DadosCliente("Cep")
            HTMLBoleto geraBoleto = new HTMLBoleto();// gerarBoletoBB();
            //Dim geraBoleto As New HTMLBoleto()
            geraBoleto.ImagesFolder = "imagesBoleto";
            geraBoleto.AddBoleto(bolBB);
            geraBoleto.SaveToFile((Server.MapPath("/")+"\\boletoBB"));
            Response.Write(geraBoleto.ToString());
        }
    }
}