using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2
{
    public partial class MatriculaLinea  : System.Web.UI.Page
    {
        private const decimal CostoMateria = 80000;
        private const decimal CostoMatricula = 65000;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BuscarEstudiante_Click(object sender, EventArgs e)
        {
            string cedula = cedulaBuscar.Text;

            if (string.IsNullOrEmpty(cedula))
            {
                // Manejo de error si no se proporciona la cédula
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    e.Nombre + ' ' + e.Apellido AS NombreCompleto,
                    e.NivelEducacion,
                    e.FacultadBachiller AS Facultad,
                    e.Carreras
                FROM ExpedienteEstudiantes e
                WHERE e.cedula = @cedula";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblNombreCompleto.Text = row["NombreCompleto"].ToString();
                        lblNivelEducacion.Text = row["NivelEducacion"].ToString();
                        lblFacultad.Text = row["Facultad"].ToString();
                        lblCarreras.Text = row["Carreras"].ToString();

                        infoPanel.Visible = true;
                    }
                    else
                    {
                        // Manejo de error si no se encuentra el estudiante
                        infoPanel.Visible = false;
                    }
                }
            }
        }

        protected void MostrarMaterias_Click(object sender, EventArgs e)
        {
            string nivel = lblNivelEducacion.Text;
            string facultad = lblFacultad.Text;
            string cedula = cedulaBuscar.Text;

            if (string.IsNullOrEmpty(nivel) || string.IsNullOrEmpty(facultad) || string.IsNullOrEmpty(cedula))
            {
                // Manejo de error si no se proporciona la información de nivel, facultad o cédula
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Obtener las materias disponibles basadas en nivel y facultad
                string queryMaterias = @"
                SELECT m.NombreMateria
                FROM Materias m
                INNER JOIN (
                    SELECT NombreMateria
                    FROM (
                        VALUES 
                        ('bachiller', 'ciencias empresariales', 'Comunicación'),
                        ('bachiller', 'ciencias empresariales', 'Matemáticas'),
                        ('bachiller', 'ciencias empresariales', 'Contabilidad'),
                        ('bachiller', 'ciencias empresariales', 'Administración'),
                        ('bachiller', 'ciencias empresariales', 'Computación'),
                        ('bachiller', 'diseño', 'Matemáticas'),
                        ('bachiller', 'diseño', 'Comunicación'),
                        ('bachiller', 'diseño', 'Publicidad I'),
                        ('bachiller', 'diseño', 'Computación'),
                        ('bachiller', 'derecho', 'Derecho Civil I'),
                        ('bachiller', 'derecho', 'Comunicación'),
                        ('bachiller', 'derecho', 'Derecho Penal I'),
                        ('bachiller', 'derecho', 'Computación'),
                        ('bachiller', 'educacion', 'Matemáticas I'),
                        ('bachiller', 'educacion', 'Comunicación'),
                        ('bachiller', 'educacion', 'Español I'),
                        ('bachiller', 'educacion', 'Computación'),
                        ('bachiller', 'ingenieria industrial', 'Matemáticas I'),
                        ('bachiller', 'ingenieria industrial', 'Cálculo I'),
                        ('bachiller', 'ingenieria industrial', 'Intro. a la Ingeniería'),
                        ('bachiller', 'ingenieria industrial', 'Computación'),
                        ('bachiller', 'ingenieria informatica', 'Matemáticas I'),
                        ('bachiller', 'ingenieria informatica', 'Cálculo I'),
                        ('bachiller', 'ingenieria informatica', 'Estructura y Algoritmos'),
                        ('bachiller', 'ingenieria informatica', 'Computación'),
                        ('bachiller', 'psicologia', 'Comunicación'),
                        ('bachiller', 'psicologia', 'Historia de la Psicología'),
                        ('bachiller', 'psicologia', 'Psicoanálisis I'),
                        ('bachiller', 'psicologia', 'Computación'),
                        ('tecnico', 'ciencias empresariales', 'Fundamentos en Administración'),
                        ('tecnico', 'ciencias empresariales', 'Fundamentos en Contabilidad'),
                        ('tecnico', 'diseño', 'Fundamentos en Publicidad'),
                        ('tecnico', 'diseño', 'Dibujo en Computadora'),
                        ('tecnico', 'electricidad', 'Electricidad Básica I'),
                        ('tecnico', 'electricidad', 'Fundamentos en Electrónica'),
                        ('tecnico', 'educacion', 'Fundamentos en Educación'),
                        ('tecnico', 'educacion', 'Lectoescritura'),
                        ('tecnico', 'ingenieria industrial', 'Administración en Proyectos'),
                        ('tecnico', 'ingenieria industrial', 'Estadística Descriptiva'),
                        ('tecnico', 'ingenieria informatica', 'Fundamentos de la Informática'),
                        ('tecnico', 'ingenieria informatica', 'Fundamentos en Redes'),
                        ('tecnico', 'psicologia', 'Psicología I'),
                        ('tecnico', 'idiomas', 'Inglés I'),
                        ('tecnico', 'idiomas', 'Inglés II')
                    ) AS AvailableMaterias(Nivel, Facultad, NombreMateria)
                    WHERE Nivel = @nivel AND Facultad = @facultad
                ) AS materias ON m.NombreMateria = materias.NombreMateria";

                // Obtener las materias en las que el estudiante ya está matriculado
                string queryMatriculas = @"
                SELECT m.NombreMateria
                FROM Matriculas mt
                INNER JOIN Materias m ON mt.MateriaID = m.MateriaID
                WHERE mt.cedula = @cedula";

                using (SqlCommand cmd = new SqlCommand(queryMaterias, conn))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    SqlDataAdapter daMatriculas = new SqlDataAdapter(cmd);
                    DataTable dtMatriculas = new DataTable();
                    daMatriculas.Fill(dtMatriculas);

                    HashSet<string> materiasMatriculadas = new HashSet<string>();
                    foreach (DataRow row in dtMatriculas.Rows)
                    {
                        materiasMatriculadas.Add(row["NombreMateria"].ToString());
                    }

                    cmd.CommandText = queryMaterias;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nivel", nivel);
                    cmd.Parameters.AddWithValue("@facultad", facultad);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtMaterias = new DataTable();
                    da.Fill(dtMaterias);

                    chkMaterias.Items.Clear();
                    foreach (DataRow row in dtMaterias.Rows)
                    {
                        string materia = row["NombreMateria"].ToString();
                        if (!materiasMatriculadas.Contains(materia))
                        {
                            chkMaterias.Items.Add(new ListItem(materia));
                        }
                    }

                    if (chkMaterias.Items.Count == 0)
                    {
                        lblNoMaterias.Text = "Ya ha matriculado todas las materias disponibles.";
                        lblNoMaterias.Visible = true;
                        materiasPanel.Visible = false;
                    }
                    else
                    {
                        lblNoMaterias.Visible = false;
                        materiasPanel.Visible = true;
                    }
                }
            }
        }

        protected void FormalizarMatricula_Click(object sender, EventArgs e)
        {
            string cedula = cedulaBuscar.Text;
            if (string.IsNullOrEmpty(cedula))
            {
                // Manejo de error si no se proporciona la cédula
                return;
            }

            decimal totalMonto = 0;
            DataTable dtDesglose = new DataTable();
            dtDesglose.Columns.Add("Materia");
            dtDesglose.Columns.Add("Costo", typeof(decimal));

            foreach (ListItem item in chkMaterias.Items)
            {
                if (item.Selected)
                {
                    string materia = item.Text;
                    totalMonto += CostoMateria;

                    dtDesglose.Rows.Add(materia, CostoMateria);
                }
            }

            totalMonto += CostoMatricula;

            // Mostrar el desglose en el GridView
            gvDesglose.DataSource = dtDesglose;
            gvDesglose.DataBind();

            lblMontoTotal.Text = $"Monto Total: {totalMonto:C}";
            desglosePanel.Visible = true;

            // Guardar en la base de datos
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (ListItem item in chkMaterias.Items)
                {
                    if (item.Selected)
                    {
                        string query = @"
                        INSERT INTO Matriculas (cedula, MateriaID, FechaMatricula)
                        SELECT @cedula, (SELECT MateriaID FROM Materias WHERE NombreMateria = @materia), GETDATE()";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cedula", cedula);
                            cmd.Parameters.AddWithValue("@materia", item.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                conn.Close();
            }
        }

        protected void ReturnToMenu_Click(object sender, EventArgs e)
        {
            // Redirigir al menú
            Response.Redirect("/Menu.aspx");
        }
    }
}