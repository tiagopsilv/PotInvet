using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class ProjetosInvestidosDAL : clsConexao
    {
        public int ProjetosInvestidos_Add(ProjetosInvestidos ProjetosInvestidos, string LOGIN)
        {
            
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de ProjetosInvestidos
                new SqlParameter("@ID_Investidor", ProjetosInvestidos.ID_Investidor),
                new SqlParameter("@ID_Projeto", ProjetosInvestidos.ID_Projeto),
                new SqlParameter("@Valor", ProjetosInvestidos.Valor),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_ProjetosInvestidos_Add"));
        }

        public List<ProjetosInvestidos> ProjetosInvestidos_Sel(int ID_ProjetosInvestidos = 0, int ID_Investidor = 0, int ID_Projeto = 0)
        {
            ProjetosInvestidos ProjetosInvestidoss_Sel;
            List<ProjetosInvestidos> Lista = new List<ProjetosInvestidos>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de ProjetosInvestidos
                (ID_ProjetosInvestidos == 0 ? new SqlParameter("@ID_ProjetoInvestidos", DBNull.Value): new SqlParameter("@ID_ProjetoInvestidos", ID_ProjetosInvestidos)),
                (ID_Investidor == 0 ? new SqlParameter("@ID_Investidor", DBNull.Value): new SqlParameter("@ID_Investidor", ID_Investidor)),
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_ProjetosInvestidos_Sel");

            while (dr.Read())
            {
                ProjetosInvestidoss_Sel = new ProjetosInvestidos();
                ProjetosInvestidoss_Sel.ID_ProjetoInvestidos = Convert.ToInt32(dr["ID_ProjetoInvestidos"]);
                ProjetosInvestidoss_Sel.ID_Investidor = Convert.ToInt32(dr["ID_Investidor"]);
                ProjetosInvestidoss_Sel.ID_Projeto = Convert.ToInt32(dr["ID_Projeto"]);
                ProjetosInvestidoss_Sel.Valor = Convert.ToDecimal(dr["Valor"]);

                Lista.Add(ProjetosInvestidoss_Sel);
            }
            FechaConn();
            return Lista;
        }
    }
}
