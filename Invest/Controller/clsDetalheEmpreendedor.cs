using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsDetalheEmpreendedor : EmpreendedorBLL
    {
        public Login _Login;
        private LoginBLL _LoginBLL;
        public List<Documento> _Documento;
        public int ID;
        public int ID_Projeto;
        public string Tipo = "Projeto";
        public Empreendedor _Empreendedor;

        public clsDetalheEmpreendedor()
        {
            _LoginBLL = new LoginBLL();
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

        public void CarregarEmpreendedor(int ID)
        {
            _Empreendedor = Selecionar(ID);
        }

        public string multiplica(string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }

            return sb.ToString();
        }

    }
}