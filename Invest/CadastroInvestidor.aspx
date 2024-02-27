<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroInvestidor.aspx.cs" Inherits="Invest.CadastroInvestidor" %>


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
    <div style="height: 1456px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            Cadastro de Investidor
            
        </h2>
        <div style="float: left;">
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
                Style="border: 0;" MaxLength="14"></asp:TextBox>
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
                Style="border: 0;" MaxLength="15"></asp:TextBox>
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
                Style="border: 0;" MaxLength="15"></asp:TextBox><br />
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
                        <asp:DropDownList ID="cboSexo" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Feminino</asp:ListItem>
            </asp:DropDownList> 
            <asp:Label ID="lblObriSexo" runat="server" Text="*"></asp:Label>
            <br /> </br>
            <asp:Label ID="lblUsuario" runat="server" Text="Usuário" 
                BorderStyle="None" Font-Size="Medium"></asp:Label></br>
                            <asp:TextBox ID="txtUsuario" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="50"></asp:TextBox>
            <asp:Label ID="lblObriUsuario" runat="server" Text="*"></asp:Label>
            <br />
            </br>
            <asp:Label ID="Label16" runat="server" Text="Senha" 
                BorderStyle="None" Font-Size="Medium"></asp:Label></br>
                            <asp:TextBox ID="txtSenha" TextMode="password" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="50"></asp:TextBox>
            <asp:Label ID="lblObriSenha" runat="server" Text="*"></asp:Label>
            </br>
            </br>
            <asp:Label ID="Label17" runat="server" Text="Confirmar Senha" 
                BorderStyle="None" Font-Size="Medium"></asp:Label></br>
                            <asp:TextBox ID="txtConfirmarSenha" TextMode="password" runat="server" Width="250" Height="20" 
                Style="border: 0;" MaxLength="50"></asp:TextBox>
            <asp:Label ID="Label18" runat="server" Text="*"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Foto Perfil" 
                BorderStyle="None" Font-Size="Medium"></asp:Label> <br/>

                    <asp:FileUpload ID="fupFoto" runat="server" 
                        ErrorMessage="Pemitido somente Jpegs e Gifs." On="CarrgaFoto" 
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF)$" 
                        Width="280px" />
                <br />
                </br>
            <%--            <asp:TextBox ID="TextBox14" runat="server" Width="400" Height="20" 
                Style="border: 0;"></asp:TextBox><br />--%>
            <asp:TextBox ID="txtContrato" runat="server" Height="88px" ReadOnly="True" 
                TextMode="MultiLine" Width="474px">TERMO E CONDIÇÕES DE USO E AQUISIÇÃO DE COTAS DE PROJETOS

IDÉIAS INVEST

CONSIDERAÇÕES INICIAIS


(a) O Idéias Invest é um site hospedado sob o domínio www.ideiasinvest.com.br, de propriedade da Idéias Invest LTDA, registrada no CNPJ/MF sob o nº. 08.198.451/0001-66, e disponibilizado através da URL http://www.ideiasinvest.com.br/ (&quot;Site&quot;). 

(b) O serviço oferecido pelo Idéias Invest consiste em disponibilizar aos Investidores dispostos a comprar cotas de projetos, o contado com desenvolvedores/administradores (Agentes) de trabalhos de conclusão de curso (TCC) de níveis superiores cadastrados através do Site, e vice-versa, proporcionando a divulgação dos trabalhos e a aquisição dessas cotas.

(c) O investidor ao adquirir quaisquer cotas de projetos disponibilizados através do Site o faz diretamente do Agente, e o Idéias Invest não garante e/ou se responsabiliza pela qualidade destes. 


1. ACEITE


1.1. 1.1. Os Serviços oferecidos pelo Idéias Invest são rigidos por estes Termos Condições de Uso e Aquisição de Cotas (&quot;T&amp;C&quot;). 

1.2. A utilização dos serviços implica na mais alta compreensão, aceitação e vinculação automática do Investidor e Agentes aos T&amp;C. Ao fazer uso dos Serviços oferecidos, ambas as partes concordam em respeitar e seguir todas e quaisquer diretrizes dispostas nestes T&amp;C. 

1.3. Estes T&amp;C poderão sofrer alterações periódicas, seja por questões legais ou estratégicas do Idéias Invest. O Investidor e o Agente desde já concordam e reconhecem que é de sua única e inteira responsabilidade a verificação periódica destes T&amp;C. 


2. MODELO IDÉIAS INVEST DE COMPRA DE COTAS

(i) Os projetos serão divulgados através do Site em nome do Agente respectivo, juntamente com as informações.

(ii) A manifestação do Investidor, quando interessado em adquirir cotas do projeto divulgado, deverá se dar no período de oferta e de acordo com as condições e valores de cada projeto, junto com a efetuação do pagamento conforme instruções indicadas no próprio Site, após recebimento de proposta oficial via e-mail.

(iii) A proposta do Ideias Invest é proporcionar a interação entre agentes, empreendedores e investidores, a garantia ou deposito dos valores das cotas sugeridas pelo investidor não é responsabilidade do Ideias Invest. Fica a critério do investidor, empreendedor e agente os critérios de valores.

