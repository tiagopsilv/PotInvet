<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContratoInvestir.aspx.cs" Inherits="Invest.ContratoInvestir" %>


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
    <div style="height: 1220px; padding-left: 150px; padding-top: 10px; background-color: #ebe7e8;">
        <h2>
            <asp:Label ID="lblTitulo" runat="server" Text="Investir no Projeto:"></asp:Label>
        &nbsp;</h2>
        <div style="float: left;">

        <asp:Label ID="lblErro1" runat="server" Text="Erro:" ForeColor="Red" 
                Visible="False"></asp:Label>

        <br />
            <asp:Label ID="Label19" runat="server" Text="Valor" 
                BorderStyle="None" Font-Size="Medium" onkeyup="test();" ></asp:Label>
            <br />
            <asp:TextBox ID="txtValor" runat="server" Width="140" Height="20" 
                onKeyDown="formataValor(this,event);" 
                onKeyPress="formataValor(this,event);" onKeyUp="formataValor(this,event);" 
                Style="border-style: none; border-color: inherit; border-width: 0; text-align: right;" 
                MaxLength="13"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtContrato" runat="server" Height="99px" ReadOnly="True" 
                TextMode="MultiLine" Width="763px">TERMO E CONDIÇÕES DE USO E AQUISIÇÃO DE COTAS DE PROJETOS

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
</asp:TextBox>
<br />
<br />
            <asp:CheckBox ID="chkAceite" runat="server" Font-Size="Medium" 
                Text="Sim, aceito as condições conforme acima descrito." />
            <br />
            <br />
            <asp:ImageButton ID="btnSalvar" runat="server" 
                ImageUrl="~/Imagens/botaoInvestir.jpg" onclick="btnSalvar_Click" />
           &nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="btnVoltar" runat="server" 
                ImageUrl="~/Imagens/botaoVoltar.jpg" onclick="btnVoltar_Click" />
           <br />
        </div>
    </div>
    <br />
    <div class="footer" style="padding-left: 150px;">
        <p class="p">
            Invest &copy 201212</p>
    </div>
    </form>
</body>
</html>
