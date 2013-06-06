<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvioBoleto.aspx.cs" Inherits="SwapMobileWWW.EnvioBoleto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Gerar Boleto de Teste<br />
    <strong>Dados do Sacado</strong><br />
    Nome/Razão Social:<br />
    <asp:TextBox ID="txbNome" runat="server" Width="324px">José Silva</asp:TextBox>
    <br />
    Endereço:<br />
    <asp:TextBox ID="txbEndereco" runat="server" Width="324px">Av. Rio Branco 980 sl 1505</asp:TextBox>
    <br />
    CPF/CNPJ:<br />
    <asp:TextBox ID="txbCPF" runat="server" Width="179px">864.567.645-98</asp:TextBox>
    <br />
    Bairro:<br />
    <asp:TextBox ID="txbBairro" runat="server" Width="215px">Centro</asp:TextBox>
    <br />
    Cidade:<br />
    <asp:TextBox ID="txbCidade" runat="server" Width="324px">Rio de Janeiro</asp:TextBox>
    <br />
    UF:<br />
    <asp:TextBox ID="txbUF" runat="server" Width="40px">RJ</asp:TextBox>
    <br />
    CEP:<br />
    <asp:TextBox ID="txbCEP" runat="server" Width="123px">22.876-043</asp:TextBox>
    <br />
    Valor do boleto:<br />R$
    <asp:TextBox ID="txbValor" runat="server" Width="123px">1,00</asp:TextBox>
    <br />
    Banco:<br />
        <asp:DropDownList ID="ddlBanco" runat="server">
            <asp:ListItem Value="bb">Banco do Brasil</asp:ListItem>
            <asp:ListItem Value="brad">Bradesco</asp:ListItem>
            <asp:ListItem Value="cef">Caixa Econômica</asp:ListItem>
            <asp:ListItem Value="hsbc">HSBC</asp:ListItem>
            <asp:ListItem Value="itau">Itaú</asp:ListItem>
        </asp:DropDownList>
    <br />
    Mensagem:
    <asp:TextBox ID="txbMensagem" runat="server" Width="332px">Prezado(a) cliente, segue o link do seu boleto online:</asp:TextBox>
    <br />
    DDD:
    <asp:TextBox ID="txbDDD" runat="server" Width="41px"></asp:TextBox>
&nbsp;Celular:
    <asp:TextBox ID="txbCelular" runat="server" Width="141px"></asp:TextBox>
    <br />
    <asp:Button ID="btnEnviar" runat="server" onclick="btnEnviar_Click" 
        Text="Enviar Boleto" />
&nbsp;<asp:Button ID="btnLimpar" runat="server" Text="Habilitar Novo Envio" 
            Enabled="False" onclick="btnLimpar_Click" />
    <br />
    <asp:Label ID="lblResultado" runat="server"></asp:Label>
        <br />
        <asp:HyperLink ID="hlLink" runat="server">Link Gerado</asp:HyperLink><br />
        <asp:HyperLink ID="hlLinkReduzida" runat="server">Link Reduzido</asp:HyperLink>
        <br />
    <asp:Label ID="lblMsgEnviada" runat="server"></asp:Label>
        <br />
</p>
</asp:Content>
