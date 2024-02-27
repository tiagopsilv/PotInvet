<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroPesquisa.aspx.cs" Inherits="Invest.CadastroPesquisa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
    <script language="Javascript" src="Scripts/Mascara.js">
    </script>
    <style type="text/css">
        #form1
        {
            height: 1820px;
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
    <div style="height: 1569px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Pesquisa</h2>
        <div style="float: left; width: 806px;">
        <asp:Label ID="lblErro1" runat="server" Text="Erro:" ForeColor="Red" 
                Visible="False"></asp:Label>
            <br />

            <asp:Label ID="Label1" runat="server" Text="1) O site está estruturado de forma que facilitará a identificação de projetos interessantes?" 
                BorderStyle="None" Font-Size="Medium" Width="701px"></asp:Label>
            <br />
            <asp:radiobuttonlist id="rdl1" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb1Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb1Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
            <br />
&nbsp;<asp:Label ID="Label13" runat="server" Text="Porque?" BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque1" runat="server" Width="140" Height="20" Style="border: 0;" MaxLength="6000"></asp:TextBox>&nbsp;&nbsp; 
            <br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="2) As funcionalidades apresentadas do sistema, são suficientes para avaliar a capacidade de desenvolvimento da ideia?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
            <asp:radiobuttonlist id="rdl2" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb2Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb2Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
            <br />
&nbsp;<asp:Label ID="Label14" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque2" runat="server" Width="140" Height="20"  Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label3" runat="server" Text="3) As funcionalidades apresentadas do sistema, são suficientes para avaliar a qualidade das equipes dos projetos?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
            <asp:radiobuttonlist id="rdl3" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb3Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb3Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
<br />
&nbsp;<asp:Label ID="Label15" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque3" runat="server" Width="140" Height="20" Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label4" runat="server" Text="4) A apresentação de vídeos auxiliou na sua avaliação do projeto?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
            <asp:radiobuttonlist id="rdl4" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb4Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb4Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
<br />
&nbsp;<asp:Label ID="Label16" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque4" runat="server" Width="140" Height="20" Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label5" runat="server" Text="5) A apresentação do Ranking auxiliou sua avaliação do projeto?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
        <asp:radiobuttonlist id="rdl5" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb5Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb5Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
<br />
&nbsp;<asp:Label ID="Label17" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque5" runat="server" Width="140" Height="20" Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label6" runat="server" Text="6) A apresentação da Lista de Custo(resultando o gráfico ROI) auxiliou sua avaliação do projeto?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
        <asp:radiobuttonlist id="rdl6" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb6Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb6Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
<br />
&nbsp;<asp:Label ID="Label18" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque6" runat="server" Width="140" Height="20" 
                Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label7" runat="server" Text="7) A apresentação da Lista de Lucro(resultando o gráfico ROI) auxiliou sua avaliação do projeto?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
        <asp:radiobuttonlist id="rdl7" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb7Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb7Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
<br />
&nbsp;<asp:Label ID="Label19" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque7" runat="server" Width="140" Height="20" 
                Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label12" runat="server" Text="8) A vinculação do projeto com um agente(faculdades, universidades, unidades de apoio a empreendedores “incubadoras”),  melhorou a credibilidade/qualidade no projeto?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
        <asp:radiobuttonlist id="rdl8" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb8Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb8Nao" runat="server" value="Não" />
</asp:radiobuttonlist>
<br />
&nbsp;<asp:Label ID="Label20" runat="server" Text="Porque?" 
                BorderStyle="None" Font-Size="Medium" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPorque8" runat="server" Width="140" Height="20" 
                Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label8" runat="server" Text="9) Qual funcionalidade do site IdeiasInvest mais te interessou?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />

                    <asp:radiobuttonlist id="rdl13" runat="server" RepeatLayout="Flow" 
                style="font-size: medium">
                <asp:listitem id="rdb9Aprensetacao" runat="server" value="Apresentação de vido com breve apresentação do projeto." />
                <asp:listitem id="rdb9Disponibilizacao" runat="server" value="Disponibilização dos gráficos ROI de custo e Lucro" />
                <asp:listitem id="rdb9Pesquisa" runat="server" value="Pesquisas dos projetos por área de atuação." />
</asp:radiobuttonlist>

            <br />
            <br />

            <asp:Label ID="Label9" runat="server" Text="Qual sua avaliação quanto ao sistema IdeiasInvest?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
                    <asp:radiobuttonlist id="rdl10" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb10MuitoBom" runat="server" value="Muito bom" />
        <asp:listitem id="rdb10Bom" runat="server" value="Bom" />
                <asp:listitem id="rdb10Regular" runat="server" value="Regular" />
                <asp:listitem id="rdb10Ruim" runat="server" value="Ruim" />
                <asp:listitem id="rdb10MuitoRuim" runat="server" value="MuitoRuim" />
</asp:radiobuttonlist>
&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />

            <asp:Label ID="Label10" runat="server" Text="11) Melhorias ou sugestões?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
            <asp:TextBox ID="txtSegestao" runat="server" Width="645px" Height="20px" 
                Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label11" runat="server" Text="12) Você já utilizou algum sistema semelhante?" 
                BorderStyle="None" Font-Size="Medium" Width="798px"></asp:Label>
            <br />
        <asp:radiobuttonlist id="rdl12" runat="server" RepeatLayout="Flow" style="font-size: medium">
        <asp:listitem id="rdb12Sim" runat="server" value="Sim" />
        <asp:listitem id="rdb12Nao" runat="server" value="Não" />
</asp:radiobuttonlist>

            <br />

            <asp:Label ID="Label24" runat="server" Text="Qual?" 
                BorderStyle="None" Font-Size="Medium" Width="44px"></asp:Label>
            <asp:TextBox ID="txtPorque11" runat="server" Width="140" Height="20" 
                Style="border: 0;" MaxLength="6000"></asp:TextBox>
            <br />
            <br />
            <div style="text-align: right; vertical-align: sub; height: 37px; width: 806px;">
                <asp:ImageButton ID="ImageButton3" runat="server"
                ImageUrl="~/Imagens/botaoSalvar.jpg" style="text-align: right" 
                    onclick="ImageButton3_Click" />
            </div>
            <br />
            <br />
            <br />
            <br />
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
    <br />
    <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 201212</p>
    </div>
    </div>
    </form>
</body>
</html>

</body>
</html>