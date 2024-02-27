using System;

namespace POCO
{
    public class ProjetosInvestidos : Projeto
    {
        public int ID_ProjetoInvestidos { get; set; }
        public int ID_Investidor { get; set; }
        public int ID_Projeto { get; set; }
        public Decimal Valor { get; set; }
    }
}
