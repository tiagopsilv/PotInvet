using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invest
{
    public partial class AtualizaProjeto : System.Web.UI.Page
    {
        //private clscadastroAgente ClasscadastroAgente;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    ClasscadastroAgente = new clscadastroAgente();

        //    HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

        //    string strIP = Request.ServerVariables["LOCAL_ADDR"];

        //    string strUrlReferrer = null;
        //    if (Request.UrlReferrer != null)
        //        strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

        //    if (null == cookie)
        //    {
        //        Response.Redirect("login.aspx");
        //    }

        //    ClasscadastroAgente.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

        //    ClasscadastroAgente.Incluir_Log(strIP, "CadastroAgente.aspx", strUrlReferrer);

        //    if (ClasscadastroAgente.VerificaLogin(cookie.Value.ToString()) == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
        //    {
        //        linkButton.Text = "Bem vindo, " + ClasscadastroAgente.Usuario() + "!";
        //        ClasscadastroAgente.CarregaProjetosVisitados();

        //        ListaProjetosVisitados.DataSource = ClasscadastroAgente._ProjetosVisitados;
        //        ListaProjetosVisitados.DataBind();

        //        ClasscadastroAgente.CarregarListaEmpreendedor();

        //        ClasscadastroAgente.CarregarProjeto();

        //        if (ClasscadastroAgente.Tipo == null)
        //            ClasscadastroAgente.Tipo = Request.QueryString["Tipo"];

        //        if (ClasscadastroAgente._Projeto.AlteracaoCadastroAgente == true)
        //        {
        //            if (ClasscadastroAgente._Projeto.NomeProjeto != null && ClasscadastroAgente._Projeto.NomeProjeto != "" && ClasscadastroAgente._Projeto.NomeProjeto != txtNomeProjeto.Text)
        //                txtNomeProjeto.Text = ClasscadastroAgente._Projeto.NomeProjeto;

        //            if (ClasscadastroAgente._Projeto.DescricaoProjeto != null && ClasscadastroAgente._Projeto.DescricaoProjeto != "" && ClasscadastroAgente._Projeto.DescricaoProjeto != txtDescricaoProjeto.Text)
        //                txtDescricaoProjeto.Text = ClasscadastroAgente._Projeto.DescricaoProjeto;

        //            //if (ClasscadastroAgente._Projeto.ImagemProjeto != null && ClasscadastroAgente._Projeto.ImagemProjeto != "")
        //            //    fupImagem.FileName.Insert(0, ClasscadastroAgente._Projeto.ImagemProjeto);

        //            if (ClasscadastroAgente._Projeto.VideoProjeto != null && ClasscadastroAgente._Projeto.VideoProjeto != "" && ClasscadastroAgente._Projeto.VideoProjeto != txtVideo.Text)
        //                txtVideo.Text = ClasscadastroAgente._Projeto.VideoProjeto;

        //            if (ClasscadastroAgente._Projeto.PerfilProjeto != null && ClasscadastroAgente._Projeto.PerfilProjeto != "" && ClasscadastroAgente._Projeto.PerfilProjeto != cboPerfil.Text)
        //                cboPerfil.Text = ClasscadastroAgente._Projeto.PerfilProjeto;

        //            if (ClasscadastroAgente._Projeto.RamoAtividade != null && ClasscadastroAgente._Projeto.RamoAtividade != "" && ClasscadastroAgente._Projeto.RamoAtividade != cboRamo.Text)
        //                cboRamo.Text = ClasscadastroAgente._Projeto.RamoAtividade;

        //            if (ClasscadastroAgente._Projeto.Email != null && ClasscadastroAgente._Projeto.Email != "" && ClasscadastroAgente._Projeto.Email != txtEmail.Text)
        //                txtEmail.Text = ClasscadastroAgente._Projeto.Email;

        //            if (ClasscadastroAgente._Projeto.DDD != null && ClasscadastroAgente._Projeto.DDD != "" && ClasscadastroAgente._Projeto.DDD != txtDDD.Text)
        //                txtDDD.Text = ClasscadastroAgente._Projeto.DDD;

        //            if (ClasscadastroAgente._Projeto.Telefone != null && ClasscadastroAgente._Projeto.Telefone != "" && ClasscadastroAgente._Projeto.Telefone != txtTelefone.Text)
        //                txtTelefone.Text = ClasscadastroAgente._Projeto.Telefone;

        //            if (ClasscadastroAgente._Projeto.Endereco != null && ClasscadastroAgente._Projeto.Endereco != "" && ClasscadastroAgente._Projeto.Endereco != txtEndereco.Text)
        //                txtEndereco.Text = ClasscadastroAgente._Projeto.Endereco;

        //            if (ClasscadastroAgente._Projeto.Cidade != null && ClasscadastroAgente._Projeto.Cidade != "" && ClasscadastroAgente._Projeto.Cidade != txtCidade.Text)
        //                txtCidade.Text = ClasscadastroAgente._Projeto.Cidade;

        //            if (ClasscadastroAgente._Projeto.Estado != null && ClasscadastroAgente._Projeto.Estado != "" && ClasscadastroAgente._Projeto.Estado != cboEstado.Text)
        //                cboEstado.Text = ClasscadastroAgente._Projeto.Estado;

        //            //if (ClasscadastroAgente._Projeto.ImgApres != null && ClasscadastroAgente._Projeto.ImgApres != "")
        //            //    fupImagem.FileName.Insert(1, ClasscadastroAgente._Projeto.ImgApres);

        //            ClasscadastroAgente.AlteracaoCadastroAgente(false);
        //        }

        //        if (Request.QueryString["EmprExcluir"] != null)
        //            ClasscadastroAgente.ExcluirEmpreendedor(Request.QueryString["EmprExcluir"]);

        //        listaEmpreendedor.DataSource = ClasscadastroAgente._ListaEmpreendedor;
        //        listaEmpreendedor.DataBind();

        //    }
        //    else
        //        Response.Redirect("login.aspx");

        //}

        //protected void linkButton2_Click(object sender, EventArgs e)
        //{

        //    if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
        //    if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx?Tipo=Normal");
        //}

        //protected void linkButton_Click(object sender, EventArgs e)
        //{
        //    if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
        //    if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        //}

        //protected void linkButton1_Click(object sender, EventArgs e)
        //{
        //    if (ClasscadastroAgente.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
        //    if (ClasscadastroAgente.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        //}

        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    Session[ClasscadastroAgente._Login.LOGIN] = false;
        //    ClasscadastroAgente.SairLogin();
        //    Response.Redirect("home.aspx");
        //}


        //protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        //{
        //    ClasscadastroAgente.QuardaDados(txtNomeProjeto.Text, txtDescricaoProjeto.Text, "", txtVideo.Text, cboPerfil.Text, cboRamo.Text, txtEmail.Text, txtDDD.Text, txtTelefone.Text, txtEndereco.Text, txtCidade.Text, cboEstado.Text, "");
        //    Response.Redirect("VerificaCPFEmpreendedor.aspx?Tipo=Agente");
        //}

        //protected void LinkButton7_Click(object sender, EventArgs e, int teste)
        //{

        //}

        //protected void lnkLucro_Click(object sender, EventArgs e)
        //{
        //    ClasscadastroAgente.QuardaDados(txtNomeProjeto.Text, txtDescricaoProjeto.Text, "", txtVideo.Text, cboPerfil.Text, cboRamo.Text, txtEmail.Text, txtDDD.Text, txtTelefone.Text, txtEndereco.Text, txtCidade.Text, cboEstado.Text, "");
        //    Response.Redirect("cadastroLucroAgenteEdicao.aspx?Tipo=Add");
        //}

        //protected void lnkCusto_Click(object sender, EventArgs e)
        //{
        //    ClasscadastroAgente.QuardaDados(txtNomeProjeto.Text, txtDescricaoProjeto.Text, "", txtVideo.Text, cboPerfil.Text, cboRamo.Text, txtEmail.Text, txtDDD.Text, txtTelefone.Text, txtEndereco.Text, txtCidade.Text, cboEstado.Text, "");
        //    Response.Redirect("cadastroCustoAgenteEdicao.aspx?Tipo=Add");
        //}

        //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        //{
        //    string Erro;

        //    Erro = ClasscadastroAgente.Salvar(txtNomeProjeto.Text, txtDescricaoProjeto.Text, "", txtVideo.Text, cboPerfil.Text, cboRamo.Text, txtEmail.Text, txtDDD.Text, txtTelefone.Text, txtEndereco.Text, txtCidade.Text, cboEstado.Text, "");
        //    if (Erro == "Sem Erros")
        //    {
        //        //if (fupImagem.FileName.Length > 0)
        //        //    fupImagem.PostedFile.SaveAs(Server.MapPath("~/Fotos/ApresProj_") + ClasscadastroAgente.ID_Agente + ".jpg");

        //        Response.Redirect("CadastroAgenteDoc.aspx?ID=" + Convert.ToString(ClasscadastroAgente.ID_Projeto));
        //    }
        //    else
        //    {
        //        lblErro1.Text = Erro;
        //        lblErro1.Visible = true;
        //    }
        //}

        //protected void linkButton3_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Contato.aspx");
        //}
    }
}