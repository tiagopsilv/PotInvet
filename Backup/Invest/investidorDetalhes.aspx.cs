using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class investidorDetalhes : System.Web.UI.Page
    {
        private clsinvestidorDetalhes ClassinvestidorDetalhes;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassinvestidorDetalhes = new clsinvestidorDetalhes();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassinvestidorDetalhes.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassinvestidorDetalhes.Incluir_Log(strIP, "investidorDetalhes.aspx?ID=" + Request.QueryString["ID"], strUrlReferrer);

            if (ClassinvestidorDetalhes.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassinvestidorDetalhes.Usuario() + "!";
                if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
                {
                    Carregar(Convert.ToInt32(Request.QueryString["ID"]));
                }

                ClassinvestidorDetalhes.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClassinvestidorDetalhes._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

                ClassinvestidorDetalhes.carregarDoc(Convert.ToInt32(Request.QueryString["ID"]));

                lblEmail.Text = ClassinvestidorDetalhes._Projeto.Email;
                lblDDD.Text = ClassinvestidorDetalhes._Projeto.DDD;
                lblTelefone.Text = ClassinvestidorDetalhes._Projeto.Telefone;
                lblEndereco.Text = ClassinvestidorDetalhes._Projeto.Endereco;
                lblCidade.Text = ClassinvestidorDetalhes._Projeto.Cidade;
                lblEstado.Text = ClassinvestidorDetalhes._Projeto.Estado;

                ListaDocumento.DataSource = ClassinvestidorDetalhes._Documento;
                ListaDocumento.DataBind();

            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassinvestidorDetalhes.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassinvestidorDetalhes.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassinvestidorDetalhes.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassinvestidorDetalhes.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassinvestidorDetalhes.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassinvestidorDetalhes.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassinvestidorDetalhes._Login.LOGIN] = false;
            ClassinvestidorDetalhes.SairLogin();
            Response.Redirect("home.aspx");
        }


        private void Carregar(int ID)
        {
            ClassinvestidorDetalhes.CarregaProjeto(ID);

            listaEquipe.DataSource = ClassinvestidorDetalhes.ListaEmpreendedores(ClassinvestidorDetalhes._Projeto.ID_Projeto);
            listaEquipe.DataBind();

            ListaMensagem.DataSource = ClassinvestidorDetalhes.SelecionarMensagem(ClassinvestidorDetalhes._Projeto.ID_Projeto);
            ListaMensagem.DataBind();

            imageLogoUm.ImageUrl = ClassinvestidorDetalhes._Projeto.ImagemProjeto;
            lblProjeto.Text = ClassinvestidorDetalhes._Projeto.NomeProjeto;

            lblEmail.Text = ClassinvestidorDetalhes._Projeto.Email;
            lblDDD.Text = ClassinvestidorDetalhes._Projeto.DDD;
            lblTelefone.Text = ClassinvestidorDetalhes._Projeto.Telefone;
            lblEndereco.Text = ClassinvestidorDetalhes._Projeto.Endereco;
            lblCidade.Text = ClassinvestidorDetalhes._Projeto.Cidade;
            lblEstado.Text = ClassinvestidorDetalhes._Projeto.Estado;

        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

    }
}