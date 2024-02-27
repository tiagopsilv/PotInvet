<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEmpreendedor.aspx.cs" Inherits="Invest.CadastroEmpreendedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="Styles/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invest | Tudo é possível. </title>
    <script language="Javascript" src="Scripts/Mascara.js">
    </script>
</head>
<form id="form1" runat="server">
    <div class="superior">
        <asp:LinkButton ID="linkButton" runat="server" Text="Bem vindo!" 
            CssClass="link"></asp:LinkButton>
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
                <asp:LinkButton ID="linkButton1" runat="server" Text="Sobre" CssClass="linkMenu"></asp:LinkButton>
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
    <div style="height: 2126px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Cadastro de Empreendedor
            
        </h2>
        <div style="float: left;">
            <asp:Label ID="Label19" runat="server" 
                
                
                Text="Anteção! Esses dados serão usados como apresentação do empreedendor, quanto mais informações melhor."></asp:Label>
            <br />
        <asp:Label ID="lblErro1" runat="server" Text="Erro:" ForeColor="Red" 
                Visible="False"></asp:Label>&nbsp;</br>

            <asp:Label ID="Label1" runat="server" Text="Nome" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtNome" runat="server" Width="500" Height="20"
                Style="border: 0;" MaxLength="50"></asp:TextBox>
            <asp:Label ID="lblObriNome" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label2" runat="server" Text="CPF" 
                BorderStyle="None" Font-Size="Medium" onkeyup="test();" ></asp:Label>
            <br />
            <asp:TextBox ID="txtCPF" runat="server" Width="140" Height="20" 
                onKeyDown="formataCPF(this,event);" onKeyPress="formataCPF(this,event);" onKeyUp="formataCPF(this,event);" 
                Style="border: 0;" MaxLength="14" Enabled="False"></asp:TextBox>
            <asp:Label ID="lblObriCPF" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label4" runat="server" Text="Email" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" Width="300" Height="20" 
                Style="border: 0;" MaxLength="30"></asp:TextBox>
            <asp:Label ID="lblObriEmail" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label15" runat="server" Text="DDD" 
                BorderStyle="None" Font-Size="Medium" Height="18px"></asp:Label>
                &nbsp;
             <asp:Label ID="Label5" runat="server" Text="Telefone" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtDDD" runat="server" Width="30" Height="20" 
                onkeyup="formataInteiro(this,event);" Style="border: 0;" MaxLength="3"></asp:TextBox>
                &nbsp;&nbsp;
            <asp:TextBox ID="txtTelefone" runat="server" Width="150" Height="20"  
                Style="border: 0;" MaxLength="10"></asp:TextBox>
            <asp:Label ID="lblObriTelefone" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label6" runat="server" Text="DDD" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
                &nbsp;
             <asp:Label ID="Label9" runat="server" Text="Celular" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtDDD_Celular" runat="server" Width="30" Height="20" 
                onkeyup="formataInteiro(this,event);" Style="border: 0;" MaxLength="3"></asp:TextBox>
                &nbsp;&nbsp;
            <asp:TextBox ID="txtCelular" runat="server" Width="150" Height="20" 
                Style="border: 0;" MaxLength="10"></asp:TextBox><br />
            <br />
             <asp:Label ID="Label7" runat="server" Text="Data de nascimento" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtDataNascimento" runat="server" Width="139px" Height="20px" 
            onKeyDown="formataData(this,event);" onKeyPress="formataData(this,event);" onKeyUp="formataData(this,event);" 
                Style="border: 0;" MaxLength="10"></asp:TextBox>
            <asp:Label ID="lblObriDtNacimento" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label10" runat="server" Text="Endereço" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtEndereco" runat="server" Width="500" Height="20" 
                Style="border: 0;" MaxLength="60"></asp:TextBox><br />
            <br />
             <asp:Label ID="Label8" runat="server" Text="Complemento" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtComplemento" runat="server" Width="400" Height="20" 
                Style="border: 0;" MaxLength="50"></asp:TextBox><br />
            <br />
             <asp:Label ID="Label11" runat="server" Text="CEP" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtCEP" runat="server" Width="90" Height="20" 
            onKeyDown="formataCEP(this,event);" onKeyPress="formataCEP(this,event);" onKeyUp="formataCEP(this,event);" 
                Style="border: 0;" MaxLength="9"></asp:TextBox><br />
            <br />
            
             <asp:Label ID="Label13" runat="server" Text="UF" 
                BorderStyle="None" Font-Size="Medium"></asp:Label><br />

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
            <asp:Label ID="lblObriUF" runat="server" Text="*"></asp:Label>
<br />

           <%--            <asp:TextBox ID="TextBox13" runat="server" Width="400" Height="20" 
                Style="border: 0;"></asp:TextBox><br />--%>
            <br />
             <asp:Label ID="Label12" runat="server" Text="Cidade" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtCidade" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <asp:Label ID="lblObriCidade" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label14" runat="server" Text="Sexo" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
                        <asp:DropDownList ID="cboSexo" runat="server" Height="19px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Feminino</asp:ListItem>
            </asp:DropDownList> 
            <asp:Label ID="lblObriSexo" runat="server" Text="*"></asp:Label>
            <br /> 
            <br />
             <asp:Label ID="Label20" runat="server" Text="Escolaridade" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
                        <asp:DropDownList ID="cboEscolarida" runat="server" Height="18px" 
                Width="459px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Ensino Fundamental</asp:ListItem>
                <asp:ListItem>Ensino Médio</asp:ListItem>
                            <asp:ListItem>Ensino Superior</asp:ListItem>
                            <asp:ListItem>Especialização, Mestrado, Doutorado</asp:ListItem>
            </asp:DropDownList> 
            <asp:Label ID="lblObriSexo0" runat="server" Text="*"></asp:Label>
            <br />
            <br />
             <asp:Label ID="Label21" runat="server" Text="Formacao" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtFormacao" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label22" runat="server" Text="Faculdade" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtFaculdade" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label24" runat="server" Text="Currículo" 
                BorderStyle="None" Font-Size="Medium" Width="138px"></asp:Label>
            <br />
            <asp:TextBox ID="txtCurriculo" runat="server" Width="543px"
                Height="126px" Style="border: 0;" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Foto Perfil" 
                BorderStyle="None" Font-Size="Medium"></asp:Label> 
            <br />

                    <asp:FileUpload ID="fupFoto" runat="server" 
                        ErrorMessage="Pemitido somente Jpegs e Gifs." On="CarrgaFoto" 
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF)$" 
                        Width="280px" />
                <br />
            <br />
             <asp:Label ID="Label23" runat="server" Text="Web Site" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtWebSite" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label25" runat="server" Text="Linkedin" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtLinkid" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label26" runat="server" Text="Facebook" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtFacebook" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label27" runat="server" Text="Google Plus" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtGooglePlus" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label28" runat="server" Text="Skype" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtSkype" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label29" runat="server" Text="Twitter" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtTwitter" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="Label30" runat="server" Text="Msn" 
                BorderStyle="None" Font-Size="Medium"></asp:Label>
            <br />
            <asp:TextBox ID="txtMsn" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="25"></asp:TextBox>
            <br />
            </br>

            <asp:ImageButton ID="btnSalvar" runat="server" 
                ImageUrl="~/Imagens/botaoSalvar.jpg" onclick="btnSalvar_Click" />

           &nbsp;<asp:ImageButton ID="btnVoltar" runat="server" 
                ImageUrl="~/Imagens/botaoVoltar.jpg" onclick="btnVoltar_Click" />

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
