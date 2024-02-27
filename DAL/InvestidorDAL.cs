using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class InvestidorDAL : clsConexao
    {
        public int Investidor_Add(Investidor Investidor, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Investidor

                (Investidor.Nome == null ? new SqlParameter("@Nome", DBNull.Value): new SqlParameter("@Nome", Investidor.Nome)),
                (Investidor.CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", Investidor.CPF)),
                (Investidor.WebPage == null ? new SqlParameter("@WebPage", DBNull.Value): new SqlParameter("@WebPage", Investidor.WebPage)),
                (Investidor.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", Investidor.Email)),
                (Investidor.DDD == 0 ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", Investidor.DDD)),
                (Investidor.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", Investidor.Telefone)),
                (Investidor.DDD_Celular == 0 ? new SqlParameter("@DDD_Celular", DBNull.Value): new SqlParameter("@DDD_Celular", Investidor.DDD_Celular)),
                (Investidor.Celular == null ? new SqlParameter("@Celular", DBNull.Value): new SqlParameter("@Celular", Investidor.Celular)),
                (Investidor.DataNascimento == Compara ? new SqlParameter("@DataNascimento", DBNull.Value): new SqlParameter("@DataNascimento", Investidor.DataNascimento)),
                (Investidor.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", Investidor.Endereco)),
                (Investidor.Complemento == null ? new SqlParameter("@Complemento", DBNull.Value): new SqlParameter("@Complemento", Investidor.Complemento)),
                (Investidor.CEP == null ? new SqlParameter("@CEP", DBNull.Value): new SqlParameter("@CEP", Investidor.CEP)),
                (Investidor.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", Investidor.Cidade)),
                (Investidor.UF == null ? new SqlParameter("@UF", DBNull.Value): new SqlParameter("@UF", Investidor.UF)),
                (Investidor.Sexo == null ? new SqlParameter("@Sexo", DBNull.Value): new SqlParameter("@Sexo", Investidor.Sexo)),
                (Investidor.Foto == null ? new SqlParameter("@Foto", DBNull.Value): new SqlParameter("@Foto", Investidor.Foto)),
                new SqlParameter("@Usuario", LOGIN)
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Investidor_Add"));

        }

        public Investidor Investidor_Sel(int ID_Investidor, string CPF = null)
        {
            Investidor Investidor_Sel = new Investidor();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Investidor
                (ID_Investidor == 0 ? new SqlParameter("@ID_Investidor", DBNull.Value): new SqlParameter("@ID_Investidor", ID_Investidor)),
                (CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", CPF))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Investidor_Sel");

            while (dr.Read())
            {
                Investidor_Sel.ID_Investidor = Convert.ToInt32(dr["ID_Investidor"]);
                
                if (dr["Nome"] != DBNull.Value) Investidor_Sel.Nome = Convert.ToString(dr["Nome"]);
                if (dr["CPF"] != DBNull.Value) Investidor_Sel.CPF = Convert.ToString(dr["CPF"]);
                if (dr["WebPage"] != DBNull.Value) Investidor_Sel.WebPage = Convert.ToString(dr["WebPage"]);
                if (dr["Email"] != DBNull.Value) Investidor_Sel.Email = Convert.ToString(dr["Email"]);
                if (dr["DDD"] != DBNull.Value) Investidor_Sel.DDD = Convert.ToInt32(dr["DDD"]);
                if (dr["Telefone"] != DBNull.Value) Investidor_Sel.Telefone = Convert.ToString(dr["Telefone"]);
                if (dr["DDD_Celular"] != DBNull.Value) Investidor_Sel.DDD_Celular = Convert.ToInt32(dr["DDD_Celular"]);
                if (dr["Celular"] != DBNull.Value) Investidor_Sel.Celular = Convert.ToString(dr["Celular"]);
                if (dr["DataNascimento"] != DBNull.Value) Investidor_Sel.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                if (dr["Endereco"] != DBNull.Value) Investidor_Sel.Endereco = Convert.ToString(dr["Endereco"]);
                if (dr["Complemento"] != DBNull.Value) Investidor_Sel.Complemento = Convert.ToString(dr["Complemento"]);
                if (dr["CEP"] != DBNull.Value) Investidor_Sel.CEP = Convert.ToString(dr["CEP"]);
                if (dr["Cidade"] != DBNull.Value) Investidor_Sel.Cidade = Convert.ToString(dr["Cidade"]);
                if (dr["UF"] != DBNull.Value) Investidor_Sel.UF = Convert.ToString(dr["UF"]);
                if (dr["Sexo"] != DBNull.Value) Investidor_Sel.Sexo = Convert.ToString(dr["Sexo"]);
                if (dr["Foto"] != DBNull.Value) Investidor_Sel.Foto = Convert.ToString(dr["Foto"]);

            }
            FechaConn();
            return Investidor_Sel;
        }

        public void Investidor_Upd(Investidor Investidor, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Investidor
                new SqlParameter("@ID_Investidor", Investidor.ID_Investidor),
                (Investidor.CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", Investidor.CPF)),
	            (Investidor.Nome == null ? new SqlParameter("@Nome", DBNull.Value): new SqlParameter("@Nome", Investidor.Nome)),
	            (Investidor.WebPage == null ? new SqlParameter("@WebPage", DBNull.Value): new SqlParameter("@WebPage", Investidor.WebPage)),
	            (Investidor.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", Investidor.Email)),
	            (Investidor.DDD == 0 ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", Investidor.DDD)),
	            (Investidor.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", Investidor.Telefone)),
	            (Investidor.DDD_Celular == 0 ? new SqlParameter("@DDD_Celular", DBNull.Value): new SqlParameter("@DDD_Celular", Investidor.DDD_Celular)),
	            (Investidor.Celular == null ? new SqlParameter("@Celular", DBNull.Value): new SqlParameter("@Celular", Investidor.Celular)),
	            (Investidor.DataNascimento == Compara ? new SqlParameter("@DataNascimento", DBNull.Value): new SqlParameter("@DataNascimento", Investidor.DataNascimento)),
	            (Investidor.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", Investidor.Endereco)),
	            (Investidor.Complemento == null ? new SqlParameter("@Complemento", DBNull.Value): new SqlParameter("@Complemento", Investidor.Complemento)),
	            (Investidor.CEP == null ? new SqlParameter("@CEP", DBNull.Value): new SqlParameter("@CEP", Investidor.CEP)),
	            (Investidor.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", Investidor.Cidade)),
	            (Investidor.UF == null ? new SqlParameter("@UF", DBNull.Value): new SqlParameter("@UF", Investidor.UF)),
	            (Investidor.Sexo == null ? new SqlParameter("@Sexo", DBNull.Value): new SqlParameter("@Sexo", Investidor.Sexo)),
                (Investidor.Foto == null ? new SqlParameter("@Foto", DBNull.Value): new SqlParameter("@Foto", Investidor.Foto)),
                new SqlParameter("@Usuario", LOGIN)

             };

            ExecuteScalar(sqlParam, "sp_Investidor_Upd");

        }

    }
}
