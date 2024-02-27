<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="naoDisponivel.aspx.cs" Inherits="Invest.naoDisponivel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
    <script language="Javascript" src="Scripts/Mascara.js">
    </script>
    <style type="text/css">
        .style1
        {
            width: 282px;
            height: 278px;
            text-align: center;
        }
    </style>
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
    <div style="height: 317px; padding-left: 150px; padding-top: 10px; background-color: #FFFFFF;">
        <h2>
            Pagina não Disponível</h2>
            <div style="text-align: center">
                <img alt="" class="style1" src="Imagens/investidoranjo.jpg" /></div>
    </div>
    <br />
    <div style="padding-left: 150px;">
        <br />
    </div>
    <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 2012</p>
    </div>
    </form>
</body>
</html>

</body>
</html>
