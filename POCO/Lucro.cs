using System;

namespace POCO
{
    public class Lucro
    {
        public int ID_Lucro { get; set; }
        public int ID_Projeto { get; set; }
        public string Descricao { get; set; }
        public decimal ValorEstimado { get; set; }
        public string Justificativa { get; set; }
        public DateTime Data { get; set; }
    }
}