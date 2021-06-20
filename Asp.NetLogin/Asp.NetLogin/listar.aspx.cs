using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetLogin
{
    public partial class listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            string query = @"SELECT id, nome, nivel FROM usuario";
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dt);

                rptUsuarios.DataSource = dt;
                rptUsuarios.DataBind();

            }
            catch (Exception ex)
            {
                lblMsg.Text = "Falha:" + ex.Message;
            }
          
            
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adicionar.aspx");
        }
    }
}









