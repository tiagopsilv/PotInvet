<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sobre.aspx.cs" Inherits="Invest.sobre" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
        <asp:LinkButton ID="linkButton" runat="server" Text="Login" 
            CssClass="link" onclick="linkButton_Click"></asp:LinkButton>
    </div>
    <div class="sair" style="text-align: right">
    <asp:LinkButton ID="btnSair" runat="server" Text="Sair" 
    onclick="LinkButton4_Click" Font-Size="Small" ForeColor="Black" CssClass="link" 
            Visible="False"></asp:LinkButton>
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
    <div style="height: 260px; padding-left: 150px; padding-top: 10px; background-color: #FFFFFF; width: 833px;">
    <div style="float: left; width: 557px;">
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            <font face="Arial" size="2">O Ideias Invest permite o encontro entre 
            Investidores e diversos projetos, pré-avaliados pelos Agentes (faculdades, 
            universidades, etc).</font></div>
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            &nbsp;</div>
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            <font face="Arial" size="2">Desta forma é possível conhecer e investir naqueles 
            que melhor se adequem ao seu perfil de investimento, analisando sua viabilidade, 
            capacidade de execução, amplitude do mercado, potencial de sucesso e 
            rentabilidade.</font></div>
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            &nbsp;</div>
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            <font face="Arial" size="2">O portal vê a figura do “Investidor Anjo”, como 
            indispensável para os bons resultados dos projetos, já que este visa a captação 
            de investidores, para as startups, sejam elas uma empresa ou ideia (projeto), 
            com custos de manutenção muito baixos, mas com grande potencial de crescimento.</font></div>
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            &nbsp;</div>
        <div align="justify" 
            style="color: rgb(0, 0, 0); font-family: arial, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); ">
            <font face="Arial" size="2">O investimento poderá ser feito através do sistema 
            de Crowdfunding, que é uma forma de angariação de fundos, onde pessoas investem 
            pequenas quantias até acumular-se o capital necessário para financiar a startup 
            ou projeto.</font>
            </div>
            </div>
            <div style="float: left; width: 184px;">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagens/investidoranjo.jpg" />
            </div>

    </div>

    <br />
    <div class="footer" style="padding-left: 150px">
        <p class="p">
            Invest &copy 201212</p>
    </div>
    </form>
</body>
</html>