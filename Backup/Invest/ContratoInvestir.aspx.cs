using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Configuration;

namespace Invest
{
    public partial class ContratoInvestir : System.Web.UI.Page
    {
        private clsContratoInvestir ClassContratoInvestir;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassContratoInvestir = new clsContratoInvestir();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassContratoInvestir.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            if (ClassContratoInvestir.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
                linkButton.Text = "Bem vindo, " + ClassContratoInvestir.Usuario() + "!";
            else
                Response.Redirect("login.aspx");

            ClassContratoInvestir.ID = Convert.ToInt32(Request.QueryString["ID"]);

            ClassContratoInvestir.Carregar(Convert.ToInt32(Request.QueryString["ID"]));

            lblTitulo.Text = "Projeto: " + ClassContratoInvestir._Projeto.NomeProjeto;

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassContratoInvestir.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassContratoInvestir.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassContratoInvestir.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassContratoInvestir.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassContratoInvestir.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassContratoInvestir.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassContratoInvestir._Login.LOGIN] = false;
            ClassContratoInvestir.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassContratoInvestir.Salvar(txtValor.Text, chkAceite.Checked);
            if (Erro == "Sem Erros")
            {
                if (ClassContratoInvestir._PesquisaBLL.VerifUsuario(ClassContratoInvestir._Login.ID, ClassContratoInvestir._Login.Tipo))
                    Response.Redirect("principalInvestidor.aspx");
                else
                    Response.Redirect("CadastroPesquisa.aspx");
            }
            else
            {
                lblErro1.Text = Erro;
                lblErro1.Visible = true;
            }   
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("projeto.aspx?ID=" + Convert.ToString(ClassContratoInvestir.ID));
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }
    
    }
}