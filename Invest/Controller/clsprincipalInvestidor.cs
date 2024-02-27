using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsprincipalInvestidor : InvestidorBLL
    {
        private LoginBLL _LoginBLL;
        public Investidor _Investidor;
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        public ProjetoBLL _ProjetoBLL;
        public List<ListaInvestidor> _ListaProjetos;
        private InvestidorBLL _InvestidorBLL;
        public PesquisaBLL _PesquisaBLL;

        public clsprincipalInvestidor()
        {
            _LoginBLL = new LoginBLL();
            _ProjetoBLL = new ProjetoBLL();
            _Investidor = new Investidor();
            _InvestidorBLL = new InvestidorBLL();
            _PesquisaBLL = new PesquisaBLL();
        }
        public Login Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            return _Login;
        }
        public bool VerificaLogin()
        {
            return _LoginBLL.VerificaLogado(_Login.LOGIN);
        }

        public void CarregarLogin(string Login, bool Logado)
        {
            _LoginBLL.CarregarLogin(Login, Logado);
            _Login = _LoginBLL.ConsultarLogin(Login);
        }

        public void CarregaInvestidor()
        {
            _Investidor = _InvestidorBLL.Selecionar(Usuario().ID);
        }

        public void CarregaProjetosVisitados()
        {
            ListaProjetosVisitados TempProjetosVisitados;
            bool Achou = false;
            int Linha = 4;
            List<ProjetosVisitados> _ListTemp;

            _ListTemp = _ProjetoBLL.SeleciorProjetosVisitados(0, Usuario().ID);
            _ProjetosVisitados = new List<ListaProjetosVisitados>();

            if (_ListTemp.Count < 4)
            {
                Linha = _ListTemp.Count;
            }

            for (int i = 0; i < Linha; i++)
            {
                Achou = false;
                TempProjetosVisitados = new ListaProjetosVisitados();

                for (int j = 0; j < _ProjetosVisitados.Count; j++)
                {
                    if (_ListTemp[i].ID_Projeto == _ProjetosVisitados[j].ID_Projeto)
                    {
                        Achou = true;
                        break;
                    }
                }
                if (Achou == false)
                {
                    TempProjetosVisitados.ID_ProjetoVisitados = _ListTemp[i].ID_ProjetoVisitados;
                    TempProjetosVisitados.ID_Projeto = _ListTemp[i].ID_Projeto;
                    TempProjetosVisitados.ID_Investidor = _ListTemp[i].ID_Investidor;
                    TempProjetosVisitados.Data = _ListTemp[i].Data;
                    TempProjetosVisitados.Hora = _ListTemp[i].Hora;
                    TempProjetosVisitados.NomeProjeto = _ListTemp[i].NomeProjeto;
                    TempProjetosVisitados.Url = "~/projeto.aspx?ID=" + Convert.ToString(_ListTemp[i].ID_Projeto); ;

                    _ProjetosVisitados.Add(TempProjetosVisitados);
                }
            }
        }

        public string Get_Tipo()
        {
            if (_Login != null)
            {
                _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
                if (_Login.LOGIN != null)
                    return _Login.Tipo;
                else
                    return "Investidor";
            }
            else
                return "Investidor";
        }

        public void SairLogin()
        {
            _LoginBLL.SairLogin(_Login.LOGIN);
        }

        public void CarregarProjetos(int ID_Investidor = 0)
        {
            bool bAchou = false;
            List<ProjetosInvestidos> _Projetos = new List<ProjetosInvestidos>();
            ListaInvestidor Proj;
            _Projetos = ListaProjetos(ID_Investidor);

            _Projetos.Distinct();

            _ListaProjetos = new List<ListaInvestidor>();

            for (int i = 0; i < _Projetos.Count; i++)
            {
                bAchou = false;
                for (int j = 0; j < _ListaProjetos.Count; j++)
                {
                    if (_Projetos[i].ID_Projeto == _ListaProjetos[j].ID_Projeto)
                    {
                        bAchou = true;
                    }
                }
                if (bAchou == false)
                {
                    Proj = new ListaInvestidor();
                    Proj.ID_Projeto = _Projetos[i].ID_Projeto;
                    Proj.NomeProjeto = _Projetos[i].NomeProjeto;
                    Proj.DescricaoProjeto = _Projetos[i].DescricaoProjeto;
                    Proj.ImagemProjeto = _Projetos[i].ImagemProjeto;
                    Proj.VideoProjeto = _Projetos[i].VideoProjeto;
                    Proj.PerfilProjeto = _Projetos[i].PerfilProjeto;
                    Proj.RamoAtividade = _Projetos[i].RamoAtividade;
                    Proj.Ranking = _Projetos[i].Ranking;
                    Proj.Custo_Projeto = _Projetos[i].Custo_Projeto;
                    Proj.Valor_Arrecadado = ValorInvestido(_Projetos[i].ID_Projeto);
                    Proj.Porcentagem = _Projetos[i].Porcentagem;
                    Proj.Data = _Projetos[i].Data;
                    Proj.Email = _Projetos[i].Email;
                    Proj.DDD = _Projetos[i].DDD;
                    Proj.Telefone = _Projetos[i].Telefone;
                    Proj.Endereco = _Projetos[i].Endereco;
                    Proj.Cidade = _Projetos[i].Cidade;
                    Proj.Estado = _Projetos[i].Estado;
                    Proj.ImgApres = _Projetos[i].ImgApres;
                    Proj.TextoResumo = FormataDescricao(_Projetos[i].DescricaoProjeto);
                    Proj.Url = "~/investidorDetalhes.aspx?ID=" + Convert.ToString(_Projetos[i].ID_Projeto);
                    Proj.ID_Agente = _Projetos[i].ID_Agente;

                    _ListaProjetos.Add(Proj);
                }
            }
        }

        private string FormataDescricao(string Descricao)
        {
            int iMax = 100;

            Descricao = Descricao.Replace("<p>", "").Replace("</p>", "").Replace("<br />", "").Replace("<em>", "").Replace("</em>", "");

            if (Descricao.Length > 100)
            {
                while (Descricao.Substring(iMax, 1) != " ")
                {
                    iMax++;
                }

                Descricao = Descricao.Substring(0, iMax);
            }

            return Descricao + "...";

        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
            if (_Login != null)
                _Log = _Login.LOGIN;
            _LoginBLL.Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

        public decimal ValorInvestido(int ID_Projeto)
        {
            decimal val = 0;
            List<ProjetosInvestidos> ListaInvestidos = new List<ProjetosInvestidos>();
            ListaInvestidos = _ProjetoBLL.SelecionarProjetosInvestidos(0, _Login.ID, ID_Projeto);
            for (int i = 0; i < ListaInvestidos.Count; i++)
            {
                val += ListaInvestidos[i].Valor;
            }
            return val;
        }

    }
}