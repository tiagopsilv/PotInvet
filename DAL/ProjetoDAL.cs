using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using POCO;

namespace DAL
{
    public class ProjetoDAL : clsConexao
    {
        public int Projeto_Add(Projeto Projeto, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Projeto

                (Projeto.NomeProjeto == null ? new SqlParameter("@NomeProjeto", DBNull.Value): new SqlParameter("@NomeProjeto", Projeto.NomeProjeto)),
                (Projeto.DescricaoProjeto == null ? new SqlParameter("@DescricaoProjeto", DBNull.Value): new SqlParameter("@DescricaoProjeto", Projeto.DescricaoProjeto)),
                (Projeto.ImagemProjeto == null ? new SqlParameter("@ImagemProjeto", DBNull.Value): new SqlParameter("@ImagemProjeto", Projeto.ImagemProjeto)),
                (Projeto.VideoProjeto == null ? new SqlParameter("@VideoProjeto", DBNull.Value): new SqlParameter("@VideoProjeto", Projeto.VideoProjeto)),
                (Projeto.PerfilProjeto == null ? new SqlParameter("@PerfilProjeto", DBNull.Value): new SqlParameter("@PerfilProjeto", Projeto.PerfilProjeto)),
                (Projeto.RamoAtividade == null ? new SqlParameter("@RamoAtividade", DBNull.Value): new SqlParameter("@RamoAtividade", Projeto.RamoAtividade)),
                (Projeto.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", Projeto.Email)),
                (Projeto.DDD == null ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", Projeto.DDD)),
                (Projeto.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", Projeto.Telefone)),
                (Projeto.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", Projeto.Endereco)),
                (Projeto.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", Projeto.Cidade)),
                (Projeto.Estado == null ? new SqlParameter("@Estado", DBNull.Value): new SqlParameter("@Estado", Projeto.Estado)),
                (Projeto.ImgApres == null ? new SqlParameter("@ImgApres", DBNull.Value): new SqlParameter("@ImgApres", Projeto.ImgApres)),
                (Projeto.ID_Agente == 0 ? new SqlParameter("@ID_Agente", DBNull.Value): new SqlParameter("@ID_Agente", Projeto.ID_Agente)),
                (Projeto.ROIImg == null ? new SqlParameter("@ROIImg", DBNull.Value): new SqlParameter("@ROIImg", Projeto.ROIImg)),
                new SqlParameter("@Usuario", LOGIN)
             };

            return Convert.ToInt32(ExecuteScalar(sqlParam, "sp_Projetos_Add"));
        }

        public List<Projeto> Projeto_Sel(int ID_Projeto = 0, string PerfilProjeto = null, bool Industria = false, bool Varejo = false, bool Artistico = false, bool TI = false, bool Pw = false, bool Video = false, bool Audio = false, string Where = null, int ID_Agente = 0)
        {
            List<Projeto> ListProjeto= new List<Projeto>();
            Projeto _Projeto;

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Projeto
                (ID_Projeto == 0 ? new SqlParameter("@ID_Projeto", DBNull.Value): new SqlParameter("@ID_Projeto", ID_Projeto)),
                (PerfilProjeto == null ? new SqlParameter("@PerfilProjeto", DBNull.Value): new SqlParameter("@PerfilProjeto", PerfilProjeto)),
                new SqlParameter("@Industria", Industria),
                new SqlParameter("@Varejo", Varejo),
                new SqlParameter("@Artistico", Artistico),
                new SqlParameter("@TI", TI),
                new SqlParameter("@Pw", Pw),
                new SqlParameter("@Video", Video),
                new SqlParameter("@Audio", Audio),
                (Where == null ? new SqlParameter("@_Where", DBNull.Value): new SqlParameter("@_Where", Where)),
                (ID_Agente == 0 ? new SqlParameter("@ID_Agente", DBNull.Value): new SqlParameter("@ID_Agente", ID_Agente)),
             };

            SqlDataReader dr = ExecuteReader(sqlParam, "sp_Projetos_Sel");

            while (dr.Read())
            {
                _Projeto = new Projeto();
                _Projeto.ID_Projeto = Convert.ToInt32(dr["ID_Projeto"]);
                if (dr["NomeProjeto"] != DBNull.Value) _Projeto.NomeProjeto = Convert.ToString(dr["NomeProjeto"]);
                if (dr["DescricaoProjeto"] != DBNull.Value) _Projeto.DescricaoProjeto = Convert.ToString(dr["DescricaoProjeto"]);
                if (dr["ImagemProjeto"] != DBNull.Value) _Projeto.ImagemProjeto = Convert.ToString(dr["ImagemProjeto"]);
                if (dr["DescricaoProjeto"] != DBNull.Value) _Projeto.DescricaoProjeto = Convert.ToString(dr["DescricaoProjeto"]);
                if (dr["ImagemProjeto"] != DBNull.Value) _Projeto.ImagemProjeto = Convert.ToString(dr["ImagemProjeto"]);
                if (dr["VideoProjeto"] != DBNull.Value) _Projeto.VideoProjeto = Convert.ToString(dr["VideoProjeto"]);
                if (dr["PerfilProjeto"] != DBNull.Value) _Projeto.PerfilProjeto = Convert.ToString(dr["PerfilProjeto"]);
                if (dr["RamoAtividade"] != DBNull.Value) _Projeto.RamoAtividade = Convert.ToString(dr["RamoAtividade"]);
                if (dr["Ranking"] != DBNull.Value) _Projeto.Ranking = Convert.ToInt32(dr["Ranking"]);
                if (dr["Custo_Projeto"] != DBNull.Value) _Projeto.Custo_Projeto = Convert.ToDecimal(dr["Custo_Projeto"]);
                if (dr["Valor_Arrecadado"] != DBNull.Value) _Projeto.Valor_Arrecadado = Convert.ToDecimal(dr["Valor_Arrecadado"]);
                if (dr["Porcentagem"] != DBNull.Value) _Projeto.Porcentagem = Convert.ToDecimal(dr["Porcentagem"]);
                if (dr["Data"] != DBNull.Value) _Projeto.Data = Convert.ToDateTime(dr["Data"]);
                if (dr["Email"] != DBNull.Value) _Projeto.Email = Convert.ToString(dr["Email"]);
                if (dr["DDD"] != DBNull.Value) _Projeto.DDD = Convert.ToString(dr["DDD"]);
                if (dr["Telefone"] != DBNull.Value) _Projeto.Telefone = Convert.ToString(dr["Telefone"]);
                if (dr["Endereco"] != DBNull.Value) _Projeto.Endereco = Convert.ToString(dr["Endereco"]);
                if (dr["Cidade"] != DBNull.Value) _Projeto.Cidade = Convert.ToString(dr["Cidade"]);
                if (dr["Estado"] != DBNull.Value) _Projeto.Estado = Convert.ToString(dr["Estado"]);
                if (dr["ImgApres"] != DBNull.Value) _Projeto.ImgApres = Convert.ToString(dr["ImgApres"]);
                if (dr["ID_Agente"] != DBNull.Value) _Projeto.ID_Agente = Convert.ToInt32(dr["ID_Agente"]);
                if (dr["ROIImg"] != DBNull.Value) _Projeto.ROIImg = Convert.ToString(dr["ROIImg"]);

                ListProjeto.Add(_Projeto);
            }
            FechaConn();
            return ListProjeto;
        }

        public void Projeto_Upd(Projeto Projeto, string LOGIN)
        {
            DateTime Compara = new DateTime();

            SqlParameter[] sqlParam = new SqlParameter[]
            {
                //TODO: Incluir todos os parametros de Projeto
                new SqlParameter("@ID_Projeto", Projeto.ID_Projeto),
                (Projeto.NomeProjeto == null ? new SqlParameter("@NomeProjeto", DBNull.Value): new SqlParameter("@NomeProjeto", Projeto.NomeProjeto)),
	            (Projeto.DescricaoProjeto == null ? new SqlParameter("@DescricaoProjeto", DBNull.Value): new SqlParameter("@DescricaoProjeto", Projeto.DescricaoProjeto)),
	            (Projeto.ImagemProjeto == null ? new SqlParameter("@ImagemProjeto", DBNull.Value): new SqlParameter("@ImagemProjeto", Projeto.ImagemProjeto)),
	            (Projeto.VideoProjeto == null ? new SqlParameter("@VideoProjeto", DBNull.Value): new SqlParameter("@VideoProjeto", Projeto.VideoProjeto)),
	            (Projeto.PerfilProjeto == null ? new SqlParameter("@PerfilProjeto", DBNull.Value): new SqlParameter("@PerfilProjeto", Projeto.PerfilProjeto)),
	            (Projeto.RamoAtividade == null ? new SqlParameter("@RamoAtividade", DBNull.Value): new SqlParameter("@RamoAtividade", Projeto.RamoAtividade)),
                (Projeto.Data == Compara ? new SqlParameter("@Data", DBNull.Value): new SqlParameter("@Data", Projeto.Data)),
                (Projeto.Email == null ? new SqlParameter("@Email", DBNull.Value): new SqlParameter("@Email", Projeto.Email)),
                (Projeto.DDD == null ? new SqlParameter("@DDD", DBNull.Value): new SqlParameter("@DDD", Projeto.DDD)),
                (Projeto.Telefone == null ? new SqlParameter("@Telefone", DBNull.Value): new SqlParameter("@Telefone", Projeto.Telefone)),
                (Projeto.Endereco == null ? new SqlParameter("@Endereco", DBNull.Value): new SqlParameter("@Endereco", Projeto.Endereco)),
                (Projeto.Cidade == null ? new SqlParameter("@Cidade", DBNull.Value): new SqlParameter("@Cidade", Projeto.Cidade)),
                (Projeto.Estado == null ? new SqlParameter("@Estado", DBNull.Value): new SqlParameter("@Estado", Projeto.Estado)),
                (Projeto.ImgApres == null ? new SqlParameter("@ImgApres", DBNull.Value): new SqlParameter("@ImgApres", Projeto.ImgApres)),
                (Projeto.ID_Agente == 0 ? new SqlParameter("@ID_Agente", DBNull.Value): new SqlParameter("@ID_Agente", Projeto.ID_Agente)),
                (Projeto.ROIImg == null ? new SqlParameter("@ROIImg", DBNull.Value): new SqlParameter("@ROIImg", Projeto.ROIImg)),
                new SqlParameter("@Usuario", LOGIN),
             };

            ExecuteScalar(sqlParam, "sp_Projetos_Upd");

        }

        public void Ranking_Add(int ID_Projetos, int ID_Investidor, int Nota, string LOGIN)
        {
            SqlParameter[] sqlParam = new SqlParameter[]

            {
                //TODO: Incluir todos os parametros de Projeto

                (ID_Projetos == 0 ? new SqlParameter("@ID_Projetos", DBNull.Value): new SqlParameter("@ID_Projetos", ID_Projetos)),
                (ID_Investidor == 0 ? new SqlParameter("@ID_Investidor", DBNull.Value): new SqlParameter("@ID_Investidor", ID_Investidor)),
                (Nota == null ? new SqlParameter("@Nota", DBNull.Value): new SqlParameter("@Nota", Nota)),
                new SqlParameter("@Usuario", LOGIN)
             };

            ExecuteScalar(sqlParam, "sp_Ranking_Add");
        }

    }
}
