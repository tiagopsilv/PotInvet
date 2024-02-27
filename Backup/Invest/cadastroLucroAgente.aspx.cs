using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class cadastroLucroAgente : System.Web.UI.Page
    {

        private clscadastroLucroAgente ClasscadastroLucroAgente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClasscadastroLucroAgente = new clscadastroLucroAgente();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClasscadastroLucroAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClasscadastroLucroAgente.Incluir_Log(strIP, "CadastroLucroAgente.aspx", strUrlReferrer);

            if (ClasscadastroLucroAgente.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClasscadastroLucroAgente.Usuario() + "!";
                listaLucro.DataSource = ClasscadastroLucroAgente.Listar(Convert.ToInt32(Request.QueryString["ID"]));
                listaLucro.DataBind();

                ClasscadastroLucroAgente.CarregaProjetosVisitados();

                ClasscadastroLucroAgente.ID = Convert.ToInt32(Request.QueryString["ID"]);

                ListaProjetosVisitados.DataSource = ClasscadastroLucroAgente._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();
            }
            else
                Response.Redirect("login.aspx");



        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClasscadastroLucroAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClasscadastroLucroAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClasscadastroLucroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroLucroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClasscadastroLucroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroLucroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClasscadastroLucroAgente._Login.LOGIN] = false;
            ClasscadastroLucroAgente.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("projeto.aspx?ID=" + Convert.ToString(ClasscadastroLucroAgente.ID));
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}