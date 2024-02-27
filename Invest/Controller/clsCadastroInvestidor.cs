using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using POCO;
using System.IO;


namespace Invest.Controller
{
    public class clsCadastroInvestidor : InvestidorBLL
    {

        private Investidor _Investidor;
        private Login _Login;
        private LoginBLL _LoginBLL;
        public string ID_Investidor;

        public clsCadastroInvestidor()
        {
            _LoginBLL = new LoginBLL();
        }

        public string Salvar(string Nome, string CPF, string WebPage, string Email, string DDD, string Telefone, string DDD_Celular, string Celular, string DataNascimento, string Endereco, string Complemento, string CEP, string Cidade, string UF, string Sexo, string Login, string Senha, string ConfirmarSenha, bool Aceite, string EndFoto)
        {
            string Erro;
            bool Cadastrado;
            _Investidor = new Investidor();
            _Login = new Login();

            Erro = Validar(Nome, CPF, WebPage, Email, DDD, Telefone, DDD_Celular, Celular, DataNascimento, Endereco, Complemento, CEP, Cidade, UF, Sexo, Login, Senha, ConfirmarSenha, Aceite, EndFoto);

            if (Erro == "Sem Erros")
            {
                _Investidor.Nome = Nome;
                _Investidor.CPF = FormatarCpf(CPF);
                _Investidor.WebPage = WebPage == "" ? null : WebPage;
                _Investidor.Email = Email;
                _Investidor.DDD = Convert.ToInt32(DDD);
                _Investidor.Telefone = Telefone;
                _Investidor.DDD_Celular = Convert.ToInt32(DDD_Celular == "" ? null : DDD_Celular);
                _Investidor.Celular = Celular == "" ? null : Celular;
                _Investidor.DataNascimento = Convert.ToDateTime(DataNascimento);
                _Investidor.Endereco = Endereco == "" ? null : Endereco;
                _Investidor.Complemento = Complemento == "" ? null : Complemento;
                _Investidor.CEP = CEP == "" ? null : CEP;
                _Investidor.Cidade = Cidade == "" ? null : Cidade;
                _Investidor.UF = UF == "" ? null : UF;
                _Investidor.Sexo = Sexo;

                _Investidor = Incluir(_Investidor, Login);

                ID_Investidor = Convert.ToString(_Investidor.ID_Investidor);

                _Investidor.Foto = EndFoto == "" ? null : "Perfil_" + ID_Investidor + ".jpg";

                if (_Investidor.Foto != null)
                    Alterar(_Investidor, Login);

                _Login.LOGIN = Login;
                _Login.ID = _Investidor.ID_Investidor;
                _Login.Tipo = "Investidor";

                _LoginBLL.Incluir(_Login, Senha);

                Cadastrado = _LoginBLL.Login_Validar(_Login.LOGIN, Senha);

                if (Cadastrado == false)
                    Erro = "Erro Login, cadastre novamente";

            }

            return Erro;

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

        private string Validar(string Nome, string CPF, string WebPage, string Email, string DDD, string Telefone, string DDD_Celular, string Celular, string DataNascimento, string Endereco, string Complemento, string CEP, string Cidade, string UF, string Sexo, string Login, string Senha, string ConfirmarSenha, bool Aceite, string EndFoto)
        {

            //Validar campo obrigatórios.

            if (Aceite == false)
                return "Para cadastrar-se é obrigatório o aceite do contrato.";

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

            Login.Trim();
            if (Login.Length <= 0)
                return "Preencimento do Campo Usuário é obrigatório.";

            Senha.Trim();
            if (Senha.Length <= 0)
                return "Preencimento do Campo Senha é obrigatório.";

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

            if(CPFCadastrado(CPF) == true)
                return "CPF já cadastrado.";

            if(Senha.Length <= 5)
                return "O Valor da Senha deve conter mais de 5 caracteres.";

            if(Senha != ConfirmarSenha)
                return "Valores de Senhas diferentes.";

            if (LoginCadastrado(Login) == true)
                return "Login já cadastrado.";

            EndFoto.Trim();
            if (ValidaFoto(EndFoto) == false && EndFoto.Length > 0)
                return "Foto deve ser no formato imagem";

            return "Sem Erros";
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

        public void SairLogin(string Usuario)
        {
            _LoginBLL.SairLogin(Usuario);
        }

        public static string Formatar( string valor, string mascara )
        {
            StringBuilder dado = new StringBuilder();
            // remove caracteres nao numericos
            foreach ( char c in valor )
            {
            if ( Char.IsNumber(c) )
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
            saida.Append( ( mascara[indMascara] == '#' ) ? dado[indCampo++] : mascara[indMascara] );
            }
            return saida.ToString();
        }

        public static string FormatarCpf(string cpf)
        {
            cpf = cpf.Replace("-", "").Replace("/", "").Replace(".", "");
            return Formatar(cpf, "###.###.###-##");
        }

        public bool CPFCadastrado(string cpf)
        {
            Investidor Invest;
            Invest = Selecionar(0, cpf);

            if (Invest.CPF == null)
                return false;
            else
                return true;

        }

        public bool LoginCadastrado(string Login)
        {
            Login Log;
            Log = _LoginBLL.Selecionar(Login);

            if (Log == null)
                return false;
            if (Log.LOGIN == null)
                return false;
            else
                return true;

        }

        public void CarregarLogin(string Login, bool Logado)
        {
            _LoginBLL.CarregarLogin(Login, Logado);
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