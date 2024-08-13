<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroMatricula.aspx.cs" Inherits="Proyecto_2.RegistroMatricula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/StyleMatriculaLinea.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container">
        <h2>Consulta de Boleta de Matrícula</h2>

        <form id="form1" runat="server">
            <div class="form-group">
                <asp:TextBox ID="cedulaConsulta" runat="server" CssClass="input-field" placeholder="Número de Cédula" />
                <asp:Button ID="BuscarBoleta" runat="server" Text="Buscar" CssClass="btn btn-search" OnClick="BuscarBoleta_Click" />
            </div>

            <asp:Panel ID="boletaPanel" runat="server" CssClass="boleta-panel" Visible="false">
                <h3>Boleta de Matrícula</h3>
                <p><strong>Nombre del Estudiante:</strong> <asp:Label ID="lblNombreEstudiante" runat="server" /></p>
                <p><strong>Nivel:</strong> <asp:Label ID="lblNivel" runat="server" /></p>
                <p><strong>Facultad:</strong> <asp:Label ID="lblFacultad" runat="server" /></p>
                <p><strong>Carrera:</strong> <asp:Label ID="lblCarrera" runat="server" /></p>

                <asp:GridView ID="gvBoleta" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                    <Columns>
                        <asp:BoundField DataField="CodigoMateria" HeaderText="Código de Materia" />
                        <asp:BoundField DataField="NombreMateria" HeaderText="Nombre de Materia" />
                        <asp:BoundField DataField="Modalidad" HeaderText="Modalidad" />
                        <asp:BoundField DataField="Horario" HeaderText="Horario" />
                        <asp:BoundField DataField="Profesor" HeaderText="Profesor" />
                    </Columns>
                </asp:GridView>
                <p><strong>Total de la Matrícula:</strong> <asp:Label ID="lblTotalMatricula" runat="server" /></p>
            </asp:Panel>

            <asp:Button ID="ReturnToMenu" runat="server" Text="Regresar al Menú" CssClass="btn btn-return" OnClick="ReturnToMenu_Click" />
        </form>
    </div>
</body>
</html>