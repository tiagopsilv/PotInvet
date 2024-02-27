using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsmensagem
    {
        public Login _Login;
        private InvestidorBLL _InvestidorBLL;
        private AgenteBLL _AgenteBLL;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        private ProjetoBLL _ProjetoBLL;
        private LoginBLL _LoginBLL;
        private Mensagem _Mensagem;

        public clsmensagem()
        {
            _LoginBLL = new LoginBLL();
             _InvestidorBLL = new InvestidorBLL();
             _AgenteBLL = new AgenteBLL();
             _ProjetoBLL = new ProjetoBLL();
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
        public void CarregaMensagem(int IDMensagem, string Tipo)
        {
            switch (Tipo)
            {
                case "Agente":
                    _Mensagem = _AgenteBLL.SelecionarMensagem(IDMensagem)[0];
                    break;
                case "Investidor":
                    _Mensagem = _InvestidorBLL.SelecionarMensagem(IDMensagem)[0];
                    break;
                case "Projeto":
                    _Mensagem = _ProjetoBLL.SelecionarMensagem(IDMensagem)[0];
                    break;
            }
        }
        public string Titulo()
        {
            return _Mensagem.Titulo;
        }
        public string Data()
        {
            return Convert.ToString(_Mensagem.Data);
        }
        public string UsuarioMensagem()
        {
            return Convert.ToString(_Mensagem.Usuario);
        }
        public string Texto()
        {
            return _Mensagem.Texto;
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

    }
}