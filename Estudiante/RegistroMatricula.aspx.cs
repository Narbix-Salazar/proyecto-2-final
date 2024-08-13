using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2
{
    public partial class RegistroMatricula : System.Web.UI.Page
    {
        private const decimal CostoMateria = 80000;
        private const decimal CostoMatricula = 65000;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BuscarBoleta_Click(object sender, EventArgs e)
        {
            string cedula = cedulaConsulta.Text;

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
                    e.Nombre + ' ' + e.Apellido AS NombreEstudiante,
                    e.NivelEducacion AS Nivel,
                    e.FacultadBachiller AS Facultad,
                    e.Carreras AS Carrera,
                    m.MateriaID AS CodigoMateria,
                    ma.NombreMateria AS NombreMateria,
                    ma.Modalidad,
                    ma.Hora AS Horario,
                    ma.Profesor
                FROM Matriculas m
                INNER JOIN ExpedienteEstudiantes e ON m.cedula = e.cedula
                INNER JOIN Materias ma ON m.MateriaID = ma.MateriaID
                WHERE m.cedula = @cedula";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblNombreEstudiante.Text = row["NombreEstudiante"].ToString();
                        lblNivel.Text = row["Nivel"].ToString();
                        lblFacultad.Text = row["Facultad"].ToString();
                        lblCarrera.Text = row["Carrera"].ToString();

                        gvBoleta.DataSource = dt;
                        gvBoleta.DataBind();

                        decimal totalMatricula = CostoMatricula + (dt.Rows.Count * CostoMateria);
                        lblTotalMatricula.Text = totalMatricula.ToString("C");

                        boletaPanel.Visible = true;
                    }
                    else
                    {
                        // Manejo de error si no se encuentra la matrícula
                        boletaPanel.Visible = false;
                    }
                }
            }
        }

        protected void ReturnToMenu_Click(object sender, EventArgs e)
            {
                Response.Redirect("/Menu.aspx");
            }
        }
    }