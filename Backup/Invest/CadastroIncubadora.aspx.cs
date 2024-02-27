using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class CadastroIncubadora : System.Web.UI.Page
    {

        private clsCadastroIncubadora ClassCadastroIncubadora;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassCadastroIncubadora = new clsCadastroIncubadora();

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            ClassCadastroIncubadora.Incluir_Log(strIP, "CadastroIncubadora.aspx", strUrlReferrer);

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            string Usuario = "";

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            if (null != cookie)
            {
                Usuario = cookie.Value.ToString();
            }

            if (ClassCadastroIncubadora.Get_Tipo(Usuario) == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassCadastroIncubadora.Get_Tipo(Usuario) == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassCadastroIncubadora.Salvar(txtNomeAgente.Text, txtCPF.Text, txtCNPJ.Text, txtEmail.Text, txtDDDTel.Text, txtTel.Text, txtDDDCel.Text, txtCel.Text, txtEndereco.Text, txtComplemento.Text, txtCep.Text, txtCidade.Text, cboEstado.SelectedValue, txtUsuario.Text, txtSenha.Text, txtConfirmarSenha.Text, chkAceite.Checked, fupLogo.FileName);
            if (Erro == "Sem Erros")
            {
                if (fupLogo.FileName.Length > 0)
                    fupLogo.PostedFile.SaveAs(Server.MapPath("~/Logos/Perfil_") + ClassCadastroIncubadora.ID_Agente + ".jpg");

                HttpCookie cookie = new HttpCookie("LoginIdeiasInvest");
                cookie.Value = txtUsuario.Text;

                DateTime dtNow = DateTime.Now;

                TimeSpan tsMinute = new TimeSpan(0, 5, 1, 0);

                cookie.Expires = dtNow + tsMinute;

                Response.Cookies.Add(cookie);

                Session[txtUsuario.Text] = true;

                Response.Redirect("principalAgente.aspx");
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