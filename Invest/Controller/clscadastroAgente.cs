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
    public class clscadastroAgente : ProjetoBLL 
    {
        private LoginBLL _LoginBLL;
        private AgenteBLL _AgenteBLL; 
        public Login _Login;
        public EmpreendedorBLL _EmpreendedorBLL;

        public CustoBLL _CustoBLL;
        public LucroBLL _LucroBLL;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        public List<ListaEmpreendedor> _ListaEmpreendedor;
        public List<ListaCusto> _ListaCusto;
        public List<ListaLucro> _ListaLucro;
        public ListaProjeto _Projeto;
        public string Tipo;
        public string ID_Agente;
        public int ID_Projeto;

        public clscadastroAgente()
        {
            _LoginBLL = new LoginBLL();
            _EmpreendedorBLL = new EmpreendedorBLL();
            _CustoBLL = new CustoBLL();
            _LucroBLL = new LucroBLL();
            _AgenteBLL = new AgenteBLL();
        }
        public string Usuario()
        {
            _Login = _LoginBLL.ConsultarLogin(_Login.LOGIN);
            if (_Login != null)
                return _Login.LOGIN;
            else
                return null;
        }
        public bool VerificaLogin(string LOGIN)
        {
            return _LoginBLL.VerificaLogado(LOGIN);
        }

        public void CarregaProjetosVisitados()
        {
            ListaProjetosVisitados TempProjetosVisitados;
            bool Achou = false;
            int Linha = 4;
            List<ProjetosVisitados> _ListTemp;

            _ListTemp = SeleciorProjetosVisitados(0, _Login.ID);
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

        public void CarregarProjeto()
        {
            _Projeto = new ListaProjeto();
            modLista Lista = new modLista();
            if (Lista.get_ListaProjeto(_Login.LOGIN).Count > 0)
                _Projeto = Lista.get_ListaProjeto(_Login.LOGIN)[0];
        }

        public void CarregarListaEmpreendedor()
        {
            _ListaEmpreendedor = new List<ListaEmpreendedor>();
            modLista Lista = new modLista();
            _ListaEmpreendedor = Lista.get_ListaEmpreendedor(_Login.LOGIN);
        }

        public void CarregarListaCusto()
        {
            _ListaCusto = new List<ListaCusto>();
            modLista Lista = new modLista();
            _ListaCusto = Lista.get_ListaCusto(_Login.LOGIN);
        }

        public void CarregarListaLucro()
        {
            _ListaLucro = new List<ListaLucro>();
            modLista Lista = new modLista();
            _ListaLucro = Lista.get_ListaLucro(_Login.LOGIN);
        }

        public void QuardaDados(string NomeProjeto, string DescricaoProjeto, string ImagemProjeto, string VideoProjeto, string PerfilProjeto, string RamoAtividade, string Email, string DDD, string Telefone, string Endereco, string Cidade, string Estado, string ImgApres)
        {

            _Projeto = new ListaProjeto();

            modLista Lista = new modLista();

            Lista.del_ListaProjeto(_Login.LOGIN);

            _Projeto.NomeProjeto = NomeProjeto;
            _Projeto.DescricaoProjeto = DescricaoProjeto;
            _Projeto.ImagemProjeto = ImagemProjeto;
            _Projeto.VideoProjeto = VideoProjeto;
            _Projeto.PerfilProjeto = PerfilProjeto;
            _Projeto.RamoAtividade = RamoAtividade;
            _Projeto.Email  = Email;
            _Projeto.DDD  = DDD;
            _Projeto.Telefone  = Telefone;
            _Projeto.Endereco  = Endereco;
            _Projeto.Cidade  = Cidade;
            _Projeto.Estado  = Estado;
            _Projeto.ImgApres  = ImgApres;
            _Projeto.ID_Agente  = _Login.ID;
            _Projeto.Usuario = _Login.LOGIN;
            _Projeto.DataCad = DateTime.Now.Date;
            _Projeto.AlteracaoCadastroAgente = true;

            Lista.Add_ListaProjeto(_Projeto);

        }

        public void AlteracaoCadastroAgente(bool Valor)
        {
            modLista Lista = new modLista();
            Lista.set_AlteracaoCadastroAgente(_Login.LOGIN, Valor);
        }

        public string Salvar(string NomeProjeto, string DescricaoProjeto, string Imagem, string Video, string Perfil, string Ramo, string Email, string DDD, string Telefone, string Endereco, string Complemento, string UF, string Cidade)
        {
            string Erro;
            Projeto _ProjetoNovo = new Projeto();
            GrupoProjeto _GrupoProjeto;
            Empreendedor _EmpreededorNovo = new Empreendedor();
            Custo _CustoNovo = new Custo();
            Lucro _LucroNovo = new Lucro();

            Erro = Validar(NomeProjeto, DescricaoProjeto, Video, Imagem, Perfil, Ramo, Email, DDD, Telefone, Endereco, Complemento, UF, Cidade);

            if (Erro == "Sem Erros")
            {
                _ProjetoNovo.NomeProjeto = NomeProjeto;
                _ProjetoNovo.DescricaoProjeto = DescricaoProjeto;
                _ProjetoNovo.ImagemProjeto = _AgenteBLL.Selecionar(_Login.ID).Logo;
                _ProjetoNovo.VideoProjeto = FormataEnderecoVideo(Video);
                _ProjetoNovo.PerfilProjeto = Perfil;
                _ProjetoNovo.RamoAtividade = Ramo;
                _ProjetoNovo.Email  = Email;
                _ProjetoNovo.DDD  = DDD;
                _ProjetoNovo.Telefone  = Telefone;
                _ProjetoNovo.Endereco  = Endereco;
                _ProjetoNovo.Cidade  = Cidade;
                _ProjetoNovo.Estado  = UF;
                _ProjetoNovo.ImgApres  = Imagem;
                _ProjetoNovo.ID_Agente  = _Login.ID;

                _ProjetoNovo = Incluir(_ProjetoNovo, _Login.LOGIN);

                ID_Agente = Convert.ToString(_ProjetoNovo.ID_Agente);
                ID_Projeto = _ProjetoNovo.ID_Projeto;

                for (int i = 0; i < _ListaEmpreendedor.Count; i++)
                {
                    _GrupoProjeto = new GrupoProjeto();
                    _EmpreededorNovo = new Empreendedor();

                    _EmpreededorNovo.ID_Empreendedor = _ListaEmpreendedor[i].ID_Empreendedor;
                    _EmpreededorNovo.CPF = _ListaEmpreendedor[i].CPF;
                    _EmpreededorNovo.Nome = _ListaEmpreendedor[i].Nome;
                    _EmpreededorNovo.WebPage = _ListaEmpreendedor[i].WebPage;
                    _EmpreededorNovo.Foto = _ListaEmpreendedor[i].Foto;
                    _EmpreededorNovo.Email = _ListaEmpreendedor[i].Email;
                    _EmpreededorNovo.DDD = _ListaEmpreendedor[i].DDD;
                    _EmpreededorNovo.Telefone = _ListaEmpreendedor[i].Telefone;
                    _EmpreededorNovo.DDD_Celular = _ListaEmpreendedor[i].DDD_Celular;
                    _EmpreededorNovo.Celular = _ListaEmpreendedor[i].Celular;
                    _EmpreededorNovo.DataNascimento = _ListaEmpreendedor[i].DataNascimento;
                    _EmpreededorNovo.Escolaridade = _ListaEmpreendedor[i].Escolaridade;
                    _EmpreededorNovo.Formacao = _ListaEmpreendedor[i].Formacao;
                    _EmpreededorNovo.Faculdade = _ListaEmpreendedor[i].Faculdade;
                    _EmpreededorNovo.Endereco = _ListaEmpreendedor[i].Endereco;
                    _EmpreededorNovo.Complemento = _ListaEmpreendedor[i].Complemento;
                    _EmpreededorNovo.CEP = _ListaEmpreendedor[i].CEP;
                    _EmpreededorNovo.Cidade = _ListaEmpreendedor[i].Cidade;
                    _EmpreededorNovo.UF = _ListaEmpreendedor[i].UF;
                    _EmpreededorNovo.Sexo = _ListaEmpreendedor[i].Sexo;
                    _EmpreededorNovo.Contato = _ListaEmpreendedor[i].Contato;
                    _EmpreededorNovo.Descricao = _ListaEmpreendedor[i].Descricao;
                    _EmpreededorNovo.Linkedin = _ListaEmpreendedor[i].Linkedin;
                    _EmpreededorNovo.Facebook = _ListaEmpreendedor[i].Facebook;
                    _EmpreededorNovo.GooglePlus = _ListaEmpreendedor[i].GooglePlus;
                    _EmpreededorNovo.Skype = _ListaEmpreendedor[i].Skype;
                    _EmpreededorNovo.Twitter = _ListaEmpreendedor[i].Twitter;
                    _EmpreededorNovo.Msn = _ListaEmpreendedor[i].Msn;

                    if (_ListaEmpreendedor[i].Tipo == "upd")
                        _EmpreendedorBLL.Alterar(_GrupoProjeto, _Login.LOGIN);
                    else
                        _EmpreededorNovo = _EmpreendedorBLL.Incluir(_EmpreededorNovo, _Login.LOGIN);

                    _GrupoProjeto.ID_Projeto = _ProjetoNovo.ID_Projeto;
                    _GrupoProjeto.ID_Empreendedor = _EmpreededorNovo.ID_Empreendedor;
                    _EmpreendedorBLL.IncluirEmpreendedorProjeto(_GrupoProjeto, _Login.LOGIN);


                }

                for (int i = 0; i < _ListaCusto.Count; i++)
                {
                    _CustoNovo.ID_Custo = _ListaCusto[i].ID_Custo;
                    _CustoNovo.ID_Projeto = _ProjetoNovo.ID_Projeto;
                    _CustoNovo.Descricao = _ListaCusto[i].Descricao;
                    _CustoNovo.CustoEstimado = _ListaCusto[i].CustoEstimado;
                    _CustoNovo.Justificativa = _ListaCusto[i].Justificativa;
                    _CustoNovo.Data = _ListaCusto[i].Data;

                    _CustoBLL.Incluir(_CustoNovo, _Login.LOGIN);

                }

                for (int i = 0; i < _ListaLucro.Count; i++)
                {
                    _LucroNovo.ID_Lucro = _ListaLucro[i].ID_Lucro;
                    _LucroNovo.ID_Projeto = _ProjetoNovo.ID_Projeto;
                    _LucroNovo.Descricao = _ListaLucro[i].Descricao;
                    _LucroNovo.ValorEstimado = _ListaLucro[i].ValorEstimado;
                    _LucroNovo.Justificativa = _ListaLucro[i].Justificativa;
                    _LucroNovo.Data = _ListaLucro[i].Data;

                    _LucroBLL.Incluir(_LucroNovo, _Login.LOGIN);

                }

                modLista Lista = new modLista();
                Lista.del_Tudo(_Login.LOGIN);

        }

            return Erro;
        }

        private string Validar(string NomeProjeto, string DescricaoProjeto, string Video, string Imagem, string Perfil, string Ramo, string Email, string DDD, string Telefone, string Endereco, string Complemento, string UF, string Cidade)
        {
            //Validar campo obrigatórios.

            NomeProjeto = NomeProjeto.Trim();
            if (NomeProjeto.Length <= 0)
                return "Preencimento do Campo Nome Projeto é obrigatório.";

            DescricaoProjeto = DescricaoProjeto.Trim();
            if (DescricaoProjeto.Length <= 0)
                return "Preencimento do Campo Descricao Projeto é obrigatório.";

            if(_ListaCusto.Count <= 0)
                return "Preencimento do Custo Projeto é obrigatório.";

            Video = Video.Trim();
            if (Video.Length <= 0)
                return "Preencimento do Campo Video é obrigatório.";

            if (_ListaEmpreendedor.Count <= 0)
                return "Preencimento do Lista de Empreendedores do Projeto é obrigatório.";

            return "Sem Erros";
        }

        public string FormataEnderecoVideo(string EndOrigina)
        {
            int inic = (EndOrigina.IndexOf("watch?v=") + 8);
            int Fim = (EndOrigina.IndexOf("&feature") - EndOrigina.IndexOf("watch?v=") - 8);
            return "http://www.youtube.com/embed/" + EndOrigina.Substring(inic, Fim) + "?feature=player_detailpage";

        }

        public void Incluir_Log(string IP, string Pagina, string PaginaAnt)
        {
            string _Log = null;
            if (_Login != null)
                _Log = _Login.LOGIN;
            _LoginBLL.Incluir_Log(IP, Pagina, PaginaAnt, _Log);
        }

        public void ExcluirEmpreendedor(string CPF)
        {
            CPF = FormatarCpf(CPF);
            modLista Lista = new modLista();

            Lista.del_ListaEmpreendedor(CPF);
        }

        public string FormatarCpf(string cpf)
        {
            cpf = cpf.Replace("-", "").Replace("/", "").Replace(".", "");
            return Formatar(cpf, "###.###.###-##");
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
