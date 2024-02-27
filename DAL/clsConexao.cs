using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using POCO;

namespace DAL
{
    public class clsConexao
    {
        public static List<Login> Login_Atual = new List<Login>();
        public static bool Logado = false;
        private SqlConnection conn;
        private SqlCommand cmd;
        private String connectionString = "Initial Catalog=ideiasinvest;Data Source=mssql.ideiasinvest.com.br;User ID=ideiasinvest;password=tccinvestmmt";

        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteScalar do SqlCommand.
        /// </summary>
        /// <param name="param">Vetor de Parametros para executar a procedure.</param>
        /// <param name="spName">Nome da procedure.</param>
        protected object ExecuteScalar(SqlParameter[] param, String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            conn.Open();
            object objReturn = cmd.ExecuteScalar();
            conn.Close();
            conn.Dispose();
            conn = null;
            return objReturn;
        }
        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteScalar do SqlCommand.
        /// </summary>
        /// <param name="param">Parametro para executar a procedure.</param>
        /// <param name="spName">Nome da procedure.</param>
        protected object ExecuteScalar(SqlParameter param, String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            conn.Close();
            conn.Dispose();
            conn = null;
            Object objReturn = cmd.ExecuteScalar();
            conn.Close();
            return objReturn;
        }


        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteNonQuery do SqlCommand.
        /// </summary>
        /// <param name="param">Vetor de Parametros para executar a procedure.</param>
        /// <param name="spName">Nome da procedure.</param>
        protected int ExecuteNonQuery(SqlParameter[] param, String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            conn.Open();
            int intReturn = cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            conn = null;
            return intReturn;
        }
        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteNonQuery do SqlCommand.
        /// </summary>
        /// <param name="param">Parametro para executar a procedure.</param>
        /// <param name="spName">Nome da procedure.</param>
        protected int ExecuteNonQuery(SqlParameter param, String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            conn.Open();
            int intReturn = cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            conn = null;
            return intReturn;
        }


        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteReader do SqlCommand.
        /// </summary>
        /// <param name="param">Vetor de Parametros para executar a procedure.</param>
        /// <param name="spName">Nome da procedure.</param>
        protected SqlDataReader ExecuteReader(SqlParameter[] param, String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            conn.Open();
            SqlDataReader sdrReturn = cmd.ExecuteReader();
            return sdrReturn;
        }
        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteReader do SqlCommand.
        /// </summary>
        /// <param name="param">Parametro para executar a procedure.</param>
        /// <param name="spName">Nome da procedure.</param>
        protected SqlDataReader ExecuteReader(SqlParameter param, String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (param.Value != null) { cmd.Parameters.Add(param); }
            conn.Open();
            SqlDataReader sdrReturn = cmd.ExecuteReader();
            //conn.Close();
            //conn.Dispose();
            //conn = null;
            return sdrReturn;
        }
        /// <summary>
        /// Conecta com o banco de dados e executa uma StoredProcedure com o metodo ExecuteReader do SqlCommand.
        /// </summary>
        /// <param name="spName">Nome da procedure.</param>
        protected SqlDataReader ExecuteReader(String spName)
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader sdrReturn = cmd.ExecuteReader();
            conn.Close();
            conn.Dispose();
            conn = null;
            return sdrReturn;
        }

