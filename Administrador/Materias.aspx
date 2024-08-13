<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="Proyecto_2.Administrador.Materias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/StyleAdmin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Gestión de Materias</h2>
            
            <div class="button-container">
                <asp:Button ID="AddMateria" runat="server" Text="Agregar" CssClass="btn-action" OnClick="AddMateria_Click" />
                <asp:Button ID="ModifyMateria" runat="server" Text="Modificar" CssClass="btn-action" OnClick="ModifyMateria_Click" />
                <asp:Button ID="DeleteMateria" runat="server" Text="Eliminar" CssClass="btn-action" OnClick="DeleteMateria_Click" />
            </div>
            
            <div class="form-group">
                <label for="materiaID">Materia ID:</label>
                <asp:TextBox ID="materiaID" runat="server" CssClass="input-field" />
                <asp:Button ID="SearchMateria" runat="server" Text="Buscar" CssClass="btn-search" OnClick="SearchMateria_Click" />
            </div>
            
            <div class="form-group">
                <label for="nombreMateria">Nombre de Materia:</label>
                <asp:TextBox ID="nombreMateria" runat="server" CssClass="input-field" />
            </div>
            
            <div class="form-group">
                <label for="hora">Hora:</label>
                <asp:TextBox ID="hora" runat="server" CssClass="input-field" />
            </div>
            
            <div class="form-group">
                <label for="profesor">Profesor:</label>
                <asp:TextBox ID="profesor" runat="server" CssClass="input-field" />
            </div>
            
            <div class="form-group">
                <label for="modalidad">Modalidad:</label>
                <asp:TextBox ID="modalidad" runat="server" CssClass="input-field" />
            </div>
            
            <div class="form-group">
                <label for="nivelAcademico">Nivel Académico:</label>
                <asp:TextBox ID="nivelAcademico" runat="server" CssClass="input-field" />
            </div>
            
            <div class="form-group">
                <label for="facultadAcademica">Facultad Académica:</label>
                <asp:TextBox ID="facultadAcademica" runat="server" CssClass="input-field" />
            </div>
            
            <div class="form-group">
                <label for="inicioLecciones">Inicio de Lecciones:</label>
                <asp:TextBox ID="inicioLecciones" runat="server" CssClass="input-field" />
            </div>
            <asp:Button ID="ReturnToMenu" runat="server" Text="Regresar al Menú" CssClass="login" OnClick="ReturnToMenu_Click" />
            
        </div>
    </form>
</body>
</html>