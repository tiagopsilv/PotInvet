using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POCO;
using Invest.Controller;

namespace Invest
{
    public partial class principalInvestidor : System.Web.UI.Page
    {
        private clsprincipalInvestidor ClassprincipalInvestidor; 

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassprincipalInvestidor = new clsprincipalInvestidor();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassprincipalInvestidor.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassprincipalInvestidor.Incluir_Log(strIP, "principalInvestidor.aspx", strUrlReferrer);

            if (ClassprincipalInvestidor.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassprincipalInvestidor.Usuario().LOGIN + "!";
                ClassprincipalInvestidor.CarregarProjetos(ClassprincipalInvestidor.Usuario().ID);

                ClassprincipalInvestidor.CarregaInvestidor();

                if (ClassprincipalInvestidor._Investidor.Foto != null)
                    ImgFoto.ImageUrl = "~/Fotos/" + ClassprincipalInvestidor._Investidor.Foto;
                else
                    ImgFoto.ImageUrl = "~/Fotos/Perfil_padrao.jpg";
                lblNome.Text = ClassprincipalInvestidor._Investidor.Nome;

                ListaInvestidos.DataSource = ClassprincipalInvestidor._ListaProjetos;
                ListaInvestidos.DataBind();

                ListaMensagem.DataSource = ClassprincipalInvestidor.SelecionarMensagem(ClassprincipalInvestidor.Usuario().ID);
                ListaMensagem.DataBind();

                ClassprincipalInvestidor.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClassprincipalInvestidor._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

                if (ClassprincipalInvestidor._PesquisaBLL.VerifUsuario(ClassprincipalInvestidor._Login.ID, ClassprincipalInvestidor._Login.Tipo))
                    LinkButton4.Visible = false;
                else
                    LinkButton4.Visible = true;

            }
            else
                Response.Redirect("login.aspx");
            

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassprincipalInvestidor.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassprincipalInvestidor.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassprincipalInvestidor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassprincipalInvestidor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassprincipalInvestidor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassprincipalInvestidor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassprincipalInvestidor._Login.LOGIN] = false;
            ClassprincipalInvestidor.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CadastroPesquisa.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}