using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsFormCadLucroAgente : LucroBLL
    {
        private LoginBLL _LoginBLL;
        public Login _Login;
        public ListaLucro _Lucro;
        public string Tipo;
        public string Acao;
        public decimal ValorUpd;
        public DateTime DataUpd;
        public ListaLucro LucroUpd;
        public int ID;
        public int ID_Proj;

        public clsFormCadLucroAgente()
        {
            _LoginBLL = new LoginBLL();
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

        public string Salvar(string DescLucro, string Valor, string Justificativa, string Data)
        {
            string Erro;
            _Lucro = new ListaLucro();

            modLista Lista = new modLista();

            Erro = Validar(Valor, Data);

            if (Erro == "Sem Erros")
            {
                if (Tipo == "Add")
                {
                    _Lucro.Descricao = DescLucro;
                    _Lucro.ValorEstimado = Convert.ToDecimal(Valor);
                    _Lucro.Justificativa = Justificativa;
                    _Lucro.Data = Convert.ToDateTime(Data);
                    _Lucro.Usuario = _Login.LOGIN;
                    _Lucro.DataCad = DateTime.Now.Date;
                    _Lucro.URLExcluir = "~/cadastroLucroAgenteEdicao.aspx?Tipo=" + Tipo + "&Acao=Excluir&Valor=" + Valor.Replace(".", "") + "&Data=" + Data.Replace("/", "");
                    _Lucro.URLAtualizar = "~/FormCadLucroAgente.aspx?Tipo=" + Tipo + "&Acao=upd&ValorUpd=" + Valor.Replace(".", "") + "&DataUpd=" + Data.Replace("/", "");

                    if (Acao == "upd")
                        Lista.upd_ListaLucro(_Login.LOGIN, ValorUpd, DataUpd, _Lucro);
                    else
                        Lista.Add_ListaLucro(_Lucro);
                }
                else
                {
                    Lucro _LucroUpd = new Lucro();
                    _LucroUpd.ID_Lucro = ID;
                    _LucroUpd.Descricao = DescLucro;
                    _LucroUpd.ValorEstimado = Convert.ToDecimal(Valor);
                    _LucroUpd.Justificativa = Justificativa;
                    _LucroUpd.Data = Convert.ToDateTime(Data);
                    Alterar(_LucroUpd, _Login.LOGIN);
                }

            }

            return Erro;
        }

        private string Validar(string Valor, string Data)
        {
            Valor = Valor.Trim();
            if (Valor.Length <= 0)
                return "Preencimento do Campo Valor é obrigatório.";

            Data = Data.Trim();
            if (Data.Length <= 0)
                return "Preencimento do Campo Data é obrigatório.";

            if (ValidaInt(Valor.Replace(".", "").Replace(",","")) == false)
                return "O campo Valor só aceita valores númericos.";

            if (ValidaDate(Data) == false)
                return "O campo Data só aceita valores númericos.";

            return "Sem Erros";
        }

        public bool ValidaDate(string Valor)
        {
            DateTime result;
            if (DateTime.TryParse(Valor, out result))
                return true;
            else
                return false;
        }

        public bool ValidaInt(string Valor)
        {
            int result;
            if (int.TryParse(Valor, out result))
                return true;
            else
                return false;
        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
            if (_Login != null)
                _Log = _Login.LOGIN;
            _LoginBLL.Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

        public void CarregaListaLucro()
        {
            List<ListaLucro> LstLucro;
            modLista Lista = new modLista();

            LstLucro = Lista.get_ListaLucro(_Login.LOGIN);

            for (int i = 0; i < LstLucro.Count; i++)
            {
                if (LstLucro[i].Data == DataUpd && LstLucro[i].ValorEstimado == ValorUpd)
                {
                    LucroUpd = new ListaLucro();
                    LucroUpd.ValorEstimado = LstLucro[i].ValorEstimado;
                    LucroUpd.Data = LstLucro[i].Data;
                    LucroUpd.DataCad = LstLucro[i].DataCad;
                    LucroUpd.Descricao = LstLucro[i].Descricao;
                    LucroUpd.ID_Lucro = LstLucro[i].ID_Lucro;
                    LucroUpd.ID_Projeto = LstLucro[i].ID_Projeto;
                    LucroUpd.Justificativa = LstLucro[i].Justificativa;
                    LucroUpd.URLAtualizar = LstLucro[i].URLAtualizar;
                    LucroUpd.URLExcluir = LstLucro[i].URLExcluir;
                    LucroUpd.Usuario = LstLucro[i].Usuario;
                }
            }
        }

        public void CarregaListaLucroUpd()
        {
            Lucro LstLucro;
            modLista Lista = new modLista();

            LstLucro = Selecionar(ID);

            LucroUpd = new ListaLucro();
            LucroUpd.ValorEstimado = LstLucro.ValorEstimado;
            LucroUpd.Data = LstLucro.Data;
            LucroUpd.Descricao = LstLucro.Descricao;
            LucroUpd.ID_Lucro = LstLucro.ID_Lucro;
            LucroUpd.ID_Projeto = LstLucro.ID_Projeto;
            LucroUpd.Justificativa = LstLucro.Justificativa;

        }

        public string Formatar(string valor, string mascara)
        {
            StringBuilder dado = new StringBuilder();
            // remove caracteres nao numericos
            foreach (char c in valor)
            {
                if (Char.IsNumber(c))
                    dado.Append(c);
            }
            int indMascara = mascara.Length;
            int indCampo = dado.Length;
            for (; indCampo > 0 && indMascara > 0; )
            {
                if (mascara[--indMascara] == '#')
                    indCampo--;
            }
            StringBuilder saida = new StringBuilder();
            for (; indMascara < mascara.Length; indMascara++)
            {
                saida.Append((mascara[indMascara] == '#') ? dado[indCampo++] : mascara[indMascara]);
            }
            return saida.ToString();
        }
    }
}