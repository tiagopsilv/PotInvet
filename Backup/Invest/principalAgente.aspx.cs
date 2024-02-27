using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class principalAgente : System.Web.UI.Page
    {
        private clsprincipalAgente ClassprincipalAgente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassprincipalAgente = new clsprincipalAgente();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassprincipalAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassprincipalAgente.Incluir_Log(strIP, "principalAgente.aspx", strUrlReferrer);

            if (ClassprincipalAgente.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassprincipalAgente.Usuario() + "!";

                ClassprincipalAgente.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClassprincipalAgente._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

                ClassprincipalAgente.CarregarProjeto();

                ListaProjeto.DataSource = ClassprincipalAgente._ListaProjetos;
                ListaProjeto.DataBind();

                ListaMensagem.DataSource = ClassprincipalAgente.SelecionarMensagemAgente();
                ListaMensagem.DataBind();

                modLista Lista = new modLista();
                Lista.del_Tudo(ClassprincipalAgente._Login.LOGIN);

                if (ClassprincipalAgente._PesquisaBLL.VerifUsuario(ClassprincipalAgente._Login.ID, ClassprincipalAgente._Login.Tipo))
                    LinkButton4.Visible = false;
                else
                    LinkButton4.Visible = true;

            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassprincipalAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassprincipalAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassprincipalAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassprincipalAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassprincipalAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassprincipalAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassprincipalAgente._Login.LOGIN] = false;
            ClassprincipalAgente.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CadastroPesquisaAgente.aspx");
        }
    }
}