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
    public partial class Empleados : Form
    {
        private string ID_Empleado = null;
        private bool Editar = false;
        CN_Empleados objectoCN = new CN_Empleados();
        private int xClick;
        private int yClick;

        public Empleados()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }

        private void MostrarEmpleados()
        {
            CN_Empleados objecto = new CN_Empleados();
            dgvEmpleados.DataSource = objecto.MostrarDoc();
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTeléfono.Clear();
            txtDirección.Clear();
            txtPuesto.Clear();
            txtCédula.Clear();
            txtSalario.Clear();
            txtSexo.Text = "Masculino";
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                ID_Empleado = dgvEmpleados.CurrentRow.Cells["id_empleado"].Value.ToString();
                objectoCN.EliminarEmpleado(ID_Empleado);
                MessageBox.Show("Eliminado correctamente");
                MostrarEmpleados();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells["Nombre"].Value.ToString(); //Agregar valores a los text box
                txtApellido.Text = dgvEmpleados.CurrentRow.Cells["Apellido"].Value.ToString();
                txtCorreo.Text = dgvEmpleados.CurrentRow.Cells["Correo_Electrónico"].Value.ToString();
                txtTeléfono.Text = dgvEmpleados.CurrentRow.Cells["Teléfono"].Value.ToString();
                txtDirección.Text = dgvEmpleados.CurrentRow.Cells["Dirección"].Value.ToString();
                txtPuesto.Text = dgvEmpleados.CurrentRow.Cells["Puesto"].Value.ToString();
                txtCédula.Text = dgvEmpleados.CurrentRow.Cells["Cédula"].Value.ToString();
                txtSalario.Text = dgvEmpleados.CurrentRow.Cells["Salario"].Value.ToString();
                txtFecha.Text = dgvEmpleados.CurrentRow.Cells["Fecha_De_Nacimiento"].Value.ToString();
                ID_Empleado = dgvEmpleados.CurrentRow.Cells["id_empleado"].Value.ToString();
                txtSexo.Text = dgvEmpleados.CurrentRow.Cells["Sexo"].Value.ToString();
                

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCorreo.Text == "" || txtTeléfono.Text == "" || txtDirección.Text == "" || txtPuesto.Text == "" || txtCédula.Text == "" || txtSalario.Text == "" || txtFecha.Text == "")
            {
                MessageBox.Show("Favor Completar todos los campos");
            }
            else
            {
                //Insertar
                if (Editar == false)
                {


                    try
                    {
                        objectoCN.InsertarEmpleado(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTeléfono.Text, txtDirección.Text, txtPuesto.Text, txtCédula.Text, txtSalario.Text, txtFecha.Text, txtSexo.Text);
                        MessageBox.Show("El registro se ha ingresado correctamente");
                        MostrarEmpleados();
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
                        objectoCN.EditarEmpleado(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtTeléfono.Text, txtDirección.Text, txtPuesto.Text, txtCédula.Text, txtSalario.Text, txtFecha.Text, txtSexo.Text, ID_Empleado);
                        MessageBox.Show("El registro se ha editado correctamente");
                        MostrarEmpleados();
                        Editar = false;
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No se pudo editar los datos por: " + ex);
                    }
                }
            }
           
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

        private void Minimizar_MouseHover(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            Minimizar.BackColor = color;
        }

        private void Empleados_MouseMove(object sender, MouseEventArgs e)
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

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
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

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                Conexion.conectar();
            string consulta = "select * from empleados where id_empleado = " + txtBuscar.Text + "";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEmpleados.DataSource = dt;
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            SqlDataReader leer;

            leer = cmd.ExecuteReader();
            }
            else
            {
                MessageBox.Show("Por favor digite un id");
            }
        }
    }
}
