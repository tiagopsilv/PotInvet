using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class mensagem : System.Web.UI.Page
    {
        private clsmensagem Classmensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            Classmensagem = new clsmensagem();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            Classmensagem.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            Classmensagem.Incluir_Log(strIP, "login.aspx?ID=" + Request.QueryString["ID"] + "&Tipo=" + Request.QueryString["Tipo"], strUrlReferrer);

            if (Classmensagem.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + Classmensagem.Usuario() + "!";
                if (Convert.ToInt32(Request.QueryString["ID"]) > 0 && Request.QueryString["Tipo"] != "")
                {
                    Classmensagem.CarregaMensagem(Convert.ToInt32(Request.QueryString["ID"]), Request.QueryString["Tipo"]);

                    lblTitulo.Text = Classmensagem.Titulo();
                    lblData.Text = Classmensagem.Data();
                    lblUsuario.Text = Classmensagem.UsuarioMensagem();
                    lblTexto.Text = Classmensagem.Texto();
                }

                Classmensagem.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = Classmensagem._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();
            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (Classmensagem.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (Classmensagem.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (Classmensagem.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (Classmensagem.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (Classmensagem.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (Classmensagem.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[Classmensagem._Login.LOGIN] = false;
            Classmensagem.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}