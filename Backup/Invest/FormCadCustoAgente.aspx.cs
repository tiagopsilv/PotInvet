using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class FormCadCustoAgente : System.Web.UI.Page
    {
        private clsFormCadCustoAgente ClassFormCadCustoAgente;


        protected void Page_Load(object sender, EventArgs e)
        {
            ClassFormCadCustoAgente = new clsFormCadCustoAgente();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassFormCadCustoAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassFormCadCustoAgente.Incluir_Log(strIP, "FormCadCustoAgente.aspx", strUrlReferrer);

            if (ClassFormCadCustoAgente.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClassFormCadCustoAgente.Usuario() + "!";

                ClassFormCadCustoAgente.Tipo = Request.QueryString["Tipo"];

                ClassFormCadCustoAgente.Acao = Request.QueryString["Acao"];


                if (ClassFormCadCustoAgente.Tipo == "Add")
                {
                    if (ClassFormCadCustoAgente.Acao == "upd")
                    {
                        ClassFormCadCustoAgente.DataUpd = Convert.ToDateTime(ClassFormCadCustoAgente.Formatar(Request.QueryString["DataUpd"], "##/##/####"));
                        ClassFormCadCustoAgente.ValorUpd = Convert.ToDecimal(Request.QueryString["ValorUpd"]);
                        ClassFormCadCustoAgente.CarregaListaCusto();

                        if (txtData.Text == "")
                            txtData.Text = ClassFormCadCustoAgente.CustoUpd.Data.ToString("dd/MM/yyyy");
                        if (txtDescCusto.Text == "")
                            txtDescCusto.Text = ClassFormCadCustoAgente.CustoUpd.Descricao;
                        if (txtJustiCusto.Text == "")
                            txtJustiCusto.Text = ClassFormCadCustoAgente.CustoUpd.Justificativa;
                        if (txtValor.Text == "")
                            txtValor.Text = ClassFormCadCustoAgente.CustoUpd.CustoEstimado.ToString();
                    }
                }
                else
                {
                    ClassFormCadCustoAgente.ID = Convert.ToInt32(Request.QueryString["ID"]);
                    ClassFormCadCustoAgente.ID_Proj = Convert.ToInt32(Request.QueryString["ID_Proj"]);
                    ClassFormCadCustoAgente.CarregaListaCustoUpd();
                    if (txtData.Text == "")
                        txtData.Text = ClassFormCadCustoAgente.CustoUpd.Data.ToString("dd/MM/yyyy");
                    if (txtDescCusto.Text == "")
                        txtDescCusto.Text = ClassFormCadCustoAgente.CustoUpd.Descricao;
                    if (txtJustiCusto.Text == "")
                        txtJustiCusto.Text = ClassFormCadCustoAgente.CustoUpd.Justificativa;
                    if (txtValor.Text == "")
                        txtValor.Text = ClassFormCadCustoAgente.CustoUpd.CustoEstimado.ToString();

                    txtValor.Enabled = false;
                }

                

            }
            else
                Response.Redirect("login.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassFormCadCustoAgente.Salvar(txtDescCusto.Text, txtValor.Text, txtJustiCusto.Text, txtData.Text);
            if (Erro == "Sem Erros")
            {
                if (ClassFormCadCustoAgente.Tipo == "Add")
                    Response.Redirect("cadastroCustoAgenteEdicao.aspx?Tipo=" + ClassFormCadCustoAgente.Tipo);
                else
                    Response.Redirect("cadastroCustoAgenteEdicao.aspx?Tipo=" + ClassFormCadCustoAgente.Tipo + "&ID=" + Convert.ToString(ClassFormCadCustoAgente.ID_Proj));
            }
            else
            {
                lblErro1.Text = Erro;
                lblErro1.Visible = true;
            }   
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassFormCadCustoAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassFormCadCustoAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassFormCadCustoAgente._Login.LOGIN] = false;
            ClassFormCadCustoAgente.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassFormCadCustoAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassFormCadCustoAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassFormCadCustoAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassFormCadCustoAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }
    }
}