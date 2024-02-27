<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projeto.aspx.cs" Inherits="Invest.projeto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
    <style type="text/css">
        .style1
        {
            width: 284px;
        }
        .style2
        {
            width: 293px;
        }
        .style4
        {
            width: 206px;
        }
        .style6
        {
            width: 319px;
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
    <div class="pesquisar">
        <h2>
            Filtros de Busca</h2>
        <p>
            Perfil: <i>
            <asp:Label ID="lblPerfil" runat="server" Text="Perfil"></asp:Label></i><br />
            Ramo de Atividade: <i><asp:Label ID="lblRamo" runat="server" Text="Ramo"></asp:Label></i><br />
            Formato da Apresentação: <i>Vídeo</i>
            <br />
            <br />
    </div>
    <div style="height: 10px; background-color: #ebe7e8;">
        </div>
    <div style="padding-left: 150px; background-color: #ebe7e8;" class="conteudo">
        <table cellpadding="0" cellspacing="0" style="background-color: #b8b2ae">
            <tr>
                <td class="style2">
                <asp:Literal ID="Video" runat="server"></asp:Literal>
                </td>
                <td style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px; vertical-align: top; text-align: justify;" 
                class="style1" rowspan="3">
                    <asp:Image ID="imageLogoUm" runat="server" ImageAlign="TextTop"
                        Width="150" Height="111" Style="padding-top: 10px;" />
                    <p style="color: #f56808; font-size: 14px;">
                        <b><asp:Label ID="lblNomeProjeto" runat="server" Text="Nome Projeto"></asp:Label></b></p>
                    <p style="color: #ffffff; font-size: 12px;">
                        <b>Data de Publicação:</b> 
                        <asp:Label ID="lblData" runat="server" Text="10/12/2012"></asp:Label></p>
                    <p style="color: #ffffff; font-size: 12px;">
                        <b>Valor Arrecadado:</b> 
                        <asp:Label ID="lblValor" runat="server" Text="R$0.000,00"></asp:Label> [ <asp:Label 
                            ID="lblPorcentagem" runat="server" Text="00.00"></asp:Label> % ]</p>
                    <p>
                        <asp:Table ID="tblProcentagem" runat="server" Height="19px" Width="220px" border="0" cellspacing="0" 
                        cellpadding="0">
                        <asp:TableRow>
                        <asp:TableCell width=0 style="background-image: url('Imagens/btnPorcentagem100.jpg'); text-align: center" ID="tblPorcentagem100"></asp:TableCell>
                        <asp:TableCell width=0 style="background-image: url('Imagens/btnPorcentagem0.jpg'); text-align: center" ID="tblPorcentagem0"></asp:TableCell>
                        </asp:TableRow>
                        </asp:Table>
                            <b>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            </b>
                    </p>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <p>
                            <b>
                            <asp:Label ID="lblDarnota" runat="server" Text="Dar Nota"></asp:Label>
                            <asp:ImageButton ID="btnAddNota" runat="server" Height="16px" 
                                ImageUrl="~/Imagens/more.png" onclick="btnAddNota_Click" Width="16px" />
                            <asp:Label ID="lblDescNota" runat="server" Text="Nota:" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtNota" runat="server" AutoPostBack="True" MaxLength="2" 
                                Visible="False" Width="30px"></asp:TextBox>
                            <asp:LinkButton ID="btnSalvarNota" runat="server" onclick="btnSalvarNota_Click" 
                                Visible="False">Salvar</asp:LinkButton>
                            </b>
                            <asp:Label ID="lblErroTam" runat="server" ForeColor="Red" 
                                Text="Erro: Digite valores somente até 10." Visible="False"></asp:Label>
                            <asp:Label ID="lblErroNum" runat="server" ForeColor="Red" 
                                Text="Erro: Digite somente valores númericos." Visible="False"></asp:Label>
                            &nbsp;Notas de 0 à 10.</p>
                                                <p style="color: #ffffff; font-size: 12px;">
                        <b>Ranking:</b>
                        <asp:Image ID="star1" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" />
                        <asp:Image ID="star2" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" />
                        <asp:Image ID="star3" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" />
                        <asp:Image ID="star4" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" />
                        <asp:Image ID="star5" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" />
                    </p>
                        </ContentTemplate>

                    </asp:UpdatePanel>

                                                    <asp:UpdatePanel runat="server" ID="panel" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkInvestir" runat="server" Text="Desejo Investir" Style="color: #f56808;
                                            font-size: 14px; text-decoration: none; font-weight: bold; padding-bottom: 5px;"
                                            OnClick="linkInvestir_Click">
                                        </asp:LinkButton>
                                        <br />
                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                            ImageUrl="~/Imagens/botaoInvestir.jpg" onclick="ImageButton1_Click" />
                                        <br />
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                    <p>
                        <asp:Label ID="lblDescricaoProjeto" runat="server" Text="Descricao Projeto"></asp:Label>
                        </p>

                                <br />
                                <asp:UpdatePanel runat="server" ID="panel1" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkDownloads" runat="server" Text="Downloads" Style="color: #f56808;
                                            font-size: 14px; text-decoration: none; font-weight: bold; padding-bottom: 5px;"
                                            OnClick="linkDownloads_Click">
                                        </asp:LinkButton>
                                        <br />
                                        <br />
                                        <asp:ImageButton ID="linkWord" runat="server" ImageUrl="~/Imagens/btnWord_1.jpg"
                                            ToolTip="Baixar Documentação" Visible="false" />
                                        <asp:ImageButton ID="linkExcel" runat="server" ImageUrl="~/Imagens/btnExcel_1.jpg"
                                            ToolTip="Baixar Planilha de Custos" Visible="false" />
                                        <asp:ImageButton ID="linkPowerPoint" runat="server" ImageUrl="~/Imagens/btnPowerPoint_1.jpg"
                                            ToolTip="Baixar Apresentação" Visible="false" />
                                        <asp:ImageButton ID="linkProject" runat="server" ImageUrl="~/Imagens/btnProject_1.jpg"
                                            ToolTip="Baixar Projeto" Visible="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <asp:LinkButton ID="linkDetalheCusto" runat="server" 
                        Text="Detalhes de Custo" 
                                    Style="color: #f56808; font-size: 14px; text-decoration: none; font-weight: bold; padding-bottom: 5px;"
                        onclick="linkDetalheCusto_Click">
                                </asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="linkDetalheLucro" runat="server" 
                        Text="Detalhes de Lucro" 
                                    Style="color: #f56808; font-size: 14px; text-decoration: none; font-weight: bold; padding-bottom: 5px;"
                        onclick="linkDetalheLucro_Click">
                                </asp:LinkButton>
                                <br />
                                <br />
                                <br />
                                <br />
                </td>
            
            </tr>
                <tr>
                    <td>
                       <table style="background-color: #b8b2ae">
            <tr>
                <td style="background-color: #b8b2ae; padding-left: 2px; padding-right: 50px;" 
                    class="style6">
                    <h3 style="color: #0f1745;">
                        Equipe
                    </h3>
                    <asp:Repeater ID="listaEquipe" runat="server">
                        <ItemTemplate>
                            <asp:Image ID="image7" runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem, "Foto")%> Width="50"
                                Height="50" ImageAlign="AbsMiddle" />
                            <b><%#DataBinder.Eval(Container.DataItem, "Nome")%> </b>    
                            <br />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> BorderWidth="0" style="border:0px;padding:0px;">
                            Clique e veja detalhe
                            </asp:HyperLink>
                            <br />
                            <br />
                        </ItemTemplate>

                    </asp:Repeater>

                    <br />
                </td>
                <td style="background-color: #b8b2ae; padding-left: 0px; padding-right: 135px;" 
                    class="style4">
                            <p style="padding-bottom: 5px; padding-top: 5px;">
                            E-mail:</b>
                                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                 </p> <b>
                                <p style="padding-bottom: 5px; padding-top: 5px;">
                                Telefone:</b> + 55 
                                    <asp:Label ID="lblDDD" runat="server" Text="00"></asp:Label>
&nbsp;<asp:Label ID="lblTelefone" runat="server" Text="9999-9999"></asp:Label>
                                     </p> <b>
                                    <p style="padding-bottom: 5px; padding-top: 5px;">
                                    Endereço:</b>
                                        <asp:Label ID="lblEndereco" runat="server" Text="Endereço"></asp:Label>
&nbsp;- 
                                        <asp:Label ID="lblCidade" runat="server" Text="Cidade"></asp:Label>
                                         - 
                                        <asp:Label ID="lblEstado" runat="server" Text="xx"></asp:Label>
                                         </p>
                </td>
            </tr>
        </table>
                    </td>
                </tr>
                <tr>
                <td style="background-color: #b8b2ae; padding-bottom: 50px; padding-left: 60px;
                    padding-right: 10px; padding-top: 10px;" class="style2">
                    <h3 style="color: #0f1745;">
                        ROI
                        
                    </h3>
                    <div Height="249px" Width="495px" ">

                    <asp:Image ID="imgROI" runat="server" Height="249px" Width="495px" />
                    </div>
                </td>
                </tr>
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
                <asp:Image ID="image3" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200"
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
