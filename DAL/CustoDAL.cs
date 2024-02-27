using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class CustoDAL : clsConexao
    {
        public int Custo_Add(Custo Custo, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Custo
                new SqlParameter("@ID_Projeto", Custo.ID_Projeto),
                (Custo.Descricao == null ? new SqlParameter("@Descricao", Custo.Descricao): new SqlParameter("@Descricao", Custo.Descricao)),
                (Custo.CustoEstimado == 0 ? new SqlParameter("@CustoEstimado", DBNull.Value): new SqlParameter("@CustoEstimado", Custo.CustoEstimado)),
                (Custo.Justificativa == null ? new SqlParameter("@Justificativa", DBNull.Value): new SqlParameter("@Justificativa", Custo.Justificativa)),
                (Custo.Data.Date == Compara ? new SqlParameter("@Data", DBNull.Value): new SqlParameter("@Data", Custo.Data)),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_CustoProjeto_Add"));
        }

        public void Custos_Upd(Custo Custo, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Custo
                new SqlParameter("@ID_Custo", Custo.ID_Custo),
                (Custo.ID_Projeto == null ? new SqlParameter("@ID_Projeto", Custo.ID_Projeto): new SqlParameter("@ID_Projeto", Custo.ID_Projeto)),
                (Custo.Descricao == null ? new SqlParameter("@Descricao", Custo.Descricao): new SqlParameter("@Descricao", Custo.Descricao)),
                (Custo.CustoEstimado == 0 ? new SqlParameter("@CustoEstimado", DBNull.Value): new SqlParameter("@CustoEstimado", Custo.CustoEstimado)),
                (Custo.Justificativa == null ? new SqlParameter("@Justificativa", DBNull.Value): new SqlParameter("@Justificativa", Custo.Justificativa)),
                (Custo.Data.Date == Compara ? new SqlParameter("@Data", DBNull.Value): new SqlParameter("@Data", Custo.Data)),
                new SqlParameter("@Usuario", LOGIN),
            };

            ExecuteScalar(sqlParam, "sp_CustoProjeto_Upd");
        
        }

        public List<Custo> Custos_Sel(int ID_Custo = 0, int ID_Projeto = 0)
        {
            Custo Custos_Sel;
            List<Custo> Lista = new List<Custo>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Custo
                (ID_Custo == 0 ? new SqlParameter("@ID_Custo", DBNull.Value): new SqlParameter("@ID_Custo", ID_Custo)),
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_CustoProjeto_Sel");

            while (dr.Read())
            {
                Custos_Sel = new Custo();
                Custos_Sel.ID_Custo = Convert.ToInt32(dr["ID_Custo"]);
                Custos_Sel.ID_Projeto = Convert.ToInt32(dr["ID_Projeto"]);
                if (dr["Descricao"] != DBNull.Value) Custos_Sel.Descricao = Convert.ToString(dr["Descricao"]);
                if (dr["CustoEstimado"] != DBNull.Value) Custos_Sel.CustoEstimado = Convert.ToDecimal(dr["CustoEstimado"]);
                if (dr["Justificativa"] != DBNull.Value) Custos_Sel.Justificativa = Convert.ToString(dr["Justificativa"]);
                if (dr["Data"] != DBNull.Value) Custos_Sel.Data = Convert.ToDateTime(dr["Data"]);
                Lista.Add(Custos_Sel);
            }
            FechaConn();
            return Lista;
        }

        public bool Custos_Del(int ID_Custo)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Custo
                (ID_Custo == 0 ? new SqlParameter("@ID_Custo", DBNull.Value): new SqlParameter("@ID_Custo", ID_Custo))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_CustoProjeto_Del");
            FechaConn();
            return true;
        }

    }
}
