using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class LucroBLL
    {
        LucroDAL DAL;

        public LucroBLL()
        {
            DAL = new LucroDAL();
        }

        public Lucro Incluir(Lucro Lucro, string LOGIN)
        {
            return Selecionar(DAL.Lucro_Add(Lucro, LOGIN));
        }

        public Lucro Alterar(Lucro Lucro, string LOGIN)
        {
            Lucro Atual = Selecionar(Lucro.ID_Lucro);

            if (Atual.ID_Projeto != Lucro.ID_Projeto & Lucro.ID_Projeto != 0) Atual.ID_Projeto = Lucro.ID_Projeto;
            if (Atual.Descricao != Lucro.Descricao & Lucro.Descricao != null) Atual.Descricao = Lucro.Descricao;
            if (Atual.ValorEstimado != Lucro.ValorEstimado & Lucro.ValorEstimado != 0) Atual.ValorEstimado = Lucro.ValorEstimado;
            if (Atual.Justificativa != Lucro.Justificativa & Lucro.Justificativa != null) Atual.Justificativa = Lucro.Justificativa;
            if (Atual.Data != Lucro.Data & Lucro.Data != null) Atual.Data = Lucro.Data;

            DAL.Lucro_Upd(Atual, LOGIN);

            return Selecionar(Atual.ID_Lucro);

        }

        public Lucro Selecionar(int ID_Lucro)
        {
            return DAL.Lucros_Sel(ID_Lucro)[0];
        }

        public bool Excluir(int ID_Lucro)
        {
            DAL.Lucros_Del(ID_Lucro);
            return true;
        }

        public List<Lucro> Listar(int ID_Projeto)
        {
            return DAL.Lucros_Sel(0, ID_Projeto);
        }
    }
}
