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
    public class clscadastroLucroAgenteEdicao : LucroBLL
    {
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        private LoginBLL _LoginBLL;
        private ProjetoBLL _ProjetoBLL;
        public List<ListaLucro> _ListaLucro;
        public String Tipo;

        public clscadastroLucroAgenteEdicao()
        {
            _ProjetoBLL = new ProjetoBLL();
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
            if (_Login != null)
                return _LoginBLL.VerificaLogado(_Login.LOGIN);
            else
                return false;
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

        public void CarregarListaLucro()
        {
            _ListaLucro = new List<ListaLucro>();
            modLista Lista = new modLista();
            _ListaLucro = Lista.get_ListaLucro(_Login.LOGIN);
        }

        public void CarregarListaLucroUpd(int ID_Projeto)
        {
            _ListaLucro = new List<ListaLucro>();
            List<Lucro> Lista = Listar(ID_Projeto);
            ListaLucro _LstLucro;

            for (int i = 0; i < Lista.Count; i++)
            {
                _LstLucro = new ListaLucro();
                _LstLucro.ID_Lucro = Lista[i].ID_Lucro;
                _LstLucro.ID_Projeto = Lista[i].ID_Projeto;
                _LstLucro.Descricao = Lista[i].Descricao;
                _LstLucro.ValorEstimado = Lista[i].ValorEstimado;
                _LstLucro.Justificativa = Lista[i].Justificativa;
                _LstLucro.Data = Lista[i].Data;
                _LstLucro.Usuario = _Login.LOGIN;
                _LstLucro.DataCad = DateTime.Now;
                _LstLucro.URLExcluir = "";
                _LstLucro.URLAtualizar = "~/FormCadLucroAgente.aspx?Tipo=" + Tipo + "&Acao=upd&ID=" + Lista[i].ID_Lucro + "&ID_Proj=" + Lista[i].ID_Projeto; ;
                _ListaLucro.Add(_LstLucro);
            }

        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
            if (_Login != null)
                _Log = _Login.LOGIN;
            _LoginBLL.Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

        public void ExcluirLucro(string Valor, string Data)
        {
            modLista Lista = new modLista();
            DateTime dData = Convert.ToDateTime(Formatar(Data, "##/##/####"));
            Decimal dValor = Convert.ToDecimal(Valor);

            Lista.del_ListaLucro(_Login.LOGIN, dValor, dData);
        }

        public static string Formatar(string valor, string mascara)
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