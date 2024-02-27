using System;

namespace POCO
{
    public class Login
    {
        public int ID { get; set; }
        public string LOGIN { get; set; }
        public string Tipo { get; set; }
        public DateTime DataUltimo { get; set; }
        public bool Logado { get; set; }
    }
}
