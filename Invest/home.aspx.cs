using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class home : System.Web.UI.Page
    {
        private clsHome ClassHome; 
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassHome = new clsHome();
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;

            if (Request.UrlReferrer != null)
               strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null != cookie)
            {

                ClassHome.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

                if (ClassHome.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]) == true)
                {
                    linkButton.Text = "Bem vindo, " + ClassHome.Usuario() + "!";
                    btnSair.Visible = true;
                    modLista Lista = new modLista();
                    Lista.del_Tudo(ClassHome._Login.LOGIN);
                }

            }

            ClassHome.Incluir_Log(strIP, "home.aspx", strUrlReferrer);

            ClassHome.CarregarProjetos();
            lblDescricao1.Text = ClassHome.DescrProjeto1;
            lblDescricao2.Text = ClassHome.DescrProjeto2;
            lblDescricao3.Text = ClassHome.DescrProjeto3;
            image3.ImageUrl = ClassHome.img1;
            image4.ImageUrl = ClassHome.img2;
            image5.ImageUrl = ClassHome.img3;
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassHome.VerificaLogin() == false)
                Response.Redirect("login.aspx");
            else
            {
                if (ClassHome.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
                if (ClassHome.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
            }
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassHome.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassHome.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassHome._Login.LOGIN] = false;
            ClassHome.SairLogin();
            linkButton.Text = "Login";
            btnSair.Visible = false;
        }

        protected void btnMais1_Click(object sender, ImageClickEventArgs e)
        {
            if (ClassHome._Login.Tipo != "Agente")
                Response.Redirect(ClassHome.LinckProjeto1);
            else
                lblErro1.Visible = true;
        }

        protected void btnMais2_Click(object sender, ImageClickEventArgs e)
        {
            if (ClassHome._Login.Tipo != "Agente")
                Response.Redirect(ClassHome.LinckProjeto2);
            else
                lblErro2.Visible = true;
        }

        protected void btnMais3_Click(object sender, ImageClickEventArgs e)
        {
            if (ClassHome._Login.Tipo != "Agente")
                Response.Redirect(ClassHome.LinckProjeto3);
            else
                lblErro3.Visible = true;
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sobre.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}