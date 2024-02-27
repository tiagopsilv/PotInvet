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
    public class clsCadastroIncubadora : AgenteBLL
    {
        private Agente _Agente;
        private Login _Login;
        private LoginBLL _LoginBLL;
        public string ID_Agente;

        public clsCadastroIncubadora()
        {
            _LoginBLL = new LoginBLL();
        }

        public string Salvar(string Nome, string CPF, string CNPJ, string Email, string DDD, string Telefone, string DDD_Celular, string Celular, string Endereco, string Complemento, string CEP, string Cidade, string UF, string Login, string Senha, string ConfirmarSenha, bool Aceite, string EndFoto)
        {
            string Erro;
            bool Cadastrado;
            _Agente = new Agente();
            _Login = new Login();

            Erro = Validar(Nome, CPF, CNPJ, Email, DDD, Telefone, DDD_Celular, Celular, Endereco, Complemento, CEP, Cidade, UF, Login, Senha, ConfirmarSenha, Aceite, EndFoto);

            if (Erro == "Sem Erros")
            {
                _Agente.Logo = EndFoto == "" ? null : "~/Logos/" + EndFoto;
                _Agente.Nome = Nome;
                _Agente.CPF = CPF == "" ? null : CPF;
                _Agente.CNPJ = CNPJ == "" ? null : CNPJ;
                _Agente.Email = Email;
                _Agente.DDD = Convert.ToInt32(DDD);
                _Agente.Telefone = Telefone;
                _Agente.DDD_Celular= Convert.ToInt32(DDD_Celular == "" ? null : DDD_Celular);
                _Agente.Celular =  Celular == "" ? null : Celular;
                _Agente.Endereco = Endereco == "" ? null : Endereco;
                _Agente.Complemento= Complemento == "" ? null : Complemento;
                _Agente.CEP= CEP == "" ? null : CEP;
                _Agente.Cidade= Cidade == "" ? null : Cidade;
                _Agente.UF = UF == "" ? null : UF;

                _Agente = Incluir(_Agente, Login);

                ID_Agente = Convert.ToString(_Agente.ID_Agente);

                _Agente.Logo = EndFoto == "" ? null : "Perfil_" + ID_Agente + ".jpg";

                _Login.LOGIN = Login;
                _Login.ID = _Agente.ID_Agente;
                _Login.Tipo = "Agente";

                if (_Agente.Logo != null)
                    Alterar(_Agente, Login);

                _LoginBLL.Incluir(_Login, Senha);

                Cadastrado = _LoginBLL.Login_Validar(_Login.LOGIN, Senha);

                if (Cadastrado == false)
                    Erro = "Erro Login, cadastre novamente";
            }

            return Erro;
        }

        private string Validar(string Nome, string CPF, string CNPJ, string Email, string DDD, string Telefone, string DDD_Celular, string Celular, string Endereco, string Complemento, string CEP, string Cidade, string UF, string Login, string Senha, string ConfirmarSenha, bool Aceite, string EndFoto)
        {

            //Validar campo obrigatórios.

            if (Aceite == false)
                return "Para cadastrar-se é obrigatório o aceite do contrato.";

            Nome = Nome.Trim();
            if (Nome.Length <= 0)
                return "Preencimento do Campo Nome é obrigatório.";

            CPF = CPF.Trim();
            CNPJ = CNPJ.Trim();
            if (CNPJ.Length <= 0 && CPF.Length <= 0)
                return "Preencimento do Campo CNPJ é obrigatório.";

            if (CNPJ.Length > 0 && CPF.Length > 0)
                return "Preencimento do Campo CNPJ ou CPF somente, nunca os dois campos juntos.";

            DDD.Trim();
            if (DDD.Length <= 0)
                return "Preencimento do Campo DDD é obrigatório.";

            DDD.Trim();
            if (DDD.Length <= 0)
                return "Preencimento do Campo DDD é obrigatório.";

            Telefone.Trim();
            if (Telefone.Length <= 0)
                return "Preencimento do Campo Telefone é obrigatório.";

            UF.Trim();
            if (UF.Length <= 0)
                return "Preencimento do Campo UF é obrigatório.";

            Cidade.Trim();
            if (Cidade.Length <= 0)
                return "Preencimento do Campo Cidade é obrigatório.";

            Endereco.Trim();
            if (Endereco.Length <= 0)
                return "Preencimento do Campo Endereço é obrigatório.";

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

            if (CNPJ.Length > 0)
            {
                if (ValidaCnpj(CNPJ) == false)
                    return "Número de CNPJ incorreto.";
                CNPJ = FormatarCnpj(CNPJ);
            }

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

            //if (CPFCadastrado(CPF) == true)
            //    return "CPF já cadastrado.";

            if (Senha.Length <= 5)
                return "O Valor da Senha deve conter mais de 5 caracteres.";

            if (Senha != ConfirmarSenha)
                return "Valores de Senhas diferentes.";

            if (LoginCadastrado(Login) == true)
                return "Login já cadastrado.";

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

        public void SairLogin(string Usuario)
        {
            _LoginBLL.SairLogin(Usuario);
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

        public static string FormatarCpf(string cpf)
        {
            cpf = cpf.Replace("-", "").Replace("/", "").Replace(".", "");
            return Formatar(cpf, "###.###.###-##");
        }

        public static string FormatarCnpj(string CNPJ)
        {
            CNPJ = CNPJ.Replace("-", "").Replace("/", "").Replace(".", "").Replace("-","");
            return Formatar(CNPJ, "##.###.###/####-##");
        }

        public bool ValidaCnpj(string cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)

                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);

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

        public string Get_Tipo(string Usuario)
        {
            _Login = _LoginBLL.ConsultarLogin(Usuario);
            if (_Login.LOGIN != null)
                return _Login.Tipo;
            else
                return "Investidor";
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