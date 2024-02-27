using System;
using POCO;

namespace Invest.Model
{
    public class ListaEmpreendedor : GrupoProjeto
    {
        public string URL { get; set; }
        public string Usuario { get; set; }
        public DateTime DataCad { get; set; }
        public string Tipo { get; set; }
        public string URLExcluir { get; set; }
    }
}