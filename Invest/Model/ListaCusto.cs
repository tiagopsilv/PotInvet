using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCO;

namespace Invest.Model
{
    public class ListaCusto : Custo
    {
        public string Usuario { get; set; }
        public DateTime DataCad { get; set; }
        public String URLExcluir { get; set; }
        public String URLAtualizar { get; set; }
    }
}