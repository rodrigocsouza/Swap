using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwapMobile;

namespace SwapMobileWWW.Admin
{
    public partial class Contatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    CarregarContatos();
            }
        }

        private void CarregarContatos()
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];
            gvContatos.DataSource = HumanHelper.ListaContatos(usuario.IdUsuario);
            gvContatos.DataBind();

        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Detalhes")
            //{
            //    int idUsuario = Convert.ToInt32(e.CommandArgument);
            //    pnlDadosUsuarios.Visible = true;
            //    txbUsuario.Enabled = false;
            //    hfIdUsuario.Value = idUsuario.ToString();
            //    CarregaUsuario(idUsuario);

            //}
        }

        private void CarregaUsuario(int idUsuario)
        {
            //Usuario usuario = new Usuario();
            //usuario.LoadByPrimaryKey(idUsuario);
            //txbUsuario.Text = usuario.Usuario;
            //txbNome.Text = usuario.Nome;
            //txbSobrenome.Text = usuario.Sobrenome;
            //txbEmail.Text = usuario.Email;
            //txbSenha.Text = usuario.Senha;
            //txbConfirmacao.Text = usuario.Senha;
            //ckbAdmin.Checked = usuario.Admin;
            //lblMsg.Text = string.Empty;
        }

        protected void imgNovo_Click(object sender, ImageClickEventArgs e)
        {
            pnlDadosUsuarios.Visible = true;
            LimpaCampos();
            lblMsg.Text = "Novo cadastro em andamento...";
        }

        private void LimpaCampos()
        {
            txbNome.Text = string.Empty;
            txbSobrenome.Text = string.Empty;
            txbEmail.Text = string.Empty;
            txbPais.Text = "55";
            txbDDD.Text = string.Empty;
            txbTelefone.Text = string.Empty;
            txbEmpresa.Text = string.Empty;
            lblMsg.Text = string.Empty;
            hfIdContato.Value = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            pnlDadosUsuarios.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
             int IdContato = Convert.ToInt32(hfIdContato.Value);
            if (IdContato == 0)
            {
                        //Prosseguir com a criação do contato
                        try
                        {
                            Usuario usuario = new Usuario();
                            usuario = (Usuario)Session["Usuario"];
                            
                            pnlDadosUsuarios.Visible = false;
                            LimpaCampos();
                            //HumanHelper. CarregarUsuarios(idCliente);
                        }
                        catch (Exception exx)
                        {
                            lblMsg.Text = "Ocorreu o seguinte erro: " + exx.Message;
                        }
                    
            }
            else
            {
                //Atualização de cadastro
                try
                {
                    //int idUsuario = Convert.ToInt32(hfIdUsuario.Value);
                    //Usuario usuario = new Usuario();
                   //usuario.LoadByPrimaryKey(idUsuario);
                    //usuario.Where.Usuario.Value = .ToLower();
                    //usuario.Where.Usuario.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
                    //usuario.Query.Load();
                    //usuario.Usuario = txbUsuario.Text.ToLower();
                    //usuario.Nome = txbNome.Text;
                    //usuario.Sobrenome = txbSobrenome.Text;
                    //usuario.Email = txbEmail.Text;
                 
                    //usuario.Save();
                    //pnlDadosUsuarios.Visible = false;
                    //LimpaCampos();
                    //CarregarUsuarios(idCliente);
                }
                catch (Exception exx)
                {
                    lblMsg.Text = "Ocorreu o seguinte erro: " + exx.Message;
                }
            }
        }

        
    }
}