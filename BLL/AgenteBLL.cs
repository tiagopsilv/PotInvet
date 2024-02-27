using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BLL
{
    public class AgenteBLL
    {
        /* Aqui deve conter toda regra de negócio, por exemplo, calculos
         * Sugestão essa classe instancia a dal recebendo como parâmetro um agente 
         */

        AgenteDAL DAL;
        MensagemDAL MensagemDAL;

        public AgenteBLL()
        {
           DAL = new AgenteDAL();
           MensagemDAL = new MensagemDAL();
		}

        public Agente Incluir(Agente Agente, string Usuario = null)
        {
            return Selecionar(DAL.Agentes_Add(Agente, Usuario));
        }

        public Agente Alterar(Agente Agente, string Usuario = null)
        {
            Agente Atual = Selecionar(Agente.ID_Agente);

            if (Atual.Logo != Agente.Logo & Agente.Logo != null) Atual.Logo = Agente.Logo;
            if (Atual.Nome != Agente.Nome & Agente.Nome != null) Atual.Nome = Agente.Nome;
            if (Atual.CPF != Agente.CPF & Agente.CPF != null) Atual.CPF = Agente.CPF;
            if (Atual.CNPJ != Agente.CNPJ & Agente.CNPJ != null) Atual.CNPJ = Agente.CNPJ;
            if (Atual.Email != Agente.Email & Agente.Email != null) Atual.Email = Agente.Email;
            if (Atual.DDD != Agente.DDD & Agente.DDD != 0) Atual.DDD = Agente.DDD;
            if (Atual.Telefone != Agente.Telefone & Agente.Telefone != null) Atual.Telefone = Agente.Telefone;
            if (Atual.DDD_Celular != Agente.DDD_Celular & Agente.DDD_Celular != 0) Atual.DDD_Celular = Agente.DDD_Celular;
            if (Atual.Celular != Agente.Celular & Agente.Celular != null) Atual.Celular = Agente.Celular;
            if (Atual.Endereco != Agente.Endereco & Agente.Endereco != null) Atual.Endereco = Agente.Endereco;
            if (Atual.Complemento != Agente.Complemento & Agente.Complemento != null) Atual.Complemento = Agente.Complemento;
            if (Atual.CEP != Agente.CEP & Agente.CEP != null) Atual.CEP = Agente.CEP;
            if (Atual.Cidade != Agente.Cidade & Agente.Cidade != null) Atual.Cidade = Agente.Cidade;
            if (Atual.UF != Agente.UF & Agente.UF != null) Atual.UF = Agente.UF;
            
            DAL.Agentes_Upd(Atual, Usuario);

            return Selecionar(Atual.ID_Agente);

        }

        public Agente Selecionar(int ID_Agente)
        {
           return DAL.Agentes_Sel(ID_Agente);
        }

        public bool Excluir(int ID_Agente)
        {

            return false;
        }

        public List<Mensagem> SelecionarMensagem(int IDProjeto)
        {
            return MensagemDAL.Mensagem_Sel("Agente", 0, IDProjeto);
        }

    }
}