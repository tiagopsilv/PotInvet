using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsAtualizaProjeto : ProjetoBLL 
    {
        private LoginBLL _LoginBLL;
        private AgenteBLL _AgenteBLL; 
        public Login _Login;
        public EmpreendedorBLL _EmpreendedorBLL;

        public CustoBLL _CustoBLL;
        public LucroBLL _LucroBLL;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        public List<ListaEmpreendedor> _ListaEmpreendedor;
        public List<ListaCusto> _ListaCusto;
        public List<ListaLucro> _ListaLucro;
        public ListaProjeto _Projeto;
        public string Tipo;
        public string ID_Agente;
        public int ID_Projeto;

        public clsAtualizaProjeto()
        {
            _LoginBLL = new LoginBLL();
            _EmpreendedorBLL = new EmpreendedorBLL();
            _CustoBLL = new CustoBLL();
            _LucroBLL = new LucroBLL();
            _AgenteBLL = new AgenteBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            if (_Login != null)
                return _Login.LOGIN;
            else
                return null;
        }
        public bool VerificaLogin(string LOGIN)
        {
            return _LoginBLL.VerificaLogado(LOGIN);
        }

        public void CarregaProjetosVisitados()
        {
            ListaProjetosVisitados TempProjetosVisitados;
            bool Achou = false;
            int Linha = 4;
            List<ProjetosVisitados> _ListTemp;

            _ListTemp = SeleciorProjetosVisitados(0, _Login.ID);
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
    }
}