(iv) Confirmada a validação, será distribuído eletronicamente ao Agente um Documento de Identificação de Investidor do Projeto, bem como as formas de contato direto com o Agente. Serão reproduzidas todas as condições de uso e/ou entrega, para que os projetos sejam recebidos pelo Investidor do projeto.



3. POLÍTICA DE USO E LIMITAÇÃO DE RESPONSABILIDADES


3.1. O Investidor está ciente e desde já concorda que qualquer cota de projeto serviço adquirida através do Site é feito diretamente do Agente e que este responde exclusiva e inteiramente pela qualidade dos produtos e/ou serviços ofertados.

3.2. O Investidor está ciente de que o Idéias Invest não detém a posse nem propriedade dos projetos divulgados através do Site, e que as ofertas são realizadas em nome do respectivo Agente. 

3.3. Ao adquirir uma cota de projeto através do Site, o Investidor declara conhecer as condições de pagamento e de prazo de validade destes.

3.4. O Investidor aceita que o Idéias Invest é responsável pela criação, manutenção e administração de grupos de divulgação para cada um dos projetos negociados com os Agentes respectivos, não fazendo parte da cadeia de consumo e/ou fornecimento do produto e/ou serviço adquirido. 

3.5. O Investidor está ciente de que a única comprovação de aquisição da cota do projeto é o recebimento do Documento de Identificação que, após distribuído eletronicamente ao Investidor, passa a ser de sua exclusiva responsabilidade

3.6. O Site e o Conteúdo nele disponível poderão conter links para outros websites sem qualquer relação ou ligação com o Idéias Invest. O acesso de eventuais links através do Site é realizado por livre e inteira opção do Agente e sob sua exclusiva responsabilidade. 

3.7. O Idéias Invest envidará seus melhores esforços para manter o sigilo e segurança das informações armazenadas dos Investidores, porém, caso se dê por intervenção de terceiros alheios ao seu controle, não se responsabilizará pelos eventuais danos causados. 

3.8. Qualquer tentativa de violar os sistemas e/ou banco de dados do Idéias Invest importarão, além das sanções aqui previstas por violação destes T&amp;C, em ações judiciais cabíveis e indenizações por eventuais danos causados. 

3.9. O Idéias Invest não se responsabiliza por quaisquer obrigações tributárias eventualmente incidentes sobre as atividades dos Investidores e/ou Agentes. 


4. PENALIDADES E CANCELAMENTO DE CADASTRO

4.1. Qualquer Investidor que desrespeitar a legislação aplicável e/ou os compromissos por aqui assumidos, estará sujeito às sanções previstas nestes T&amp;C, sem prejuízo de responder civil e criminalmente pelas conseqüências de seus atos e/ou omissões. 

4.2. Sem prejuízo das demais sanções legais e daquelas aqui previstas, o Idéias Invest poderá, a seu critério, notificar, suspender e/ou cancelar o cadastro do Investidor ou do Agente, a qualquer tempo, definitiva ou temporariamente, nos seguintes casos: 

(i) Descumprimento quaisquer disposições destes T&amp;C; 

(ii) Não cumprimento de quaisquer de suas obrigações; 

(iii) Verificação de cadastro duplicado; 

(iv) Verificação de novo cadastro realizado por Investidor ou Agente que teve seu cadastro cancelado e/ou suspenso; 

(v) For constatada fraude ou tentativa de fraude; e/ou

(vi) Fornecimento de informações solicitadas incorretas e/ou inverídicas ou ainda se negar a prestar eventuais informações adicionais solicitadas pelo Idéias Invest. 

4.2.1. As hipóteses acima são meramente exemplificativas. 

5. PROPRIEDADE INTELECTUAL

Os elementos e/ou ferramentas encontrados no Site são de titularidade ou licenciados pelo Idéias Invest, sujeitos à proteção dos direitos intelectuais de acordo com as leis brasileiras e tratados e convenções internacionais dos quais o Brasil seja signatário. Apenas a título exemplificativo, entendem-se como tais: textos, softwares, scripts, imagens gráficas, fotos, sons, músicas, vídeos, recursos interativos e similares, marcas, marcas de serviços, logotipos e &quot;look and feel&quot;. 

6. CADASTRO


6.1. O Investidor, se pessoa física, declara ser maior de 18 anos, menor emancipado, ou possuir o consentimento legal, expresso e por escrito, dos pais ou responsável legal e ser plenamente capaz para se vincular a estes T&amp;C, acatar e cumprir com suas disposições. 

6.2. Menores de idade não devem enviar informações pessoais, tais como endereço de e-mail, nome e/ou informação para contato ao Idéias Invest. 

6.3. O Usuário, sendo pessoa jurídica, o fará na figura do seu representante legal, respeitando as mesmas disposições do item 6.1 acima. 


7. REGRAS GERAIS, LEGISLAÇÃO APLICÁVEL E FORO


