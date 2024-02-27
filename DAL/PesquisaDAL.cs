using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class PesquisaDAL : clsConexao
    {
        public int Pesquisa_Add(Pesquisa Pesquisa, string LOGIN)
        {
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Lucro
                new SqlParameter("@ID_Investidor", Pesquisa.ID_Investidor),
                new SqlParameter("@ID_Pergunta", Pesquisa.ID_Pergunta),
                (Pesquisa.Opcao == null ? new SqlParameter("@Opcao", Pesquisa.Opcao): new SqlParameter("@Opcao", Pesquisa.Opcao)),
                new SqlParameter("@Tipo", Pesquisa.Tipo),
                (Pesquisa.Resposta == null ? new SqlParameter("@Resposta", Pesquisa.Resposta): new SqlParameter("@Resposta", Pesquisa.Resposta)),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Pesquisa_Add"));
        }

        public bool Pesquisa_Verif(int ID_Investidor, string Tipo)
        {
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Lucro
                new SqlParameter("@ID_Investidor", ID_Investidor),
                new SqlParameter("@Tipo", Tipo),
             };

            return Convert.ToBoolean(ExecuteScalar(sqlParam, "sp_Pesquisa_Verif"));
        }
    }
}
