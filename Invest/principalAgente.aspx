<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principalAgente.aspx.cs"
    Inherits="Invest.principalAgente" %>

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
        onclick="LinkButton4_Click" Font-Size="Small" ForeColor="Black" CssClass="link"></asp:LinkButton>
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
                <asp:LinkButton ID="linkButton3" runat="server" Text="Contato" 
                    CssClass="linkMenu" onclick="linkButton3_Click"></asp:LinkButton>
            </td>
        </table>
    </div>
    <br />
    <br />
    <div style="padding-left: 150px; background-color: #ebe7e8; padding-top: 20px;" class="conteudo">
    <div style="text-align: right; width: 929px">
        <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click1">Responder Pesquisa</asp:LinkButton>
    </div>
        <h3 style="color: #0f1745;">
            Investimentos
        </h3>
<asp:Repeater ID="ListaProjeto" runat="server">
         <ItemTemplate>
        <table>

            <tr>
                <td style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px; padding-top: 20px;">
                    <asp:Image ID="imageLogoUm" runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem, "ImgApres")%>
                        Width="150" Height="111" />
                    <p style="color: #0f1745; font-size: 13px; text-align: center;">
                        <b><%#DataBinder.Eval(Container.DataItem, "Data", "{0:dd/MM/yyyy}")%></b></p>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                    <br />
                    <b><%#DataBinder.Eval(Container.DataItem, "NomeProjeto")%></b>
                    <br />
                    <%#DataBinder.Eval(Container.DataItem, "TextoResumo")%>
                    <br /><br />
                    <b>Valor Arrecadado:</b> R$<%#DataBinder.Eval(Container.DataItem, "Valor_Arrecadado")%>
                    <br />
                    <b>Porcentagem já arrecadada: [ <%#DataBinder.Eval(Container.DataItem, "Porcentagem")%> % ]</b><br /><br />
                    <table style="width: 220px; height: 19px;" border="0" cellspacing="0" 
                    cellpadding="0">
                        <tr>
                            <td width=<%#DataBinder.Eval(Container.DataItem, "Porcentagem100")%> style="background-image: url('Imagens/btnPorcentagem100.jpg'); text-align: center"> 
                            </td>
                            <td width=<%#DataBinder.Eval(Container.DataItem, "Porcentagem0")%> style="background-image: url('Imagens/btnPorcentagem0.jpg'); text-align: center">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                   <asp:HyperLink ID="linkButtonAlteraCusto" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "UrlAtualizarCusto")%>  style="text-decoration:none;" ForeColor="#0000CC">Alterar Custo</asp:HyperLink>
                    <br /><br />
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "UrlAtualizarLucro")%>  style="text-decoration:none;" ForeColor="#0000CC">Alterar Lucro</asp:HyperLink>
                    <br /><br />
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "Url")%>  style="text-decoration:none;" ForeColor="#0000CC">Alterar Projeto</asp:HyperLink>
                </td>
            </tr>
        </table>
        <br />
        </ItemTemplate>
        </asp:Repeater>
        <h3 style="color: #0f1745;">
            Mensagens
        </h3>
        <table>
            <asp:Repeater ID="ListaMensagem" runat="server">
            <ItemTemplate>
            <tr>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px; padding-top: 20px; padding-bottom: 20px;">
                    <b><%#DataBinder.Eval(Container.DataItem, "Data")%> – </b><%#DataBinder.Eval(Container.DataItem, "Titulo")%>
                </td>
                <td style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px; padding-top: 20px; padding-bottom: 20px;">
                    <b><a> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> > Visualizar </asp:HyperLink></a></b>
                </td>
             </tr>
            </ItemTemplate>

            </asp:Repeater>
        </table>
    </div>
    <div style="height: 100px; background-color: #ebe7e8;">
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