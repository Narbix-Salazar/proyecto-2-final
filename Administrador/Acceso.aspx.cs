using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Administrador
{
    public partial class Acceso : System.Web.UI.Page
    {

        protected void AddEstudiante_Click(object sender, EventArgs e)
        {
            // Lógica para agregar un estudiante
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Estudiantes (usuario, contraseña) VALUES (@usuario, @contraseña)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.Text);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            ClearFields();
        }

        protected void ModifyEstudiante_Click(object sender, EventArgs e)
        {
            // Lógica para modificar un estudiante
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Estudiantes SET contraseña = @contraseña WHERE usuario = @usuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.Text);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            ClearFields();
        }

        protected void DeleteEstudiante_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar un estudiante
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Estudiantes WHERE usuario = @usuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            ClearFields();
        }

        protected void SearchEstudiante_Click(object sender, EventArgs e)
        {
            // Lógica para buscar un estudiante
            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT contraseña FROM Estudiantes WHERE usuario = @usuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario.Text);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        contraseña.Text = reader["contraseña"].ToString();
                    }
                    else
                    {
                        contraseña.Text = string.Empty;
                        // Manejo si no se encuentra el estudiante
                    }
                    conn.Close();
                }
            }
        }

        protected void ReturnToMenu_Click(object sender, EventArgs e)
        {
            // Redirigir al menú
            Response.Redirect("/MenuAdministrador.aspx");
        }

        private void ClearFields()
        {
            usuario.Text = string.Empty;
            contraseña.Text = string.Empty;
        }
    }
}