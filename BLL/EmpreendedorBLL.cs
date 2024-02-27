using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class EmpreendedorBLL
    {
        EmpreendedorDAL DAL;
        GrupoProjetoDAL GrupoProjetoDAL;

        public EmpreendedorBLL()
        {
            DAL = new EmpreendedorDAL();
            GrupoProjetoDAL = new GrupoProjetoDAL();
		}

        public Empreendedor Incluir(Empreendedor Empreendedor, string LOGIN)
        {
            return Selecionar(DAL.Empreendedor_Add(Empreendedor, LOGIN));
        }

        public Empreendedor Selecionar(int ID_Empreendedo, string CPF = null)
        {
            return DAL.Empreendedor_Sel(ID_Empreendedo, CPF);
        }

        public Empreendedor Alterar(Empreendedor Empreendedor, string LOGIN)
        {
            Empreendedor Atual = Selecionar(Empreendedor.ID_Empreendedor);

            if (Atual.CPF != Empreendedor.CPF & Empreendedor.CPF != null) Atual.CPF = Empreendedor.CPF;
            if (Atual.Nome != Empreendedor.Nome & Empreendedor.Nome != null) Atual.Nome = Empreendedor.Nome;
            if (Atual.WebPage != Empreendedor.WebPage & Empreendedor.WebPage != null) Atual.WebPage = Empreendedor.WebPage;
            if (Atual.Foto != Empreendedor.Foto & Empreendedor.Foto != null) Atual.Foto = Empreendedor.Foto;
            if (Atual.Email != Empreendedor.Email & Empreendedor.Email != null) Atual.Email = Empreendedor.Email;
            if (Atual.DDD != Empreendedor.DDD & Empreendedor.DDD != 0) Atual.DDD = Empreendedor.DDD;
            if (Atual.Telefone != Empreendedor.Telefone & Empreendedor.Telefone != null) Atual.Telefone = Empreendedor.Telefone;
            if (Atual.DDD_Celular != Empreendedor.DDD_Celular & Empreendedor.DDD_Celular != 0) Atual.DDD_Celular = Empreendedor.DDD_Celular;
            if (Atual.Celular != Empreendedor.Celular & Empreendedor.Celular != null) Atual.Celular = Empreendedor.Celular;
            if (Atual.DataNascimento != Empreendedor.DataNascimento & Empreendedor.DataNascimento != null) Atual.DataNascimento = Empreendedor.DataNascimento;
            if (Atual.Escolaridade != Empreendedor.Escolaridade & Empreendedor.Escolaridade != null) Atual.Escolaridade = Empreendedor.Escolaridade;
            if (Atual.Formacao != Empreendedor.Formacao & Empreendedor.Formacao != null) Atual.Formacao = Empreendedor.Formacao;
            if (Atual.Faculdade != Empreendedor.Faculdade & Empreendedor.Faculdade != null) Atual.Faculdade = Empreendedor.Faculdade;
            if (Atual.Endereco != Empreendedor.Endereco & Empreendedor.Endereco != null) Atual.Endereco = Empreendedor.Endereco;
            if (Atual.Complemento != Empreendedor.Complemento & Empreendedor.Complemento != null) Atual.Complemento = Empreendedor.Complemento;
            if (Atual.CEP != Empreendedor.CEP & Empreendedor.CEP != null) Atual.CEP = Empreendedor.CEP;
            if (Atual.Cidade != Empreendedor.Cidade & Empreendedor.Cidade != null) Atual.Cidade = Empreendedor.Cidade;
            if (Atual.UF != Empreendedor.UF & Empreendedor.UF != null) Atual.UF = Empreendedor.UF;
            if (Atual.Sexo != Empreendedor.Sexo & Empreendedor.Sexo != null) Atual.Sexo = Empreendedor.Sexo;     

            DAL.Empreendedor_Upd(Atual, LOGIN);

            return Selecionar(Atual.ID_Empreendedor);

        }

        public GrupoProjeto IncluirEmpreendedorProjeto(GrupoProjeto GrupoProjeto, string LOGIN)
        {
            return ListaGrupoProjetos(GrupoProjetoDAL.GrupoProjeto_Add(GrupoProjeto, LOGIN))[0];
        }

        public List<GrupoProjeto> ListaGrupoProjetos(int ID_GrupoProjeto = 0, int ID_Projeto = 0, int ID_Emprededor = 0)
        {
            ProjetoBLL ProjBLL = new ProjetoBLL();
            Empreendedor Empr;
            List<GrupoProjeto> ListProjInvest;

            ListProjInvest = GrupoProjetoDAL.GrupoProjetos_Sel(ID_GrupoProjeto, ID_Projeto, ID_Emprededor);

            for (int i = 0; i < ListProjInvest.Count; i++)
            {
                Empr = Selecionar(ListProjInvest[i].ID_Empreendedor);

                ListProjInvest[i].CPF = Empr.CPF;
                ListProjInvest[i].Nome = Empr.Nome;
                ListProjInvest[i].WebPage = Empr.WebPage;
                ListProjInvest[i].Foto = Empr.Foto;
                ListProjInvest[i].Email = Empr.Email;
                ListProjInvest[i].DDD = Empr.DDD;
                ListProjInvest[i].Telefone = Empr.Telefone;
                ListProjInvest[i].DDD_Celular = Empr.DDD_Celular;
                ListProjInvest[i].Celular = Empr.Celular;
                ListProjInvest[i].DataNascimento = Empr.DataNascimento;
                ListProjInvest[i].Escolaridade = Empr.Escolaridade;
                ListProjInvest[i].Formacao = Empr.Formacao;
                ListProjInvest[i].Faculdade = Empr.Faculdade;
                ListProjInvest[i].Endereco = Empr.Endereco;
                ListProjInvest[i].Complemento = Empr.Complemento;
                ListProjInvest[i].CEP = Empr.CEP;
                ListProjInvest[i].Cidade = Empr.Cidade;
                ListProjInvest[i].UF = Empr.UF;
                ListProjInvest[i].Sexo = Empr.Sexo;
                ListProjInvest[i].Contato = Empr.Contato;
                ListProjInvest[i].Descricao = Empr.Descricao;
                ListProjInvest[i].Linkedin = Empr.Linkedin;
                ListProjInvest[i].Facebook = Empr.Facebook;
                ListProjInvest[i].GooglePlus = Empr.GooglePlus;
                ListProjInvest[i].Skype = Empr.Skype;
                ListProjInvest[i].Twitter = Empr.Twitter;
                ListProjInvest[i].Msn = Empr.Msn;
            }

            return ListProjInvest;

        }

    }
}
