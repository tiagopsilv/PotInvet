using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class cadastroAgenteDoc : System.Web.UI.Page
    {
        private clscadastroAgenteDoc ClasscadastroAgente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClasscadastroAgente = new clscadastroAgenteDoc();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClasscadastroAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClasscadastroAgente.Incluir_Log(strIP, "CadastroAgenteDoc.aspx", strUrlReferrer);

            if (ClasscadastroAgente.VerificaLogin(cookie.Value.ToString()) == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + ClasscadastroAgente.Usuario() + "!";

                ClasscadastroAgente.ID_Projeto = Convert.ToInt32(Request.QueryString["ID"]);
            }
            else
                Response.Redirect("login.aspx");
        }

        protected void btnDocumento1_Click(object sender, ImageClickEventArgs e)
        {
            btnDocumento2.Visible = true;
            fupDocumento2.Visible = true;
        }

        protected void btnDocumento2_Click(object sender, ImageClickEventArgs e)
        {
            btnDocumento3.Visible = true;
            fupDocumento3.Visible = true;
        }

        protected void btnDocumento3_Click(object sender, ImageClickEventArgs e)
        {
            btnDocumento4.Visible = true;
            fupDocumento4.Visible = true;
        }

        protected void btnDocumento4_Click(object sender, ImageClickEventArgs e)
        {
            btnDocumento5.Visible = true;
            fupDocumento5.Visible = true;
        }

        protected void btnDocumento5_Click(object sender, ImageClickEventArgs e)
        {
            btnDocumento6.Visible = true;
            fupDocumento6.Visible = true;
        }

        protected void btnDocumento6_Click(object sender, ImageClickEventArgs e)
        {
            btnDocumento6.Visible = true;
            fupDocumento6.Visible = true;
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session[ClasscadastroAgente._Login.LOGIN] = false;
            ClasscadastroAgente.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx?Tipo=Normal");
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (fupImagem.FileName.Length > 0)
            {
                fupImagem.PostedFile.SaveAs(Server.MapPath("~/Imagens/ImgApres_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Imagem = "~/Imagens/ImgApres_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.upd();
            }

            if (fupDocumento1.FileName.Length > 0)
            {
                fupDocumento1.PostedFile.SaveAs(Server.MapPath("~/Doc/1_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Doc1 = "~/Doc/1_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.AdicionarDoc(ClasscadastroAgente.Doc1);
            }

            if (fupDocumento2.FileName.Length > 0)
            {
                fupDocumento2.PostedFile.SaveAs(Server.MapPath("~/Doc/2_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Doc2 = "~/Doc/2_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.AdicionarDoc(ClasscadastroAgente.Doc2);
            }

            if (fupDocumento3.FileName.Length > 0)
            {
                fupDocumento3.PostedFile.SaveAs(Server.MapPath("~/Doc/3_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Doc3 = "~/Doc/3_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.AdicionarDoc(ClasscadastroAgente.Doc3);
            }

            if (fupDocumento4.FileName.Length > 0)
            {
                fupDocumento4.PostedFile.SaveAs(Server.MapPath("~/Doc/4_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Doc4 = "~/Doc/4_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.AdicionarDoc(ClasscadastroAgente.Doc4);
            }

            if (fupDocumento5.FileName.Length > 0)
            {
                fupDocumento5.PostedFile.SaveAs(Server.MapPath("~/Doc/5_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Doc5 = "~/Doc/5_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.AdicionarDoc(ClasscadastroAgente.Doc5);
            }

            if (fupDocumento6.FileName.Length > 0)
            {
                fupDocumento6.PostedFile.SaveAs(Server.MapPath("~/Doc/6_") + ClasscadastroAgente.ID_Projeto + ".jpg");
                ClasscadastroAgente.Doc6 = "~/Doc/6_" + ClasscadastroAgente.ID_Projeto + ".jpg";
                ClasscadastroAgente.AdicionarDoc(ClasscadastroAgente.Doc6);
            }

            Response.Redirect("principalAgente.aspx");

        }
    }
}