﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificaCPFEmpreendedor.aspx.cs" Inherits="Invest.VerificaCPFEmpreendedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
    <script language="Javascript" src="Scripts/Mascara.js">
    </script>
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
    <div style="height: 1474px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Cadastro Empreendedor</h2>
        <div style="float: left;">
        <asp:Label ID="lblErro1" runat="server" Text="Erro:" ForeColor="Red" 
                Visible="False"></asp:Label>
            <br />

            <asp:Label ID="Label1" runat="server" Text="CPF" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:TextBox ID="txtCPF" runat="server" Width="140" Height="20" 
                onKeyDown="formataCPF(this,event);" onKeyPress="formataCPF(this,event);" onKeyUp="formataCPF(this,event);" 
                Style="border: 0;" MaxLength="14"></asp:TextBox>&nbsp;&nbsp; <br />
            <div style="text-align: right; vertical-align: sub; height: 37px; width: 415px;">
                <asp:ImageButton ID="ImageButton3" runat="server"
                ImageUrl="~/Imagens/botaoVerificar.jpg" style="text-align: right" 
                    onclick="ImageButton3_Click" />
            </div>
            <br />

            <br />
            &nbsp;<br />
            <br />
            <br />

            <br />
            <br />
            <br />

            &nbsp;<br />
            <br />
            &nbsp;<br />

            <br />
            <br />
            <br />

            <br />
            <br />
            <br />

            <br />
            <br />
            <br />
                <br />
                <br />
                <br />
                &nbsp;
             <br />
                &nbsp;&nbsp;
            <br />
            <br />
                <br />
                <br />
                <br />
                <br />
            <br />
            <br />
                <br />
             <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;<br />
            <br />
            &nbsp;<br />
            <br />
        </div>
    </div>
    <br />
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

</body>
</html>
