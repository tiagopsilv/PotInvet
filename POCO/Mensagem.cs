using System;

namespace POCO
{
    public class Mensagem
    {
        public int ID_Mensagens{ get; set; }
        public int ID{ get; set; }
        public string Tipo { get; set; }
        public string Texto{ get; set; }
        public string Titulo{ get; set; }
        public DateTime Data{ get; set; }
        public string Usuario{ get; set; }
        public string URL { get; set; }
    }
}
