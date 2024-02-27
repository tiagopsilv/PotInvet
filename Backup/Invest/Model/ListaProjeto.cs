using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;

namespace Invest.Model
{
    public class ListaProjeto : Projeto
    {
        public string Usuario { get; set; }
        public DateTime DataCad { get; set; }
        public bool AlteracaoCadastroAgente { get; set; }
    }
}