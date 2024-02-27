using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;
using BLL;
using Invest.Model;
using System.IO;

namespace Invest.Controller
{
    public class clsCadastroEmpreendedor : EmpreendedorBLL
    {
        private LoginBLL _LoginBLL;
        public Login _Login;
        public List<ListaProjetosVisitados> _ProjetosVisitados;
        public ListaEmpreendedor _Empreendedor;
        public Empreendedor _ConsultaEmpreendedor;
        public string ID_Empreendedor;
        public string CPF;
        public string Tipo;
        public int _ID_Empreendedor = 0;
        public clsCadastroEmpreendedor()
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
            if (_Login != null)
                return _LoginBLL.VerificaLogado(_Login.LOGIN);
            else
                return false;
        }

        public void CarregaConsultaEmpreendedor(string cpf)
        {
            _ConsultaEmpreendedor = Selecionar(0, cpf);
            if (_ConsultaEmpreendedor != null)
                Tipo = "upd";
            else
                Tipo = "add";
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


        public string Salvar(string Nome, string CPF, string Email, string DDD, string Telefone, string DDD_Celular, string Celular, string DataNascimento, string Endereco, string Complemento, string CEP, string Cidade, string UF, string Sexo, string Escolaridade, string Formacao, string Faculdade, string Curriculo, string WebPage, string Linkid, string Facebook, string GooglePlus, string Skype, string Twitter, string Msn, string EndFoto)
        {
            string Erro;
            _Empreendedor = new ListaEmpreendedor();

            modLista Lista = new modLista();

            Erro = Validar(Nome, CPF, WebPage, Email, DDD, Telefone, DDD_Celular, Celular, DataNascimento, Endereco, Complemento, CEP, Cidade, UF, Sexo, EndFoto, Escolaridade);

            if (Erro == "Sem Erros")
            {
                if (Tipo == "upd")
                    _Empreendedor.ID_Empreendedor = _ID_Empreendedor;

                _Empreendedor.Nome = Nome;
                _Empreendedor.CPF = FormatarCpf(CPF);
                _Empreendedor.WebPage = WebPage == "" ? null : WebPage;
                _Empreendedor.Email = Email;
                _Empreendedor.DDD = Convert.ToInt32(DDD);
                _Empreendedor.Telefone = Telefone;
                _Empreendedor.DDD_Celular = Convert.ToInt32(DDD_Celular == "" ? null : DDD_Celular);
                _Empreendedor.Celular = Celular == "" ? null : Celular;
                _Empreendedor.DataNascimento = Convert.ToDateTime(DataNascimento);
                _Empreendedor.Endereco = Endereco == "" ? null : Endereco;
                _Empreendedor.Complemento = Complemento == "" ? null : Complemento;
                _Empreendedor.CEP = CEP == "" ? null : CEP;
                _Empreendedor.Cidade = Cidade == "" ? null : Cidade;
                _Empreendedor.UF = UF == "" ? null : UF;
                _Empreendedor.Sexo = Sexo;
                _Empreendedor.Sexo = Sexo == "" ? null : Sexo;
                _Empreendedor.Formacao = Formacao == "" ? null : Formacao;
                _Empreendedor.Faculdade = Faculdade == "" ? null : Faculdade;
                _Empreendedor.Descricao = Curriculo == "" ? null : Curriculo;
                _Empreendedor.WebPage = WebPage == "" ? null : WebPage;
                _Empreendedor.Linkedin = Linkid == "" ? null : Linkid;
                _Empreendedor.Facebook = Facebook == "" ? null : Facebook;
                _Empreendedor.GooglePlus = GooglePlus == "" ? null : GooglePlus;
                _Empreendedor.Skype = Skype == "" ? null : Skype;
                _Empreendedor.Twitter = Twitter == "" ? null : Twitter;
                _Empreendedor.Msn = Msn == "" ? null : Msn;
                _Empreendedor.Foto = EndFoto == "" ? null : "Empr_" + FormatarCpf(CPF).Replace("-", "").Replace("/", "").Replace(".", "") + ".jpg";
                _Empreendedor.Usuario = _Login.LOGIN;
                _Empreendedor.DataCad = DateTime.Now.Date;
                _Empreendedor.Tipo = Tipo;
                _Empreendedor.URLExcluir = "~/cadastroAgente.aspx?EmprExcluir=" + CPF.Replace("-", "").Replace("/", "").Replace(".", ""); ;

                Lista.Add_ListaEmpreendedor(_Empreendedor);

                //_Empreendedor = Incluir(_Empreendedor);

                //ID_Empreendedor = Convert.ToString(_Empreendedor.ID_Empreendedor);

                //_Empreendedor.Foto = EndFoto == "" ? null : "Perfil_" + ID_Empreendedor + "_Empr.jpg";

                //if (_Empreendedor.Foto != null)
                //    Alterar(_Empreendedor);

            }

            return Erro;

        }

        private string Validar(string Nome, string CPF, string WebPage, string Email, string DDD, string Telefone, string DDD_Celular, string Celular, string DataNascimento, string Endereco, string Complemento, string CEP, string Cidade, string UF, string Sexo, string EndFoto, string Escolaridade)
        {

            //Validar campo obrigatórios.

            Nome = Nome.Trim();
            if (Nome.Length <= 0)
                return "Preencimento do Campo Nome é obrigatório.";

            CPF = CPF.Trim();
            if (CPF.Length <= 0)
                return "Preencimento do Campo CPF é obrigatório.";

            DDD.Trim();
            if (DDD.Length <= 0)
                return "Preencimento do Campo DDD é obrigatório.";

            DDD.Trim();
            if (DDD.Length <= 0)
                return "Preencimento do Campo DDD é obrigatório.";

            Telefone.Trim();
            if (Telefone.Length <= 0)
                return "Preencimento do Campo Telefone é obrigatório.";

            DataNascimento.Trim();
            if (DataNascimento.Length <= 0)
                return "Preencimento do Campo Data de nascimento é obrigatório.";

            UF.Trim();
            if (UF.Length <= 0)
                return "Preencimento do Campo UF é obrigatório.";

            Cidade.Trim();
            if (Cidade.Length <= 0)
                return "Preencimento do Campo Cidade é obrigatório.";

            Sexo.Trim();
            if (Sexo.Length <= 0)
                return "Preencimento do Campo Sexo é obrigatório.";

            Escolaridade.Trim();
            if (Escolaridade.Length <= 0)
                return "Preencimento do Campo Escolaridade é obrigatório.";

            //Consistência de Dados
            if (ValidaCPF(CPF) == false)
                return "Número de CPF incorreto.";
            CPF = FormatarCpf(CPF);

            if (ValidaInt(DDD) == false)
                return "O campo DDD só aceita valores númericos.";

            if (ValidaInt(DDD_Celular) == false && DDD_Celular.Length > 0)
                return "O campo DDD só aceita valores númericos.";

            if (ValidaInt(CEP.Replace("-", "")) == false && CEP.Length > 0)
                return "O campo CEP só aceita valores númericos. Exceto a letra \"-\".";

            Telefone.Trim();
            if (ValidaInt(Telefone.Replace("-", "")) == false)
                return "O campo Telefone só aceita valores númericos. \"-\".";

            Celular = Celular.Trim();
            if (ValidaInt(Celular.Replace("-", "")) == false && Celular.Length > 0)
                return "O campo Celular só aceita valores númericos.";

            if (ValidaDate(DataNascimento) == false)
                return "O campo DDD só aceita valores númericos.";

            //if (CPFCadastrado(CPF) == true)
            //    return "CPF já cadastrado.";

            EndFoto.Trim();
            if (ValidaFoto(EndFoto) == false && EndFoto.Length > 0)
                return "Foto deve ser no formato imagem";

            return "Sem Erros";
        }

        public bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public bool ValidaInt(string Valor)
        {
            int result;
            if (int.TryParse(Valor, out result))
                return true;
            else
                return false;
        }

        public bool ValidaDate(string Valor)
        {
            DateTime result;
            if (DateTime.TryParse(Valor, out result))
                return true;
            else
                return false;
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

        public string FormatarCpf(string cpf)
        {
            cpf = cpf.Replace("-", "").Replace("/", "").Replace(".", "");
            return Formatar(cpf, "###.###.###-##");
        }

        public bool CPFCadastrado(string cpf)
        {
            Empreendedor Empree;
            Empree = Selecionar(0, cpf);

            if (Empree.CPF == null)
                return false;
            else
                return true;

        }

        public bool ValidaFoto(string folder)
        {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

            if (ImageExtensions.Contains(Path.GetExtension(folder).ToUpperInvariant()))
            {
                return true;
            }
            else
            {
                return false;
            }
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