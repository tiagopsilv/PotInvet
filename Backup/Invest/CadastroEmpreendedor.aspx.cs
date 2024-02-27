using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class CadastroEmpreendedor : System.Web.UI.Page
    {
        private clsCadastroEmpreendedor ClassCadastroEmpreendedor; 

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassCadastroEmpreendedor = new clsCadastroEmpreendedor();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            ClassCadastroEmpreendedor.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            ClassCadastroEmpreendedor.Incluir_Log(strIP, "CadastroEmpreendedor.aspx?CPF=" + Request.QueryString["CPF"], strUrlReferrer);

            

            if (ClassCadastroEmpreendedor.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                DateTime DtNull = new DateTime();
                linkButton.Text = "Bem vindo, " + ClassCadastroEmpreendedor.Usuario() + "!";
                ClassCadastroEmpreendedor.CPF = ClassCadastroEmpreendedor.FormatarCpf(Request.QueryString["CPF"]);
                txtCPF.Text = ClassCadastroEmpreendedor.CPF;
                ClassCadastroEmpreendedor.CarregaConsultaEmpreendedor(ClassCadastroEmpreendedor.FormatarCpf(Request.QueryString["CPF"]));
                if (ClassCadastroEmpreendedor.Tipo == "upd")
                {
                    ClassCadastroEmpreendedor._ID_Empreendedor = ClassCadastroEmpreendedor._ConsultaEmpreendedor.ID_Empreendedor;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Nome != null && txtNome.Text == "")
                        txtNome.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Nome;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Email != null && txtEmail.Text == "")
                        txtEmail.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Email;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.DDD != 0 && txtDDD.Text == "")
                        txtDDD.Text = Convert.ToString(ClassCadastroEmpreendedor._ConsultaEmpreendedor.DDD);
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Telefone != null && txtTelefone.Text == "")
                        txtTelefone.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Telefone;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.DDD_Celular != 0 && txtDDD_Celular.Text == "")
                        txtDDD_Celular.Text = Convert.ToString(ClassCadastroEmpreendedor._ConsultaEmpreendedor.DDD_Celular);
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.DataNascimento != DtNull && txtDataNascimento.Text == "")
                        txtDataNascimento.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.DataNascimento.ToString("dd/MM/yyyy");
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Endereco != null && txtEndereco.Text == "")
                        txtEndereco.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Endereco;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Complemento != null && txtComplemento.Text == "")
                        txtComplemento.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Complemento;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.CEP != null && txtCEP.Text == "")
                        txtCEP.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.CEP;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.UF != null && cboEstado.Text == "")
                        cboEstado.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.UF;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Cidade != null && txtCidade.Text == "")
                        txtCidade.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Cidade;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Sexo != null && cboSexo.Text == "")
                    {
                        if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Sexo == "M")
                            cboSexo.Text = "Masculino";
                        else
                            cboSexo.Text = "Feminino";
                    }
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Escolaridade != null && cboEscolarida.Text == "")
                        cboEscolarida.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Escolaridade;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Formacao != null && txtFormacao.Text == "")
                        txtFormacao.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Formacao;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Faculdade != null && txtFaculdade.Text == "")
                        txtFaculdade.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Faculdade;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Descricao != null && txtCurriculo.Text == "")
                        txtCurriculo.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Descricao;

                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.WebPage != null && txtWebSite.Text == "")
                        txtWebSite.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.WebPage;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Linkedin != null && txtLinkid.Text == "")
                        txtLinkid.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Linkedin;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Facebook != null && txtFacebook.Text == "")
                        txtFacebook.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Facebook;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.GooglePlus != null && txtGooglePlus.Text == "") 
                        txtGooglePlus.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.GooglePlus;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Skype != null && txtSkype.Text == "")
                        txtSkype.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Skype;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Twitter != null && txtTwitter.Text == "")
                        txtTwitter.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Twitter;
                    if (ClassCadastroEmpreendedor._ConsultaEmpreendedor.Msn != null && txtMsn.Text == "")
                        txtMsn.Text = ClassCadastroEmpreendedor._ConsultaEmpreendedor.Msn;
                }
            }
            else
                Response.Redirect("login.aspx");
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (ClassCadastroEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (ClassCadastroEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (ClassCadastroEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassCadastroEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (ClassCadastroEmpreendedor.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (ClassCadastroEmpreendedor.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[ClassCadastroEmpreendedor._Login.LOGIN] = false;
            ClassCadastroEmpreendedor.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            string Erro;

            Erro = ClassCadastroEmpreendedor.Salvar(txtNome.Text, txtCPF.Text, txtEmail.Text, txtDDD.Text, txtTelefone.Text, txtDDD_Celular.Text, txtCelular.Text, txtDataNascimento.Text, txtEndereco.Text, txtComplemento.Text, txtCEP.Text, txtCidade.Text, cboEstado.SelectedValue, cboSexo.Text, cboEscolarida.Text,txtFormacao.Text, txtFaculdade.Text, txtCurriculo.Text, txtWebSite.Text, txtLinkid.Text, txtFacebook.Text, txtGooglePlus.Text, txtSkype.Text, txtTwitter.Text, txtMsn.Text, fupFoto.FileName);
            if (Erro == "Sem Erros")
            {
                if (fupFoto.FileName.Length > 0)
                    fupFoto.PostedFile.SaveAs(Server.MapPath("~/Fotos/Empr_") + ClassCadastroEmpreendedor.FormatarCpf(txtCPF.Text).Replace("-", "").Replace("/", "").Replace(".", "") + ".jpg");
                Response.Redirect("cadastroAgente.aspx");
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

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cadastroAgente.aspx");
        }


    }
}