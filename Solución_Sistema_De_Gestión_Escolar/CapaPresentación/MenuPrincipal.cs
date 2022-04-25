
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_FinalP2.Menu_Principal;
using Proyecto_FinalP2.Menu_Principal.Sistema;



namespace CapaPresentación
{
    public partial class MenuPrincipal : Form
    {

        private int xClick;
        private int yClick;

        

        public MenuPrincipal()
        {
           
            int xer = this.Location.X;
            int yer = this.Location.Y;
            this.Location = new Point(xer,yer);
            InitializeComponent();
        }


        private void MenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MenuPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void MenuPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
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

        public void grupoEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estudiantes grpenti = new Estudiantes();
            grpenti.Show();
        }

        private void tipoEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profesores tipo = new Profesores();
            tipo.Show();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados enti = new Empleados();
            enti.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acer = new AcercaDe();
            acer.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MostrarFecha_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.ToLongTimeString(); Fecha larga
            //lblHora.Text = DateTime.Now.ToShortTimeString(); Fecha corta
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            //lblFecha.Text = DateTime.Now.ToLongDateString();
            lblFecha.Text = DateTime.Now.ToString("dd MMMM yyy");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void btnMinimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            btnMinimizar.BackColor = color;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Transparent;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.Show();
        }
    }
}
