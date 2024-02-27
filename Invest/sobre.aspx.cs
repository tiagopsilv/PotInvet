using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class sobre : System.Web.UI.Page
    {
        private clsSobre ClassSobre; 
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassSobre = new clsSobre();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (cookie != null)
            {

                ClassSobre.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

                ClassSobre.Incluir_Log(strIP, "principalInvestidor.aspx", strUrlReferrer);

                if (ClassSobre.VerificaLogin(Request.ServerVariables["LOCAL_ADDR"]) == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
                {
                    linkButton.Text = "Bem vindo, " + ClassSobre.Usuario() + "!";
                    btnSair.Visible = true;
                }
            }

        }


        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassSobre.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassSobre.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void btnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassSobre.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassSobre.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];
            Session[ClassSobre._Login.LOGIN] = false;
            ClassSobre.SairLogin(cookie.Value.ToString());
            Response.Redirect("home.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sobre.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}