7.1. Estes T&amp;C e quaisquer outras políticas divulgadas pelo Idéias Invest no Site estabelecem o pleno e completo acordo e entendimento entre o Investidor superando e revogando todos e quaisquer entendimentos, propostas, acordos, negociações e discussões havidos anteriormente entre as partes. 

7.2. Os T&amp;C e a relação entre as partes são regidos pelas leis da República Federativa do Brasil. 

7.3. As partes elegem o Foro da Comarca da Capital do Estado de São Paulo como sendo o único competente para dirimir quaisquer litígios e/ou demandas que venham a envolver as Partes em relação ao uso e acesso do Site. 

7.4. A incapacidade do Idéias Invest em exercer ou fazer cumprir qualquer direito ou cláusula dos T&amp;C não representa uma renúncia desse direito ou cláusula. 

7.5. Na hipótese de que qualquer item, termo ou disposição destes T&amp;C vir a ser declarado nulo ou não aplicável, tal nulidade ou inexequibilidade não afetará quaisquer outros itens, termos ou disposições aqui contidos, os quais permanecerão em pleno vigor e efeito. 

Privacidade
www.ideiasinvest.com.br é um serviço do Idéias Invest SA., subsequentemente chamado Idéias Invest e informa nesta declaração de proteção de dados quais consentimentos foram dados a respeito de levantamento, utilização e processamento de dados:

1. Somos autorizados a levantar dados pessoais. São considerados dados pessoais os dados de estoque (por exemplo seu nome, seu endereço, sua senha e seu e-mail). 

2. Utilizamos e processamos seus dados pessoais para fins de constituição, realização e execução do seu contrato de utilização e dos contratos de aquisição de cotas, bem como o de divulgação de projetos com o Idéias Invest. Isto abrange a transmissão dos seus dados a terceiros e a utilização por estes, na medida em que este procedimento é necessário para a constituição, realização e execução do contrato e dos contratos de compra concluídos. 

3. Utilizamos Cookies em diferentes partes do site para tornar a visita do nosso site mais atraente e possibilitar o uso de certas funções. Cookies são pequenos arquivos de texto que são armazenados em seu computador. A maioria dos Cookies utilizados em nosso site serão apagados do seu disco rígido automaticamente ao encerrar a sessão do navegador (chamados Cookies de sessão). Outros tipos de Cookies permanecerão no seu computador e possibilitam a identificação do seu computador na próxima visita do nosso site (chamados Cookies permanentes). Nossos parceiros não são autorizados a levantar, utilizar e processar dados pessoais obtidos por meio de Cookies do nosso site. 

4. O Idéias Invest utiliza diferentes sistemas de tracking de terceiros, como por exemplo Google Analytics, um serviço de análise de internet da Google Inc. O Google Analytics utiliza Cookies (arquivos de texto) que são armazenados em seu computador e possibilitam a análise de utilização do site. As informações geradas a partir dos Cookies a respeito da utilização do site (incluindo o seu endereço IP) serão transmitidos a um servidor nos Estados Unidos e lá armazenados. 

O Google utilizará essas informações para analisar a utilização do site para fornecer relatórios sobre a utilização aos operadores de sites bem como o fornecimento de outros serviços ligados à utilização do site e da internet. O Google transmitirá também essas informações a terceiros, caso seja imposto por lei ou no caso em que o terceiro processe esses dados por ordem do Google. O Google não ligará seu endereço IP a outros dados.

Você pode impedir a instalação de Cookies configurando seu navegador. Avisamos que neste caso a totalidade das funções do site não será disponível. 

Ao utilizar o site você concorda com o processamento dos dados levantados pelo Google na forma e na finalidade anteriormente descrita.

5. Somos autorizados a utilizar e processar seus dados pessoais para fins de publicidade (e-mail, newsletter, etc.). 

Você pode cancelar a sua inclusão nestes programas de publicidade a todo momento através de solicitação pelo Site. Não disponibilizaremos seus dados para fins de publicidade a terceiros, que não sejam os Agentes, dos quais foram adquiridas cotas.
O cancelamento é possível em todo momento através do link no seu e-mail. 

6. Somos autorizados a transmitir seus dados a terceiros caso isto seja necessário para cumprir regulações legais (por exemplo, da legislação brasileira) como no caso da transmissão de dados a autoridades de perseguição penal e inspeção para fins de defesa de perigos para a segurança pública bem como a perseguição penal. 


7. Conforme a legislação brasileira, você tem direito a informação gratuita sobre os dados armazenados e eventualmente a correção, bloqueio ou eliminação desses dados. Você pode exigir a qualquer hora informações sobre a quantidade de utilização de dados. 

8. Fica expressamente proibida a utilização total, ou parcial de qualquer projeto divulgado no Idéias Invest, sem a devida autorização do Agente. Podendo ser aplicadas as devidas implicações de acordo com a LEI Nº 9.610, DE 19 DE FEVEREIRO DE 1998. (Direitos Autorais).
</asp:TextBox>
            </br>
            </br>
            <asp:CheckBox ID="chkAceite" runat="server" Font-Size="Medium" 
                Text="Sim, aceito as condições conforme acima descrito." />
            </br>
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
