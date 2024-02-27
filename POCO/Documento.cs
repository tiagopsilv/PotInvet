using System;

namespace POCO
{
    public class Documento
    {
        public int ID_Documento{ get; set; }
        public int ID_Projeto{ get; set; }
        public string EnderecoDocumento { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
    }
}
