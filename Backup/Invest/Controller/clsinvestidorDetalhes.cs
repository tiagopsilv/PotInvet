using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;

namespace Invest.Controller
{
    public class clsinvestidorDetalhes : ProjetoBLL
    {
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        private LoginBLL _LoginBLL;
        private EmpreendedorBLL _EmpreendedorBLL;
        public ListaInvestidor _Projeto;
        public List<Documento> _Documento;

        public clsinvestidorDetalhes()
        {
            _LoginBLL = new LoginBLL();
            _EmpreendedorBLL = new EmpreendedorBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
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

        public void CarregaProjetosVisitados()
        {
            ListaProjetosVisitados TempProjetosVisitados;
            bool Achou = false;
            List<ProjetosVisitados> _ListTemp;

            _ListTemp = SeleciorProjetosVisitados(0, _Login.ID);
            _ProjetosVisitados = new List<ListaProjetosVisitados>();

            for (int i = 0; i < _ListTemp.Count; i++)
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
                    TempProjetosVisitados.Url = "~/projeto.aspx?ID=" + Convert.ToString(_ListTemp[i].ID_Projeto);

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

        public void CarregaProjeto(int ID_Projeto)
        {
            Projeto _Proj = new Projeto();
            _Proj = Listar(ID_Projeto)[0];

            _Projeto = new ListaInvestidor();

            _Projeto = new ListaInvestidor();
            _Projeto.ID_Projeto = _Proj.ID_Projeto;
            _Projeto.NomeProjeto = _Proj.NomeProjeto;
            _Projeto.DescricaoProjeto = _Proj.DescricaoProjeto;
            _Projeto.ImagemProjeto = _Proj.ImagemProjeto;
            _Projeto.VideoProjeto = _Proj.VideoProjeto;
            _Projeto.PerfilProjeto = _Proj.PerfilProjeto;
            _Projeto.RamoAtividade = _Proj.RamoAtividade;
            _Projeto.Ranking = _Proj.Ranking;
            _Projeto.Custo_Projeto = _Proj.Custo_Projeto;
            _Projeto.Valor_Arrecadado = _Proj.Valor_Arrecadado;
            _Projeto.Porcentagem = _Proj.Porcentagem;
            _Projeto.Data = _Proj.Data;
            _Projeto.Email = _Proj.Email;
            _Projeto.DDD = _Proj.DDD;
            _Projeto.Telefone = _Proj.Telefone;
            _Projeto.Endereco = _Proj.Endereco;
            _Projeto.Cidade = _Proj.Cidade;
            _Projeto.Estado = _Proj.Estado;
            _Projeto.Url = "~/projeto.aspx?ID=" + Convert.ToString(_Proj.ID_Projeto);

        }

        public List<ListaEmpreendedor> ListaEmpreendedores(int ID_Projeto)
        {

            List<GrupoProjeto> _ListaGrupo;
            List<ListaEmpreendedor> tempLista = new List<ListaEmpreendedor>();
            ListaEmpreendedor _ListaEmpreendedor;

            _ListaGrupo = _EmpreendedorBLL.ListaGrupoProjetos(0, ID_Projeto);

            for (int i = 0; i < _ListaGrupo.Count; i++)
            {
                _ListaEmpreendedor = new ListaEmpreendedor();

                _ListaEmpreendedor.ID_Empreendedor = _ListaGrupo[i].ID_Empreendedor;
                _ListaEmpreendedor.CPF = _ListaGrupo[i].CPF;
                _ListaEmpreendedor.Nome = _ListaGrupo[i].Nome;
                _ListaEmpreendedor.WebPage = _ListaGrupo[i].WebPage;
                _ListaEmpreendedor.Foto = _ListaGrupo[i].Foto;
                _ListaEmpreendedor.Email = _ListaGrupo[i].Email;
                _ListaEmpreendedor.DDD = _ListaGrupo[i].DDD;
                _ListaEmpreendedor.Telefone = _ListaGrupo[i].Telefone;
                _ListaEmpreendedor.DDD_Celular = _ListaGrupo[i].DDD_Celular;
                _ListaEmpreendedor.Celular = _ListaGrupo[i].Celular;
                _ListaEmpreendedor.DataNascimento = _ListaGrupo[i].DataNascimento;
                _ListaEmpreendedor.Escolaridade = _ListaGrupo[i].Escolaridade;
                _ListaEmpreendedor.Formacao = _ListaGrupo[i].Formacao;
                _ListaEmpreendedor.Endereco = _ListaGrupo[i].Endereco;
                _ListaEmpreendedor.Complemento = _ListaGrupo[i].Complemento;
                _ListaEmpreendedor.CEP = _ListaGrupo[i].CEP;
                _ListaEmpreendedor.Cidade = _ListaGrupo[i].Cidade;
                _ListaEmpreendedor.UF = _ListaGrupo[i].UF;
                _ListaEmpreendedor.Sexo = _ListaGrupo[i].Sexo;
                _ListaEmpreendedor.Contato = _ListaGrupo[i].Contato;
                _ListaEmpreendedor.Descricao = _ListaGrupo[i].Descricao;
                _ListaEmpreendedor.Linkedin = _ListaGrupo[i].Linkedin;
                _ListaEmpreendedor.Facebook = _ListaGrupo[i].Facebook;
                _ListaEmpreendedor.GooglePlus = _ListaGrupo[i].GooglePlus;
                _ListaEmpreendedor.Skype = _ListaGrupo[i].Skype;
                _ListaEmpreendedor.Twitter = _ListaGrupo[i].Twitter;
                _ListaEmpreendedor.Msn = _ListaGrupo[i].Msn;
                _ListaEmpreendedor.ID_GrupoProjeto = _ListaGrupo[i].ID_GrupoProjeto;
                _ListaEmpreendedor.ID_Projeto = _ListaGrupo[i].ID_Projeto;
                _ListaEmpreendedor.ID_Empreendedor = _ListaGrupo[i].ID_Empreendedor;
                _ListaEmpreendedor.URL = "~/DetalheEmpreendedor.aspx?ID=" + Convert.ToString(_ListaGrupo[i].ID_Empreendedor) + "&ID_Projeto=" + ID_Projeto;

                tempLista.Add(_ListaEmpreendedor);

            }

            return tempLista;
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

        public void carregarDoc(int id)
        {
            _Documento = new List<Documento>();
            _Documento = SeleciorDocumento(0, id);
        }

    }
}