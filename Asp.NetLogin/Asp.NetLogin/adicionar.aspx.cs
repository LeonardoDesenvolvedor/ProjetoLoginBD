using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetLogin
{
    public partial class adicionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            // Encriptar a Sanha ! instalar o BCrypt.Net

            var senhaEncriptada = BCrypt.Net.BCrypt.HashPassword(txtSenha.Text);

            MySqlCommand cmd = new MySqlCommand();

            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"INSERT INTO usuario (nome, login, senha, nivel)
                                    VALUES (@nome, @login, @senha, @nivel)";

                // Passagem dos valores dos atributos com 
                // verificação de SQL Injector !!

                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("login", txtLogin.Text);
                cmd.Parameters.AddWithValue("senha", senhaEncriptada);
                cmd.Parameters.AddWithValue("nivel", ddlNivel.SelectedValue);

                Conexao.Conecctar();
                cmd.ExecuteNonQuery();

                Response.Redirect("listar.aspx");

            }
            catch (Exception ex)
            {
                lblResultado.Text = "Falha: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }


        }
    }
}






