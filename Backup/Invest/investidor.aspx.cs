using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Invest.Controller;
using POCO;

namespace Invest
{
    public partial class investidor : System.Web.UI.Page
    {
        private clsinvestidor Classinvestidor;

        protected void Page_Load(object sender, EventArgs e)
        {
            Classinvestidor = new clsinvestidor();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            Classinvestidor.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            Classinvestidor.Incluir_Log(strIP, "investidor.aspx", strUrlReferrer);

            if (Classinvestidor.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + Classinvestidor.Usuario() + "!";

                Classinvestidor.CarregarProjetos();

                ListaProjeto.DataSource = Classinvestidor._ListaProjetos;
                ListaProjeto.DataBind();

                Classinvestidor.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = Classinvestidor._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();
            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (Classinvestidor.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (Classinvestidor.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Classinvestidor.CarregarProjetos(0, cboPerfil.Text == "Todos" ? null : cboPerfil.Text, checkRamoAtividade.Items[0].Selected, checkRamoAtividade.Items[1].Selected, checkRamoAtividade.Items[2].Selected, checkRamoAtividade.Items[3].Selected, checkFormatoProjeto.Items[0].Selected, checkFormatoProjeto.Items[1].Selected, checkFormatoProjeto.Items[2].Selected, textSearch.Text == "" ? null : textSearch.Text);

            ListaProjeto.DataSource = Classinvestidor._ListaProjetos;
            ListaProjeto.DataBind();
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (Classinvestidor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (Classinvestidor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (Classinvestidor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (Classinvestidor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session[Classinvestidor._Login.LOGIN] = false;
            Classinvestidor.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

    }
}