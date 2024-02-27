using System;

namespace POCO
{
    public class ProjetosVisitados : Projeto
    {
        public int ID_ProjetoVisitados{ get; set; }
        public int ID_Projeto{ get; set; }
        public int ID_Investidor{ get; set; }
        public DateTime Data{ get; set; }
        public DateTime Hora { get; set; }
        public string NomeProjeto { get; set; }
    }
}
