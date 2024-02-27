using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsDownloads : ProjetoBLL
    {
        public Login _Login;
        private LoginBLL _LoginBLL;
        public List<Documento> _Documento;
        public int ID;

        public clsDownloads()
        {
            _LoginBLL = new LoginBLL();
        }
        
        public void carregarDoc(int id)
        {
            _Documento = new List<Documento>();
            _Documento = SeleciorDocumento(0, id);
        }

        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            return _Login.LOGIN;
        }

        public bool VerificaLogin()
        {
            if (_Login != null)
                return _LoginBLL.VerificaLogado(_Login.LOGIN);
            else
                return false;
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