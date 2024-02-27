using System;

namespace POCO {
    public class Custo
    {
        public int ID_Custo{ get; set; }
        public int ID_Projeto{ get; set; }
        public string Descricao{ get; set; }
        public decimal CustoEstimado{ get; set; }
        public string Justificativa{ get; set; }
        public DateTime Data{ get; set; }
    }
}
