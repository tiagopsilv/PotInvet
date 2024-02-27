using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;


namespace Invest.Controller
{
    public class clsPesquisa : PesquisaBLL
    {
        public Login _Login;
        private LoginBLL _LoginBLL;
        private ProjetoBLL _ProjetoBLL;
        public List<ListaProjetosVisitados> _ProjetosVisitados;

        public bool b1 = false;
        public bool b2 = false;
        public bool b3 = false;
        public bool b4 = false;
        public bool b5 = false;
        public bool b6 = false;
        public bool b7 = false;
        public bool b8 = false;
        public bool b9 = false;
        public bool b10 = false;
        public bool b11 = false;
        public bool b12 = false;

        public clsPesquisa()
        {
            _ProjetoBLL = new ProjetoBLL();
            _LoginBLL = new LoginBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            return _Login.LOGIN;
        }
        public bool VerificaLogin()
        {
            return _LoginBLL.VerificaLogado(_Login.LOGIN);
        }

        public string Get_Tipo(string Usuario)
        {
            _Login = _LoginBLL.ConsultarLogin(Usuario);
            if (_Login.LOGIN != null)
                return _Login.Tipo;
            else
                return "Investidor";
        }

        public void SairLogin(string Usuario)
        {
            _LoginBLL.SairLogin(Usuario);
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

        public string Salvar(int ID_Pergunta, bool Sim, bool Nao, string s1 = null)
        {
            Pesquisa Pesq = new Pesquisa();

            Pesq.ID_Investidor = _Login.ID;
            Pesq.ID_Pergunta = ID_Pergunta;
            Pesq.Tipo = _Login.Tipo;
            if (Sim == true)
                Pesq.Opcao = true;
            else
                Pesq.Opcao = false;

            if (s1 != null && s1 != "")
            {
                Pesq.Resposta = s1;
            }

            Incluir(Pesq, _Login.LOGIN);

            return "";
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

    }
}