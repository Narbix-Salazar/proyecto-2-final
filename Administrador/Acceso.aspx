<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="Proyecto_2.Administrador.Acceso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/StyleAdmin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container">
        <h2>Gestión de Estudiantes</h2>

        <form id="form1" runat="server">
            <div class="form-group">
                <asp:TextBox ID="usuario" runat="server" placeholder="ID del Estudiante" CssClass="input-field" />
                <asp:Button ID="SearchEstudiante" runat="server" Text="Buscar" CssClass="btn btn-search" OnClick="SearchEstudiante_Click" />
            </div>
            
            <div class="form-group">
                <asp:TextBox ID="contraseña" runat="server" CssClass="input-field" placeholder="Contraseña" TextMode="Password" />
            </div>

            <div class="form-group">
                <asp:Button ID="AddEstudiante" runat="server" Text="Agregar" CssClass="btn btn-action" OnClick="AddEstudiante_Click" />
                <asp:Button ID="ModifyEstudiante" runat="server" Text="Modificar" CssClass="btn btn-action" OnClick="ModifyEstudiante_Click" />
                <asp:Button ID="DeleteEstudiante" runat="server" Text="Eliminar" CssClass="btn btn-action" OnClick="DeleteEstudiante_Click" />
            </div>

            <div class="form-group">
                <asp:Button ID="ReturnToMenu" runat="server" Text="Regresar al Menú" CssClass="btn btn-return" OnClick="ReturnToMenu_Click" />
            </div>
        </form>
    </div>
</body>
</html>