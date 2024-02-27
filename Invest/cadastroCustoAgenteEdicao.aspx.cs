using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class cadastroCustoAgenteEdicao : System.Web.UI.Page
    {
        private clscadastroCustoAgenteEdicao ClasscadastroCustoAgenteEdicao;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClasscadastroCustoAgenteEdicao = new clscadastroCustoAgenteEdicao();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClasscadastroCustoAgenteEdicao.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClasscadastroCustoAgenteEdicao.Incluir_Log(strIP, "CadastroCustoAgenteEdicao.aspx", strUrlReferrer);

            if (ClasscadastroCustoAgenteEdicao.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClasscadastroCustoAgenteEdicao.Usuario() + "!";
                ClasscadastroCustoAgenteEdicao.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClasscadastroCustoAgenteEdicao._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

                ClasscadastroCustoAgenteEdicao.Tipo = Request.QueryString["Tipo"];

                if (Request.QueryString["Acao"] != null)
                {
                    if (Request.QueryString["Acao"] == "Excluir")
                    {
                        ClasscadastroCustoAgenteEdicao.ExcluirCusto(Request.QueryString["Valor"], Request.QueryString["Data"]);
                    }
                }

                if (Request.QueryString["Tipo"] == "Upd")
                {
                    ClasscadastroCustoAgenteEdicao.CarregarListaCustoUpd(Convert.ToInt32(Request.QueryString["ID"]));
                    ImageButton1.Visible = false;
                }
                else
                    ClasscadastroCustoAgenteEdicao.CarregarListaCusto();

                listaCustos.DataSource = ClasscadastroCustoAgenteEdicao._ListaCusto;
                listaCustos.DataBind();

            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClasscadastroCustoAgenteEdicao.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClasscadastroCustoAgenteEdicao.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx?Tipo=Normal");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClasscadastroCustoAgenteEdicao.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroCustoAgenteEdicao.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClasscadastroCustoAgenteEdicao.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroCustoAgenteEdicao.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClasscadastroCustoAgenteEdicao._Login.LOGIN] = false;
            ClasscadastroCustoAgenteEdicao.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FormCadCustoAgente.aspx?Tipo=" + ClasscadastroCustoAgenteEdicao.Tipo + "&Acao=Add");
        }

        protected void BtnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            if (ClasscadastroCustoAgenteEdicao.Tipo == "Add")
                Response.Redirect("cadastroAgente.aspx?Tipo=Run");
            else
                Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            if (ClasscadastroCustoAgenteEdicao.Tipo == "Add")
                Response.Redirect("cadastroAgente.aspx?Tipo=Run");
            else
                Response.Redirect("principalAgente.aspx");
        }
    }
}