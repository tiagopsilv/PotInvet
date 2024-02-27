using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class DetalheEmpreendedor : System.Web.UI.Page
    {
        public clsDetalheEmpreendedor ClassDetalheEmpreendedor;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassDetalheEmpreendedor = new clsDetalheEmpreendedor();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassDetalheEmpreendedor.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            if (ClassDetalheEmpreendedor.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassDetalheEmpreendedor.Usuario() + "!";

                ClassDetalheEmpreendedor.ID = Convert.ToInt32(Request.QueryString["ID"]);

                ClassDetalheEmpreendedor.ID_Projeto = Convert.ToInt32(Request.QueryString["ID_Projeto"]);

                ClassDetalheEmpreendedor.Tipo = Convert.ToString(Request.QueryString["Tipo"]);

                ClassDetalheEmpreendedor.CarregarEmpreendedor(ClassDetalheEmpreendedor.ID);

                CarregaCampos();

            }
            else
                Response.Redirect("login.aspx");

        }

        public void CarregaCampos()
        {
            ImgFoto.ImageUrl = ClassDetalheEmpreendedor._Empreendedor.Foto;
            lblNome.Text = ClassDetalheEmpreendedor._Empreendedor.Nome;
            if (ClassDetalheEmpreendedor._Empreendedor.Email != null)
                lblEmail.Text = ClassDetalheEmpreendedor._Empreendedor.Email;
            else
                lblEmail.Text = ClassDetalheEmpreendedor.multiplica(" ", 10);
            lblCPF.Text = ClassDetalheEmpreendedor._Empreendedor.CPF;
            lblDDD.Text = Convert.ToString(ClassDetalheEmpreendedor._Empreendedor.DDD);
            lblTelefone.Text = ClassDetalheEmpreendedor._Empreendedor.Telefone;
            lblDDDCel.Text = Convert.ToString(ClassDetalheEmpreendedor._Empreendedor.DDD_Celular);
            lblCelular.Text = ClassDetalheEmpreendedor._Empreendedor.Celular;
            lblEndereco.Text = ClassDetalheEmpreendedor._Empreendedor.Endereco;
            lblComplemento.Text = ClassDetalheEmpreendedor._Empreendedor.Complemento;
            lblUF.Text = ClassDetalheEmpreendedor._Empreendedor.UF;
            lblCEP.Text = ClassDetalheEmpreendedor._Empreendedor.CEP;
            lblDtNascimento.Text = ClassDetalheEmpreendedor._Empreendedor.DataNascimento.ToString("dd/MM/yyyy");
            lblEscolaridade.Text = ClassDetalheEmpreendedor._Empreendedor.Escolaridade;
            lblFormacao.Text = ClassDetalheEmpreendedor._Empreendedor.Formacao;
            lblFaculdade.Text = ClassDetalheEmpreendedor._Empreendedor.Faculdade;
            lblDescricao.Text = ClassDetalheEmpreendedor._Empreendedor.Descricao;
            lnkWebSite.OnClientClick = "window.open(\'" + ClassDetalheEmpreendedor._Empreendedor.WebPage + "\');";
            lnkWebSite.Text = ClassDetalheEmpreendedor._Empreendedor.WebPage;
            lnkLinkeid.OnClientClick = "window.open(\'" + ClassDetalheEmpreendedor._Empreendedor.Linkedin + "\');";
            lnkLinkeid.Text = ClassDetalheEmpreendedor._Empreendedor.Linkedin;
            lnkFacebook.OnClientClick = "window.open(\'" + ClassDetalheEmpreendedor._Empreendedor.Facebook + "\');";
            lnkFacebook.Text = ClassDetalheEmpreendedor._Empreendedor.Facebook;
            lnkGooglePlus.OnClientClick = "window.open(\'" + ClassDetalheEmpreendedor._Empreendedor.GooglePlus + "\');";
            lnkGooglePlus.Text = ClassDetalheEmpreendedor._Empreendedor.GooglePlus;
            lnkTwitter.OnClientClick = "window.open(\'" + ClassDetalheEmpreendedor._Empreendedor.Twitter + "\');";
            lnkTwitter.Text = ClassDetalheEmpreendedor._Empreendedor.Twitter;
            lblSkype.Text = ClassDetalheEmpreendedor._Empreendedor.Skype;
            lblMsn.Text = ClassDetalheEmpreendedor._Empreendedor.Msn;
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassDetalheEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassDetalheEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassDetalheEmpreendedor._Login.LOGIN] = false;
            ClassDetalheEmpreendedor.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassDetalheEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassDetalheEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassDetalheEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassDetalheEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void lnkWebSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            if (ClassDetalheEmpreendedor.Tipo == "Projeto")
                Response.Redirect("projeto.aspx?ID=" + Convert.ToString(ClassDetalheEmpreendedor.ID_Projeto));
            else
                Response.Redirect("investidorDetalhes.aspx?ID=" + Convert.ToString(ClassDetalheEmpreendedor.ID_Projeto));
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

    }
}