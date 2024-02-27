<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Invest.Cadastro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="superior">
        <asp:LinkButton ID="linkButton" runat="server" Text="Bem Vindo!" 
            CssClass="link" onclick="linkButton_Click"></asp:LinkButton>
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
                <asp:LinkButton ID="linkButton1" runat="server" Text="Sobre" 
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
    <div style="height: 900px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
    <div>
        <table border="0" height="261" style="width: 921px; margin-right: 0px;">
            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:ImageButton ID="ImageButton1" runat="server" style="text-align: center" 
                        ImageUrl="~/Imagens/botaoInvestidor.jpg" onclick="ImageButton1_Click" />
                </td>
                <td style="vertical-align: middle; text-align: center">
                    <asp:ImageButton ID="ImageButton2" runat="server" style="text-align: center" 
                        ImageUrl="~/Imagens/botaoAgente.jpg" onclick="ImageButton2_Click" />
                </td>
            </tr>
        </table>
        </div>
            <div style="padding-left: 150px; background-color: #ebe7e8;" class="conteudo">
       
    </div>

    </div>
        <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 2012</p>
    </div>
    </form>
</body>
</html>
