using System;
using POCO;

namespace Invest.Model
{
    public class ListaInvestidor : Projeto
    {
        public string TextoResumo { get; set; }
        public bool star1 { get; set; }
        public bool star2 { get; set; }
        public bool star3 { get; set; }
        public bool star4 { get; set; }
        public bool star5 { get; set; }
        public int Porcentagem100 { get; set; }
        public int Porcentagem0 { get; set; }
        public string Url { get; set; }
        public string UrlAtualizar { get; set; }
        public string UrlAtualizarLucro { get; set; }
        public string UrlAtualizarCusto { get; set; }
    }
}