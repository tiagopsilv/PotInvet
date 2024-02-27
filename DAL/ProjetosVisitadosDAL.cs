using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class ProjetosVisitadosDAL : clsConexao
    {
        public int ProjetosVisitados_Add(ProjetosVisitados ProjetosVisitados, string LOGIN)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de ProjetosVisitados
                new SqlParameter("@ID_Investidor", ProjetosVisitados.ID_Investidor),
                new SqlParameter("@ID_Projeto", ProjetosVisitados.ID_Projeto),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_ProjetosVisitados_Add"));
        }

        public List<ProjetosVisitados> ProjetosVisitados_Sel(int ID_ProjetosVisitados = 0, int ID_Investidor = 0, int ID_Projeto = 0)
        {
            ProjetosVisitados ProjetosVisitadoss_Sel;
            List<ProjetosVisitados> Lista = new List<ProjetosVisitados>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de ProjetosVisitados
                (ID_ProjetosVisitados == 0 ? new SqlParameter("@ID_ProjetosVisitados", DBNull.Value): new SqlParameter("@ID_ProjetosVisitados", ID_ProjetosVisitados)),
                (ID_Investidor == 0 ? new SqlParameter("@ID_Investidor", DBNull.Value): new SqlParameter("@ID_Investidor", ID_Investidor)),
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_ProjetosVisitados_Sel");

            while (dr.Read())
            {
                ProjetosVisitadoss_Sel = new ProjetosVisitados();
                ProjetosVisitadoss_Sel.ID_ProjetoVisitados = Convert.ToInt32(dr["ID_ProjetosVisitados"]);
                ProjetosVisitadoss_Sel.ID_Investidor = Convert.ToInt32(dr["ID_Investidor"]);
                ProjetosVisitadoss_Sel.ID_Projeto = Convert.ToInt32(dr["ID_Projeto"]);
                ProjetosVisitadoss_Sel.Data = Convert.ToDateTime(dr["Data"]);
                ProjetosVisitadoss_Sel.Hora = Convert.ToDateTime(dr["Hora"]);
                ProjetosVisitadoss_Sel.NomeProjeto = Convert.ToString(dr["NomeProjeto"]);

                Lista.Add(ProjetosVisitadoss_Sel);
            }
            FechaConn();
            return Lista;
        }
    }
}
