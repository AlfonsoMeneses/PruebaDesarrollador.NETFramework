<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaDesarrolladorNet.App.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>

    <link type="text/css" rel="stylesheet" href="Content/css/bootstrap.css" />
    <link type="text/css" rel="stylesheet" href="Content/css/bootstrap.min.css" />

    <script type="text/javascript" src="Content/js/bootstrap.js"></script>
    <script type="text/javascript" src="Content/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>


</head>
<body class="bg-info">

    <form id="form1" runat="server">

        <div class="container mt-xl-5">

            <div class="card m-5">

                <div class="card-header">
                    <h3>Iniciar sesión</h3>
                </div>
                <div class="card-body">

                    <div class="container">

                        <div class="form-group">
                            <label for="exampleInputEmail1">Usuario</label>

                            <asp:TextBox ID="txtUserName" placeholder="ingrese su usuario"
                                CssClass="form-control" runat="server" />

                            <!--
                            <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Usuario..." />
                            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                      -->
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Contraseña</label>
                            <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="ingrese contraseña"
                                CssClass="form-control" runat="server" />

                            <!--   <input type="password"
                                class="form-control" id="exampleInputPassword1"
                                placeholder="Ingersa la clave" />-->
                        </div>
                        <div class="form-group mt-1" >
                            <asp:Label ID="errorMessage"
                                CssClass="alert alert-danger form-control"
                                runat="server" Visible="false" />

                        </div>


                        <asp:Button runat="server"
                            CssClass="btn btn-primary mt-1"
                            Text="Aceptar" OnClick="Login_Click" />

                    </div>

                </div>
                <div class="card-footer">
                    <asp:Label Text="prueba tecnica" runat="server" />
                </div>
            </div>

        </div>

    </form>
</body>
</html>
