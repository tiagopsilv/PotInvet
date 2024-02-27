using System;

namespace POCO
{
    public class Projeto
    {
        public int ID_Projeto{ get; set; }
        public string NomeProjeto{ get; set; }
        public string DescricaoProjeto{ get; set; }
        public string ImagemProjeto{ get; set; }
        public string VideoProjeto{ get; set; }
        public string PerfilProjeto{ get; set; }
        public string RamoAtividade{ get; set; }
        public int Ranking{ get; set; }
        public decimal Custo_Projeto{ get; set; }
        public decimal Valor_Arrecadado { get; set; }
        public decimal Porcentagem { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string ImgApres { get; set; }
        public int ID_Agente { get; set; }
        public string ROIImg { get; set; }
    }

}
