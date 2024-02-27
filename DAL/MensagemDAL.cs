using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class MensagemDAL : clsConexao
    {
        public List<Mensagem> Mensagem_Sel(string Tipo, int ID_Mensagem = 0, int ID = 0)
        {
            Mensagem Mensagem_Sel;
            List<Mensagem> Lista = new List<Mensagem>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Mensagem
                new SqlParameter("@Tipo", Tipo),
                (ID_Mensagem == 0 ? new SqlParameter("@ID_Mensagem", DBNull.Value): new SqlParameter("@ID_Mensagem", ID_Mensagem)),
                (ID == 0 ? new SqlParameter("@ID", DBNull.Value): new SqlParameter("@ID", ID))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Mesagem_Sel");

            while (dr.Read())
            {
                Mensagem_Sel = new Mensagem();
                Mensagem_Sel.ID_Mensagens = Convert.ToInt32(dr["ID_Mensagens"]);
                Mensagem_Sel.ID = Convert.ToInt32(dr["ID"]);
                Mensagem_Sel.Tipo = Tipo;
                if (dr["Texto"] != DBNull.Value) Mensagem_Sel.Texto = Convert.ToString(dr["Texto"]);
                if (dr["Titulo"] != DBNull.Value) Mensagem_Sel.Titulo = Convert.ToString(dr["Titulo"]);
                if (dr["DtCadastro"] != DBNull.Value) Mensagem_Sel.Data = Convert.ToDateTime(dr["DtCadastro"]);
                if (dr["Usuario"] != DBNull.Value) Mensagem_Sel.Usuario = Convert.ToString(dr["Usuario"]);
                Mensagem_Sel.URL = "~/mensagem.aspx?ID=" + Convert.ToString(dr["ID"]) + "&Tipo=" + Tipo;
                Lista.Add(Mensagem_Sel);
            }
            FechaConn();
            return Lista;
        }
    }
}
