using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class EmpreendedorDAL : clsConexao
    {
        public int Empreendedor_Add(Empreendedor Empreendedor, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Empreendedor
                (Empreendedor.CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", Empreendedor.CPF)),
	            (Empreendedor.Nome == null ? new SqlParameter("@Nome", DBNull.Value): new SqlParameter("@Nome", Empreendedor.Nome)),
	            (Empreendedor.WebPage == null ? new SqlParameter("@WebPage", DBNull.Value): new SqlParameter("@WebPage", Empreendedor.WebPage)),
	            (Empreendedor.Foto == null ? new SqlParameter("@Foto", DBNull.Value): new SqlParameter("@Foto", Empreendedor.Foto)),
	            (Empreendedor.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", Empreendedor.Email)),
	            (Empreendedor.DDD == 0 ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", Empreendedor.DDD)),
	            (Empreendedor.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", Empreendedor.Telefone)),
	            (Empreendedor.DDD_Celular == 0 ? new SqlParameter("@DDD_Celular", DBNull.Value): new SqlParameter("@DDD_Celular", Empreendedor.DDD_Celular)),
	            (Empreendedor.Celular == null ? new SqlParameter("@Celular", DBNull.Value): new SqlParameter("@Celular", Empreendedor.Celular)),
	            (Empreendedor.DataNascimento == Compara ? new SqlParameter("@DataNascimento", DBNull.Value): new SqlParameter("@DataNascimento", Empreendedor.DataNascimento)),
	            (Empreendedor.Escolaridade == null ? new SqlParameter("@Escolaridade", DBNull.Value): new SqlParameter("@Escolaridade", Empreendedor.Escolaridade)),
	            (Empreendedor.Formacao == null ? new SqlParameter("@Formacao", DBNull.Value): new SqlParameter("@Formacao", Empreendedor.Formacao)),
	            (Empreendedor.Faculdade == null ? new SqlParameter("@Faculdade", DBNull.Value): new SqlParameter("@Faculdade", Empreendedor.Faculdade)),
                (Empreendedor.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", Empreendedor.Endereco)),
	            (Empreendedor.Complemento == null ? new SqlParameter("@Complemento", DBNull.Value): new SqlParameter("@Complemento", Empreendedor.Complemento)),
	            (Empreendedor.CEP == null ? new SqlParameter("@CEP", DBNull.Value): new SqlParameter("@CEP", Empreendedor.CEP)),
	            (Empreendedor.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", Empreendedor.Cidade)),
	            (Empreendedor.UF == null ? new SqlParameter("@UF", DBNull.Value): new SqlParameter("@UF", Empreendedor.UF)),
	            (Empreendedor.Sexo == null ? new SqlParameter("@Sexo", DBNull.Value): new SqlParameter("@Sexo", Empreendedor.Sexo)),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Empreendedor_Add"));
        }

        public Empreendedor Empreendedor_Sel(int ID_Empreendedor, string cpf = null)
        {
            Empreendedor Empreendedor_Sel = new Empreendedor();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Empreendedor
                (ID_Empreendedor == 0 ? new SqlParameter("@ID_Empreendedor", DBNull.Value): new SqlParameter("@ID_Empreendedor", ID_Empreendedor)),
                (cpf == null ? new SqlParameter("@cpf", DBNull.Value): new SqlParameter("@cpf", cpf))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Empreendedor_Sel");

            while (dr.Read())
            {
                Empreendedor_Sel.ID_Empreendedor = Convert.ToInt32(dr["ID_Empreendedor"]);
                if (dr["CPF"] != DBNull.Value) Empreendedor_Sel.CPF = Convert.ToString(dr["CPF"]);
	            if (dr["Nome"] != DBNull.Value) Empreendedor_Sel.Nome = Convert.ToString(dr["Nome"]);
	            if (dr["WebPage"] != DBNull.Value) Empreendedor_Sel.WebPage = Convert.ToString(dr["WebPage"]);
	            if (dr["Foto"] != DBNull.Value) Empreendedor_Sel.Foto = Convert.ToString(dr["Foto"]);
	            if (dr["Email"] != DBNull.Value) Empreendedor_Sel.Email = Convert.ToString(dr["Email"]);
                if (dr["DDD"] != DBNull.Value) Empreendedor_Sel.DDD = Convert.ToInt32(dr["DDD"]);
	            if (dr["Telefone"] != DBNull.Value) Empreendedor_Sel.Telefone = Convert.ToString(dr["Telefone"]);
                if (dr["DDD_Celular"] != DBNull.Value) Empreendedor_Sel.DDD_Celular = Convert.ToInt32(dr["DDD_Celular"]);
	            if (dr["Celular"] != DBNull.Value) Empreendedor_Sel.Celular = Convert.ToString(dr["Celular"]);
	            if (dr["DataNascimento"] != DBNull.Value) Empreendedor_Sel.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
	            if (dr["Escolaridade"] != DBNull.Value) Empreendedor_Sel.Escolaridade = Convert.ToString(dr["Escolaridade"]);
	            if (dr["Formacao"] != DBNull.Value) Empreendedor_Sel.Formacao = Convert.ToString(dr["Formacao"]);
                if (dr["Faculdade"] != DBNull.Value) Empreendedor_Sel.Faculdade = Convert.ToString(dr["Faculdade"]);
	            if (dr["Endereco"] != DBNull.Value) Empreendedor_Sel.Endereco = Convert.ToString(dr["Endereco"]);
	            if (dr["Complemento"] != DBNull.Value) Empreendedor_Sel.Complemento = Convert.ToString(dr["Complemento"]);
	            if (dr["CEP"] != DBNull.Value) Empreendedor_Sel.CEP = Convert.ToString(dr["CEP"]);
	            if (dr["Cidade"] != DBNull.Value) Empreendedor_Sel.Cidade = Convert.ToString(dr["Cidade"]);
	            if (dr["UF"] != DBNull.Value) Empreendedor_Sel.UF = Convert.ToString(dr["UF"]);
	            if (dr["Sexo"] != DBNull.Value) Empreendedor_Sel.Sexo = Convert.ToString(dr["Sexo"]);
                if (dr["Descricao"] != DBNull.Value) Empreendedor_Sel.Descricao = Convert.ToString(dr["Descricao"]);
                if (dr["Linkedin"] != DBNull.Value) Empreendedor_Sel.Linkedin = Convert.ToString(dr["Linkedin"]);
                if (dr["Facebook"] != DBNull.Value) Empreendedor_Sel.Facebook = Convert.ToString(dr["Facebook"]);
                if (dr["GooglePlus"] != DBNull.Value) Empreendedor_Sel.GooglePlus = Convert.ToString(dr["GooglePlus"]);
                if (dr["Skype"] != DBNull.Value) Empreendedor_Sel.Skype = Convert.ToString(dr["Skype"]);
                if (dr["Twitter"] != DBNull.Value) Empreendedor_Sel.Twitter = Convert.ToString(dr["Twitter"]);
                if (dr["Msn"] != DBNull.Value) Empreendedor_Sel.Msn = Convert.ToString(dr["Msn"]);
            }
            FechaConn();
            return Empreendedor_Sel;
        }

        public void Empreendedor_Upd(Empreendedor Empreendedor, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Empreendedor
                new SqlParameter("@ID_Empreendedor", Empreendedor.ID_Empreendedor),
                (Empreendedor.CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", Empreendedor.CPF)),
	            (Empreendedor.Nome == null ? new SqlParameter("@Nome", DBNull.Value): new SqlParameter("@Nome", Empreendedor.Nome)),
	            (Empreendedor.WebPage == null ? new SqlParameter("@WebPage", DBNull.Value): new SqlParameter("@WebPage", Empreendedor.WebPage)),
	            (Empreendedor.Foto == null ? new SqlParameter("@Foto", DBNull.Value): new SqlParameter("@Foto", Empreendedor.Foto)),
	            (Empreendedor.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", Empreendedor.Email)),
	            (Empreendedor.DDD == 0 ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", Empreendedor.DDD)),
	            (Empreendedor.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", Empreendedor.Telefone)),
	            (Empreendedor.DDD_Celular == 0 ? new SqlParameter("@DDD_Celular", DBNull.Value): new SqlParameter("@DDD_Celular", Empreendedor.DDD_Celular)),
	            (Empreendedor.Celular == null ? new SqlParameter("@Celular", DBNull.Value): new SqlParameter("@Celular", Empreendedor.Celular)),
	            (Empreendedor.DataNascimento == Compara ? new SqlParameter("@DataNascimento", DBNull.Value): new SqlParameter("@DataNascimento", Empreendedor.DataNascimento)),
	            (Empreendedor.Escolaridade == null ? new SqlParameter("@Escolaridade", DBNull.Value): new SqlParameter("@Escolaridade", Empreendedor.Escolaridade)),
	            (Empreendedor.Formacao == null ? new SqlParameter("@Formacao", DBNull.Value): new SqlParameter("@Formacao", Empreendedor.Formacao)),
	            (Empreendedor.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", Empreendedor.Endereco)),
	            (Empreendedor.Complemento == null ? new SqlParameter("@Complemento", DBNull.Value): new SqlParameter("@Complemento", Empreendedor.Complemento)),
	            (Empreendedor.CEP == null ? new SqlParameter("@CEP", DBNull.Value): new SqlParameter("@CEP", Empreendedor.CEP)),
	            (Empreendedor.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", Empreendedor.Cidade)),
	            (Empreendedor.UF == null ? new SqlParameter("@UF", DBNull.Value): new SqlParameter("@UF", Empreendedor.UF)),
	            (Empreendedor.Sexo == null ? new SqlParameter("@Sexo", DBNull.Value): new SqlParameter("@Sexo", Empreendedor.Sexo)),
                new SqlParameter("@Usuario", LOGIN),

             };

            ExecuteScalar(sqlParam, "sp_Empreendedor_Upd");

        }

    }
}
