<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Invest.home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invest | Tudo é possível. </title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="superior">

        <asp:LinkButton ID="linkButton" runat="server" Text="Login" CssClass="link" 
            onclick="linkButton_Click" ></asp:LinkButton>
    </div>
    <div class="header">
    <div class="sair" style="text-align: right">
                <asp:LinkButton ID="btnSair" runat="server" Text="Sair" 
            onclick="LinkButton4_Click" Font-Size="Small" ForeColor="Black" CssClass="link" 
                    Visible="False"></asp:LinkButton>
            </div>
        <table>
            <td style="width: 100px;">
                <asp:Image ID="image2" ImageUrl="~/Imagens/logo.jpg" runat="server" />
                
            </td>
            <td style="width: 250px;">
            </td>
            <td style="width: 200px;">
            <asp:LinkButton ID="linkButton1" runat="server" Text="Sobre" CssClass="linkMenu"></asp:LinkButton>
            </td>
            <td style="width: 200px;">
            <asp:LinkButton ID="linkButton2" runat="server" Text="Projetos" CssClass="linkMenu" 
                    onclick="linkButton2_Click"></asp:LinkButton>
            </td>
            <td style="width: 200px;">
            <asp:LinkButton ID="linkButton3" runat="server" Text="Contato" CssClass="linkMenu" ></asp:LinkButton>
            </td>
        </table>
    </div>
    <br />
                <br />
    <div class="principal">
        <asp:Image ID="image1" ImageUrl="~/Imagens/fundoLaranjaHigh.jpg" Width="100%" runat="server" />
    </div>
    <div style="padding-left: 150px;" class="conteudo">
        <table>
            <td style="vertical-align: top; width: 300px;">
                <h2>
                    &nbsp;Projeto 1</h2>
                   <asp:Image ID="image3" ImageUrl="~/Imagens/imagemProjeto1.jpg" runat="server" />
                <p style="color: #0f1745; text-align: left;">
                <asp:Label ID="lblDescricao1" runat="server" Text="
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maur
                    s phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                   Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus."></asp:Label></p>
                <br />
                <asp:ImageButton runat="server" ID="botaoMais" ImageUrl="~/Imagens/botaoMaisHigh.jpg" />
                <br />
                <br />
            </td>
            <td style="padding-left: 20px; padding-right: 20px;">
            <asp:Image ID="image6" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200" Width="1" />
            </td>
            <td style="width: 300px; vertical-align: top;">
                <h2>
                    Projeto 2</h2>
                    <asp:Image ID="image4" ImageUrl="~/Imagens/imagemProjeto2.jpg" runat="server" />
                <p style="color: #0f1745; text-align: left;">
                    <asp:Label ID="lblDescricao2" runat="server" Text="
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus."></asp:Label></p>
                <br />
                <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/Imagens/botaoMaisHigh.jpg" />
                <br />
                <br />
            </td>
              <td style="padding-left: 20px; padding-right: 20px;">
            <asp:Image ID="image7" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200" Width="1" />
            </td>
            <td style="width: 300px; vertical-align: top;">
                <h2>
                    Projeto 3</h2>
                    <asp:Image ID="image5" ImageUrl="~/Imagens/imagemProjeto3.jpg" runat="server" />
                <p style="color: #0f1745;">
                    <asp:Label ID="lblDescricao3" runat="server" Text="
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus.&lt;br /&gt;
                    Lorem ipsum dolor sitamet, inconset etuer adipiscingelit praesent vesintibun molestie
                    aenean nonumy. Hendre maurs phaselus."></asp:Label></p>
                <br />
                <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/Imagens/botaoMaisHigh.jpg" />
                <br />
                <br />
            </td>
        </table>
    </div>
    <div style="padding-left: 150px;">
        <br />
        <table>
            <td>
                <h2>
                    Como investir?
                </h2>
                <p>
                    Rida atcursus nec uctus a lornque orci ac sem. Duis ultrciesagn usan malesuda orciec
                    sit eros.
                    <br />
                    Lorem ipsum dolor sit atetuer piscing elit. Mauris fermentum magnad oreet auam lllu
                    apibus eget
                    <br />
                    elementum vel cursus eleife eliean auctor wisi et urnat volutpatis ac turpis. Integer
                    rutrum ante eu lacuestib.</p>
                <br />
                <asp:Image ID="image" ImageUrl="~/Imagens/imagemHome.gif" runat="server" />
                <p>
                    Rida atcursus nec uctus a lornque orci ac sem. Duis ultrciesagn usan malesuda orciec
                    sit eros.
                    <br />
                    Lorem ipsum dolor sit atetuer piscing elit. Mauris fermentum magnad oreet auam lllu
                    apibus eget
                    <br />
                    elementum vel cursus eleife eliean auctor wisi et urnat volutpatis ac turpis. Integer
                    rutrum ante eu lacuestib.</p>
                <br />
            </td>
            <td width="100px;" >
            </td>
            <td style="padding-right: 100px;">
            <asp:Image ID="image9" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200" Width="1" />
            </td>
            <td width="200px;">
                <h2>
                    Patrocínios
                </h2>
                <p>
                    Rida atcursus nec uctus a lornque orci ac sem. Duis ultrciesagn usan malesuda orciec
                    sit eros. Lorem ipsum dolor sit atetuer piscing elit. Mauris fermentum magnad oreet
                    auam lllu apibus eget elementum vel cursus eleife eliean auctor wisi et urnat volutpatis
                    ac turpis. Integer rutrum ante eu lacuestib.
                    <br />
                    Rida atcursus nec uctus a lornque orci ac sem. Duis ultrciesagn usan malesuda orciec
                    sit eros. Lorem ipsum dolor sit atetuer piscing elit. Mauris fermentum magnad oreet
                    auam lllu apibus eget elementum vel cursus eleife eliean auctor wisi et urnat volutpatis
                    ac turpis. Integer rutrum ante eu lacuestib.
                </p>
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
