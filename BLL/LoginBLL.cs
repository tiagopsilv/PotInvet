using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;
using System.Web.Security;

namespace BLL
{
    public class LoginBLL
    {
        LoginDAL DAL;

        //private string hashMethod = "Investorpecuniacogitationesinsanasincolit";

        private string hashMethod = "CT";

        public LoginBLL()
        {
            DAL = new LoginDAL();
		}

        public bool Login_Validar(string login, string senha)
        {
            senha = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "md5");
            return DAL.Validar(login, senha);
		}

        public bool Incluir(Login Login, string senha)
        {
            senha = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "md5");
            return DAL.Incluir(Login, senha);
        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt = null, string login = null)
        {
            DAL.Incluir_Log(IP, Pagina, PaginaAnt, login);
        }

        public Login ConsultarLogin(string LOGIN)
        {
            return DAL.Login_Atual_Sel(LOGIN);
        }

        public bool VerificaLogado(string LOGIN)
        {
            return DAL.get_Logado(LOGIN);
        }

        public void SairLogin(string LOGIN)
        {
            DAL.SairLogin(LOGIN);
        }

        public Login Selecionar(string Login)
        {
            if (DAL.Login_Sel(Login).Count > 0)
                return DAL.Login_Sel(Login)[0];
            else
                return null;
        }

        public int Diff(Login _Login)
        {
            DateTime t_inicio = _Login.DataUltimo;
            DateTime t_fim;
            TimeSpan t_diferenca;

            t_fim = DateTime.Now;
            t_diferenca = t_fim.Subtract(t_inicio);
            return Convert.ToInt32(t_diferenca.TotalHours);

        }

        public void CarregarLogin(string Login, bool Logado)
        {
            DAL.CarregarLogin(Login, Logado);
        }

    }
}
