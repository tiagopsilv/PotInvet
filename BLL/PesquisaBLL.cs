using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class PesquisaBLL
    {
        PesquisaDAL DAL;

        public PesquisaBLL()
        {
            DAL = new PesquisaDAL();
        }

        public int Incluir(Pesquisa Pesquisa, string LOGIN)
        {
           return DAL.Pesquisa_Add(Pesquisa, LOGIN);
        }

        public bool VerifUsuario(int ID_Investidor, string Tipo)
        {
            return DAL.Pesquisa_Verif(ID_Investidor, Tipo);
        }

    }
}
