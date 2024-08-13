using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Login_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Value;
            string contrasena = txtContrasena.Value;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Admini WHERE usuario = @usuario AND contraseña = @contrasena";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                conn.Open();
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    // Autenticación exitosa
                    Response.Redirect("MenuAdministrador.aspx");
                }
                else
                {
                    // Mostrar error
                    Response.Write("<script>alert('Cédula o contraseña incorrectos.');</script>");
                }
            }
        }
        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}