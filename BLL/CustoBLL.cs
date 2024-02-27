using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class CustoBLL
    {
        CustoDAL DAL;

        public CustoBLL()
        {
           DAL = new CustoDAL();
		}

        public Custo Incluir(Custo Custo, string LOGIN)
        {
            return Selecionar(DAL.Custo_Add(Custo, LOGIN));
        }

        public Custo Alterar(Custo Custo, string LOGIN)
        {
            Custo Atual = Selecionar(Custo.ID_Custo);

            if (Atual.ID_Projeto != Custo.ID_Projeto & Custo.ID_Projeto != 0) Atual.ID_Projeto = Custo.ID_Projeto;
            if (Atual.Descricao != Custo.Descricao & Custo.Descricao != null) Atual.Descricao = Custo.Descricao;
            if (Atual.CustoEstimado != Custo.CustoEstimado & Custo.CustoEstimado != 0) Atual.CustoEstimado = Custo.CustoEstimado;
            if (Atual.Justificativa != Custo.Justificativa & Custo.Justificativa != null) Atual.Justificativa = Custo.Justificativa;
            if (Atual.Data != Custo.Data & Custo.Data != null) Atual.Data = Custo.Data;

            DAL.Custos_Upd(Atual, LOGIN);

            return Selecionar(Atual.ID_Custo);

        }

        public Custo Selecionar(int ID_Custo)
        {
           return DAL.Custos_Sel(ID_Custo)[0];
        }

        public bool Excluir(int ID_Custo)
        {
            DAL.Custos_Del(ID_Custo);
            return true;
        }

        public List<Custo> Listar(int ID_Projeto)
        {
            return DAL.Custos_Sel(0, ID_Projeto);
        }
    }
}
