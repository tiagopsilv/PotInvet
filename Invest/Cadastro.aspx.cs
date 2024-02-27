using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Invest.Controller;
using System.Web.UI.WebControls;

namespace Invest
{
    public partial class Cadastro : System.Web.UI.Page
    {
        private clscadastroAgente ClasscadastroAgente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClasscadastroAgente = new clscadastroAgente();
            //if (ClasscadastroAgente.VerificaLogin() == true)
            //    linkButton.Text = "Bem vindo, " + ClasscadastroAgente.Usuario() + "!";

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            string Usuario = "";
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null != cookie)
            {
                Usuario = cookie.Value.ToString();
            }

            ClasscadastroAgente.Incluir_Log(strIP, "Cadastro.aspx", strUrlReferrer);

            if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx?Tipo=Normal");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            string Usuario = "";
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            if (null != cookie)
            {
                Usuario = cookie.Value.ToString();
            }
            if (ClasscadastroAgente.VerificaLogin(Usuario) == false)
                Response.Redirect("login.aspx");
            else
            {
                if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
                if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
            }
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sobre.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CadastroInvestidor.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("naoDisponivel.aspx");
        }

        protected void lblSair_Click(object sender, EventArgs e)
        {

        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}