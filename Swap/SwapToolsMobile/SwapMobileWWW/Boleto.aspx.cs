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
            bolBRD.Aceite = false;// System.Web.Profile.DadosCedente("Aceite")
            bolBRD.CedenteAgencia = "001";// Profile.DadosCedente("AgenciaCedente")
            bolBRD.CedenteConta = "0012345-0";// Profile.DadosCedente("ContaCedente")
            bolBRD.CedenteContaDV = "99";// Profile.DadosCedente("DVContaCedente")
            bolBRD.CedenteNome = "Swap Informática";// Profile.DadosCedente("NomeCedente")
            bolBRD.Carteira = 32; //Int32.Parse(Profile.DadosCedente("Carteira"))
            bolBRD.Instrucao1 = "Pagar ainda hoje de preferência";// Profile.DadosCedente("instrucao")

            bolBRD.Sequencial = 1;//Convert.ToInt32(Profile.DadosDocumento("Sequencial"))
            bolBRD.Documento = "112345";//Profile.DadosDocumento("NumeroDocumento")
            bolBRD.DtDocumento = Convert.ToDateTime(DateTime.Now);//  .DadosDocumento("DataDocumento"))
            bolBRD.DtEmissao = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataEmissao"))
            bolBRD.DtProcessamento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataProcessamento"))
            bolBRD.DtVencimento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataVencimento"))
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); // 100.98f;// CSng( Convert.ToDouble(Profile.DadosDocumento("Valor")))
            bolBRD.Valor = fValor;
            bolBRD.SacadoNome = Request.QueryString["sacado"].ToString();// Luciano Gay";// Profile.DadosCliente("NomeSacado")
            bolBRD.SacadoEndereco = Request.QueryString["endereco"].ToString();// "Rua das dores";// Profile.DadosCliente("EnderecoSacado")
            bolBRD.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();// "05.599.090/0001-99";// Profile.DadosCliente("CPF_CNPJSacado")
            bolBRD.SacadoCidade = Request.QueryString["cidade"].ToString();// "Juiz de Fora";// Profile.DadosCliente("Cidade")
            bolBRD.SacadoUF = Request.QueryString["uf"].ToString(); //"MG";// Profile.DadosCliente("Estado")
            bolBRD.SacadoBairro = Request.QueryString["bairro"].ToString();// "Centro";//Profile.DadosCliente("Bairro")
            bolBRD.SacadoCEP = Request.QueryString["cep"].ToString(); //"98989-000";// Profile.DadosCliente("Cep")
            ImprimeBoleto(bolBRD);
        }

        private void gerarBoletoCEF()
        {
            BoletoCEF bol = new BoletoCEF();
            bol.Aceite = false;// System.Web.Profile.DadosCedente("Aceite")
            bol.CedenteAgencia = "001";// Profile.DadosCedente("AgenciaCedente")
            bol.CedenteConta = "0012345-0";// Profile.DadosCedente("ContaCedente")
            bol.CedenteContaDV = "99";// Profile.DadosCedente("DVContaCedente")
            bol.CedenteNome = "Swap Informática";// Profile.DadosCedente("NomeCedente")
            bol.Carteira = 32; //Int32.Parse(Profile.DadosCedente("Carteira"))
            bol.Instrucao1 = "Pagar ainda hoje de preferência";// Profile.DadosCedente("instrucao")

            bol.Sequencial = 1;//Convert.ToInt32(Profile.DadosDocumento("Sequencial"))
            bol.Documento = "112345";//Profile.DadosDocumento("NumeroDocumento")
            bol.DtDocumento = Convert.ToDateTime(DateTime.Now);//  .DadosDocumento("DataDocumento"))
            bol.DtEmissao = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataEmissao"))
            bol.DtProcessamento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataProcessamento"))
            bol.DtVencimento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataVencimento"))
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); // 100.98f;// CSng( Convert.ToDouble(Profile.DadosDocumento("Valor")))
            bol.Valor = fValor;
            bol.SacadoNome = Request.QueryString["sacado"].ToString();// Luciano Gay";// Profile.DadosCliente("NomeSacado")
            bol.SacadoEndereco = Request.QueryString["endereco"].ToString();// "Rua das dores";// Profile.DadosCliente("EnderecoSacado")
            bol.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();// "05.599.090/0001-99";// Profile.DadosCliente("CPF_CNPJSacado")
            bol.SacadoCidade = Request.QueryString["cidade"].ToString();// "Juiz de Fora";// Profile.DadosCliente("Cidade")
            bol.SacadoUF = Request.QueryString["uf"].ToString(); //"MG";// Profile.DadosCliente("Estado")
            bol.SacadoBairro = Request.QueryString["bairro"].ToString();// "Centro";//Profile.DadosCliente("Bairro")
            bol.SacadoCEP = Request.QueryString["cep"].ToString(); //"98989-000";// Profile.DadosCliente("Cep")
            ImprimeBoleto(bol);
        }

        private void gerarBoletoHSBC()
        {
            BoletoHSBC bol = new BoletoHSBC();
            bol.Aceite = false;// System.Web.Profile.DadosCedente("Aceite")
            bol.CedenteAgencia = "001";// Profile.DadosCedente("AgenciaCedente")
            bol.CedenteConta = "00123450";// Profile.DadosCedente("ContaCedente")
            bol.CedenteContaDV = "99";// Profile.DadosCedente("DVContaCedente")
            bol.CedenteNome = "Swap Informática";// Profile.DadosCedente("NomeCedente")
            bol.Carteira = 32; //Int32.Parse(Profile.DadosCedente("Carteira"))
            bol.Instrucao1 = "Pagar ainda hoje de preferência";// Profile.DadosCedente("instrucao"

            bol.Sequencial = 1;//Convert.ToInt32(Profile.DadosDocumento("Sequencial"))
            bol.Documento = "112345";//Profile.DadosDocumento("NumeroDocumento")
            bol.DtDocumento = Convert.ToDateTime(DateTime.Now);//  .DadosDocumento("DataDocumento"))
            bol.DtEmissao = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataEmissao"))
            bol.DtProcessamento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataProcessamento"))
            bol.DtVencimento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataVencimento"))
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); // 100.98f;// CSng( Convert.ToDouble(Profile.DadosDocumento("Valor")))
            bol.Valor = fValor;
            bol.SacadoNome = Request.QueryString["sacado"].ToString();// Luciano Gay";// Profile.DadosCliente("NomeSacado")
            bol.SacadoEndereco = Request.QueryString["endereco"].ToString();// "Rua das dores";// Profile.DadosCliente("EnderecoSacado")
            bol.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();// "05.599.090/0001-99";// Profile.DadosCliente("CPF_CNPJSacado")
            bol.SacadoCidade = Request.QueryString["cidade"].ToString();// "Juiz de Fora";// Profile.DadosCliente("Cidade")
            bol.SacadoUF = Request.QueryString["uf"].ToString(); //"MG";// Profile.DadosCliente("Estado")
            bol.SacadoBairro = Request.QueryString["bairro"].ToString();// "Centro";//Profile.DadosCliente("Bairro")
            bol.SacadoCEP = Request.QueryString["cep"].ToString(); //"98989-000";// Profile.DadosCliente("Cep")
            ImprimeBoleto(bol);
        }

        private void gerarBoletoItau()
        {
            BoletoItau bol = new BoletoItau();
            bol.Aceite = false;// System.Web.Profile.DadosCedente("Aceite")
            bol.CedenteAgencia = "0123401";// Profile.DadosCedente("AgenciaCedente")
            bol.CedenteConta = "0012345011";// Profile.DadosCedente("ContaCedente")
            bol.CedenteContaDV = "99";// Profile.DadosCedente("DVContaCedente")
            bol.CedenteNome = "Swap Informática";// Profile.DadosCedente("NomeCedente")
            bol.Carteira = 32; //Int32.Parse(Profile.DadosCedente("Carteira"))
            bol.Instrucao1 = "Pagar ainda hoje de preferência";// Profile.DadosCedente("instrucao")
            bol.SequNossNume = "0000000";
            bol.Sequencial = 1;//Convert.ToInt32(Profile.DadosDocumento("Sequencial"))
            bol.Documento = "112345";//Profile.DadosDocumento("NumeroDocumento")
            bol.DtDocumento = Convert.ToDateTime(DateTime.Now);//  .DadosDocumento("DataDocumento"))
            bol.DtEmissao = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataEmissao"))
            bol.DtProcessamento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataProcessamento"))
            bol.DtVencimento = Convert.ToDateTime(DateTime.Now);// Profile.DadosDocumento("DataVencimento"))
            float fValor = 0f;
            float.TryParse(Request.QueryString["valor"].ToString(), out fValor); // 100.98f;// CSng( Convert.ToDouble(Profile.DadosDocumento("Valor")))
            bol.Valor = fValor;
            bol.SacadoNome = Request.QueryString["sacado"].ToString();// Luciano Gay";// Profile.DadosCliente("NomeSacado")
            bol.SacadoEndereco = Request.QueryString["endereco"].ToString();// "Rua das dores";// Profile.DadosCliente("EnderecoSacado")
            bol.SacadoCPF_CNPJ = Request.QueryString["cpf"].ToString();// "05.599.090/0001-99";// Profile.DadosCliente("CPF_CNPJSacado")
            bol.SacadoCidade = Request.QueryString["cidade"].ToString();// "Juiz de Fora";// Profile.DadosCliente("Cidade")
            bol.SacadoUF = Request.QueryString["uf"].ToString(); //"MG";// Profile.DadosCliente("Estado")
            bol.SacadoBairro = Request.QueryString["bairro"].ToString();// "Centro";//Profile.DadosCliente("Bairro")
            bol.SacadoCEP = Request.QueryString["cep"].ToString(); //"98989-000";// Profile.DadosCliente("Cep")
            ImprimeBoleto(bol);
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
            ImprimeBoleto(bolBB);
        }

        private void ImprimeBoleto(Boleto boleto)
        {
            HTMLBoleto geraBoleto = new HTMLBoleto();// gerarBoletoBB();
            //Dim geraBoleto As New HTMLBoleto()
            geraBoleto.ImagesFolder = "imagesBoleto";
            geraBoleto.AddBoleto(boleto);
            geraBoleto.SaveToFile((Server.MapPath("/") + "\\boletoXX"));
            Response.Write(geraBoleto.ToString());
        }
    }
}