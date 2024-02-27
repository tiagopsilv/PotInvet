using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsSobre
    {
        public Login _Login;
        private LoginBLL _LoginBLL;
        private ProjetoBLL _ProjetoBLL;

        public clsSobre()
        {
            _ProjetoBLL = new ProjetoBLL();
            _LoginBLL = new LoginBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            return _Login.LOGIN;
        }
        public bool VerificaLogin(string Usuario)
        {
            if (_Login == null)
                return _LoginBLL.VerificaLogado(Usuario);
            else
                return _LoginBLL.VerificaLogado(_Login.LOGIN);
        }

        public string Get_Tipo(string Usuario = "")
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
    }
}