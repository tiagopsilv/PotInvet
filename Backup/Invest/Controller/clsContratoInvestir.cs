using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using POCO;
using Invest.Model;

namespace Invest.Controller
{
    public class clsContratoInvestir : ProjetoBLL
    {
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        private LoginBLL _LoginBLL;
        public Projeto _Projeto;
        public int ID;
        public PesquisaBLL _PesquisaBLL;

        public clsContratoInvestir()
        {
            _LoginBLL = new LoginBLL();
            _PesquisaBLL = new PesquisaBLL();
        }
        public void Carregar(int ID_Projeto)
        {
            _Projeto = Selecionar(ID_Projeto);
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

        public string Salvar(string Valor, bool Aceite)
        {
            string Erro;
            Erro = Validar(Valor, Aceite);
            if (Erro == "Sem Erros")
            {
                InvestirProjeto(_Projeto.ID_Projeto, _Login.ID, Convert.ToDecimal(Valor), _Login.LOGIN);
            }

            return Erro;

        }

        private string Validar(string Valor, bool Aceite)
        {

            //Validar campo obrigatórios.

            if (Aceite == false)
                return "Para cadastrar-se é obrigatório o aceite do contrato.";

            Valor = Valor.Trim();
            if (Valor.Length <= 0)
                return "Preencimento do Campo Valor é obrigatório.";

            if (ValidaInt(Valor) == false)
                return "O campo Valor só aceita valores númericos.";

            if (Convert.ToDecimal(Valor) > (_Projeto.Custo_Projeto - _Projeto.Valor_Arrecadado))
                return "Valor limete é R$" + Convert.ToString((_Projeto.Custo_Projeto - _Projeto.Valor_Arrecadado));

            return "Sem Erros";
        }

        public bool ValidaInt(string Valor)
        {
            decimal result;
            Valor = Valor.Replace(".", "").Replace(",", "").Replace("R", "").Replace("$", "");
            if (decimal.TryParse(Valor, out result))
                return true;
            else
                return false;
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