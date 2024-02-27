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
    public class clsFormCadCustoAgente : CustoBLL 
    {
        private LoginBLL _LoginBLL;
        public Login _Login;
        public ListaCusto _Custo;
        public string Tipo;
        public string Acao;
        public decimal ValorUpd;
        public DateTime DataUpd;
        public ListaCusto CustoUpd;
        public int ID;
        public int ID_Proj;

        public clsFormCadCustoAgente()
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

        public string Salvar(string DescCusto, string Valor, string Justificativa, string Data)
        {
            string Erro;
            _Custo = new ListaCusto();

            modLista Lista = new modLista();

            Erro = Validar(Valor, Data);

            if (Erro == "Sem Erros")
            {
                if (Tipo == "Add")
                {
                    _Custo.Descricao = DescCusto;
                    _Custo.CustoEstimado = Convert.ToDecimal(Valor);
                    _Custo.Justificativa = Justificativa;
                    _Custo.Data = Convert.ToDateTime(Data);
                    _Custo.Usuario = _Login.LOGIN;
                    _Custo.DataCad = DateTime.Now.Date;
                    _Custo.URLExcluir = "~/cadastroCustoAgenteEdicao.aspx?Tipo=" + Tipo + "&Acao=Excluir&Valor=" + Valor.Replace(".", "") + "&Data=" + Data.Replace("/", "");
                    _Custo.URLAtualizar = "~/FormCadCustoAgente.aspx?Tipo=" + Tipo + "&Acao=upd&ValorUpd=" + Valor.Replace(".", "") + "&DataUpd=" + Data.Replace("/", "");

                    if (Acao == "upd")
                        Lista.upd_ListaCusto(_Login.LOGIN, ValorUpd, DataUpd, _Custo);
                    else
                        Lista.Add_ListaCusto(_Custo);
                }
                else
                {
                    Custo _CustoUpd = new Custo();
                    _CustoUpd.ID_Custo = ID;
                    _CustoUpd.Descricao = DescCusto;
                    _CustoUpd.CustoEstimado = Convert.ToDecimal(Valor);
                    _CustoUpd.Justificativa = Justificativa;
                    _CustoUpd.Data = Convert.ToDateTime(Data);
                    Alterar(_CustoUpd, _Login.LOGIN);
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

        public void CarregaListaCusto()
        {
            List<ListaCusto> LstCusto;
            modLista Lista = new modLista();

            LstCusto = Lista.get_ListaCusto(_Login.LOGIN);

            for (int i = 0; i < LstCusto.Count; i++)
            {
                if (LstCusto[i].Data == DataUpd && LstCusto[i].CustoEstimado == ValorUpd)
                {
                    CustoUpd = new ListaCusto();
                    CustoUpd.CustoEstimado = LstCusto[i].CustoEstimado;
                    CustoUpd.Data = LstCusto[i].Data;
                    CustoUpd.DataCad = LstCusto[i].DataCad;
                    CustoUpd.Descricao = LstCusto[i].Descricao;
                    CustoUpd.ID_Custo = LstCusto[i].ID_Custo;
                    CustoUpd.ID_Projeto = LstCusto[i].ID_Projeto;
                    CustoUpd.Justificativa = LstCusto[i].Justificativa;
                    CustoUpd.URLAtualizar = LstCusto[i].URLAtualizar;
                    CustoUpd.URLExcluir = LstCusto[i].URLExcluir;
                    CustoUpd.Usuario = LstCusto[i].Usuario;
                }
            }
        }

        public void CarregaListaCustoUpd()
        {
            Custo LstCusto;
            modLista Lista = new modLista();

            LstCusto = Selecionar(ID);

            CustoUpd = new ListaCusto();
            CustoUpd.CustoEstimado = LstCusto.CustoEstimado;
            CustoUpd.Data = LstCusto.Data;
            CustoUpd.Descricao = LstCusto.Descricao;
            CustoUpd.ID_Custo = LstCusto.ID_Custo;
            CustoUpd.ID_Projeto = LstCusto.ID_Projeto;
            CustoUpd.Justificativa = LstCusto.Justificativa;

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