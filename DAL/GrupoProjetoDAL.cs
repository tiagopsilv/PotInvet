using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class GrupoProjetoDAL : clsConexao 
    {
        public int GrupoProjeto_Add(GrupoProjeto GrupoProjeto, string LOGIN)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de GrupoProjeto
                new SqlParameter("@ID_Projeto", GrupoProjeto.ID_Projeto),
                new SqlParameter("@ID_Emprededor ", GrupoProjeto.ID_Empreendedor ),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_GrupoProjeto_Add"));
        }

        public List<GrupoProjeto> GrupoProjetos_Sel(int ID_GrupoProjeto = 0, int ID_Projeto = 0, int ID_Emprededor = 0)
        {
            GrupoProjeto GrupoProjetos_Sel;
            List<GrupoProjeto> Lista = new List<GrupoProjeto>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de GrupoProjeto
                (ID_GrupoProjeto == 0 ? new SqlParameter("@ID_GrupoProjetos", DBNull.Value): new SqlParameter("@ID_GrupoProjetos", ID_GrupoProjeto)),
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto)),
                (ID_Emprededor == 0 ? new SqlParameter("@ID_Emprededor", DBNull.Value): new SqlParameter("@ID_Emprededor", ID_Emprededor))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_GrupoProjeto_Sel");

            while (dr.Read())
            {
                GrupoProjetos_Sel = new GrupoProjeto();
                GrupoProjetos_Sel.ID_GrupoProjeto = Convert.ToInt32(dr["ID_GrupoProjetos"]);
                GrupoProjetos_Sel.ID_Projeto = Convert.ToInt32(dr["ID_Projetos"]);
                if (dr["ID_Emprededor"] != DBNull.Value) GrupoProjetos_Sel.ID_Empreendedor = Convert.ToInt32(dr["ID_Emprededor"]);
                Lista.Add(GrupoProjetos_Sel);
            }
            FechaConn();
            return Lista;
        }
    }
}
