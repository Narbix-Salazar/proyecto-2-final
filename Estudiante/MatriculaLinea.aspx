<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatriculaLinea.aspx.cs" Inherits="Proyecto_2.MatriculaLinea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/StyleMatriculaLinea.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container">
        <h2>Formulario de Matrícula</h2>

        <form id="form1" runat="server">
            <asp:TextBox ID="cedulaBuscar" runat="server" CssClass="input-field" placeholder="Ingrese la Cédula" />
            <asp:Button ID="BuscarEstudiante" runat="server" Text="Buscar" CssClass="login" OnClick="BuscarEstudiante_Click" />
            
            <asp:Panel ID="infoPanel" runat="server" Visible="false">
                <h3>Información del Estudiante</h3>
                <asp:Label ID="lblNombreCompleto" runat="server" CssClass="form-group" />
                <asp:Label ID="lblNivelEducacion" runat="server" CssClass="form-group" />
                <asp:Label ID="lblFacultad" runat="server" CssClass="form-group" />
                <asp:Label ID="lblCarreras" runat="server" CssClass="form-group" />
                
                <asp:Button ID="MostrarMaterias" runat="server" Text="Mostrar Materias" CssClass="login" OnClick="MostrarMaterias_Click" />
            </asp:Panel>

            <asp:Panel ID="materiasPanel" runat="server" Visible="false">
                <h3>Materias Disponibles</h3>
                <asp:CheckBoxList ID="chkMaterias" runat="server" CssClass="form-group" />
                
                <asp:Label ID="lblNoMaterias" runat="server" CssClass="form-group" Visible="false" />
                
                <asp:Button ID="FormalizarMatricula" runat="server" Text="Formalizar" CssClass="login" OnClick="FormalizarMatricula_Click" />
            </asp:Panel>

            <asp:Panel ID="desglosePanel" runat="server" Visible="false">
                <h3>Desglose de Pago</h3>
                <asp:GridView ID="gvDesglose" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Materia" HeaderText="Materia" />
                        <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C}" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblMontoTotal" runat="server" CssClass="form-group" />
            </asp:Panel>

            <asp:Button ID="ReturnToMenu" runat="server" Text="Regresar al Menú" CssClass="login" OnClick="ReturnToMenu_Click" />
        </form>
    </div>
</body>
</html>