        /// <summary>
        /// Se a conexão estiver aberta ela é fechada
        /// </summary>
        protected void Close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Pega o valor boleano do SqlDataReader da coluna especificada. Retorna false se houver algum erro.
        /// </summary>
        /// <param name="sqldr">SqlDataReader para pegar o valor.</param>
        /// <param name="strColumn">String com o nome da coluna para pegar o valor.</param>
        protected bool GetBooleanNull(ref SqlDataReader sqldr, string strColumn)
        {
            try
            {
                return sqldr.IsDBNull(sqldr.GetOrdinal(strColumn)) ? false : sqldr.GetBoolean(sqldr.GetOrdinal(strColumn));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Pega o valor DateTime do SqlDataReader da coluna especificada. Retorna DateTime.MinValue se houver algum erro.
        /// </summary>
        /// <param name="sqldr">SqlDataReader para pegar o valor.</param>
        /// <param name="strColumn">String com o nome da coluna para pegar o valor.</param>
        protected DateTime GetDateTimeNull(ref SqlDataReader sqldr, string strColumn)
        {
            try
            {
                return sqldr.IsDBNull(sqldr.GetOrdinal(strColumn)) ? DateTime.MinValue : sqldr.GetDateTime(sqldr.GetOrdinal(strColumn));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Pega o valor Byte ou Int32 do SqlDataReader da coluna especificada. Retorna 0 se houver algum erro.
        /// </summary>
        /// <param name="sqldr">SqlDataReader para pegar o valor.</param>
        /// <param name="strColumn">String com o nome da coluna para pegar o valor.</param>
        protected int GetIntNull(ref SqlDataReader sqldr, string strColumn)
        {
            try
            {
                return sqldr.IsDBNull(sqldr.GetOrdinal(strColumn)) ? 0 : sqldr.GetInt32(sqldr.GetOrdinal(strColumn));
            }
            catch (InvalidCastException)
            {
                try
                {
                    return Convert.ToInt32(sqldr.GetByte(sqldr.GetOrdinal(strColumn)));
                }
                catch
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Pega o valor Float do SqlDataReader da coluna especificada. Retorna 0 se houver algum erro.
        /// </summary>
        /// <param name="sqldr">SqlDataReader para pegar o valor.</param>
        /// <param name="strColumn">String com o nome da coluna para pegar o valor.</param>
        protected float GetFloatNull(ref SqlDataReader sqldr, string strColumn)
        {
            try
            {
                return sqldr.IsDBNull(sqldr.GetOrdinal(strColumn)) ? 0 : sqldr.GetFloat(sqldr.GetOrdinal(strColumn));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Pega o valor Decimal do SqlDataReader da coluna especificada. Retorna 0 se houver algum erro.
        /// </summary>
        /// <param name="sqldr">SqlDataReader para pegar o valor.</param>
        /// <param name="strColumn">String com o nome da coluna para pegar o valor.</param>
        protected decimal GetDecimalNull(ref SqlDataReader sqldr, string strColumn)
        {
            try
            {
                return sqldr.IsDBNull(sqldr.GetOrdinal(strColumn)) ? 0 : sqldr.GetDecimal(sqldr.GetOrdinal(strColumn));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Pega o valor da string do SqlDataReader da coluna especificada. Retorna null se houver algum erro.
        /// </summary>
        /// <param name="sqldr">SqlDataReader para pegar o valor.</param>
        /// <param name="strColumn">String com o nome da coluna para pegar o valor.</param>
        protected string GetStringNull(ref SqlDataReader sqldr, string strColumn)
        {
            try
            {
                return sqldr.IsDBNull(sqldr.GetOrdinal(strColumn)) ? null : sqldr.GetString(sqldr.GetOrdinal(strColumn));
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Converte para DBNull.Value os parâmetros que forem vazios (0, null, String.Empty, DateTime.MinValue).
        /// </summary>
        /// <param name="sqlpJunked">O vetor de parâmetros para transformar.</param>
        protected void ToDBNull(ref SqlParameter[] sqlpJunked)
        {
            foreach (SqlParameter sqlpNull in sqlpJunked)
            {
                if
                (
                    sqlpNull.Value == null
                    || sqlpNull.Value.ToString().Trim() == string.Empty
                    || sqlpNull.Value.ToString() == "0"
                    || sqlpNull.Value.ToString() == DateTime.MinValue.ToString()
                )
                {
                    sqlpNull.Value = DBNull.Value;
                }
            }
            //return sqlpJunked;
        }

        /// <summary>
        /// Caso o valor inteiro seja 0, converte para DBNull.value
        /// </summary>
        /// <param name="intValue">Valor inteiro a ser tratado</param>
        /// <returns>DBNull.value ou o valor inteiro</returns>
        protected Object ToDBNull(int intValue)
        {
            if (intValue == 0)
                return DBNull.Value;
            else
                return intValue;
        }

        /// <summary>
        /// Caso o valor float seja 0, converte para DBNull.value
        /// </summary>
        /// <param name="intValue">Valor float a ser tratado</param>
        /// <returns>DBNull.value ou o valor float</returns>
        protected Object ToDBNull(float fltValue)
        {
            if (fltValue == 0)
                return DBNull.Value;
            else
                return fltValue;
        }

        /// <summary>
        /// Caso o valor decimal seja 0, converte para DBNull.value
        /// </summary>
        /// <param name="intValue">Valor decimal a ser tratado</param>
        /// <returns>DBNull.value ou o valor decimal</returns>
        protected Object ToDBNull(decimal decValue)
        {
            if (decValue == 0)
                return DBNull.Value;
            else
                return decValue;
        }

        /// <summary>
        /// Caso o valor DateTime seja DateTime.MinValue, converte para DBNull.value
        /// </summary>
        /// <param name="intValue">Valor DateTime a ser tratado</param>
        /// <returns>DBNull.value ou o valor DateTime</returns>
        protected Object ToDBNull(DateTime datValue)
        {
            if (datValue == DateTime.MinValue)
                return DBNull.Value;
            else
                return datValue;
        }

        /// <summary>
        /// Caso o valor String seja Empty ou Null, converte para DBNull.value
        /// </summary>
        /// <param name="intValue">Valor String a ser tratado</param>
        /// <returns>DBNull.value ou o valor String</returns>
        protected Object ToDBNull(string strValue)
        {
            if (string.IsNullOrEmpty(strValue.Trim()))
                return DBNull.Value;
            else
                return strValue;
        }

        public void FechaConn()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }

    }
}
