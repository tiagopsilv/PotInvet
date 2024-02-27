<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroLucroAgenteEdicao.aspx.cs"
    Inherits="Invest.cadastroLucroAgenteEdicao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="superior">
        <asp:LinkButton ID="linkButton" runat="server" Text="Bem vindo, Fulano!" 
            CssClass="link" onclick="linkButton_Click"></asp:LinkButton>
    </div>
        <div class="sair" style="text-align: right">
            <asp:LinkButton ID="btnSair" runat="server" Text="Sair" 
        onclick="btnSair_Click" Font-Size="Small" ForeColor="Black" CssClass="link"></asp:LinkButton>
        </div>
    <div class="header">
        <br />
        <table>
            <td style="width: 100px;">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/home.aspx" BorderWidth="0" style="border:0px;padding:1px;">
                <asp:Image ID="image2" ImageUrl="~/Imagens/logo.jpg" runat="server" BorderWidth="0" style="text-decoration:none;border:0px;padding:1px;" />
                </asp:HyperLink>
            </td>
            <td style="width: 250px;">
            </td>
            <td style="width: 200px;">
                <asp:LinkButton ID="linkButton1" runat="server" Text="Home" 
                    CssClass="linkMenu" onclick="linkButton1_Click"></asp:LinkButton>
            </td>
            <td style="width: 200px;">
                <asp:LinkButton ID="linkButton2" runat="server" Text="Projetos" 
                    CssClass="linkMenu" onclick="linkButton2_Click"></asp:LinkButton>
            </td>
            <td style="width: 200px;">
                &nbsp;</td>
        </table>
    </div>
    <br />
    <br />
    <div style="height: 100px; background-color: #ebe7e8;">
    </div>
    <div style="padding-left: 50px; background-color: #ebe7e8;" class="conteudo">
        <table cellpadding="3" cellspacing="3">
            <tr>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;" colspan="3" align="center">
                    <h2>Lista de Lucros</h2>
                </td>
            </tr>
            <tr>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                     <h2>Descrição do Lucro</h2>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                    <h2> Valor Estimado</h2>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                    <h2> Justificativa para o Valor</h2>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                   <h2>  Data</h2>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                </td>
            </tr>
            <asp:Repeater ID="listaLucros" runat="server">
            <ItemTemplate>
            <tr>
            <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                   <%#DataBinder.Eval(Container.DataItem, "Descricao")%>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                   R$<%#DataBinder.Eval(Container.DataItem, "ValorEstimado")%></td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                  <%#DataBinder.Eval(Container.DataItem, "Justificativa")%>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                  <%#DataBinder.Eval(Container.DataItem, "Data", "{0:dd/MM/yyyy}")%>
                </td>
                 <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                  <asp:HyperLink ID="HyperLink4" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URLAtualizar")%> runat="server">Alterar</asp:HyperLink>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;"align="center">
                  <asp:HyperLink ID="HyperLink1" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URLExcluir")%> runat="server">Excluir</asp:HyperLink>
                </td>
            </tr>
            <tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
<div style="height: 115px; background-color: #ebe7e8; text-align: right;">
    <div style="width: 974px">
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Imagens/botaoAdicionar.jpg" onclick="ImageButton1_Click" />
            </div>
            <div style="width: 963px; height: 30px;">
            </div> 
      <div style="width: 974px">
        <asp:ImageButton ID="BtnSalvar" runat="server" 
            ImageUrl="~/Imagens/botaoSalvar.jpg" onclick="BtnSalvar_Click" />
            &nbsp;<asp:ImageButton ID="btnVoltar" runat="server" 
                ImageUrl="~/Imagens/botaoVoltar.jpg" onclick="btnVoltar_Click" />
            </div>
    &nbsp;</div>
    </div>
    <div style="padding-left: 150px;">
        <br />
        <table>
            <td width="100px;">
            </td>
            <td style="padding-right: 100px;">
                <asp:Image ID="image9" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200"
                    Width="1" />
            </td>
            <td width="400px;">
                <h2>
                    Últimos projetos visitados
                </h2>
                <asp:Repeater ID="ListaProjetosVisitados" runat="server">
                <ItemTemplate>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> >
                <p style="color: #f56808; font-size: 14px;">
                    <b><%#DataBinder.Eval(Container.DataItem, "NomeProjeto")%></b>
                    </p>
                </asp:HyperLink>
                </ItemTemplate> 
                </asp:Repeater>
                <br />
            </td>

             <td width="100px;">
            </td>
            <td style="padding-right: 100px;">
                <asp:Image ID="image1" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200"
                    Width="1" />
            </td>
            <td width="200px;">
                <h2>
                    Patrocínios
                </h2>
                <p>
                    &nbsp;</p>
                <br />
            </td>
        </table>
    </div>
    <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 2012</p>
    </div>
    </form>
</body>
</html>
