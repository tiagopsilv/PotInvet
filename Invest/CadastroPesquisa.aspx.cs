using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class CadastroPesquisa : System.Web.UI.Page
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
            if (rdb1Sim.Selected == true || rdb1Nao.Selected == true)
                ClassPesquisa.Salvar(1, rdb1Sim.Selected, rdb1Nao.Selected, txtPorque1.Text);

            if (rdb2Sim.Selected == true || rdb2Nao.Selected == true)
                ClassPesquisa.Salvar(2, rdb2Sim.Selected, rdb2Nao.Selected, txtPorque1.Text);

            if (rdb3Sim.Selected == true || rdb3Nao.Selected == true)
                ClassPesquisa.Salvar(3, rdb3Sim.Selected, rdb3Nao.Selected, txtPorque3.Text);

            if (rdb4Sim.Selected == true || rdb4Nao.Selected == true)
                ClassPesquisa.Salvar(4, rdb3Sim.Selected, rdb3Nao.Selected, txtPorque3.Text);

            if (rdb5Sim.Selected == true || rdb5Nao.Selected == true)
                ClassPesquisa.Salvar(5, rdb5Sim.Selected, rdb5Nao.Selected, txtPorque5.Text);

            if (rdb6Sim.Selected == true || rdb6Nao.Selected == true)
                ClassPesquisa.Salvar(6, rdb6Sim.Selected, rdb6Nao.Selected, txtPorque6.Text);

            if (rdb7Sim.Selected == true || rdb7Nao.Selected == true)
                ClassPesquisa.Salvar(7, rdb7Sim.Selected, rdb7Nao.Selected, txtPorque7.Text);

            if (rdb8Sim.Selected == true || rdb8Nao.Selected == true)
                ClassPesquisa.Salvar(8, rdb8Sim.Selected, rdb8Nao.Selected, txtPorque8.Text);

            if (rdb10Bom.Selected == true || rdb10MuitoBom.Selected == true || rdb10MuitoRuim.Selected == true || rdb10Regular.Selected == true || rdb10Ruim.Selected == true)
            {
                if (rdb10Bom.Selected == true)
                    ClassPesquisa.Salvar(10, false, false, "Bom");

                if (rdb10MuitoBom.Selected == true)
                    ClassPesquisa.Salvar(10, false, false, "Muito Bom");

                if (rdb10MuitoRuim.Selected == true)
                    ClassPesquisa.Salvar(10, false, false, "Muito Ruim");

                if (rdb10Regular.Selected == true)
                    ClassPesquisa.Salvar(10, false, false, "Regular");

                if (rdb10Ruim.Selected == true)
                    ClassPesquisa.Salvar(10, false, false, "Ruim");

            }

            if (rdb12Sim.Selected == true || rdb12Nao.Selected == true)
                ClassPesquisa.Salvar(12, rdb12Sim.Selected, rdb12Nao.Selected, txtPorque1.Text);

            if (rdb9Aprensetacao.Selected == true || rdb9Disponibilizacao.Selected == true || rdb9Pesquisa.Selected == true)
            {
                if (rdb9Aprensetacao.Selected == true)
                    ClassPesquisa.Salvar(9, false, false, "Apresentação de vido com breve apresentação do projeto.");

                if (rdb9Disponibilizacao.Selected == true)
                    ClassPesquisa.Salvar(9, false, false, "Disponibilização dos gráficos ROI de custo e Lucro.");

                if (rdb9Pesquisa.Selected == true)
                    ClassPesquisa.Salvar(9, false, false, "Pesquisas dos projetos por área de atuação.");

            }

            if (txtSegestao.Text.Length > 0)
                ClassPesquisa.Salvar(11, false, false, txtSegestao.Text);

            Response.Redirect("principalInvestidor.aspx");

        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    }
}