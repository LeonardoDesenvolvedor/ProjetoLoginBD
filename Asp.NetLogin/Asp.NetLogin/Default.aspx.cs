using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetLogin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                // Recuperar a senha Encriptada que esta no Banco de Dados
                cmd.Connection = Conexao.Connection;

                cmd.CommandText = @"SELECT senha FROM usuario 
                                    WHERE login = @usuario";

                cmd.Parameters.AddWithValue("@usuario", usuario);

                Conexao.Conecctar();
                string senhaEncriptada = Convert.ToString(cmd.ExecuteScalar());  // comando que desencriptografa so funciona com uma Unica informacao do banco umico dado!

                
                
                if (string.IsNullOrEmpty(senhaEncriptada))
                {
                    throw new Exception("Usuário ou Senha Iválida");  // jogda de logica para nao deixar na cara !
                }



                
                if(BCrypt.Net.BCrypt.Verify(senha, senhaEncriptada))  // Comparando o que foi digitado com o que tem no banco
                {


                    //// Pegando o ID do usuario e por em uma Session
                    //cmd.CommandText = @"SELECT nivel FROM usuario WHERE login = @login";
                    //cmd.Parameters.AddWithValue("@login", usuario);
                    //string nivel = Convert.ToString(cmd.ExecuteScalar());

                    //// Pegando o nome do banco pra por em uma Session
                    //cmd.CommandText = @"SELECT nome FROM usuario WHERE login = @login";
                    //cmd.Parameters.AddWithValue("@login", usuario);
                    //string nome = Convert.ToString(cmd.ExecuteScalar());


                    // faser a busca dos dados em uma unica chamado do banco

                    cmd.CommandText = @"SELECT nome, nivel FROM usuario
                                        WHERE login = @login";

                    cmd.Parameters.AddWithValue("@login", usuario);

                    var dr = cmd.ExecuteReader();
                    dr.Read();

                    string nome = dr.GetString("nome");
                    string nivel = dr.GetString("nivel");

                    // fazer o Redirecionamento
                    FormsAuthentication.RedirectFromLoginPage(nivel, false);

                    // Dados da Sessão
                    Session["Perfil"] = nivel;
                    Session["Nome"] = nome;

                }
                else
                {
                    throw new Exception("Usuário ou Senha Invalido !");
                }

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }

        }
    }
}