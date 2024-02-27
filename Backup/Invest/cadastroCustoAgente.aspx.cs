using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class cadastroCustoAgente : System.Web.UI.Page
    {
        private clscadastroCustoAgente ClasscadastroCustoAgente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClasscadastroCustoAgente = new clscadastroCustoAgente();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClasscadastroCustoAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClasscadastroCustoAgente.Incluir_Log(strIP, "CadastroCustoAgente.aspx?Tipo=" + Request.QueryString["ID"], strUrlReferrer);

            if (ClasscadastroCustoAgente.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClasscadastroCustoAgente.Usuario() + "!";
                listaCustos.DataSource = ClasscadastroCustoAgente.Listar(Convert.ToInt32(Request.QueryString["ID"]));
                listaCustos.DataBind();

                ClasscadastroCustoAgente.ID = Convert.ToInt32(Request.QueryString["ID"]);

                ClasscadastroCustoAgente.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClasscadastroCustoAgente._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();
            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClasscadastroCustoAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClasscadastroCustoAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx?Tipo=Normal");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClasscadastroCustoAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroCustoAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClasscadastroCustoAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroCustoAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session[ClasscadastroCustoAgente._Login.LOGIN] = false;
            ClasscadastroCustoAgente.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("projeto.aspx?ID=" + Convert.ToString(ClasscadastroCustoAgente.ID));
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}