using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class graficoROI : System.Web.UI.Page
    {
        private clsgraficoROI ClassgraficoROI;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassgraficoROI = new clsgraficoROI();

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (ClassgraficoROI.VerificaLogin() == true)
                linkButton.Text = "Bem vindo, " + ClassgraficoROI.Usuario() + "!";
            else
                Response.Redirect("login.aspx");

            ClassgraficoROI.CarregaProjetosVisitados();

            ClassgraficoROI.Incluir_Log(strIP, "graficoROI.aspx", strUrlReferrer);

            ListaProjetosVisitados.DataSource = ClassgraficoROI._ProjetosVisitados;
            ListaProjetosVisitados.DataBind();
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("investidor.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassgraficoROI.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassgraficoROI.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassgraficoROI.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassgraficoROI.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            ClassgraficoROI.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}