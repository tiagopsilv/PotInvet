<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalheEmpreendedor.aspx.cs" Inherits="Invest.DetalheEmpreendedor" %>


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
            width: 687px;
        }
        .style2
        {
            font-size: medium;
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
    <div style="height: 1419px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Empreendedor</h2>
        <div style="float: left; background-color: #BAB2AF;">
        <table>
        <td>
        <asp:Image ID="ImgFoto" runat="server" Height="90px" Width="90px" />
        </td>
        <td class="style1">
        <asp:Label ID="lblNome" runat="server" Text="Nome" Font-Size="Large" 
                ForeColor="Black" style="font-size: x-large; font-weight: 700"></asp:Label>
            <br />
            <div style="float:left; height: 22px; width: 277px;">
            <asp:Label ID="Label3" runat="server" Text="E-mail: " 
                    style="font-size: medium; font-weight: 700;"></asp:Label>
        <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Size="Medium" 
                ForeColor="Black" CssClass="style2"></asp:Label></div>
                <div style="float:left; width: 269px; height: 22px;">
        <asp:Label ID="Label2" runat="server" Text="CPF: " 
                        style="font-size: medium; font-weight: 700" Visible="False"></asp:Label>
        <asp:Label ID="lblCPF" runat="server" Text="CPF" Font-Size="Medium" 
                ForeColor="Black" CssClass="style2" Visible="False"></asp:Label>
        </div><br />
        <div style="float:left; width: 82px; height: 22px;">
        <asp:Label ID="Label6" runat="server" Text="DDD: " 
                style="font-size: medium; font-weight: 700"></asp:Label>
            <asp:Label ID="lblDDD" runat="server" style="font-size: medium" Text="DDD"></asp:Label></div>
<div style="float:left; width: 195px; height: 22px;"><asp:Label ID="Label5" 
        runat="server" Text="Telefone: " style="font-size: medium; font-weight: 700"></asp:Label>
            <asp:Label ID="lblTelefone" runat="server" style="font-size: medium" 
                Text="Telefone"></asp:Label></div>
            <div style="float:left;height: 22px; width: 82px;" >
            <asp:Label ID="Label1" runat="server" Text="DDD: " 
                    style="font-size: medium; font-weight: 700"></asp:Label>
            <asp:Label ID="lblDDDCel" runat="server" Text="DDDCel" style="font-size: medium"></asp:Label></div>
            <div style="float:left;height: 22px; width: 188px;">
            <asp:Label ID="Label4" runat="server" Text="Celular: " 
                    style="font-size: medium; font-weight: 700"></asp:Label>
            <asp:Label ID="lblCelular" runat="server" Text="Celular" style="font-size: medium"></asp:Label>
            </div>
            <br />
            <div style="float:left; width: 277px;">
            <asp:Label ID="Label7" runat="server" Text="Endereço: " 
                    style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblEndereco" runat="server" Text="Endereco" 
                style="font-size: medium"></asp:Label></div>
            <div style="float:left; width: 272px;">
                <asp:Label ID="Label8" runat="server" Text="Complemento: " 
                style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblComplemento" runat="server" Text="Complemento" 
                style="font-size: medium"></asp:Label></div>
                <br />
                <div style="float:left; width: 277px;">
            <asp:Label ID="Label9" runat="server" Text="Cidade: " 
                style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblCidade" runat="server" Text="Cidade" 
                style="font-size: medium"></asp:Label></div>
                <div style="float:left">
            <asp:Label ID="Label10" runat="server" Text="UF: " 
                style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblUF" runat="server" Text="UF" style="font-size: medium"></asp:Label>
            </div>
            <br />
            <div style="float:left; width: 277px;">
            <asp:Label ID="Label11" runat="server" Text="CEP: " 
            style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblCEP" runat="server" style="font-size: medium" Text="CEP"></asp:Label>
            </div> 
            <div style="float:left; width: 277px;">
            <asp:Label ID="Label12" runat="server" Text="Dt. Nascimento: " 
            style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblDtNascimento" runat="server" style="font-size: medium" Text="DtNascimento"></asp:Label>
            </div> 
            <br />
            <div style="float:left; width: 277px;">
            <asp:Label ID="Label13" runat="server" Text="Escolaridade: " 
            style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblEscolaridade" runat="server" style="font-size: medium" Text="Escolaridade"></asp:Label>
            </div> 
            <div style="float:left; width: 277px;">
            <asp:Label ID="Label15" runat="server" Text="Formação: " 
            style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblFormacao" runat="server" style="font-size: medium" Text="Formação"></asp:Label>
            </div> 
            <br />
            <div style="float:left; width: 277px;">
            <asp:Label ID="Label14" runat="server" Text="Faculdade: " 
            style="font-size: medium; font-weight: 700;"></asp:Label>
            <asp:Label ID="lblFaculdade" runat="server" style="font-size: medium" Text="Faculdade"></asp:Label>
            </div> 
            </td>
        </table> 

            <h2>
            Currículo</h2>
            <asp:Label ID="lblDescricao" runat="server" Font-Overline="False" 
                style="font-size: medium" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label16" runat="server" 
                style="font-size: medium; font-weight: 700" Text="Web Site:"></asp:Label>
            &nbsp;<asp:LinkButton ID="lnkWebSite" runat="server" onclick="lnkWebSite_Click" 
                style="font-size: medium">LinkButton</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="Label17" runat="server" 
                style="font-size: medium; font-weight: 700" Text="Linkedin:"></asp:Label>
            &nbsp;<asp:LinkButton ID="lnkLinkeid" runat="server" onclick="lnkWebSite_Click" 
                style="font-size: medium">LinkButton</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="Label18" runat="server" 
                style="font-size: medium; font-weight: 700" Text="Facebook:"></asp:Label>
            &nbsp;<asp:LinkButton ID="lnkFacebook" runat="server" 
                onclick="lnkWebSite_Click" style="font-size: medium">LinkButton</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="Label19" runat="server" 
                style="font-size: medium; font-weight: 700" Text="GooglePlus:"></asp:Label>
            &nbsp;<asp:LinkButton ID="lnkGooglePlus" runat="server" 
                onclick="lnkWebSite_Click" style="font-size: medium">LinkButton</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="Label20" runat="server" 
                style="font-size: medium; font-weight: 700" Text="Twitter:"></asp:Label>
            &nbsp;<asp:LinkButton ID="lnkTwitter" runat="server" onclick="lnkWebSite_Click" 
                style="font-size: medium">LinkButton</asp:LinkButton>
            <br />
            &nbsp;<br />
            <asp:Label ID="Label21" runat="server" 
                style="font-size: medium; font-weight: 700" Text="Skype:"></asp:Label>
            &nbsp; 
            <asp:Label ID="lblSkype" runat="server" Text="Skype"></asp:Label>
            <br />
            <br />

            <asp:Label ID="Label22" runat="server" 
                style="font-size: medium; font-weight: 700" Text="MSN:"></asp:Label>
            &nbsp; 
            <asp:Label ID="lblMsn" runat="server" Text="MSN"></asp:Label>

            <br />
            &nbsp;<br />
            <br />
            <div style="text-align: right">
            <asp:ImageButton ID="btnVoltar" runat="server" 
                ImageUrl="~/Imagens/botaoVoltar.jpg" onclick="btnSalvar_Click" />
            </div>
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