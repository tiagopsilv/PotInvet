using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class LucroDAL : clsConexao
    {
        public int Lucro_Add(Lucro Lucro, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Lucro
                new SqlParameter("@ID_Projeto", Lucro.ID_Projeto),
                (Lucro.Descricao == null ? new SqlParameter("@Descricao", Lucro.Descricao): new SqlParameter("@Descricao", Lucro.Descricao)),
                (Lucro.ValorEstimado == 0 ? new SqlParameter("@ValorEstimado", DBNull.Value): new SqlParameter("@ValorEstimado", Lucro.ValorEstimado)),
                (Lucro.Justificativa == null ? new SqlParameter("@Justificativa", DBNull.Value): new SqlParameter("@Justificativa", Lucro.Justificativa)),
                (Lucro.Data.Date == Compara ? new SqlParameter("@Data", DBNull.Value): new SqlParameter("@Data", Lucro.Data)),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_LucroProjeto_Add"));
        }

        public void Lucro_Upd(Lucro Lucro, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Lucro
                new SqlParameter("@ID_Lucro", Lucro.ID_Lucro),
                (Lucro.ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", Lucro.ID_Projeto): new SqlParameter("@ID_Projeto", Lucro.ID_Projeto)),
                (Lucro.Descricao == null ? new SqlParameter("@Descricao", Lucro.Descricao): new SqlParameter("@Descricao", Lucro.Descricao)),
                (Lucro.ValorEstimado == 0 ? new SqlParameter("@ValorEstimado", DBNull.Value): new SqlParameter("@ValorEstimado", Lucro.ValorEstimado)),
                (Lucro.Justificativa == null ? new SqlParameter("@Justificativa", DBNull.Value): new SqlParameter("@Justificativa", Lucro.Justificativa)),
                (Lucro.Data.Date == Compara ? new SqlParameter("@Data", DBNull.Value): new SqlParameter("@Data", Lucro.Data)),
                new SqlParameter("@Usuario", LOGIN),
            };

            ExecuteScalar(sqlParam, "sp_LucroProjeto_Upd");

        }

        public List<Lucro> Lucros_Sel(int ID_Lucro = 0, int ID_Projeto = 0)
        {
            Lucro Lucros_Sel;
            List<Lucro> Lista = new List<Lucro>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Lucro
                (ID_Lucro == 0 ? new SqlParameter("@ID_Lucro", DBNull.Value): new SqlParameter("@ID_Lucro", ID_Lucro)),
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_LucroProjeto_Sel");

            while (dr.Read())
            {
                Lucros_Sel = new Lucro();
                Lucros_Sel.ID_Lucro = Convert.ToInt32(dr["ID_Lucro"]);
                Lucros_Sel.ID_Projeto = Convert.ToInt32(dr["ID_Projeto"]);
                if (dr["Descricao"] != DBNull.Value) Lucros_Sel.Descricao = Convert.ToString(dr["Descricao"]);
                if (dr["ValorEstimado"] != DBNull.Value) Lucros_Sel.ValorEstimado = Convert.ToDecimal(dr["ValorEstimado"]);
                if (dr["Justificativa"] != DBNull.Value) Lucros_Sel.Justificativa = Convert.ToString(dr["Justificativa"]);
                if (dr["Data"] != DBNull.Value) Lucros_Sel.Data = Convert.ToDateTime(dr["Data"]);
                Lista.Add(Lucros_Sel);
            }
            FechaConn();
            return Lista;
        }

        public bool Lucros_Del(int ID_Lucro)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Lucro
                (ID_Lucro == 0 ? new SqlParameter("@ID_Lucro", DBNull.Value): new SqlParameter("@ID_Lucro", ID_Lucro))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_LucroProjeto_Del");
            FechaConn();
            return true;
        }

    }
}
