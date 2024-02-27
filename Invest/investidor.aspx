<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="investidor.aspx.cs" Inherits="Invest.investidor" %>

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
        onclick="btnSair_Click" Font-Size="Small" ForeColor="Black" CssClass="link"></asp:LinkButton>
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
        <p>
            Perfil:
            <asp:DropDownList ID="cboPerfil" runat="server">
                <asp:ListItem>Todos</asp:ListItem>
                <asp:ListItem Text="Sonhador" Value="0"></asp:ListItem>
                <asp:ListItem Text="Empreendedor" Value="1"></asp:ListItem>
                <asp:ListItem Text="Objetivo" Value="2"></asp:ListItem>
                <asp:ListItem Text="Filantrópico" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Ramo de Atividade:
            <asp:CheckBoxList ID="checkRamoAtividade" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Indústria" Value="0"></asp:ListItem>
                <asp:ListItem Text="Varejo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Artístico" Value="2"></asp:ListItem>
                <asp:ListItem Text="Tecnologia da Informação" Value="3"></asp:ListItem>
            </asp:CheckBoxList>
        </p>
        <p>
            Formato da Apresentação:
            <asp:CheckBoxList ID="checkFormatoProjeto" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Power Point" Value="0"></asp:ListItem>
                <asp:ListItem Text="Vídeo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Áudio" Value="2"></asp:ListItem>
            </asp:CheckBoxList>
        </p>
        Procurar:
        <asp:TextBox ID="textSearch" runat="server" Width="400" Height="30"></asp:TextBox>
        <asp:ImageButton runat="server" ID="btnMais" ImageUrl="~/Imagens/botaoMaisHigh.jpg"
            ImageAlign="AbsBottom" onclick="ImageButton1_Click" />
        <br />
        <br />
    </div>
    <div style="height: 40px; background-color: #ebe7e8;" >
        <asp:Repeater ID="ListaProjeto" runat="server">
            <ItemTemplate>
                <div style="padding-left: 150px; background-color: #ebe7e8;" class="conteudo">
                    <table cellpadding="0" cellspacing="0">
                        <td style="width: 300px;">

                            <table style="display: inline-table;" border="0" cellpadding="0" cellspacing="0" width="610">

                              <tr>
                               <td width="13" height="327" rowspan="3" bgcolor="#B7B2AE" ></td>
                               <td width="585" height="14" bgcolor="#B7B2AE"></td>
                               <td width="12" height="327" rowspan="3" bgcolor="#B7B2AE"></td>
                              </tr>
                              <tr>
                               <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> BorderWidth="0" style="border:0px;padding:0px;">
                               <asp:Image ID="imagemProjetoPrincipal" width="585" height="300" runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem, "ImgApres")%>  BorderWidth="0" style="text-decoration:none;border:0px;padding:0px;"/>
                               </asp:HyperLink></td>
                              </tr>
                              <tr>
                               <td width="585" height="13" bgcolor="#B7B2AE"></td>
                              </tr>
                            </table>
                         
                            </td>

                        </td>
                        <td style="background-color: #b8b2ae; width: 400px;" >
                            <asp:HyperLink runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> BorderWidth="0" style="border:0px;padding:0px;">
                            <asp:Image ID="imageLogoUm" runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem, "ImagemProjeto")%> 
                            Width="100" Height="70" style="padding-top: 10px;text-decoration:none;border:0px;padding:0px;" DescriptionUrl  BorderWidth="0"/>
                            </asp:HyperLink>
                            <p style="color: #f56808; font-size: 14px;">
                                <b><%#DataBinder.Eval(Container.DataItem, "NomeProjeto")%></b>
                            </p>
                            <p style="color: #ffffff; font-size: 12px;">
                                <b>Data de Publicação:</b> <%#DataBinder.Eval(Container.DataItem, "Data")%>
                            </p>
                            <p style="color: #ffffff; font-size: 12px;">
                                <b>Ranking:</b>
                                <asp:Image ID="star1" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" Visible=<%#DataBinder.Eval(Container.DataItem, "star1")%>/>
                                <asp:Image ID="star2" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" Visible=<%#DataBinder.Eval(Container.DataItem, "star2")%>/>
                                <asp:Image ID="star3" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" Visible=<%#DataBinder.Eval(Container.DataItem, "star3")%>/>
                                <asp:Image ID="star4" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" Visible=<%#DataBinder.Eval(Container.DataItem, "star4")%>/>
                                <asp:Image ID="star5" ImageUrl="~/Imagens/star.png" runat="server" ImageAlign="AbsMiddle" Visible=<%#DataBinder.Eval(Container.DataItem, "star5")%>/>
                            </p>
                            <p style="color: #ffffff; font-size: 12px;">
                                <b>Valor Arrecadado:</b> R$<%#DataBinder.Eval(Container.DataItem, "Valor_Arrecadado")%>[ <%#DataBinder.Eval(Container.DataItem, "Porcentagem")%> % ]</p>
                            <table style="width: 220px; height: 19px;" border="0" cellspacing="0" 
                        cellpadding="0">
                                <tr>
                                    <td width=<%#DataBinder.Eval(Container.DataItem, "Porcentagem100")%> style="background-image: url('Imagens/btnPorcentagem100.jpg'); text-align: center"> 
                                    </td>
                                    <td width=<%#DataBinder.Eval(Container.DataItem, "Porcentagem0")%> style="background-image: url('Imagens/btnPorcentagem0.jpg'); text-align: center">
                                    </td>
                                </tr>
                            </table>
                            <p>
                                <%#DataBinder.Eval(Container.DataItem, "TextoResumo")%>...
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> BorderWidth="0" style="border:0px;padding:0px;">
                                <asp:Image ID="Image1" ImageUrl="~/Imagens/more.png" runat="server" ImageAlign="TextTop" BorderWidth="0" style="text-decoration:none;border:0px;padding:0px;"/>
                                </asp:HyperLink>
                            </p>
                        </td>
                    </table>
                </div>
                <div style="height: 20px; background-color: #ebe7e8;">
                </div>
            </ItemTemplate>
        </asp:Repeater>
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
                <asp:Image ID="image90" ImageUrl="~/Imagens/tracoCentral.jpg" runat="server" Height="200"
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
                <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 2012</p>
    </div>
    </div>

    </form>
        </body>
</html>
