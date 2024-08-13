<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expediente.aspx.cs" Inherits="Proyecto_2.Administrador.Expediente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/StyleAdmin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container">
        <h2>Gestión de Expediente Estudiantil</h2>

        <form id="form1" runat="server">
            <div class="form-group">
                <label for="cedula">Cédula:</label>
                <asp:TextBox ID="cedula" runat="server" CssClass="form-control" />
                <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="SearchExpediente_Click" CssClass="btn btn-search" />
            </div>
            <asp:TextBox ID="Nombre" runat="server" CssClass="form-group" placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="Apellido" runat="server" CssClass="form-group" placeholder="Apellido"></asp:TextBox>
            <asp:TextBox ID="FechaNacimiento" runat="server" CssClass="form-group" placeholder="Fecha de Nacimiento" TextMode="Date"></asp:TextBox>
            <asp:TextBox ID="Telefono" runat="server" CssClass="form-group" placeholder="Teléfono" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="PersonaEmergencia" runat="server" CssClass="form-group" placeholder="Persona de Emergencia"></asp:TextBox>
            <asp:TextBox ID="Provincia" runat="server" CssClass="form-group" placeholder="Provincia"></asp:TextBox>
            <asp:TextBox ID="Canton" runat="server" CssClass="form-group" placeholder="Cantón"></asp:TextBox>
            <asp:TextBox ID="Distrito" runat="server" CssClass="form-group" placeholder="Distrito"></asp:TextBox>
            <asp:TextBox ID="Direccion" runat="server" CssClass="form-group" placeholder="Dirección"></asp:TextBox>
            <asp:TextBox ID="GradoAcademico" runat="server" CssClass="form-group" placeholder="Grado Academico"></asp:TextBox>
            <asp:TextBox ID="Institucion" runat="server" CssClass="form-group" placeholder="Institucion"></asp:TextBox>
            <asp:DropDownList ID="NivelEducacion" runat="server" CssClass="form-group" AutoPostBack="True" OnSelectedIndexChanged="NivelEducacion_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione un Nivel" Value="" />
                <asp:ListItem Text="Bachillerato" Value="Bachillerato" />
                <asp:ListItem Text="Técnico" Value="Técnico" />
            </asp:DropDownList>
            <asp:DropDownList ID="FacultadBachiller" runat="server" CssClass="form-group" AutoPostBack="True" OnSelectedIndexChanged="FacultadBachiller_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione una Facultad" Value="" />
                <asp:ListItem Text="Ciencias Empresariales" Value="Ciencias Empresariales" />
                <asp:ListItem Text="Comunicación y Diseño" Value="Comunicación y Diseño" />
                <asp:ListItem Text="Derecho" Value="Derecho" />
                <asp:ListItem Text="Educación" Value="Educación" />
                <asp:ListItem Text="Ing. Industrial" Value="Ing. Industrial" />
                <asp:ListItem Text="Ing. Informática" Value="Ing. Informática" />
                <asp:ListItem Text="Psicología" Value="Psicología" />
                <asp:ListItem Text="Electricidad" Value="Electricidad" />
                <asp:ListItem Text="Idiomas" Value="Idiomas" />
            </asp:DropDownList>
            <asp:DropDownList ID="Carreras" runat="server" CssClass="form-group">

            </asp:DropDownList>

            <asp:Button ID="AddExpediente" runat="server" Text="Agregar" CssClass="login" OnClick="AddExpediente_Click" />
            <asp:Button ID="ModifyExpediente" runat="server" Text="Modificar" CssClass="login" OnClick="ModifyExpediente_Click" />
            <asp:Button ID="DeleteExpediente" runat="server" Text="Eliminar" CssClass="login" OnClick="DeleteExpediente_Click" />
            <asp:Button ID="SearchExpediente" runat="server" Text="Buscar" CssClass="login" OnClick="SearchExpediente_Click" />


            <asp:Button ID="ReturnToMenu" runat="server" Text="Regresar al Menú" CssClass="login" OnClick="ReturnToMenu_Click" />
        </form>
    </div>
</body>
</html>
