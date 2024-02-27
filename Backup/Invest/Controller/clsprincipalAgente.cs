using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsprincipalAgente : ProjetoBLL 
    {
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        private LoginBLL _LoginBLL;
        private ProjetoBLL _ProjetoBLL;
        public PesquisaBLL _PesquisaBLL;
        public List<ListaInvestidor> _ListaProjetos;

        public clsprincipalAgente()
        {
            _ProjetoBLL = new ProjetoBLL();
            _LoginBLL = new LoginBLL();
            _PesquisaBLL = new PesquisaBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            if (_Login != null)
                return _Login.LOGIN;
            else
                return null;
        }
        public bool VerificaLogin()
        {
            return _LoginBLL.VerificaLogado(_Login.LOGIN);
        }

        public void CarregarProjeto()
        {
            List<Projeto> _Projetos = new List<Projeto>();
            ListaInvestidor Proj;
            _Projetos = Listar(0, null, false, false, false, false, false, false, false, null, _Login.ID);

            _ListaProjetos = new List<ListaInvestidor>();

            for (int i = 0; i < _Projetos.Count; i++)
            {
                if (_Projetos[i].Porcentagem < 100)
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
                    Proj.Valor_Arrecadado = _Projetos[i].Valor_Arrecadado;
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
                    Proj.star1 = MostraEstrela(_Projetos[i].Ranking, 1);
                    Proj.star2 = MostraEstrela(_Projetos[i].Ranking, 2);
                    Proj.star3 = MostraEstrela(_Projetos[i].Ranking, 3);
                    Proj.star4 = MostraEstrela(_Projetos[i].Ranking, 4);
                    Proj.star5 = MostraEstrela(_Projetos[i].Ranking, 5);
                    Proj.Porcentagem100 = Porcentagem100(_Projetos[i].Porcentagem);
                    Proj.Porcentagem0 = Porcentagem0(_Projetos[i].Porcentagem);
                    Proj.Url = "~/AtualizaProjeto.aspx?ID=" + Convert.ToString(_Projetos[i].ID_Projeto);
                    Proj.UrlAtualizarCusto = "~/cadastroCustoAgenteEdicao.aspx?Tipo=Upd&ID=" + Convert.ToString(_Projetos[i].ID_Projeto);
                    Proj.UrlAtualizarLucro = "~/cadastroLucroAgenteEdicao.aspx?Tipo=Upd&ID=" + Convert.ToString(_Projetos[i].ID_Projeto);

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

            return Descricao;

        }

        private bool MostraEstrela(int Raking, int Orgem)
        {
            int valor = (5 * Raking) / 10;
            bool Resultado = false;
            switch (Orgem)
            {
                case 1:
                    if (valor >= 1)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 2:
                    if (valor >= 2)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 3:
                    if (valor >= 3)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 4:
                    if (valor >= 4)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
                case 5:
                    if (valor >= 5)
                        Resultado = true;
                    else
                        Resultado = false;
                    break;
            }
            return Resultado;
        }

        private int Porcentagem100(decimal Porcentagem)
        {
            return (600 * Convert.ToInt32(Porcentagem)) / 100;
        }

        private int Porcentagem0(decimal Porcentagem)
        {
            return 600 - Porcentagem100(Porcentagem);
        }

        public void CarregaProjetosVisitados()
        {
            ListaProjetosVisitados TempProjetosVisitados;
            bool Achou = false;
            int Linha = 4;
            List<ProjetosVisitados> _ListTemp;

            _ListTemp = _ProjetoBLL.SeleciorProjetosVisitados(0, _Login.ID);
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

        public void CarregarLogin(string Login, bool Logado)
        {
            _LoginBLL.CarregarLogin(Login, Logado);
            _Login = _LoginBLL.ConsultarLogin(Login);
        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
            if (_Login != null)
                _Log = _Login.LOGIN;
            _LoginBLL.Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

        public List<Mensagem> SelecionarMensagemAgente()
        {
            AgenteBLL BLL = new AgenteBLL();
            return BLL.SelecionarMensagem(_Login.ID);
        }

    }
}