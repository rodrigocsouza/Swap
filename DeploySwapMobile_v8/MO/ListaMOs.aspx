<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMOs.aspx.cs" Inherits="SwapMobileWWW.MO.ListaMOs" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Lista dos MO´s Recebidos<dx:ASPxGridView ID="ASPxGridView1" runat="server" 
        AutoGenerateColumns="False" 
        CssFilePath="~/App_Themes/Office2010Black/{0}/styles.css" 
        CssPostfix="Office2010Black">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0">
                <ClearFilterButton Text="Limpar" Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="ZenviaId" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Origem" FieldName="ZenviaFrom" 
                VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Destino" FieldName="ZenviaTo" 
                VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Mensagem" FieldName="ZenviaMsg" 
                VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Data Envio" FieldName="ZenviaDate" 
                VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Conta" FieldName="ZenviaAccount" 
                VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Horário Recebimento" 
                FieldName="dataHoraRecebimento" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsPager RenderMode="Lightweight" SEOFriendly="Enabled">
        </SettingsPager>
        <Settings ShowFilterRow="True" />
        <SettingsText EmptyDataRow="Sem dados" FilterBarClear="Limpar" />
        <SettingsLoadingPanel Text="Pesquisando&amp;hellip;" />
        <Images SpriteCssFilePath="~/App_Themes/Office2010Black/{0}/sprite.css">
            <LoadingPanelOnStatusBar Url="~/App_Themes/Office2010Black/GridView/Loading.gif">
            </LoadingPanelOnStatusBar>
            <LoadingPanel Url="~/App_Themes/Office2010Black/GridView/Loading.gif">
            </LoadingPanel>
        </Images>
        <ImagesFilterControl>
            <LoadingPanel Url="~/App_Themes/Office2010Black/GridView/Loading.gif">
            </LoadingPanel>
        </ImagesFilterControl>
        <Styles CssFilePath="~/App_Themes/Office2010Black/{0}/styles.css" 
            CssPostfix="Office2010Black">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="5px">
            </LoadingPanel>
        </Styles>
        <StylesPager>
            <CurrentPageNumber ForeColor="Black">
            </CurrentPageNumber>
            <PageNumber ForeColor="White">
            </PageNumber>
            <Summary ForeColor="White">
            </Summary>
            <Ellipsis ForeColor="White">
            </Ellipsis>
        </StylesPager>
        <StylesEditors ButtonEditCellSpacing="0">
            <ProgressBar Height="21px">
            </ProgressBar>
        </StylesEditors>
    </dx:ASPxGridView>
    <br />
</asp:Content>
