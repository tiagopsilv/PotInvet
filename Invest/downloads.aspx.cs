using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class downloads : System.Web.UI.Page
    {
        public clsDownloads ClassDownloads;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassDownloads = new clsDownloads();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassDownloads.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            if (ClassDownloads.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassDownloads.Usuario() + "!";

                ClassDownloads.ID = Convert.ToInt32(Request.QueryString["ID"]);

                ClassDownloads.carregarDoc(ClassDownloads.ID);

                ListaDocumento.DataSource = ClassDownloads._Documento;
                ListaDocumento.DataBind();

            }
            else
                Response.Redirect("login.aspx");


        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("projeto.aspx?ID=" + Convert.ToString(ClassDownloads.ID));
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassDownloads.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassDownloads.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassDownloads._Login.LOGIN] = false;
            ClassDownloads.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassDownloads.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassDownloads.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassDownloads.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassDownloads.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void link_Click(object sender, EventArgs e)
        {

        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}