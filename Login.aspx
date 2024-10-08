﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/StyleLogin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container">
        <div class="screen">
            <div class="screen__content">
                <form id="form1" runat="server">
                    <div class="login">
                        <h1 class="login-title">Sistema de Inicio de Sesión</h1>
                        <div class="social-title">Ingresa con tu usuario y contraseña</div> 
                        <div class="login__field">
                            <i class="login__icon ion-ios-person"></i>
                            <input type="text" id="txtUsuario" class="login__input" placeholder="Cédula" runat="server" />
                        </div>
                        <div class="login__field">
                            <i class="login__icon ion-ios-lock"></i>
                            <input type="password" id="txtContrasena" class="login__input" placeholder="Contraseña" runat="server" />
                        </div>
                        <button type="submit" class="login__submit" runat="server" onserverclick="Login_Click">Ingresar</button>
                        <button type="submit" class="login__submit" runat="server" onserverclick="Admin_Click">Administrador</button>
                    </div>
                </form>
                <div class="social-login">
                    <div class="social-icons">
                        <img src="imagen/logologin.png" class="social-login"/>
                    </div>
                </div>
            </div>
            <div class="screen__background">
                <div class="screen__background__shape screen__background__shape1"></div>
                <div class="screen__background__shape screen__background__shape2"></div>
                <div class="screen__background__shape screen__background__shape3"></div>
                <div class="screen__background__shape screen__background__shape4"></div>
            </div>
        </div>
    </div>
</body>
</html>