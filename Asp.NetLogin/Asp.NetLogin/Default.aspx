<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Asp.NetLogin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>Login</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Style.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>


</head>

<body>

    <div class="container">
        <div class="wrapper">
            <form name="Login_Form" class="form-signin" runat="server">
                <h3 class="form-signin-heading">Bem-Vindo@!</h3>

                <div class="text-black-50 text-center">

                    <asp:Label ID="lblMsg" runat="server" CssClass="text text-info"></asp:Label>
                </div>
                <hr />

                <asp:TextBox runat="server" ID="txtUsuario" type="text" class="form-control" name="Username" placeholder="Usuário" required="" autofocus="" /><br />

                <asp:TextBox runat="server" ID="txtSenha" type="password" class="form-control" name="Password" placeholder="Senha" required="" /><br />

                 <asp:Button runat="server" ID="btnLogin"  class="btn btn-lg btn-primary btn-block" 
                  Text="Acessar" name="Submit" value="Login" type="Submit" OnClick="btnLogin_Click" />

            </form>
        </div>
    </div>

</body>
</html>
