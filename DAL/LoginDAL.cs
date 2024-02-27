using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class LoginDAL : clsConexao
    {

        public bool Validar(string login, string senha)
        {
            Login _Log;
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                new SqlParameter("@login", login),
                new SqlParameter("@senha", senha),
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Login_Valida");

            dr.Read();

            if (dr["ID"] == DBNull.Value)
            {
                Logado = false;
                return false;
            }

            _Log = new Login();

            if (dr["ID"] != DBNull.Value)
                _Log.ID = Convert.ToInt32(dr["ID"]);
            if (dr["login"] != DBNull.Value)
                _Log.LOGIN = Convert.ToString(dr["login"]);
            if (dr["Tipo"] != DBNull.Value)
                _Log.Tipo = Convert.ToString(dr["Tipo"]);
               
            _Log.DataUltimo = DateTime.Now;
            Login_Atual.Add(_Log);

            Logado = true;
            FechaConn();
            return true;

        }

        public bool Incluir(Login login, string senha)
        {
            int Retorno = 0;
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                new SqlParameter("@ID", login.ID),
				new SqlParameter("@login", login.LOGIN),
				new SqlParameter("@senha", senha),
				new SqlParameter("@Tipo", login.Tipo),
             };


            Retorno = Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Login_Add"));

            if (Retorno == 2)
            {
                Logado = false;
                return false;
            }
            else
            {
                Logado = true;
                return true;
            }
        }

        public Login Login_Atual_Sel(string LOGIN)
        {
            Login _Log =  new Login();
            for (int i = 0; i < Login_Atual.Count; i++)
            {
                if (Login_Atual[i].LOGIN == LOGIN)
                {
                    _Log = Login_Atual[i];
                }
            }
            return _Log; 
        }

        public bool get_Logado(string LOGIN)
        {
            bool _Logado = false;
            for (int i = 0; i < Login_Atual.Count; i++)
            {
                if (Login_Atual[i].LOGIN == LOGIN && Login_Atual[i].Logado == true)
                {
                    _Logado = true;
                }
            }
            return _Logado; 
        }

        public void SairLogin(string LOGIN)
        {
            Logado = false;
            for (int i = 0; i < Login_Atual.Count; i++)
            {
                if (Login_Atual[i].LOGIN == LOGIN)
                {
                    Login_Atual.RemoveAt(i);
                }
            }
        }

        public void CarregarLogin(string Login, bool _Logado)
        {
            Logado = _Logado;
            bool Achou = false;

            if (Logado == true)
            {
                Login Log = Login_Sel(Login)[0];
                Log.Logado = _Logado;
                for (int i = 0; i < Login_Atual.Count; i++)
                {
                    if (Login_Atual[i].LOGIN == Login)
                    {
                        Achou = true;
                        Login_Atual[i].ID = Log.ID;
                        Login_Atual[i].LOGIN = Log.LOGIN;
                        Login_Atual[i].Tipo = Log.Tipo;
                        Login_Atual[i].Logado = Log.Logado;
                    }
                }
                if (Achou == false)
                {
                    Login_Atual.Add(Log);
                }
            }
        }

        public List<Login> Login_Sel(string Login = null)
        {
            Login Login_Sel;
            List<Login> Lista = new List<Login>();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Login
                (Login == null ? new SqlParameter("@Login", DBNull.Value): new SqlParameter("@Login", Login))
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Login_Sel");

            while (dr.Read())
            {
                Login_Sel = new Login();
                if (dr["ID"] != DBNull.Value)
                    Login_Sel.ID = Convert.ToInt32(dr["ID"]);
                if (dr["login"] != DBNull.Value)
                    Login_Sel.LOGIN = Convert.ToString(dr["login"]);
                if (dr["Tipo"] != DBNull.Value)
                    Login_Sel.Tipo = Convert.ToString(dr["Tipo"]);
                Lista.Add(Login_Sel);
            }
            FechaConn();
            return Lista;
        }

        public void Incluir_Log(string IP, string Pagina,string PaginaAnt = null, string login = null)
        {
            SqlParameter[] sqlParam = new SqlParameter[]
            {
                new SqlParameter("@IP", IP),
                (login == null ? new SqlParameter("@login", DBNull.Value): new SqlParameter("@login", login)),
				new SqlParameter("@Pagina", Pagina),
                (PaginaAnt == null ? new SqlParameter("@PaginaAnt", DBNull.Value): new SqlParameter("@PaginaAnt", PaginaAnt)),
             };


            Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Log_Add"));

        }

    }
}
