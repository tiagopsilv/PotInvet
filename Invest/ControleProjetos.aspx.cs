using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using POCO;

namespace Invest
{
    public partial class ControleProjetos : System.Web.UI.Page
    {
        ProjetoBLL _ProjetoBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ProjetoBLL = new ProjetoBLL();
            grdProjetos.DataSource = _ProjetoBLL.Listar();
            grdProjetos.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "tccinvest";
            grdProjetos.Visible = true;
            TextBox1.Visible = false;
            Button1.Visible = false;
        }
    }
}