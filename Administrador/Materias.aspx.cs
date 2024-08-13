using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Proyecto_2.Administrador
{
    public partial class Materias : System.Web.UI.Page
    {
        protected void AddMateria_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Materias (NombreMateria, Hora, Profesor, Modalidad, NivelAcademico, FacultadAcademica, InicioLecciones) " +
                                   "VALUES (@NombreMateria, @Hora, @Profesor, @Modalidad, @NivelAcademico, @FacultadAcademica, @InicioLecciones)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@NombreMateria", nombreMateria.Text);
                        command.Parameters.AddWithValue("@Hora", hora.Text);
                        command.Parameters.AddWithValue("@Profesor", profesor.Text);
                        command.Parameters.AddWithValue("@Modalidad", modalidad.Text);
                        command.Parameters.AddWithValue("@NivelAcademico", nivelAcademico.Text);
                        command.Parameters.AddWithValue("@FacultadAcademica", facultadAcademica.Text);
                        command.Parameters.AddWithValue("@InicioLecciones", DateTime.Parse(inicioLecciones.Text));

                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                Response.Write("<script>alert('Materia agregada con éxito.');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al agregar materia: " + ex.Message + "');</script>");
            }
        }

        protected void ModifyMateria_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Materias SET NombreMateria = @NombreMateria, Hora = @Hora, Profesor = @Profesor, Modalidad = @Modalidad, " +
                                   "NivelAcademico = @NivelAcademico, FacultadAcademica = @FacultadAcademica, InicioLecciones = @InicioLecciones " +
                                   "WHERE MateriaID = @MateriaID";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@MateriaID", materiaID.Text);
                        command.Parameters.AddWithValue("@NombreMateria", nombreMateria.Text);
                        command.Parameters.AddWithValue("@Hora", hora.Text);
                        command.Parameters.AddWithValue("@Profesor", profesor.Text);
                        command.Parameters.AddWithValue("@Modalidad", modalidad.Text);
                        command.Parameters.AddWithValue("@NivelAcademico", nivelAcademico.Text);
                        command.Parameters.AddWithValue("@FacultadAcademica", facultadAcademica.Text);
                        command.Parameters.AddWithValue("@InicioLecciones", DateTime.Parse(inicioLecciones.Text));

                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                Response.Write("<script>alert('Materia modificada con éxito.');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al modificar materia: " + ex.Message + "');</script>");
            }
        }

        protected void DeleteMateria_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Materias WHERE MateriaID = @MateriaID";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@MateriaID", materiaID.Text);

                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                Response.Write("<script>alert('Materia eliminada con éxito.');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al eliminar materia: " + ex.Message + "');</script>");
            }
        }

        protected void SearchMateria_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Materias WHERE MateriaID = @MateriaID";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@MateriaID", materiaID.Text);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            nombreMateria.Text = reader["NombreMateria"].ToString();
                            hora.Text = reader["Hora"].ToString();
                            profesor.Text = reader["Profesor"].ToString();
                            modalidad.Text = reader["Modalidad"].ToString();
                            nivelAcademico.Text = reader["NivelAcademico"].ToString();
                            facultadAcademica.Text = reader["FacultadAcademica"].ToString();
                            inicioLecciones.Text = Convert.ToDateTime(reader["InicioLecciones"]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            Response.Write("<script>alert('Materia no encontrada.');</script>");
                        }

                        reader.Close();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al buscar materia: " + ex.Message + "');</script>");
            }
        }
        protected void ReturnToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MenuAdministrador.aspx"); 
        }
    }
}