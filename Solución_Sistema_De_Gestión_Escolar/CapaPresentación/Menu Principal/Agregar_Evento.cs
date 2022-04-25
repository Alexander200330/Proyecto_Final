using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;


namespace WindowsFormsAgenda
{
    public partial class Estudiantes : Form
    {
        private string ID_Estudiantes = null;
        private bool Editar = false;

        public Estudiantes()
        {
            InitializeComponent();
        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
           
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int posicion;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Con esto agregamos los valores a los textbox
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

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvEstudiantes.SelectedRows.Count > 0)
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

        CN_Estudiantes objectoCN = new CN_Estudiantes();
        private void Estudiantes_Load(object sender, EventArgs e)
        {
            MostrarEstudiantes();
        }

        private void MostrarEstudiantes()
        {
            CN_Estudiantes objecto = new CN_Estudiantes();
            dgvEstudiantes.DataSource = objecto.MostrarEst();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Insertar
            if(Editar == false) { 
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
            if(Editar == true)
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

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTeléfono.Clear();
            txtDirección.Clear();
            txtFecha.Clear();
            txtSexo.Text = "Masculino";
        }
    }
}
