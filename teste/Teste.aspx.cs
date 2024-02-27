using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using POCO;

namespace teste
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SelecionarProjeto(1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            testelogin();
        }

        public void SelecionarAgente(int Id_Projeto)
        {
            AgenteBLL a = new AgenteBLL();
            Agente Mostra;
            Mostra = a.Selecionar(Id_Projeto);
            
            Label1.Text = Mostra.Nome;
        }

        public void AdicionarAgente()
        {

            AgenteBLL a = new AgenteBLL();
            Agente Mostra = new Agente();
            Mostra.ID_Projeto = 1;
            Mostra.Nome = TextoTeste.Text;
            Mostra.Sexo = "M"; 
            Mostra.CPF = "347.262.218-09";
           
            Mostra = a.Incluir(Mostra);
           
            Label1.Text = Mostra.Nome; 

        }

        public void AtualizarAgente()
        {
            AgenteBLL a = new AgenteBLL();
            Agente Mostra = new Agente();
            Mostra.ID_Agente = 2;
            Mostra.Nome = TextoTeste.Text;
            Mostra.DDD = 5;


            Mostra = a.Alterar(Mostra);

            Label1.Text = Mostra.Nome; 
        }

        public void AdicionarCusto()
        {

            CustoBLL a = new CustoBLL();
            Custo Mostra = new Custo();
            Mostra.ID_Projeto = 1;
            Mostra.Descricao = TextoTeste.Text;
            Mostra.Justificativa = "Teste";
            Mostra.Data = DateTime.Now;

            Mostra = a.Incluir(Mostra);

            Label1.Text = Mostra.Descricao;

        }

        public void AtualizarCusto()
        {
            CustoBLL a = new CustoBLL();
            Custo Mostra = new Custo();
            Mostra.ID_Custo = 2;
            Mostra.Descricao = TextoTeste.Text;
            Mostra.CustoEstimado = 5;


            Mostra = a.Alterar(Mostra);

            Label1.Text = Mostra.Descricao;
        }

        public void ExcluirCusto(int ID_Custo)
        {
            CustoBLL a = new CustoBLL();
            a.Excluir(ID_Custo);
        }

        public List<Custo> ListaCusto()
        {
            CustoBLL a = new CustoBLL();
            return a.Listar(1);
        }

        public void AdicionarEmpreendedor()
        {

            EmpreendedorBLL a = new EmpreendedorBLL();
            Empreendedor Mostra = new Empreendedor();
            Mostra.ID_Empreendedor = 1;
            Mostra.Nome = TextoTeste.Text;
            Mostra.Sexo = "M";
            Mostra.CPF = "347.262.218-09";

            Mostra = a.Incluir(Mostra);

            Label1.Text = Mostra.Nome;

        }

        public void AtualizarEmpreendedor()
        {
            EmpreendedorBLL a = new EmpreendedorBLL();
            Empreendedor Mostra = new Empreendedor();
            Mostra.ID_Empreendedor = 2;
            Mostra.Nome = TextoTeste.Text;
            Mostra.DDD = 5;


            Mostra = a.Alterar(Mostra);

            Label1.Text = Mostra.Nome;
        }

        public void AdicionarLucro()
        {

            LucroBLL a = new LucroBLL();
            Lucro Mostra = new Lucro();
            Mostra.ID_Projeto = 1;
            Mostra.Descricao = TextoTeste.Text;
            Mostra.Justificativa = "Teste";
            Mostra.Data = DateTime.Now;

            Mostra = a.Incluir(Mostra);

            Label1.Text = Mostra.Descricao;

        }

        public void AtualizarLucro()
        {
            LucroBLL a = new LucroBLL();
            Lucro Mostra = new Lucro();
            Mostra.ID_Lucro = 1;
            Mostra.Descricao = TextoTeste.Text;
            Mostra.ValorEstimado = 5;


            Mostra = a.Alterar(Mostra);

            Label1.Text = Mostra.Descricao;
        }

        public void ExcluirLucro(int ID_Lucro)
        {
            LucroBLL a = new LucroBLL();
            a.Excluir(ID_Lucro);
        }

        public List<Lucro> ListaLucro()
        {
            LucroBLL a = new LucroBLL();
            return a.Listar(1);
        }

        public void AdicionarInvestidor()
        {

            InvestidorBLL a = new InvestidorBLL();
            Investidor Mostra = new Investidor();
            Mostra.ID_Investidor = 1;
            Mostra.Nome = TextoTeste.Text;
            Mostra.Sexo = "M";
            Mostra.CPF = "347.262.218-09";

            Mostra = a.Incluir(Mostra);

            Label1.Text = Mostra.Nome;

        }

        public void AtualizarInvestidor()
        {
            InvestidorBLL a = new InvestidorBLL();
            Investidor Mostra = new Investidor();
            Mostra.ID_Investidor = 2;
            Mostra.Nome = TextoTeste.Text;
            Mostra.DDD = 5;


            Mostra = a.Alterar(Mostra);

            Label1.Text = Mostra.Nome;
        }

        public void AdicionarProjeto()
        {

            ProjetoBLL a = new ProjetoBLL();
            Projeto Mostra = new Projeto();
            Mostra.NomeProjeto = TextoTeste.Text;
            Mostra.DescricaoProjeto = "Teste";
            Mostra.Data = DateTime.Now;

            Mostra = a.Incluir(Mostra);

            Label1.Text = Mostra.NomeProjeto;

        }

        public void AtualizarProjeto()
        {
            ProjetoBLL a = new ProjetoBLL();
            Projeto Mostra = new Projeto();
            Mostra.ID_Projeto = 2;
            Mostra.DescricaoProjeto = TextoTeste.Text;
            Mostra.VideoProjeto = "teste";


            Mostra = a.Alterar(Mostra);

            Label1.Text = Mostra.DescricaoProjeto;
        }

        public void SelecionarProjetosInvestidos(int Id_Projeto)
        {
            InvestidorBLL a = new InvestidorBLL();
            List<ProjetosInvestidos> Mostra;
            Mostra = a.ListaProjetos(Id_Projeto);

            Label1.Text = Mostra[0].NomeProjeto;
        }

        public void AdicionarProjetosInvestidos()
        {

            ProjetoBLL a = new ProjetoBLL();
            ProjetosInvestidos Mostra = new ProjetosInvestidos();

            Mostra = a.InvestirProjeto(1, 1, 40);

            Label1.Text = Convert.ToString(Mostra.Valor);

        }

        public void AdicionarDocumento()
        {

            ProjetoBLL a = new ProjetoBLL();
            Documento Mostra = new Documento();
            Mostra.ID_Projeto = 2;
            Mostra.Titulo = TextoTeste.Text;
            Mostra.EnderecoDocumento = "teste";

            Mostra = a.IncluirDocumento(Mostra);

            Label1.Text = Convert.ToString(Mostra.Titulo);

        }

        public void AtualizarDocumento()
        {

            ProjetoBLL a = new ProjetoBLL();
            Documento Mostra = new Documento();
            Mostra.ID_Documento = 1;
            Mostra.Titulo = TextoTeste.Text;
            Mostra.EnderecoDocumento = "teste";

            Mostra = a.AtualizarDocumento(Mostra);

            Label1.Text = Convert.ToString(Mostra.Titulo);

        }

        public void ExcluirDocumento()
        {

            ProjetoBLL a = new ProjetoBLL();

            a.ExcluirDocumento(2);

        }

        public void AdicionarGrupoProjeto()
        {

            EmpreendedorBLL a = new EmpreendedorBLL();
            GrupoProjeto Mostra = new GrupoProjeto();
            Mostra.ID_Projeto = 1;
            Mostra.ID_Empreendedor = 1;

            Mostra = a.IncluirEmpreendedorProjeto(Mostra);

            Label1.Text = Convert.ToString(Mostra.Nome);

        }

        public void DarNotaProjeto()
        {
            ProjetoBLL a = new ProjetoBLL();
            a.DarNotaProjeto(1, 1, 5);
            SelecionarProjeto(1);
        }

        public void SelecionarProjeto(int Id_Projeto)
        {
            ProjetoBLL a = new ProjetoBLL();
            Projeto Mostra;
            Mostra = a.Selecionar(Id_Projeto);

            Label1.Text = Convert.ToString(Mostra.Ranking);
        }

        public void AdicionarProjetosVisitados()
        {

            ProjetoBLL a = new ProjetoBLL();
            ProjetosVisitados Mostra = new ProjetosVisitados();
            Mostra.ID_Projeto = 1;
            Mostra.ID_Projeto = 1;
            Mostra.ID_Investidor = 1;
            Mostra.Data = DateTime.Now;

            Mostra = a.IncluirProjetosVisitados(Mostra);

            Label1.Text = Convert.ToString(Mostra.Data);

        }

        public void testelogin()
        {
            POCO.Login login = new POCO.Login();
            LoginBLL loginCod = new LoginBLL();

            login.ID = 1;
            login.LOGIN = TextoTeste.Text;
            login.Tipo = "Investidor";

            loginCod.Incluir(login, "Jony1");

            if (loginCod.Login_Validar(login.LOGIN, "Jony1") == true)
            {
                Label1.Text = "OK";
            }
            else
            {
                Label1.Text = "Erro";
            }

            AdicionarCusto();

        }

    }
}