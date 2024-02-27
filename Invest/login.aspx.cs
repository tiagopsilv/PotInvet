using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class login : System.Web.UI.Page
    {
        private clsLogin ClassLogin; 
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLogin = new clsLogin();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null != cookie)
            {

                ClassLogin.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

                ClassLogin.Incluir_Log(strIP, "login.aspx", strUrlReferrer);

                if (ClassLogin.VerificaLogado(cookie.Value.ToString()) == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
                {
                    if (ClassLogin.Get_Tipo(cookie.Value.ToString()) == "Investidor") Response.Redirect("principalInvestidor.aspx");
                    if (ClassLogin.Get_Tipo(cookie.Value.ToString()) == "Agente") Response.Redirect("principalAgente.aspx");
                }
            }
        }

        protected void LoginButton_Click(object sender, ImageClickEventArgs e)
        {
            login _Login = new login();
            if (ClassLogin.Logar(UserName.Text, Password.Text) == true)
            {

                HttpCookie cookie = new HttpCookie("LoginIdeiasInvest");
                cookie.Value = ClassLogin._Login.LOGIN;

                DateTime dtNow = DateTime.Now;

                TimeSpan tsMinute = new TimeSpan(0, 5, 1, 0);

                cookie.Expires = dtNow + tsMinute;

                Response.Cookies.Add(cookie);

                Session[ClassLogin._Login.LOGIN] = true;
                if (ClassLogin.Tipo == "Investidor") Response.Redirect("principalInvestidor.aspx");
                if (ClassLogin.Tipo == "Agente") Response.Redirect("principalAgente.aspx");
            }
            else
            {
                FailureText.Text = "Usuário ou Senha incorreto.";
            }
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];
            if (ClassLogin.Get_Tipo(cookie.Value.ToString()) == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassLogin.Get_Tipo(cookie.Value.ToString()) == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cadastro.aspx");
        }

        protected void btnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/home.aspx");
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