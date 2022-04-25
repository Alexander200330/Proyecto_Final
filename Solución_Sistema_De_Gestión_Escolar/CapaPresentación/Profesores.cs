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
    public partial class Profesores : Form
    {
        private string ID_Docente = null;
        private bool Editar = false;
        CN_Docentes objectoCN = new CN_Docentes();
        private int xClick;
        private int yClick;

        public Profesores()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cerrar_MouseHover(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Red;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Transparent;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }

        private void Minimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            Minimizar.BackColor = color;
        }

        private void Profesores_MouseMove(object sender, MouseEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCorreo.Text == "" || txtTeléfono.Text=="" || txtDirección.Text == "" || txtMateria.Text=="" || txtCédula.Text == "" || txtSalario.Text == "" || txtFecha.Text == "")
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
                        objectoCN.InsertarDocente(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTeléfono.Text, txtDirección.Text, txtMateria.Text, txtCédula.Text, txtSalario.Text, txtFecha.Text, txtSexo.Text, txtSustituto.Text);
                        MessageBox.Show("El registro se ha ingresado correctamente");
                        MostrarDocentes();
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
                        objectoCN.EditarDocente(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTeléfono.Text, txtDirección.Text,  txtMateria.Text, txtCédula.Text, txtSalario.Text, txtFecha.Text, txtSexo.Text, txtSustituto.Text, ID_Docente);
                        MessageBox.Show("El registro se ha editado correctamente");
                        MostrarDocentes();
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

        private void Profesores_Load(object sender, EventArgs e)
        {
            MostrarDocentes();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.SelectedRows.Count > 0)
            {
                ID_Docente = dgvDocentes.CurrentRow.Cells["id_docente"].Value.ToString();
                objectoCN.EliminarDocente(ID_Docente);
                MessageBox.Show("Eliminado correctamente");
                MostrarDocentes();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void MostrarDocentes()
        {
            CN_Docentes objecto = new CN_Docentes();
            dgvDocentes.DataSource = objecto.MostrarDoc();
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTeléfono.Clear();
            txtDirección.Clear();
            txtMateria.Clear();
            txtCédula.Clear();
            txtSalario.Clear();
            
            txtSustituto.Text = "Si";
            txtSexo.Text = "Masculino";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dgvDocentes.CurrentRow.Cells["Nombre"].Value.ToString(); //Agregar valores a los text box
                txtApellido.Text = dgvDocentes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtCorreo.Text = dgvDocentes.CurrentRow.Cells["Correo_Electrónico"].Value.ToString();
                txtTeléfono.Text = dgvDocentes.CurrentRow.Cells["Teléfono"].Value.ToString();
                txtDirección.Text = dgvDocentes.CurrentRow.Cells["Dirección"].Value.ToString();
                txtMateria.Text = dgvDocentes.CurrentRow.Cells["Materia"].Value.ToString();
                txtCédula.Text = dgvDocentes.CurrentRow.Cells["Cédula"].Value.ToString();
                txtSalario.Text = dgvDocentes.CurrentRow.Cells["Salario"].Value.ToString();
                txtFecha.Text = dgvDocentes.CurrentRow.Cells["Fecha_De_Nacimiento"].Value.ToString();
                txtSexo.Text = dgvDocentes.CurrentRow.Cells["Sexo"].Value.ToString();
                txtSustituto.Text = dgvDocentes.CurrentRow.Cells["Sustituto"].Value.ToString();
                ID_Docente = dgvDocentes.CurrentRow.Cells["iD_Docente"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text!="")
            {
                Conexion.conectar();
                string consulta = "select * from docentes where id_docente = " + txtBuscar.Text + "";
                SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.conectar());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDocentes.DataSource = dt;
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
