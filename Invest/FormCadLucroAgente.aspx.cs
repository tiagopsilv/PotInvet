using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class FormCadLucroAgente : System.Web.UI.Page
    {
        private clsFormCadLucroAgente ClassFormCadLucroAgente;


        protected void Page_Load(object sender, EventArgs e)
        {
            ClassFormCadLucroAgente = new clsFormCadLucroAgente();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassFormCadLucroAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassFormCadLucroAgente.Incluir_Log(strIP, "FormCadLucroAgente.aspx", strUrlReferrer);

            if (ClassFormCadLucroAgente.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassFormCadLucroAgente.Usuario() + "!";

                ClassFormCadLucroAgente.Tipo = Request.QueryString["Tipo"];

                ClassFormCadLucroAgente.Acao = Request.QueryString["Acao"];

                if (ClassFormCadLucroAgente.Tipo == "Add")
                {
                    if (ClassFormCadLucroAgente.Acao == "upd")
                    {
                        ClassFormCadLucroAgente.DataUpd = Convert.ToDateTime(ClassFormCadLucroAgente.Formatar(Request.QueryString["DataUpd"], "##/##/####"));
                        ClassFormCadLucroAgente.ValorUpd = Convert.ToDecimal(Request.QueryString["ValorUpd"]);
                        ClassFormCadLucroAgente.CarregaListaLucro();

                        if (txtData.Text == "")
                            txtData.Text = ClassFormCadLucroAgente.LucroUpd.Data.ToString("dd/MM/yyyy");
                        if (txtDescLucro.Text == "")
                            txtDescLucro.Text = ClassFormCadLucroAgente.LucroUpd.Descricao;
                        if (txtJustiLucro.Text == "")
                            txtJustiLucro.Text = ClassFormCadLucroAgente.LucroUpd.Justificativa;
                        if (txtValor.Text == "")
                            txtValor.Text = ClassFormCadLucroAgente.LucroUpd.ValorEstimado.ToString();
                    }
                }
                else
                {
                    ClassFormCadLucroAgente.ID = Convert.ToInt32(Request.QueryString["ID"]);
                    ClassFormCadLucroAgente.ID_Proj = Convert.ToInt32(Request.QueryString["ID_Proj"]);
                    ClassFormCadLucroAgente.CarregaListaLucroUpd();
                    if (txtData.Text == "")
                        txtData.Text = ClassFormCadLucroAgente.LucroUpd.Data.ToString("dd/MM/yyyy");
                    if (txtDescLucro.Text == "")
                        txtDescLucro.Text = ClassFormCadLucroAgente.LucroUpd.Descricao;
                    if (txtJustiLucro.Text == "")
                        txtJustiLucro.Text = ClassFormCadLucroAgente.LucroUpd.Justificativa;
                    if (txtValor.Text == "")
                        txtValor.Text = ClassFormCadLucroAgente.LucroUpd.ValorEstimado.ToString();

                    txtValor.Enabled = false;
                }



            }
            else
                Response.Redirect("login.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassFormCadLucroAgente.Salvar(txtDescLucro.Text, txtValor.Text, txtJustiLucro.Text, txtData.Text);
            if (Erro == "Sem Erros")
            {
                if (ClassFormCadLucroAgente.Tipo == "Add")
                    Response.Redirect("cadastroLucroAgenteEdicao.aspx?Tipo=" + ClassFormCadLucroAgente.Tipo);
                else
                    Response.Redirect("cadastroLucroAgenteEdicao.aspx?Tipo=" + ClassFormCadLucroAgente.Tipo + "&ID=" + Convert.ToString(ClassFormCadLucroAgente.ID_Proj));
            }
            else
            {
                lblErro1.Text = Erro;
                lblErro1.Visible = true;
            }
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassFormCadLucroAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassFormCadLucroAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassFormCadLucroAgente._Login.LOGIN] = false;
            ClassFormCadLucroAgente.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassFormCadLucroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassFormCadLucroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassFormCadLucroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassFormCadLucroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }
    }
}