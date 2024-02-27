<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCadCustoAgente.aspx.cs" Inherits="Invest.FormCadCustoAgente" %>

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
        <asp:LinkButton ID="linkButton" runat="server" Text="Bem vindo!" 
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
                <asp:LinkButton ID="linkButton1" runat="server" Text="Home" CssClass="linkMenu" 
                    onclick="linkButton1_Click"></asp:LinkButton>
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
    <div style="height: 1456px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Cadastro de Custo</h2>
        <div style="float: left;">
        <asp:Label ID="lblErro1" runat="server" Text="Erro:" ForeColor="Red" 
                Visible="False"></asp:Label>&nbsp;</br>

            <asp:Label ID="Label1" runat="server" Text="Descrição Custo" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtDescCusto" runat="server" Width="500px" Height="78px"
                Style="border: 0;" MaxLength="50" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label2" runat="server" Text="Custo Estimado" 
                BorderStyle="None" Font-Size="Medium" onkeyup="test();" ></asp:Label>
            <br />
            <asp:TextBox ID="txtValor" runat="server" Width="140" Height="20" 
                onKeyDown="formataValor(this,event);" 
                onKeyPress="formataValor(this,event);" onKeyUp="formataValor(this,event);" 
                Style="border-style: none; border-color: inherit; border-width: 0; text-align: right;" 
                MaxLength="13"></asp:TextBox>
            <asp:Label ID="lblObriCPF" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label4" runat="server" Text="Justificativa para o Valor" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtJustiCusto" runat="server" Width="502px" Height="66px" 
                Style="border: 0;" MaxLength="30" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label7" runat="server" Text="Data de Execução" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtData" runat="server" Width="139px" Height="20px" 
            onKeyDown="formataData(this,event);" onKeyPress="formataData(this,event);" onKeyUp="formataData(this,event);" 
                Style="border: 0;" MaxLength="10"></asp:TextBox>
            <asp:Label ID="lblObriDtNacimento" runat="server" Text="*"></asp:Label>
            <br />
            </br>

            <asp:ImageButton ID="btnSalvar" runat="server" 
                ImageUrl="~/Imagens/botaoSalvar.jpg" onclick="btnSalvar_Click" />

           <br />
        </div>
    </div>
    <br />
    <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 2012</p>
    </div>
    </form>
</body>
</html>