using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class cadastroLucroAgenteEdicao : System.Web.UI.Page
    {
        private clscadastroLucroAgenteEdicao ClasscadastroLucroAgenteEdicao;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClasscadastroLucroAgenteEdicao = new clscadastroLucroAgenteEdicao();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClasscadastroLucroAgenteEdicao.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClasscadastroLucroAgenteEdicao.Incluir_Log(strIP, "CadastroLucroAgenteEdicao.aspx", strUrlReferrer);

            if (ClasscadastroLucroAgenteEdicao.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClasscadastroLucroAgenteEdicao.Usuario() + "!";
                ClasscadastroLucroAgenteEdicao.CarregaProjetosVisitados();

                ListaProjetosVisitados.DataSource = ClasscadastroLucroAgenteEdicao._ProjetosVisitados;
                ListaProjetosVisitados.DataBind();

                ClasscadastroLucroAgenteEdicao.Tipo = Request.QueryString["Tipo"];

                if (Request.QueryString["Acao"] != null)
                {
                    if (Request.QueryString["Acao"] == "Excluir")
                    {
                        ClasscadastroLucroAgenteEdicao.ExcluirLucro(Request.QueryString["Valor"], Request.QueryString["Data"]);
                    }
                }

                if (Request.QueryString["Tipo"] == "Upd")
                {
                    ClasscadastroLucroAgenteEdicao.CarregarListaLucroUpd(Convert.ToInt32(Request.QueryString["ID"]));
                    ImageButton1.Visible = false;
                }
                else
                    ClasscadastroLucroAgenteEdicao.CarregarListaLucro();


                listaLucros.DataSource = ClasscadastroLucroAgenteEdicao._ListaLucro;
                listaLucros.DataBind();


            }
            else
                Response.Redirect("login.aspx");


        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClasscadastroLucroAgenteEdicao.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClasscadastroLucroAgenteEdicao.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClasscadastroLucroAgenteEdicao.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroLucroAgenteEdicao.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClasscadastroLucroAgenteEdicao.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroLucroAgenteEdicao.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session[ClasscadastroLucroAgenteEdicao._Login.LOGIN] = false;
            ClasscadastroLucroAgenteEdicao.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FormCadLucroAgente.aspx?Tipo=Add&Acao=Add");
        }

        protected void BtnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            if (ClasscadastroLucroAgenteEdicao.Tipo == "Add")
                Response.Redirect("cadastroAgente.aspx?Tipo=Run");
            else
                Response.Redirect("principalAgente.aspx");
        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            if (ClasscadastroLucroAgenteEdicao.Tipo == "Add")
                Response.Redirect("cadastroAgente.aspx?Tipo=Run");
            else
                Response.Redirect("principalAgente.aspx");
        }
    }
}