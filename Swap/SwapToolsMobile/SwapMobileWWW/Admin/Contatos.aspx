<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contatos.aspx.cs" Inherits="SwapMobileWWW.Admin.Contatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 99px;
        }
        .style3
        {
            width: 98px;
        }
        .style4
        {
            width: 99px;
            height: 17px;
        }
        .style5
        {
            width: 98px;
            height: 17px;
        }
        .style6
        {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h3>Cadastro de Contatos </h3>
    <asp:GridView ID="gvContatos" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="idContato" onrowcommand="gvUsuarios_RowCommand" 
        EmptyDataText="Ainda não existem contatos cadastrados">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Sobrenome" HeaderText="Sobrenome" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Pais" HeaderText="País" />
            <asp:BoundField DataField="DDD" HeaderText="DDD" />
            <asp:BoundField DataField="Celular" HeaderText="Celular" />
            <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
            <asp:BoundField DataField="DataCadastro" HeaderText="Data de Cadastro" />
            <asp:TemplateField HeaderText="Detalhes" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                        CommandArgument='<%# Eval("idUsuario") %>' CommandName="Detalhes" Height="46px" 
                        ImageUrl="~/Images/Icons/blog_compose.png" Text="" Width="46px" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Excluir" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                        CommandName="" Height="46px" ImageUrl="~/Images/Icons/blog_delete.png" Text="" 
                        Width="46px" />
                </ItemTemplate>
                <ItemStyle Height="18px" HorizontalAlign="Center" VerticalAlign="Middle" 
                    Width="18px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    

    <asp:ImageButton ID="imgNovo" runat="server" AlternateText="Adicionar Usuário" 
        CausesValidation="False" Height="58px" ImageUrl="~/Images/Icons/blog_add.png" 
        onclick="imgNovo_Click" ToolTip="Adicionar Usuário" Width="57px" />
    <asp:Panel ID="pnlDadosUsuarios" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" 
    Text="- Dados do Contato"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nome:"></asp:Label>
        &nbsp;<asp:TextBox ID="txbNome" runat="server" Width="206px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txbNome" ErrorMessage="O campo nome é obrigatório">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Sobrenome:"></asp:Label>
        &nbsp;<asp:TextBox ID="txbSobrenome" runat="server" Width="174px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txbSobrenome" ErrorMessage="O campo sobrenome é obrigatório">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
        &nbsp;<asp:TextBox ID="txbEmail" runat="server" Width="210px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txbEmail" ErrorMessage="O campo email é obrigatório">*</asp:RequiredFieldValidator>
        <br />
        <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label8" runat="server" Text="Código do País"></asp:Label>
                </td>
                <td class="style5">
                    <asp:Label ID="Label9" runat="server" Text="DDD:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label10" runat="server" Text="Telefone:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:TextBox ID="txbPais" runat="server" MaxLength="4" Width="38px">55</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txbPais" ErrorMessage="O campo email é obrigatório">*</asp:RequiredFieldValidator>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txbDDD" runat="server" MaxLength="2" Width="79px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txbDDD" ErrorMessage="O campo DDD é obrigatório">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txbTelefone" runat="server" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txbTelefone" ErrorMessage="O campo telefone é obrigatório">*</asp:RequiredFieldValidator>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="Label11" runat="server" Text="Empresa:"></asp:Label>
        <asp:TextBox ID="txbEmpresa" runat="server" Width="272px"></asp:TextBox>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="btnSalvar" runat="server" 
            onclick="btnSalvar_Click" Text="Salvar" />
        &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
            onclick="btnCancelar_Click" Text="Cancelar" />
    </asp:Panel>
    <br />
    <asp:HiddenField ID="hfIdContato" runat="server" />
    <br />
</asp:Content>
