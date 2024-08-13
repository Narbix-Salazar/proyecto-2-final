using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Administrador
{
    public partial class Expediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializa la lista de carreras al cargar la página
                UpdateCarreras();
            }
        }

        protected void NivelEducacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualiza la lista de facultades y carreras según el nivel de educación seleccionado
            UpdateFacultadBachiller();
        }

        protected void FacultadBachiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualiza la lista de carreras según la facultad seleccionada
            UpdateCarreras();
        }

        private void UpdateFacultadBachiller()
        {
            // Aquí podrías hacer una lógica adicional si deseas mostrar diferentes facultades basadas en el nivel de educación
            // Actualmente, se muestran todas las facultades para simplificar
        }

        private void UpdateCarreras()
        {
            // Limpia la lista de carreras
            Carreras.Items.Clear();

 
            if (NivelEducacion.SelectedValue == "Bachillerato")
            {
                if (FacultadBachiller.SelectedValue == "Ciencias Empresariales")
                {
                    Carreras.Items.Add(new ListItem("Administración de Empresas"));
                    Carreras.Items.Add(new ListItem("Contabilidad"));
                    Carreras.Items.Add(new ListItem("Economia"));
                    Carreras.Items.Add(new ListItem("Marketing"));
                }
                if (FacultadBachiller.SelectedValue == "Comunicación y Diseño")
                {
                    Carreras.Items.Add(new ListItem("Diseño Gráfico"));
                    Carreras.Items.Add(new ListItem("Comunicación Visual"));
                    Carreras.Items.Add(new ListItem("Publicidad"));
                    Carreras.Items.Add(new ListItem("Marketing"));
                }
                if (FacultadBachiller.SelectedValue == "Derecho")
                {
                    Carreras.Items.Add(new ListItem("Derecho Civil"));
                    Carreras.Items.Add(new ListItem("Derecho Penal"));
                    Carreras.Items.Add(new ListItem("Derecho Notarial"));
            
                }

            }
            else if (NivelEducacion.SelectedValue == "Técnico")
            {
                if (FacultadBachiller.SelectedValue == "Ciencias Empresariales")
                {
                    Carreras.Items.Add(new ListItem("Gestión Empresarial"));
                    Carreras.Items.Add(new ListItem("Finanzas"));
                }
            }
        }

        protected void AddExpediente_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos
            int cedula = int.Parse(this.cedula.Text);
            string nombre = this.Nombre.Text;
            string apellido = this.Apellido.Text;
            DateTime fechaNacimiento = DateTime.Parse(this.FechaNacimiento.Text);
            int telefono = int.Parse(this.Telefono.Text);
            string personaEmergencia = this.PersonaEmergencia.Text;
            string provincia = this.Provincia.Text;
            string canton = this.Canton.Text;
            string distrito = this.Distrito.Text;
            string direccion = this.Direccion.Text;
            string nivelEducacion = this.NivelEducacion.SelectedValue;
            string facultadBachiller = this.FacultadBachiller.SelectedValue;
            string carreras = this.Carreras.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ExpedienteEstudiantes (cedula, Nombre, Apellido, FechaNacimiento, Telefono, PersonaEmergencia, Provincia, Canton, Distrito, Direccion, GradoAcademico, Institucion, NivelEducacion, FacultadBachiller, Carreras) VALUES (@cedula, @Nombre, @Apellido, @FechaNacimiento, @Telefono, @PersonaEmergencia, @Provincia, @Canton, @Distrito, @Direccion, @GradoAcademico, @Institucion, @NivelEducacion, @FacultadBachiller, @Carreras)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cedula", cedula);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@PersonaEmergencia", personaEmergencia);
                command.Parameters.AddWithValue("@Provincia", provincia);
                command.Parameters.AddWithValue("@Canton", canton);
                command.Parameters.AddWithValue("@Distrito", distrito);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@GradoAcademico", ""); // Ajusta si es necesario
                command.Parameters.AddWithValue("@Institucion", ""); // Ajusta si es necesario
                command.Parameters.AddWithValue("@NivelEducacion", nivelEducacion);
                command.Parameters.AddWithValue("@FacultadBachiller", facultadBachiller);
                command.Parameters.AddWithValue("@Carreras", carreras);

                connection.Open();
                command.ExecuteNonQuery();
            }

            ClearFields(); // Limpia los campos después de agregar
        }

        protected void ModifyExpediente_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos
            int cedula = int.Parse(this.cedula.Text);
            string nombre = this.Nombre.Text;
            string apellido = this.Apellido.Text;
            DateTime fechaNacimiento = DateTime.Parse(this.FechaNacimiento.Text);
            int telefono = int.Parse(this.Telefono.Text);
            string personaEmergencia = this.PersonaEmergencia.Text;
            string provincia = this.Provincia.Text;
            string canton = this.Canton.Text;
            string distrito = this.Distrito.Text;
            string direccion = this.Direccion.Text;
            string nivelEducacion = this.NivelEducacion.SelectedValue;
            string facultadBachiller = this.FacultadBachiller.SelectedValue;
            string carreras = this.Carreras.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ExpedienteEstudiantes SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, PersonaEmergencia = @PersonaEmergencia, Provincia = @Provincia, Canton = @Canton, Distrito = @Distrito, Direccion = @Direccion, NivelEducacion = @NivelEducacion, FacultadBachiller = @FacultadBachiller, Carreras = @Carreras WHERE cedula = @cedula";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cedula", cedula);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@PersonaEmergencia", personaEmergencia);
                command.Parameters.AddWithValue("@Provincia", provincia);
                command.Parameters.AddWithValue("@Canton", canton);
                command.Parameters.AddWithValue("@Distrito", distrito);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@NivelEducacion", nivelEducacion);
                command.Parameters.AddWithValue("@FacultadBachiller", facultadBachiller);
                command.Parameters.AddWithValue("@Carreras", carreras);

                connection.Open();
                command.ExecuteNonQuery();
            }

            ClearFields(); // Limpia los campos después de modificar
        }

        protected void DeleteExpediente_Click(object sender, EventArgs e)
        {
            int cedula = int.Parse(this.cedula.Text);

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ExpedienteEstudiantes WHERE cedula = @cedula";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cedula", cedula);

                connection.Open();
                command.ExecuteNonQuery();
            }

            ClearFields(); // Limpia los campos después de eliminar
        }

        protected void SearchExpediente_Click(object sender, EventArgs e)
        {
            int cedula = int.Parse(this.cedula.Text);

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ExpedienteEstudiantes WHERE cedula = @cedula";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cedula", cedula);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    this.Nombre.Text = reader["Nombre"].ToString();
                    this.Apellido.Text = reader["Apellido"].ToString();
                    this.FechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("yyyy-MM-dd");
                    this.Telefono.Text = reader["Telefono"].ToString();
                    this.PersonaEmergencia.Text = reader["PersonaEmergencia"].ToString();
                    this.Provincia.Text = reader["Provincia"].ToString();
                    this.Canton.Text = reader["Canton"].ToString();
                    this.Distrito.Text = reader["Distrito"].ToString();
                    this.Direccion.Text = reader["Direccion"].ToString();
                    this.NivelEducacion.SelectedValue = reader["NivelEducacion"].ToString();
                    this.FacultadBachiller.SelectedValue = reader["FacultadBachiller"].ToString();
                    this.Carreras.SelectedValue = reader["Carreras"].ToString();
                }
            }
        }

        protected void ReturnToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MenuAdministrador.aspx"); // Redirige al menú principal
        }

        private void ClearFields()
        {
            // Limpia todos los campos del formulario
            this.cedula.Text = string.Empty;
            this.Nombre.Text = string.Empty;
            this.Apellido.Text = string.Empty;
            this.FechaNacimiento.Text = string.Empty;
            this.Telefono.Text = string.Empty;
            this.PersonaEmergencia.Text = string.Empty;
            this.Provincia.Text = string.Empty;
            this.Canton.Text = string.Empty;
            this.Distrito.Text = string.Empty;
            this.Direccion.Text = string.Empty;
            this.NivelEducacion.SelectedIndex = 0;
            this.FacultadBachiller.SelectedIndex = 0;
            this.Carreras.Items.Clear();
        }
    }
}