using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;
using System.Windows.Forms;

namespace Invest
{
    public partial class CadastroInvestidor : System.Web.UI.Page
    {
    
        private clsCadastroInvestidor ClassCadastroInvestidor;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassCadastroInvestidor = new clsCadastroInvestidor();

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            ClassCadastroInvestidor.Incluir_Log(strIP, "CadastroInvestidor.aspx", strUrlReferrer);

        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("investidor.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassCadastroInvestidor.Salvar(txtNome.Text, txtCPF.Text, null, txtEmail.Text, txtDDD.Text, txtTelefone.Text, txtDDD_Celular.Text, txtCelular.Text, txtDataNascimento.Text, txtEndereco.Text, txtComplemento.Text, txtCEP.Text, txtCidade.Text, cboEstado.SelectedValue, cboSexo.Text, txtUsuario.Text, txtSenha.Text, txtConfirmarSenha.Text, chkAceite.Checked, fupFoto.FileName);
            if(Erro == "Sem Erros")
            {
                if (fupFoto.FileName.Length > 0)
                    fupFoto.PostedFile.SaveAs(Server.MapPath("~/Fotos/Perfil_") + ClassCadastroInvestidor.ID_Investidor + ".jpg");

                HttpCookie cookie = new HttpCookie("LoginIdeiasInvest");
                cookie.Value = txtUsuario.Text;

                DateTime dtNow = DateTime.Now;

                TimeSpan tsMinute = new TimeSpan(0, 5, 1, 0);

                cookie.Expires = dtNow + tsMinute;

                Response.Cookies.Add(cookie);

                Session[txtUsuario.Text] = true;

                Response.Redirect("principalInvestidor.aspx");
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