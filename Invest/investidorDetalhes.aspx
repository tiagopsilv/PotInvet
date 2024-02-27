<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="investidorDetalhes.aspx.cs"
    Inherits="Invest.investidorDetalhes" %>

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
    <div style="padding-left: 150px; background-color: #ebe7e8; padding-top: 20px;" class="conteudo">
        <h3 style="color: #0f1745;">
            Integrantes do Projeto
        </h3>
        <table>
            <tr>
                <td style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                    <asp:Image ID="imageLogoUm" runat="server"
                        Width="150" Height="111" />
                    <p style="color: #0f1745; font-size: 13px;">
                        <b><asp:Label ID="lblProjeto" runat="server" Text="Label"></asp:Label></b></p>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                    <br />

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

 
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                     <b>
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
         <%--   fim--%>
        </table>
        <h3 style="color: #0f1745;">
            Mensagens
        </h3>
        <table>
                    <asp:Repeater ID="ListaMensagem" runat="server">
            <ItemTemplate>
            <tr>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;
                    padding-top: 20px; padding-bottom: 20px; text-align: left;">
                    <b><%#DataBinder.Eval(Container.DataItem, "Data")%> – </b><%#DataBinder.Eval(Container.DataItem, "Titulo")%>
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;
                    padding-top: 20px; padding-bottom: 20px;"">
                    <b><a> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URL")%> > Visualizar </asp:HyperLink></a></b>
                </td>
             </tr>
            </ItemTemplate>

            </asp:Repeater>
            
        </table>
        <h3 style="color: #0f1745;">
            Documentos
        </h3>
        <table>
            <asp:Repeater ID="ListaDocumento" runat="server">
            <ItemTemplate>
            <tr>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 212px;
                    padding-top: 20px; padding-bottom: 20px;">
                    <b> <%#DataBinder.Eval(Container.DataItem, "Titulo")%> </b> - <%#DataBinder.Eval(Container.DataItem, "EnderecoDocumento").ToString().Replace("~/Doc/", "")%> 
                </td>
                <td style="width: 300px; background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;
                    padding-top: 20px; padding-bottom: 20px;">
                    <b><a><asp:HyperLink ID="HyperLink4" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "EnderecoDocumento")%> runat="server">Ver o Documento </asp:HyperLink></a></b>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
<%--        <h3 style="color: #0f1745;">
            Calendário / Reuniões
        </h3>--%>
<%--        <table>
            <tr>
                <td>
                    <asp:Calendar ID="calendarioProjetos" runat="server" BackColor="White" BorderColor="Black"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" Height="190px" NextPrevFormat="FullMonth"
                        Width="300px" Visible="False">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="1px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
                <td>
                </td>
                <td style="width: 550px; background-color: #b8b2ae; padding-left: 5px; padding-right: 5px;
                    padding-top: 5px; padding-bottom: 5px;">
                    <p style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;">
                        <b>03/04 –</b> Link e texto Descrição Mensagem Notificação</p>
                    <p style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;">
                        <b>04/04 –</b> Link e texto Descrição Mensagem Notificação</p>
                    <p style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;">
                        <b>05/04 –</b> Link e texto Descrição Mensagem Notificação</p>
                </td>
            </tr>
        </table>--%>
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
