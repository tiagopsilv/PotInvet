using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class InvestidorBLL
    {
        InvestidorDAL DAL;
        ProjetosInvestidosDAL ProjetosInvestidosDAL;
        MensagemDAL MensagemDAL;

        public InvestidorBLL()
        {
            DAL = new InvestidorDAL();
            ProjetosInvestidosDAL = new ProjetosInvestidosDAL();
            MensagemDAL = new MensagemDAL();
		}

        public Investidor Incluir(Investidor Investidor, string Usuario = null)
        {
            return Selecionar(DAL.Investidor_Add(Investidor, Usuario));
        }

        public Investidor Selecionar(int ID_Investidor, string CPF = null)
        {
            return DAL.Investidor_Sel(ID_Investidor, CPF);
        }

        public Investidor Alterar(Investidor Investidor, String Usuario = null)
        {
            Investidor Atual = Selecionar(Investidor.ID_Investidor);

            if (Atual.CPF != Investidor.CPF & Investidor.CPF != null) Atual.CPF = Investidor.CPF;
            if (Atual.Nome != Investidor.Nome & Investidor.Nome != null) Atual.Nome = Investidor.Nome;
            if (Atual.WebPage != Investidor.WebPage & Investidor.WebPage != null) Atual.WebPage = Investidor.WebPage;
            if (Atual.Email != Investidor.Email & Investidor.Email != null) Atual.Email = Investidor.Email;
            if (Atual.DDD != Investidor.DDD & Investidor.DDD != 0) Atual.DDD = Investidor.DDD;
            if (Atual.Telefone != Investidor.Telefone & Investidor.Telefone != null) Atual.Telefone = Investidor.Telefone;
            if (Atual.DDD_Celular != Investidor.DDD_Celular & Investidor.DDD_Celular != 0) Atual.DDD_Celular = Investidor.DDD_Celular;
            if (Atual.Celular != Investidor.Celular & Investidor.Celular != null) Atual.Celular = Investidor.Celular;
            if (Atual.DataNascimento != Investidor.DataNascimento & Investidor.DataNascimento != null) Atual.DataNascimento = Investidor.DataNascimento;
            if (Atual.Endereco != Investidor.Endereco & Investidor.Endereco != null) Atual.Endereco = Investidor.Endereco;
            if (Atual.Complemento != Investidor.Complemento & Investidor.Complemento != null) Atual.Complemento = Investidor.Complemento;
            if (Atual.CEP != Investidor.CEP & Investidor.CEP != null) Atual.CEP = Investidor.CEP;
            if (Atual.Cidade != Investidor.Cidade & Investidor.Cidade != null) Atual.Cidade = Investidor.Cidade;
            if (Atual.UF != Investidor.UF & Investidor.UF != null) Atual.UF = Investidor.UF;
            if (Atual.Sexo != Investidor.Sexo & Investidor.Sexo != null) Atual.Sexo = Investidor.Sexo;
            if (Atual.Foto != Investidor.Foto & Investidor.Foto != null) Atual.Foto = Investidor.Foto;

            DAL.Investidor_Upd(Atual, Usuario);

            return Selecionar(Atual.ID_Investidor);

        }

        public List<ProjetosInvestidos> ListaProjetos(int ID_Investidor)
        {
            ProjetoBLL ProjBLL = new ProjetoBLL();
            Projeto Proj;
            List<ProjetosInvestidos> ListProjInvest;
            
            ListProjInvest = ProjetosInvestidosDAL.ProjetosInvestidos_Sel(0, ID_Investidor);

            for (int i = 0; i < ListProjInvest.Count; i++)
            {
                Proj = ProjBLL.Selecionar(ListProjInvest[i].ID_Projeto);

                ListProjInvest[i].NomeProjeto = Proj.NomeProjeto;
                ListProjInvest[i].DescricaoProjeto = Proj.DescricaoProjeto;
                ListProjInvest[i].ImagemProjeto = Proj.ImagemProjeto;
                ListProjInvest[i].VideoProjeto = Proj.VideoProjeto;
                ListProjInvest[i].PerfilProjeto = Proj.PerfilProjeto;
                ListProjInvest[i].RamoAtividade = Proj.RamoAtividade;
                ListProjInvest[i].Ranking = Proj.Ranking;
                ListProjInvest[i].Custo_Projeto = Proj.Custo_Projeto;
                ListProjInvest[i].Valor_Arrecadado = Proj.Valor_Arrecadado;
                ListProjInvest[i].Porcentagem = Proj.Porcentagem;
                ListProjInvest[i].Data = Proj.Data;
                ListProjInvest[i].Email = Proj.Email;
                ListProjInvest[i].DDD = Proj.DDD;
                ListProjInvest[i].Telefone = Proj.Telefone;
                ListProjInvest[i].Endereco = Proj.Endereco;
                ListProjInvest[i].Cidade = Proj.Cidade;
                ListProjInvest[i].Estado = Proj.Estado;
                ListProjInvest[i].ImgApres = Proj.ImgApres;
                ListProjInvest[i].ID_Agente = Proj.ID_Agente;

            }

            return ListProjInvest;

        }

        public List<Mensagem> SelecionarMensagem(int IDInvestidor)
        {
            return MensagemDAL.Mensagem_Sel("Investidor", 0, IDInvestidor);
        }

    }
}
