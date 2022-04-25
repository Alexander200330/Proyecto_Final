using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Proyecto_Final_Pro;

namespace CapaPresentación
{
    public partial class Estudiantes : Form
    {
        public Estudiantes()
        {
            InitializeComponent();
        }

        private string ID_Estudiantes = null;
        private bool Editar = false;


        private void fecha_ValueChanged(object sender, EventArgs e)
        {

        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Con esto agregamos los valores a los textbox
            
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        CN_Estudiantes objectoCN = new CN_Estudiantes();
        private int xClick;
        private int yClick;

        private void Estudiantes_Load(object sender, EventArgs e)
        {
           
        }

        private void MostrarEstudiantes()
        {
            CN_Estudiantes objecto = new CN_Estudiantes();
            dgvEstudiantes.DataSource = objecto.MostrarEst();
        }

        private void BuscarEstudiante(int id)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTeléfono.Clear();
            txtDirección.Clear();
           
            txtSexo.Text = "Masculino";
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dgvEstudiantes.CurrentRow.Cells["Nombre"].Value.ToString(); //Agregar valores a los text box
                txtApellido.Text = dgvEstudiantes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtCorreo.Text = dgvEstudiantes.CurrentRow.Cells["Correo_Electrónico"].Value.ToString();
                txtTeléfono.Text = dgvEstudiantes.CurrentRow.Cells["Teléfono"].Value.ToString();
                txtDirección.Text = dgvEstudiantes.CurrentRow.Cells["Dirección"].Value.ToString();
                txtFecha.Text = dgvEstudiantes.CurrentRow.Cells["Fecha_De_Nacimiento"].Value.ToString();
                ID_Estudiantes = dgvEstudiantes.CurrentRow.Cells["id_estudiante"].Value.ToString();
                txtSexo.Text = dgvEstudiantes.CurrentRow.Cells["Sexo"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
            {

            }
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count > 0)
            {
                ID_Estudiantes = dgvEstudiantes.CurrentRow.Cells["id_estudiante"].Value.ToString();
                objectoCN.EliminarEstudiantes(ID_Estudiantes);
                MessageBox.Show("Eliminado correctamente");
                MostrarEstudiantes();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if(txtNombre.Text =="" || txtApellido.Text=="" || txtCorreo.Text=="" || txtDirección.Text =="" || txtFecha.Text == "")
            {
                MessageBox.Show("Favor de completar todos los campos");
            }
            else
            {
                //Insertar
                if (Editar == false)
                {
                    try
                    {
                        objectoCN.InsertarEstudiante(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTeléfono.Text, txtDirección.Text, txtFecha.Text, txtSexo.Text);
                        MessageBox.Show("El registro se ha ingresado correctamente");
                        MostrarEstudiantes();
                        LimpiarForm();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No se pudo insertar los datos por: " + ex);
                    }
                }

                //Editar
                if (Editar == true)
                {
                    try
                    {
                        objectoCN.EditarEstudiantes(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTeléfono.Text, txtDirección.Text, txtFecha.Text, txtSexo.Text, ID_Estudiantes);
                        MessageBox.Show("El registro se ha editado correctamente");
                        MostrarEstudiantes();
                        LimpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No se pudo editar los datos por: " + ex);
                    }
                }
            }

            
        }

        private void Estudiantes_Load_1(object sender, EventArgs e)
        {
            MostrarEstudiantes();
        }

        private void Estudiantes_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Cerrar_MouseHover(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Red;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
          Cerrar.BackColor = Color.Transparent;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Minimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            Minimizar.BackColor = color;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }

        public void buscar_Estudiante()
        {
            
           
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                Conexion.conectar();
                string consulta = "select * from estudiantes where id_estudiante = " + txtBuscar.Text + "";
                SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.conectar());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEstudiantes.DataSource = dt;
                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                SqlDataReader leer;

                leer = cmd.ExecuteReader();
            }
            else
            {
                MessageBox.Show("Por favor digite un id");
            }





        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
