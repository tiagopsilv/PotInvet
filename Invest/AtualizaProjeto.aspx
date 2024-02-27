<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtualizaProjeto.aspx.cs" Inherits="Invest.AtualizaProjeto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
    <style type="text/css">
        .style1
        {
            width: 437px;
        }
        .style2
        {
            width: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
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
    <div style="height: 1642px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Cadastro de Projeto
        </h2>
        <div style="float: left;">
        <asp:Label ID="lblErro1" runat="server" Text="Erro:" ForeColor="Red" 
                Visible="False"></asp:Label>
            <br />

            <asp:Label ID="Label1" runat="server" Text="Nome Projeto" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:TextBox ID="txtNomeProjeto" runat="server" Width="400px" Height="20px"
                Style="border: 0;" Enabled="False"></asp:TextBox><br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="Descrição Projeto" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:TextBox ID="txtDescricaoProjeto" runat="server" Width="543px"
                Height="126px" Style="border: 0;" TextMode="MultiLine"></asp:TextBox>&nbsp;<br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table cellpadding="3" cellspacing="3">
                        <tr>
                            <td align="center" colspan="2" 
                                style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px; text-align: left;">
                                <asp:Label ID="Label3" runat="server" style="text-align: left" 
                                    Text="Lista de Empreendedores"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style1" 
                                style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px; text-align: left;">
                                <asp:Label ID="Label4" runat="server" Text="Nome"></asp:Label>
                            </td>
                            <td align="center" class="style2" 
                                style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                                <asp:Label ID="Label5" runat="server" Text="Excluir"></asp:Label>
                            </td>
                        </tr>
                        <asp:Repeater ID="listaEmpreendedor" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="left" class="style1" 
                                        style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                   <%#DataBinder.Eval(Container.DataItem, "Nome")%>
                                    </td>
                                    <td align="center" class="style2" 
                                        style="background-color: #b8b2ae; padding-left: 20px; padding-right: 20px;">
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl=<%#DataBinder.Eval(Container.DataItem, "URLExcluir")%> runat="server">Excluir</asp:HyperLink>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <div style="text-align: right; vertical-align: sub; height: 37px; width: 586px;">
            &nbsp;<asp:ImageButton ID="ImageButton3" runat="server"
                ImageUrl="~/Imagens/botaoAdicionar.jpg" style="text-align: right" 
                    onclick="ImageButton3_Click" />
            </div>
            <br />

            <asp:Label ID="Label6" runat="server" Text="Video (Atenção! Obrigatório que seja um link valido do youtube.)" 
                BorderStyle="None" Font-Size="Medium" Width="549px"></asp:Label>
            <br />
           <asp:TextBox ID="txtVideo" runat="server" Width="400px" Height="20px"
                Style="border: 0;"></asp:TextBox>
            <br />
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            <br />

            <asp:Label ID="Label9" runat="server" Text="Perfil" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:DropDownList ID="cboPerfil" runat="server" Height="22px">
                <asp:ListItem>Todos</asp:ListItem>
                <asp:ListItem Text="Sonhador" Value="0"></asp:ListItem>
                <asp:ListItem Text="Empreendedor" Value="1"></asp:ListItem>
                <asp:ListItem Text="Objetivo" Value="2"></asp:ListItem>
                <asp:ListItem Text="Filantrópico" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />

            <asp:Label ID="Label10" runat="server" Text="Ramo de Atividade" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:DropDownList ID="cboRamo" runat="server" Height="20px" Width="145px">
                <asp:ListItem>Todos</asp:ListItem>
                <asp:ListItem Text="Indústria" Value="0"></asp:ListItem>
                <asp:ListItem Text="Varejo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Artístico" Value="2"></asp:ListItem>
                <asp:ListItem Text="TI" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
             <asp:Label ID="Label16" runat="server" Text="Email" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
                <br />
            <asp:TextBox ID="txtEmail" runat="server" Width="300" Height="20" 
                Style="border: 0;" MaxLength="30"></asp:TextBox> 
                <br />
                <br />
<asp:Label ID="Label15" runat="server" Text="DDD" 
                BorderStyle="None" Font-Size="Medium" Height="18px"></asp:Label>
                &nbsp;
             <asp:Label ID="Label11" runat="server" Text="Telefone" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtDDD" runat="server" Width="30" Height="20" 
                onkeyup="formataInteiro(this,event);" Style="border: 0;" MaxLength="3"></asp:TextBox>
                &nbsp;&nbsp;
            <asp:TextBox ID="txtTelefone" runat="server" Width="150" Height="20"  
                Style="border: 0;" MaxLength="15"></asp:TextBox>
            <asp:Label ID="lblObriTelefone" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label18" runat="server" Text="Endereço" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
                <br />
            <asp:TextBox ID="txtEndereco" runat="server" Width="500" Height="20" 
                Style="border: 0;" MaxLength="60"></asp:TextBox>
                <br />
                <br />
             <asp:Label ID="Label19" runat="server" Text="Complemento" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
                <br />
            <asp:TextBox ID="txtComplemento" runat="server" Width="400" Height="20" 
                Style="border: 0;" MaxLength="50"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label13" runat="server" Text="UF" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
                <br />
            <asp:DropDownList ID="cboEstado" runat="server" Height="20px" Width="152px">
                <asp:ListItem Selected="True">Escolha o Estado</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="AC">Acre</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="AL">Alagoas</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="AP">Amapá</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="AM">Amazonas</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="BA">Bahia</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="CE">Ceará</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="DF">Distrito Federal</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="ES">Espirito Santo</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="GO">Goiás</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="MA">Maranhão</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="MT">Mato Grosso</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="MS">Mato Grosso do Sul</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="MG">Minas Gerais</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="PA">Pará</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="PB">Paraiba</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="PR">Paraná</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="PE">Pernambuco</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="PI">Piauí</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="RJ">Rio de Janeiro</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="RN">Rio Grande do Norte</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="RS">Rio Grande do Sul</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="RO">Rondônia</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="RR">Roraima</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="SC">Santa Catarina</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="SP">São Paulo</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="SE">Sergipe</asp:ListItem>
	                 <asp:ListItem Selected="False" Value="TO">Tocantis</asp:ListItem>
            </asp:DropDownList>
             <br />
            <br />
             <asp:Label ID="Label12" runat="server" Text="Cidade" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtCidade" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            &nbsp;
            <br />

            <asp:Label ID="Label7" runat="server" Text="Imagem" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:FileUpload ID="fupImagem" runat="server" />
            <br />
&nbsp;<br />

            <asp:Label ID="Label8" runat="server" Text="Documento" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            
            
        
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:FileUpload ID="fupDocumento1" runat="server" Width="270px" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnDocumento1" runat="server" 
                        ImageUrl="~/Imagens/more.png" onclick="btnDocumento1_Click" />
                    <asp:FileUpload ID="fupDocumento2" runat="server" Visible="False" 
                        Width="270px" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnDocumento2" runat="server" Height="16px" 
                        ImageUrl="~/Imagens/more.png" onclick="btnDocumento2_Click" Visible="False" />
                    &nbsp;<asp:FileUpload ID="fupDocumento3" runat="server" Visible="False" 
                        Width="270px" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnDocumento3" runat="server" 
                        ImageUrl="~/Imagens/more.png" Visible="False" 
                        onclick="btnDocumento3_Click" />
                    <asp:FileUpload ID="fupDocumento4" runat="server" Visible="False" 
                        Width="270px" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnDocumento4" runat="server" 
                        ImageUrl="~/Imagens/more.png" Visible="False" Width="17px" 
                        onclick="btnDocumento4_Click" />
                    <asp:FileUpload ID="fupDocumento5" runat="server" Visible="False" 
                        Width="270px" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnDocumento5" runat="server" 
                        ImageUrl="~/Imagens/more.png" Visible="False" 
                        onclick="btnDocumento5_Click" />
                    <asp:FileUpload ID="fupDocumento6" runat="server" Visible="False" 
                        Width="270px" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnDocumento6" runat="server" 
                        ImageUrl="~/Imagens/more.png" Visible="False" 
                        onclick="btnDocumento6_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:ImageButton runat="server" ID="ImageButton2" 
                ImageUrl="~/Imagens/botaoEnviarHigh.png" onclick="ImageButton2_Click" 
                Width="84px" />
            <br />
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