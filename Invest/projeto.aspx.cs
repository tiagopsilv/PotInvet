using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invest.Controller;

namespace Invest
{
    public partial class projeto : System.Web.UI.Page
    {
        private clsprojeto Classprojeto;
        protected void Page_Load(object sender, EventArgs e)
        {
            Classprojeto = new clsprojeto();

            HttpCookie cookie = Request.Cookies["LoginIdeiasInvest"];

            string strIP = Request.ServerVariables["LOCAL_ADDR"];

            string strUrlReferrer = null;
            if (Request.UrlReferrer != null)
                strUrlReferrer = Request.UrlReferrer.AbsolutePath.ToString();

            if (null == cookie)
            {
                Response.Redirect("login.aspx");
            }

            Classprojeto.CarregarLogin(cookie.Value.ToString(), Convert.ToBoolean(Session[cookie.Value.ToString()]));

            Classprojeto.Incluir_Log(strIP, "projeto.aspx?ID=" + Request.QueryString["ID"], strUrlReferrer);

            if (Classprojeto.VerificaLogin() == true && Convert.ToBoolean(Session[cookie.Value.ToString()]))
            {
                linkButton.Text = "Bem vindo, " + Classprojeto.Usuario() + "!";
                if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
                {
                    Carregar(Convert.ToInt32(Request.QueryString["ID"]));
                }
            }
            else
                Response.Redirect("login.aspx");

        }

        protected void linkInvestir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContratoInvestir.aspx?ID=" + Convert.ToString(Classprojeto._Projeto.ID_Projeto));
            panel.Update();
        }

        protected void linkDownloads_Click(object sender, EventArgs e)
        {
            Response.Redirect("downloads.aspx?ID=" + Convert.ToString(Classprojeto._Projeto.ID_Projeto));
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            if (Classprojeto.Get_Tipo() == "Investidor") Response.Redirect("investidor.aspx");
            if (Classprojeto.Get_Tipo() == "Agente") Response.Redirect("cadastroAgente.aspx");
        }

        protected void btnAddNota_Click1(object sender, ImageClickEventArgs e)
        {
            txtNota.DataBind();
            Classprojeto.DarNotaProjeto(Classprojeto._Projeto.ID_Projeto, Classprojeto._Login.ID, Convert.ToInt32(txtNota.Text), Classprojeto._Login.LOGIN);
        }

        protected void txtNota_TextChanged(object sender, EventArgs e)
        {
            Classprojeto.DarNotaProjeto(Classprojeto._Projeto.ID_Projeto, Classprojeto._Login.ID, Convert.ToInt32(txtNota.Text), Classprojeto._Login.LOGIN);
        }

        protected void btnAddNota_Click(object sender, ImageClickEventArgs e)
        {
            lblDarnota.Visible = false;
            btnAddNota.Visible = false;
            lblDescNota.Visible = true;
            txtNota.Visible = true;
            btnSalvarNota.Visible = true;
        }

        protected void btnSalvarNota_Click(object sender, EventArgs e)
        {
            int result;

            lblErroTam.Visible = false;
            lblErroNum.Visible = false;

            if (int.TryParse(txtNota.Text, out result))
            {
            if (Convert.ToInt32(result) <= 10)
            {
                Classprojeto.DarNotaProjeto(Classprojeto._Projeto.ID_Projeto, Classprojeto._Login.ID, Convert.ToInt32(txtNota.Text), Classprojeto._Login.LOGIN);
                lblDarnota.Visible = true;
                btnAddNota.Visible = true;
                lblDescNota.Visible = false;
                txtNota.Visible = false;
                btnSalvarNota.Visible = false;
                Carregar(Classprojeto._Projeto.ID_Projeto);
            }
            else
            {
                lblErroTam.Visible = true;
            }
            }
            else
            {
                lblErroNum.Visible = true;
            }

        }

        private void Carregar(int ID)
        {
            Classprojeto.Visitar(Classprojeto._Login.ID, ID);
            Classprojeto.CarregaProjeto(ID);

            imageLogoUm.ImageUrl = Classprojeto._Projeto.ImagemProjeto;
            lblNomeProjeto.Text = Classprojeto._Projeto.NomeProjeto;
            lblData.Text = Convert.ToString(Classprojeto._Projeto.Data);
            lblValor.Text = Convert.ToString(Classprojeto._Projeto.Valor_Arrecadado);
            lblPorcentagem.Text = Convert.ToString(Classprojeto._Projeto.Porcentagem);

            tblProcentagem.Rows[0].Cells[0].Width = Classprojeto._Projeto.Porcentagem100;
            tblProcentagem.Rows[0].Cells[1].Width = Classprojeto._Projeto.Porcentagem0;

            star1.Visible = Classprojeto._Projeto.star1;
            star2.Visible = Classprojeto._Projeto.star2;
            star3.Visible = Classprojeto._Projeto.star3;
            star4.Visible = Classprojeto._Projeto.star4;
            star5.Visible = Classprojeto._Projeto.star5;

            lblDescricaoProjeto.Text = Classprojeto._Projeto.DescricaoProjeto;

            lblEmail.Text = Classprojeto._Projeto.Email;
            lblDDD.Text = Classprojeto._Projeto.DDD;
            lblTelefone.Text = Classprojeto._Projeto.Telefone;
            lblEndereco.Text = Classprojeto._Projeto.Endereco;
            lblCidade.Text = Classprojeto._Projeto.Cidade;
            lblEstado.Text = Classprojeto._Projeto.Estado;
            //txtNota.Text = Convert.ToString(Classprojeto._Projeto.Ranking);

            lblPerfil.Text = Classprojeto._Projeto.PerfilProjeto;
            lblRamo.Text = Classprojeto._Projeto.RamoAtividade;

            Classprojeto.CarregaProjetosVisitados();

            ListaProjetosVisitados.DataSource = Classprojeto._ProjetosVisitados;
            ListaProjetosVisitados.DataBind();

            listaEquipe.DataSource = Classprojeto.ListaEmpreendedores(Classprojeto._Projeto.ID_Projeto);
            listaEquipe.DataBind();

            imgROI.ImageUrl = Classprojeto.ROI2();
            imgROI.DescriptionUrl = Classprojeto.ROI2();

            Video.Text = "<iframe id=\"Iframe1\" width=\"610\" height=\"327\" src=\"" + Classprojeto._Projeto.VideoProjeto;
            Video.Text += "\" frameborder=\"0\" allowfullscreen id=\"Video\"></iframe>";

        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            if (Classprojeto.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (Classprojeto.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            if (Classprojeto.Get_Tipo() == "Investidor") Response.Redirect("principalInvestidor.aspx");
            if (Classprojeto.Get_Tipo() == "Agente") Response.Redirect("principalAgente.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session[Classprojeto._Login.LOGIN] = false;
            Classprojeto.SairLogin();
            Response.Redirect("home.aspx");
        }

        protected void linkDetalheCusto_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastroCustoAgente.aspx?ID=" + Convert.ToString(Classprojeto._Projeto.ID_Projeto));
        }

        protected void linkDetalheLucro_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastroLucroAgente.aspx?ID=" + Convert.ToString(Classprojeto._Projeto.ID_Projeto));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ContratoInvestir.aspx?ID=" + Convert.ToString(Classprojeto._Projeto.ID_Projeto));
        }

        protected void linkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contato.aspx");
        }

    }
}