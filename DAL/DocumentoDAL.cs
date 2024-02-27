using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class DocumentoDAL : clsConexao
    {
        public int Documento_Add(Documento Documento, string LOGIN)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Documento
                new SqlParameter("@ID_Projeto", Documento.ID_Projeto),
                (Documento.EnderecoDocumento == null ? new SqlParameter("@EnderecoDocumento", Documento.EnderecoDocumento): new SqlParameter("@EnderecoDocumento", Documento.EnderecoDocumento)),
                (Documento.Titulo == null ? new SqlParameter("@Titulo", DBNull.Value): new SqlParameter("@Titulo", Documento.Titulo)),
                (Documento.Tipo == null ? new SqlParameter("@Tipo", DBNull.Value): new SqlParameter("@Tipo", Documento.Tipo)),
                new SqlParameter("@Usuario", LOGIN),
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Documento_Add"));
        }

        public void Documento_Upd(Documento Documento, string LOGIN)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Documento
                new SqlParameter("@ID_Documento", Documento.ID_Documento),
                (Documento.ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", Documento.ID_Projeto): new SqlParameter("@ID_Projeto", Documento.ID_Projeto)),
                (Documento.EnderecoDocumento  == null ? new SqlParameter("@EnderecoDocumento ", Documento.EnderecoDocumento ): new SqlParameter("@EnderecoDocumento ", Documento.EnderecoDocumento )),
                (Documento.Titulo == null ? new SqlParameter("@Titulo", DBNull.Value): new SqlParameter("@Titulo", Documento.Titulo)),
                (Documento.Tipo == null ? new SqlParameter("@Tipo", DBNull.Value): new SqlParameter("@Tipo", Documento.Tipo)),
                new SqlParameter("@Usuario", LOGIN),
            };

            ExecuteScalar(sqlParam, "sp_Documento_Upd");

        }

        public List<Documento> Documentos_Sel(int ID_Documento = 0, int ID_Projeto = 0)
        {
            Documento Documentos_Sel;
            List<Documento> Lista = new List<Documento>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Documento
                (ID_Documento == 0 ? new SqlParameter("@ID_Documento", DBNull.Value): new SqlParameter("@ID_Documento", ID_Documento)),
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Documento_Sel");

            while (dr.Read())
            {
                Documentos_Sel = new Documento();
                Documentos_Sel.ID_Documento = Convert.ToInt32(dr["ID_Documento"]);
                Documentos_Sel.ID_Projeto = Convert.ToInt32(dr["ID_Projeto"]);
                if (dr["EnderecoDocumento"] != DBNull.Value) Documentos_Sel.EnderecoDocumento = Convert.ToString(dr["EnderecoDocumento"]);
                if (dr["Titulo"] != DBNull.Value) Documentos_Sel.Titulo = Convert.ToString(dr["Titulo"]);
                if (dr["Tipo"] != DBNull.Value) Documentos_Sel.Tipo = Convert.ToString(dr["Tipo"]);
                Lista.Add(Documentos_Sel);
            }
            FechaConn();
            return Lista;
        }

        public bool Documento_Del(int ID_Documento)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Documento
                (ID_Documento == 0 ? new SqlParameter("@ID_Documento", DBNull.Value): new SqlParameter("@ID_Documento", ID_Documento))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Documento_Del");
            FechaConn();
            return true;
        }

    }
}
