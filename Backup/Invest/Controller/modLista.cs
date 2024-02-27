using System;
using System.Web;
using System.Collections.Generic;
using Invest.Model;
using POCO;

namespace Invest.Controller
{
    public class modLista : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.LogRequest += new EventHandler(OnLogRequest);
        }

        #endregion

        public static List<ListaEmpreendedor> _ListaEmpreendedor = new List<ListaEmpreendedor>();
        public static List<ListaProjeto> _ListaProjeto = new List<ListaProjeto>();
        public static List<ListaCusto> _ListaCusto = new List<ListaCusto>();
        public static List<ListaLucro> _ListaLucro = new List<ListaLucro>();

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }

        public void Add_ListaEmpreendedor(ListaEmpreendedor Lista)
        {
            _ListaEmpreendedor.Add(Lista);
        }

        public void Add_ListaProjeto(ListaProjeto Lista)
        {
            _ListaProjeto.Add(Lista);
        }

        public void Add_ListaCusto(ListaCusto Lista)
        {
            _ListaCusto.Add(Lista);
        }

        public void Add_ListaLucro(ListaLucro Lista)
        {
            _ListaLucro.Add(Lista);
        }

        public List<ListaEmpreendedor> get_ListaEmpreendedor(string Usuario)
        {
            List<ListaEmpreendedor> Lista = new List<ListaEmpreendedor>();

            for (int i = 0; i < _ListaEmpreendedor.Count; i++)
            {
                if (_ListaEmpreendedor[i].Usuario == Usuario)
                {
                    Lista.Add(_ListaEmpreendedor[i]);
                }
            }

            return _ListaEmpreendedor;
        }

        public List<ListaProjeto> get_ListaProjeto(string Usuario)
        {
            List<ListaProjeto> Lista = new List<ListaProjeto>();

            for (int i = 0; i < _ListaProjeto.Count; i++)
            {
                if (_ListaProjeto[i].Usuario == Usuario)
                {
                    Lista.Add(_ListaProjeto[i]);
                }
            }

            return _ListaProjeto;
        }

        public List<ListaCusto> get_ListaCusto(string Usuario)
        {
            List<ListaCusto> Lista = new List<ListaCusto>();

            for (int i = 0; i < _ListaCusto.Count; i++)
            {
                if (_ListaCusto[i].Usuario == Usuario)
                {
                    Lista.Add(_ListaCusto[i]);
                }
            }

            return _ListaCusto;
        }

        public List<ListaLucro> get_ListaLucro(string Usuario)
        {
            List<ListaLucro> Lista = new List<ListaLucro>();

            for (int i = 0; i < _ListaLucro.Count; i++)
            {
                if (_ListaLucro[i].Usuario == Usuario)
                {
                    Lista.Add(_ListaLucro[i]);
                }
            }

            return _ListaLucro;
        }

        public List<ListaEmpreendedor> del_ListaEmpreendedor(string cpf)
        {
            List<ListaEmpreendedor> Lista = new List<ListaEmpreendedor>();

            for (int i = 0; i < _ListaEmpreendedor.Count; i++)
            {
                if (_ListaEmpreendedor[i].CPF == cpf)
                {
                    _ListaEmpreendedor.RemoveAt(i);
                }
            }

            return _ListaEmpreendedor;
        }

        public List<ListaProjeto> del_ListaProjeto(string Usuario)
        {
            List<ListaProjeto> Lista = new List<ListaProjeto>();

            for (int i = 0; i < _ListaProjeto.Count; i++)
            {
                if (_ListaProjeto[i].Usuario == Usuario)
                {
                    _ListaProjeto.RemoveAt(i);
                }
            }

            return _ListaProjeto;
        }

        public List<ListaCusto> del_ListaCusto(string Usuario, decimal Valor, DateTime Data)
        {
            List<ListaCusto> Lista = new List<ListaCusto>();

            for (int i = 0; i < _ListaCusto.Count; i++)
            {
                if (_ListaCusto[i].Usuario == Usuario && _ListaCusto[i].CustoEstimado == Valor && _ListaCusto[i].Data == Data)
                {
                    _ListaCusto.RemoveAt(i);
                }
            }

            return _ListaCusto;
        }

        public List<ListaLucro> del_ListaLucro(string Usuario, decimal Valor, DateTime Data)
        {
            List<ListaLucro> Lista = new List<ListaLucro>();

            for (int i = 0; i < _ListaLucro.Count; i++)
            {
                if (_ListaLucro[i].Usuario == Usuario && _ListaLucro[i].ValorEstimado == Valor && _ListaLucro[i].Data == Data)
                {
                    _ListaLucro.RemoveAt(i);
                }
            }

            return _ListaLucro;
        }

        public List<ListaCusto> upd_ListaCusto(string Usuario, decimal ValorAnd, DateTime DataAnd, ListaCusto Lista)
        {
            
            for (int i = 0; i < _ListaCusto.Count; i++)
            {
                if (_ListaCusto[i].Usuario == Usuario && _ListaCusto[i].CustoEstimado == ValorAnd && _ListaCusto[i].Data == DataAnd)
                {
                    _ListaCusto[i].CustoEstimado = Lista.CustoEstimado;
                    _ListaCusto[i].Data = Lista.Data;
                    _ListaCusto[i].DataCad = Lista.DataCad;
                    _ListaCusto[i].Descricao = Lista.Descricao;
                    _ListaCusto[i].ID_Custo = Lista.ID_Custo;
                    _ListaCusto[i].ID_Projeto = Lista.ID_Projeto;
                    _ListaCusto[i].Justificativa = Lista.Justificativa;
                    _ListaCusto[i].URLAtualizar = Lista.URLAtualizar;
                    _ListaCusto[i].URLExcluir = Lista.URLExcluir;
                    _ListaCusto[i].Usuario = Lista.Usuario;
                }
            }

            return _ListaCusto;
        }

        public List<ListaLucro> upd_ListaLucro(string Usuario, decimal ValorAnd, DateTime DataAnd, ListaLucro Lista)
        {

            for (int i = 0; i < _ListaLucro.Count; i++)
            {
                if (_ListaLucro[i].Usuario == Usuario && _ListaLucro[i].ValorEstimado == ValorAnd && _ListaLucro[i].Data == DataAnd)
                {
                    _ListaLucro[i].ValorEstimado = Lista.ValorEstimado;
                    _ListaLucro[i].Data = Lista.Data;
                    _ListaLucro[i].DataCad = Lista.DataCad;
                    _ListaLucro[i].Descricao = Lista.Descricao;
                    _ListaLucro[i].ID_Lucro = Lista.ID_Lucro;
                    _ListaLucro[i].ID_Projeto = Lista.ID_Projeto;
                    _ListaLucro[i].Justificativa = Lista.Justificativa;
                    _ListaLucro[i].URLAtualizar = Lista.URLAtualizar;
                    _ListaLucro[i].URLExcluir = Lista.URLExcluir;
                    _ListaLucro[i].Usuario = Lista.Usuario;
                }
            }

            return _ListaLucro;
        }

        public bool set_AlteracaoCadastroAgente(string Usuario, bool valor)
        {

            bool achou = false;

            for (int i = 0; i < _ListaProjeto.Count; i++)
            {
                if (_ListaProjeto[i].Usuario == Usuario)
                {
                    _ListaProjeto[i].AlteracaoCadastroAgente = valor;
                    achou = true;
                }
            }

            return achou;

        }

        public void del_Tudo(string Usuario)
        {
            //Exclui lista de empresa
            for (int i = 0; i < _ListaEmpreendedor.Count; i++)
            {
                if (_ListaEmpreendedor[i].Usuario == Usuario)
                {
                    _ListaEmpreendedor.RemoveAt(i);
                }
            }

            //Exclui lista de Projeto
            for (int i = 0; i < _ListaProjeto.Count; i++)
            {
                if (_ListaProjeto[i].Usuario == Usuario)
                {
                    _ListaProjeto.RemoveAt(i);
                }
            }

            //Exclui lista de Custo
            for (int i = 0; i < _ListaCusto.Count; i++)
            {
                if (_ListaCusto[i].Usuario == Usuario)
                {
                    _ListaCusto.RemoveAt(i);
                }
            }

            //Exclui lista de Lucro
            for (int i = 0; i < _ListaLucro.Count; i++)
            {
                if (_ListaLucro[i].Usuario == Usuario)
                {
                    _ListaLucro.RemoveAt(i);
                }
            }

        }

    }
}
