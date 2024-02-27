using System;

namespace POCO
{
    public class Pesquisa
    {
        public int ID_Pesquisa { get; set; }
        public int ID_Investidor { get; set; }
        public int ID_Pergunta { get; set; }
        public bool Opcao { get; set; }
        public string Resposta { get; set; }
        public string Tipo { get; set; }
    }
}
