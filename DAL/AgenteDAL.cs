using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL {
	public class AgenteDAL : clsConexao {
        public int Agentes_Add(Agente agente, string LOGIN)
        {

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de agente                
                (agente.Logo == null ? new SqlParameter("@Logo", agente.Logo): new SqlParameter("@Logo", agente.Logo)),
                (agente.Nome == null ? new SqlParameter("@Nome", agente.Nome): new SqlParameter("@Nome", agente.Nome)),
                (agente.CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", agente.CPF)),
                (agente.CNPJ == null ? new SqlParameter("@CNPJ", DBNull.Value): new SqlParameter("@CNPJ", agente.CNPJ)),
                (agente.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", agente.Email)),
                (agente.DDD == 0 ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", agente.DDD)),
                (agente.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", agente.Telefone)),
                (agente.DDD_Celular == 0 ? new SqlParameter("@DDD_Celular", DBNull.Value): new SqlParameter("@DDD_Celular", agente.DDD_Celular)),
                (agente.Celular == null ? new SqlParameter("@Celular", DBNull.Value): new SqlParameter("@Celular", agente.Celular)),
                (agente.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", agente.Endereco)),
                (agente.Complemento == null ? new SqlParameter("@Complemento", DBNull.Value): new SqlParameter("@Complemento", agente.Complemento)),
                (agente.CEP == null ? new SqlParameter("@CEP", DBNull.Value): new SqlParameter("@CEP", agente.CEP)),
                (agente.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", agente.Cidade)),
                (agente.UF == null ? new SqlParameter("@UF", DBNull.Value): new SqlParameter("@UF", agente.UF)),             
                new SqlParameter("@Usuario", LOGIN)
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Agentes_Add"));
        }

        public void Agentes_Upd(Agente agente, string LOGIN)
        {
 
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de agente
                new SqlParameter("@ID_Agente", agente.ID_Agente),
                (agente.Logo == null ? new SqlParameter("@Logo", agente.Logo): new SqlParameter("@Logo", agente.Logo)),
                (agente.Nome == null ? new SqlParameter("@Nome", DBNull.Value): new SqlParameter("@Nome", agente.Nome)),
                (agente.CPF == null ? new SqlParameter("@CPF", DBNull.Value): new SqlParameter("@CPF", agente.CPF)),
                (agente.CNPJ == null ? new SqlParameter("@CNPJ", DBNull.Value): new SqlParameter("@CNPJ", agente.CNPJ)),
                (agente.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", agente.Email)),
                (agente.DDD == 0 ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", agente.DDD)),
                (agente.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", agente.Telefone)),
                (agente.DDD_Celular == 0 ? new SqlParameter("@DDD_Celular", DBNull.Value): new SqlParameter("@DDD_Celular", agente.DDD_Celular)),
                (agente.Celular == null ? new SqlParameter("@Celular", DBNull.Value): new SqlParameter("@Celular", agente.Celular)),
                (agente.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", agente.Endereco)),
                (agente.Complemento == null ? new SqlParameter("@Complemento", DBNull.Value): new SqlParameter("@Complemento", agente.Complemento)),
                (agente.CEP == null ? new SqlParameter("@CEP", DBNull.Value): new SqlParameter("@CEP", agente.CEP)),
                (agente.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", agente.Cidade)),
                (agente.UF == null ? new SqlParameter("@UF", DBNull.Value): new SqlParameter("@UF", agente.UF)),
                new SqlParameter("@Usuario", LOGIN)

             };

            ExecuteScalar(sqlParam, "sp_Agentes_Upd");

        }

        /// 
        /// <param name="ID_Agente"></param>
        public Agente Agentes_Sel(int ID_Agente)
        {
            Agente Agend_Sel = new Agente();

             SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de agente
                new SqlParameter("@ID_Agente", ID_Agente),
             };

             SqlDataReader dr = ExecuteReader(sqlParam, "sp_Agentes_Sel");

             while (dr.Read())
             {
                Agend_Sel.ID_Agente = Convert.ToInt32(dr["ID_Agente"]);
                if (dr["Logo"] != DBNull.Value) Agend_Sel.Logo = Convert.ToString(dr["Logo"]);
                if (dr["Nome"] != DBNull.Value) Agend_Sel.Nome = Convert.ToString(dr["Nome"]);
                if (dr["CPF"] != DBNull.Value) Agend_Sel.CPF = Convert.ToString(dr["CPF"]);
                if (dr["CNPJ"] != DBNull.Value) Agend_Sel.CNPJ = Convert.ToString(dr["CNPJ"]);
                if (dr["Email"] != DBNull.Value) Agend_Sel.Email = Convert.ToString(dr["Email"]);
                if (dr["DDD"] != DBNull.Value) Agend_Sel.DDD = Convert.ToInt32(dr["DDD"]);
                if (dr["Telefone"] != DBNull.Value) Agend_Sel.Telefone = Convert.ToString(dr["Telefone"]);
                if (dr["DDD_Celular"] != DBNull.Value) Agend_Sel.DDD_Celular = Convert.ToInt32(dr["DDD_Celular"]);
                if (dr["Celular"] != DBNull.Value) Agend_Sel.Celular = Convert.ToString(dr["Celular"]);
                if (dr["Endereco"] != DBNull.Value) Agend_Sel.Endereco = Convert.ToString(dr["Endereco"]);
                if (dr["Complemento"] != DBNull.Value) Agend_Sel.Complemento = Convert.ToString(dr["Complemento"]);
                if (dr["CEP"] != DBNull.Value) Agend_Sel.CEP = Convert.ToString(dr["CEP"]);
                if (dr["Cidade"] != DBNull.Value) Agend_Sel.Cidade = Convert.ToString(dr["Cidade"]);
                if (dr["UF"] != DBNull.Value) Agend_Sel.UF = Convert.ToString(dr["UF"]);
             }
             FechaConn();
            return Agend_Sel;
        }

        /// 
        /// <param name="ID_Agente"></param>
        public bool Excluir(int ID_Agente)
        {

            return false;
        }

        /// 
        /// <param name="ID_Projeto"></param>
        public List<Agente> Listar(int ID_Projeto)
        {

            return null;
        }
		}

	}//end Agente

//}//end namespace System