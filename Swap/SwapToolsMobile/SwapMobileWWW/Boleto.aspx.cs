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
            string banco = string.Empty;
            banco = Request.QueryString["banco"].ToString();
            Bancos banco_ = new Bancos();
            if (banco == "bb")
            {
                banco_ = Bancos.Brasil;
            }
            if (banco == "cef")
            {
                banco_ = Bancos.CEF;
            } if (banco == "brad")
            {
                banco_ = Bancos.Bradesco;
            } if (banco == "itau")
            {
                banco_ = Bancos.Itau;
            } if (banco == "hsbc")
            {
                banco_ = Bancos.HSBC;
            }
            switch (banco_)
            {
                case Bancos.Bradesco:
                    gerarBoletoBradesco();
                    break;
                case Bancos.Itau:
                    gerarBoletoItau();
                    break;
                case Bancos.Brasil:
                    gerarBoletoBB();
                    break;
                case Bancos.HSBC:
                    gerarBoletoHSBC();
                    break;
                case Bancos.CEF:
                    gerarBoletoCEF();
                    break;
                default:
                    break;
            }
            
        }

        private void gerarBoletoBradesco()
        {
            BoletoBradesco bolBRD = new BoletoBradesco();
            bolBRD.Aceite = false;
            bolBRD.CedenteAgencia = "001";
            bolBRD.CedenteConta = "0012345-0";
            bolBRD.CedenteContaDV = "99";
            bolBRD.CedenteNome = "Swap Informática";
            bolBRD.Carteira = 32; 
            bolBRD.Instrucao1 = "Pagar ainda hoje de preferência";

            bolBRD.Sequencial = 1;
            bolBRD.Documento = "112345";
            bolBRD.DtDocumento = Convert.ToDateTime(DateTime.Now);
            bolBRD.DtEmissao = Convert.ToDateTime(DateTime.Now);
            bolBRD.DtProcessamento = Convert.ToDateTime(DateTime.Now);
            bolBRD.DtVencimento = Convert.ToDateTime(DateTime.Now);
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); 
            bolBRD.Valor = fValor;
            bolBRD.SacadoNome = Request.QueryString["sacado"].ToString();
            bolBRD.SacadoEndereco = Request.QueryString["endereco"].ToString();
            bolBRD.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();
            bolBRD.SacadoCidade = Request.QueryString["cidade"].ToString();
            bolBRD.SacadoUF = Request.QueryString["uf"].ToString(); 
            bolBRD.SacadoBairro = Request.QueryString["bairro"].ToString();
            bolBRD.SacadoCEP = Request.QueryString["cep"].ToString(); 
            ImprimeBoleto(bolBRD);
        }

        private void gerarBoletoCEF()
        {
            BoletoCEF bol = new BoletoCEF();
            bol.Aceite = false;
            bol.CedenteAgencia = "001";
            bol.CedenteConta = "0012345-0";
            bol.CedenteContaDV = "99";
            bol.CedenteNome = "Swap Informática";
            bol.Carteira = 32; 
            bol.Instrucao1 = "Pagar ainda hoje de preferência";

            bol.Sequencial = 1;
            bol.Documento = "112345";
            bol.DtDocumento = Convert.ToDateTime(DateTime.Now);
            bol.DtEmissao = Convert.ToDateTime(DateTime.Now);
            bol.DtProcessamento = Convert.ToDateTime(DateTime.Now);
            bol.DtVencimento = Convert.ToDateTime(DateTime.Now);
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); 
            bol.Valor = fValor;
            bol.SacadoNome = Request.QueryString["sacado"].ToString();
            bol.SacadoEndereco = Request.QueryString["endereco"].ToString();
            bol.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();
            bol.SacadoCidade = Request.QueryString["cidade"].ToString();
            bol.SacadoUF = Request.QueryString["uf"].ToString(); 
            bol.SacadoBairro = Request.QueryString["bairro"].ToString();
            bol.SacadoCEP = Request.QueryString["cep"].ToString(); 
            ImprimeBoleto(bol);
        }

        private void gerarBoletoHSBC()
        {
            BoletoHSBC bol = new BoletoHSBC();
            bol.Aceite = false;
            bol.CedenteAgencia = "001";
            bol.CedenteConta = "00123450";
            bol.CedenteContaDV = "99";
            bol.CedenteNome = "Swap Informática";
            bol.Carteira = 32; 
            bol.Instrucao1 = "Pagar ainda hoje de preferência";

            bol.Sequencial = 1;
            bol.Documento = "112345";
            bol.DtDocumento = Convert.ToDateTime(DateTime.Now);
            bol.DtEmissao = Convert.ToDateTime(DateTime.Now);
            bol.DtProcessamento = Convert.ToDateTime(DateTime.Now);
            bol.DtVencimento = Convert.ToDateTime(DateTime.Now);
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); 
            bol.Valor = fValor;
            bol.SacadoNome = Request.QueryString["sacado"].ToString();
            bol.SacadoEndereco = Request.QueryString["endereco"].ToString();
            bol.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();
            bol.SacadoCidade = Request.QueryString["cidade"].ToString();
            bol.SacadoUF = Request.QueryString["uf"].ToString(); 
            bol.SacadoBairro = Request.QueryString["bairro"].ToString();
            bol.SacadoCEP = Request.QueryString["cep"].ToString(); 
            ImprimeBoleto(bol);
        }

        private void gerarBoletoItau()
        {
            BoletoItau bol = new BoletoItau();
            bol.Aceite = false;
            bol.CedenteAgencia = "0123401";
            bol.CedenteConta = "0012345011";
            bol.CedenteContaDV = "99";
            bol.CedenteNome = "Swap Informática";
            bol.Carteira = 32; 
            bol.Instrucao1 = "Pagar ainda hoje de preferência";
            bol.SequNossNume = "0000000";
            bol.Sequencial = 1;
            bol.Documento = "112345";
            bol.DtDocumento = Convert.ToDateTime(DateTime.Now);
            bol.DtEmissao = Convert.ToDateTime(DateTime.Now);
            bol.DtProcessamento = Convert.ToDateTime(DateTime.Now);
            bol.DtVencimento = Convert.ToDateTime(DateTime.Now);
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); 
            bol.Valor = fValor;
            bol.SacadoNome = Request.QueryString["sacado"].ToString();
            bol.SacadoEndereco = Request.QueryString["endereco"].ToString();
            bol.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();
            bol.SacadoCidade = Request.QueryString["cidade"].ToString();
            bol.SacadoUF = Request.QueryString["uf"].ToString(); 
            bol.SacadoBairro = Request.QueryString["bairro"].ToString();
            bol.SacadoCEP = Request.QueryString["cep"].ToString(); 
            ImprimeBoleto(bol);
        }

        private void gerarBoletoBB()
        {
            BoletoBrasil bolBB = new BoletoBrasil();

            bolBB.Aceite = false;
            bolBB.CedenteAgencia = "001";
            bolBB.CedenteConta = "0012345-0";
            bolBB.CedenteContaDV = "99";
            bolBB.CedenteNome = "Swap Informática";
            bolBB.Carteira = 32; 
            bolBB.Instrucao1 = "Pagar ainda hoje de preferência";

            bolBB.Sequencial = 1;
            bolBB.Documento = "112345";
            bolBB.DtDocumento = Convert.ToDateTime(DateTime.Now);
            bolBB.DtEmissao = Convert.ToDateTime(DateTime.Now);
            bolBB.DtProcessamento = Convert.ToDateTime(DateTime.Now);
            bolBB.DtVencimento = Convert.ToDateTime(DateTime.Now);
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); 
            bolBB.Valor = fValor;
            
            

            bolBB.SacadoNome = Request.QueryString["sacado"].ToString();
            bolBB.SacadoEndereco = Request.QueryString["endereco"].ToString();
            bolBB.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();
            bolBB.SacadoCidade = Request.QueryString["cidade"].ToString();
            bolBB.SacadoUF = Request.QueryString["uf"].ToString(); 
            bolBB.SacadoBairro = Request.QueryString["bairro"].ToString();
            bolBB.SacadoCEP = Request.QueryString["cep"].ToString(); 
            ImprimeBoleto(bolBB);
        }

        private void ImprimeBoleto(Boleto boleto)
        {
            HTMLBoleto geraBoleto = new HTMLBoleto();
            geraBoleto.ImagesFolder = "imagesBoleto";
            geraBoleto.AddBoleto(boleto);
            geraBoleto.SaveToFile((Server.MapPath("/") + "\\boletoXX"));
            Response.Write(geraBoleto.ToString());
        }
    }
}