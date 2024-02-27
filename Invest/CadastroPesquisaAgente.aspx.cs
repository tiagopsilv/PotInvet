using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class CadastroPesquisaAgente : System.Web.UI.Page
    {
        private clsPesquisa ClassPesquisa; 
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassPesquisa = new clsPesquisa();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassPesquisa.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassPesquisa.Incluir_Log(strIP, "pesquisa.aspx", strUrlReferrer);

            if (ClassPesquisa.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassPesquisa.Usuario() + "!";

                ClassPesquisa.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClassPesquisa._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];
            if (ClassPesquisa.Get_Tipo(cookie.Value.ToString()) == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassPesquisa.Get_Tipo(cookie.Value.ToString()) == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];
            Session[ClassPesquisa._Login.LOGIN] = false;
            ClassPesquisa.SairLogin(cookie.Value.ToString());
            Response.Redirect("home.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];
            if (ClassPesquisa.Get_Tipo(cookie.Value.ToString()) == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassPesquisa.Get_Tipo(cookie.Value.ToString()) == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];
            if (ClassPesquisa.Get_Tipo(cookie.Value.ToString()) == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassPesquisa.Get_Tipo(cookie.Value.ToString()) == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (txtArea.Text.Length > 0)
                ClassPesquisa.Salvar(13, false, false, txtArea.Text);

            if (rdb2Sim.Selected == true || rdb2Nao.Selected == true)
                ClassPesquisa.Salvar(14, rdb2Sim.Selected, rdb2Nao.Selected, txtPorque2.Text);

            if (rdb3Sim.Selected == true || rdb3Nao.Selected == true)
                ClassPesquisa.Salvar(16, rdb3Sim.Selected, rdb3Nao.Selected, txtPorque3.Text);

            if (rdb4Sim.Selected == true || rdb4Nao.Selected == true)
                ClassPesquisa.Salvar(15, rdb3Sim.Selected, rdb3Nao.Selected, txtPorque3.Text);

            Response.Redirect("principalAgente.aspx");

        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}