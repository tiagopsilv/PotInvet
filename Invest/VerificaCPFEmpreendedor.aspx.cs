using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class VerificaCPFEmpreendedor : System.Web.UI.Page
    {
        private clsVerificaCPFEmpreendedor ClassVerificaCPFEmpreendedor; 

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassVerificaCPFEmpreendedor = new clsVerificaCPFEmpreendedor();

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            ClassVerificaCPFEmpreendedor.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            if (ClassVerificaCPFEmpreendedor.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassVerificaCPFEmpreendedor.Usuario() + "!";
                ClassVerificaCPFEmpreendedor.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClassVerificaCPFEmpreendedor._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

                ClassVerificaCPFEmpreendedor.Tipo = Request.QueryString["Tipo"];

            }
            else
                Response.Redirect("login.aspx");

            ClassVerificaCPFEmpreendedor.Incluir_Log(strIP, "VerificaCPFEmpreendedor.aspx?Tipo=" + Request.QueryString["Tipo"], strUrlReferrer);
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassVerificaCPFEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassVerificaCPFEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassVerificaCPFEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassVerificaCPFEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassVerificaCPFEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassVerificaCPFEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassVerificaCPFEmpreendedor._Login.LOGIN] = false;
            ClassVerificaCPFEmpreendedor.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassVerificaCPFEmpreendedor.Validar(txtCPF.Text);
            if (Erro == "Sem Erros")
            {
                Response.Redirect("CadastroEmpreendedor.aspx?Tipo=" + ClassVerificaCPFEmpreendedor.Tipo + "&CPF=" + ClassVerificaCPFEmpreendedor.LimparCpf(txtCPF.Text));
            }
            else
            {
                lblErro1.Text = Erro;
                lblErro1.Visible = true;
            }   
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

    }
}