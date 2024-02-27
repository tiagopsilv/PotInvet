using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;

namespace Invest.Controller 
{
    public class clsLogin : LoginBLL
    {

        public string Tipo = "";
        public Login _Login;

        public bool Logar(string Usuario, string Senha)
        {
            bool validar = false;
            _Login = new Login();

            validar = Login_Validar(Usuario, Senha);

            if (validar == true)
            {
                _Login = ConsultarLogin(Usuario);
                Tipo = _Login.Tipo;
            }
            return validar;
        }

        public string Get_Tipo(string Login)
        {
            _Login = ConsultarLogin(Login);
            if (_Login.LOGIN != null)
                return _Login.Tipo;
            else
                return "Investidor";
        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
                if (_Login != null)
                    _Log = _Login.LOGIN;
            Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

    }
}