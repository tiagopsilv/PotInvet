using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class ProjetoBLL
    {
        ProjetoDAL DAL;
        ProjetosInvestidosDAL ProjetosInvestidosDAL;
        DocumentoDAL DocumentoDAL;
        ProjetosVisitadosDAL ProjetosVisitadosDAL;
        MensagemDAL MensagemDAL;

        public ProjetoBLL()
        {
            DAL = new ProjetoDAL();
            ProjetosInvestidosDAL = new ProjetosInvestidosDAL();
            DocumentoDAL = new DocumentoDAL();
            ProjetosVisitadosDAL = new ProjetosVisitadosDAL();
            MensagemDAL = new MensagemDAL();
		}

        public Projeto Incluir(Projeto Projeto, string LOGIN)
        {
            return Selecionar(DAL.Projeto_Add(Projeto, LOGIN));
        }

        public Projeto Selecionar(int ID_Projeto)
        {
            return DAL.Projeto_Sel(ID_Projeto)[0];
        }

        public Projeto Alterar(Projeto Projeto, string LOGIN)
        {
            Projeto Atual = Selecionar(Projeto.ID_Projeto);

            if (Atual.NomeProjeto != Projeto.NomeProjeto & Projeto.NomeProjeto != null) Atual.NomeProjeto = Projeto.NomeProjeto;
            if (Atual.DescricaoProjeto != Projeto.DescricaoProjeto & Projeto.DescricaoProjeto != null) Atual.DescricaoProjeto = Projeto.DescricaoProjeto;
            if (Atual.ImagemProjeto != Projeto.ImagemProjeto & Projeto.ImagemProjeto != null) Atual.ImagemProjeto = Projeto.ImagemProjeto;
            if (Atual.VideoProjeto != Projeto.VideoProjeto & Projeto.VideoProjeto != null) Atual.VideoProjeto = Projeto.VideoProjeto;
            if (Atual.PerfilProjeto != Projeto.PerfilProjeto & Projeto.PerfilProjeto != null) Atual.PerfilProjeto = Projeto.PerfilProjeto;
            if (Atual.RamoAtividade != Projeto.RamoAtividade & Projeto.RamoAtividade != null) Atual.RamoAtividade = Projeto.RamoAtividade;
            if (Atual.ImgApres != Projeto.ImgApres & Projeto.ImgApres != null) Atual.ImgApres = Projeto.ImgApres;

            DAL.Projeto_Upd(Atual, LOGIN);

            return Selecionar(Atual.ID_Projeto);

        }

        public List<Projeto> Listar(int ID_Projeto = 0, string PerfilProjeto = null, bool Industria = false, bool Varejo = false, bool Artistico = false, bool TI = false, bool Pw = false, bool Video = false, bool Audio = false, string Where = null, int ID_Agente = 0)
        {
            return DAL.Projeto_Sel(ID_Projeto, PerfilProjeto, Industria, Varejo, Artistico, TI, Pw, Video, Audio, Where, ID_Agente);
        }

        public ProjetosInvestidos InvestirProjeto(int ID_Projeto, int ID_Investidor, decimal Valor, string LOGIN)
        {
            ProjetosInvestidos IP = new ProjetosInvestidos();
            Projeto Proj;
            List<ProjetosInvestidos> ListProjInvest;
            int ID_ProjetosInvestidos;

            IP.ID_Projeto = ID_Projeto;
            IP.ID_Investidor = ID_Investidor;
            IP.Valor = Valor;

            ID_ProjetosInvestidos = ProjetosInvestidosDAL.ProjetosInvestidos_Add(IP, LOGIN);

            ListProjInvest = ProjetosInvestidosDAL.ProjetosInvestidos_Sel(ID_ProjetosInvestidos, ID_Investidor, ID_Projeto);

            for (int i = 0; i < ListProjInvest.Count; i++)
            {
                Proj = Selecionar(ListProjInvest[i].ID_Projeto);

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

            return ListProjInvest[0];
        }


        public Documento IncluirDocumento(Documento Documento, string LOGIN)
        {
            return SeleciorDocumento(DocumentoDAL.Documento_Add(Documento, LOGIN))[0];
        }

        public List<Documento> SeleciorDocumento(int ID_Documento = 0, int ID_Projeto = 0)
        {
            return DocumentoDAL.Documentos_Sel(ID_Documento, ID_Projeto);
        }

        public Documento AtualizarDocumento(Documento Documento, string LOGIN)
        {
            Documento Atual = SeleciorDocumento(Documento.ID_Documento)[0];

            if (Atual.ID_Projeto != Documento.ID_Projeto & Documento.ID_Projeto != 0) Atual.ID_Projeto = Documento.ID_Projeto;
            if (Atual.EnderecoDocumento != Documento.EnderecoDocumento & Documento.EnderecoDocumento != null) Atual.EnderecoDocumento = Documento.EnderecoDocumento;
            if (Atual.Titulo != Documento.Titulo & Documento.Titulo != null) Atual.Titulo = Documento.Titulo;
            if (Atual.Tipo != Documento.Tipo & Documento.Tipo != null) Atual.Tipo = Documento.Tipo;

            DocumentoDAL.Documento_Upd(Atual, LOGIN);

            return SeleciorDocumento(Atual.ID_Documento)[0];
        }

        public bool ExcluirDocumento(int ID_Documento)
        {
            return DocumentoDAL.Documento_Del(ID_Documento);
        }

        public void DarNotaProjeto(int ID_Projetos, int ID_Investidor, int Nota, string LOGIN)
        {
            DAL.Ranking_Add(ID_Projetos, ID_Investidor, Nota, LOGIN);
        }

        public ProjetosVisitados IncluirProjetosVisitados(ProjetosVisitados ProjetosVisitados, string LOGIN)
        {
            return SeleciorProjetosVisitados(ProjetosVisitadosDAL.ProjetosVisitados_Add(ProjetosVisitados, LOGIN))[0];
        }

        public List<ProjetosVisitados> SeleciorProjetosVisitados(int ID_ProjetosVisitados = 0, int ID_Investidor = 0, int ID_Projeto = 0)
        {
            return ProjetosVisitadosDAL.ProjetosVisitados_Sel(ID_ProjetosVisitados, ID_Investidor, ID_Projeto);
        }

        public List<Mensagem> SelecionarMensagem(int IDProjeto)
        {
            return MensagemDAL.Mensagem_Sel("Projeto", 0, IDProjeto);
        }

        public List<ProjetosInvestidos> SelecionarProjetosInvestidos(int ID_ProjetosInvestidos = 0, int ID_Investidor = 0, int ID_Projeto = 0)
        {
            return ProjetosInvestidosDAL.ProjetosInvestidos_Sel(ID_ProjetosInvestidos, ID_Investidor, ID_Projeto);
        }

    }
}
