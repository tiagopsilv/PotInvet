using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;

namespace Invest.Controller
{
    public class clsHome
    {
        private ProjetoBLL _ProjetoBLL;
        public LoginBLL _LoginBLL;
        private List<Projeto> ListaProjeto;
        public Login _Login;

        public string DescrProjeto1;
        public string DescrProjeto2;
        public string DescrProjeto3;

        public string LinckProjeto1;
        public string LinckProjeto2;
        public string LinckProjeto3;

        public string img1;
        public string img2;
        public string img3;

        public clsHome()
        {
            _ProjetoBLL = new ProjetoBLL();
            _LoginBLL = new LoginBLL();
        }

        public void CarregarProjetos()
        {
            int i = 0;
            ListaProjeto = _ProjetoBLL.Listar();

            while (LinckProjeto3 == null && i < ListaProjeto.Count)
            {

                if (ListaProjeto[i].Custo_Projeto > ListaProjeto[i].Valor_Arrecadado)
                {
                    if (LinckProjeto1 == null)
                    {
                        DescrProjeto1 = FormataDescricao(ListaProjeto[i].DescricaoProjeto);
                        LinckProjeto1 = "~/projeto.aspx?ID=" + Convert.ToString(ListaProjeto[i].ID_Projeto);
                        img1 = ListaProjeto[i].ImgApres;
                    }
                    else
                    {
                        if (LinckProjeto2 == null)
                        {
                            DescrProjeto2 = FormataDescricao(ListaProjeto[i].DescricaoProjeto);
                            LinckProjeto2 = "~/projeto.aspx?ID=" + Convert.ToString(ListaProjeto[i].ID_Projeto);
                            img2 = ListaProjeto[i].ImgApres;
                        }
                        else
                        {
                            if (LinckProjeto3 == null)
                            {
                                DescrProjeto3 = FormataDescricao(ListaProjeto[i].DescricaoProjeto);
                                LinckProjeto3 = "~/projeto.aspx?ID=" + Convert.ToString(ListaProjeto[i].ID_Projeto);
                                img3 = ListaProjeto[i].ImgApres;
                            }
                        }
                    }
                }

              i++;
            }
        }

        private string FormataDescricao(string Descricao)
        {
            int iMax = 600;

            Descricao = Descricao.Replace("<p>", "").Replace("</p>", "").Replace("<br />", "").Replace("<em>", "").Replace("</em>", "");

            if (Descricao.Length > 600)
            {
                while (Descricao.Substring(iMax, 1) != " ")
                {
                    iMax++;
                }

                Descricao = Descricao.Substring(0, iMax);
            }

            return Descricao + "...";

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