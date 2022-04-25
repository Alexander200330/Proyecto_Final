using Proyecto_FinalP2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace CapaPresentación
{
    public partial class Login : Form
    {
        private int xClick;
        private int yClick;

        public Login()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario:")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario:";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña:")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña:";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
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

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            btnCerrar.BackColor = color;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Logear(this.txtuser.Text,this.txtpass.Text);
            

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6D10T5G;Initial Catalog = Sistema_gestión_escolar;Integrated Security=True ");

        public void Logear(string user, string pass)
        {
            if (txtuser.Text == "Usuario:" || txtpass.Text == "Contraseña:")
            {
                MessageBox.Show("Favor de completar los campos");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select Usuario, Contraseña From usuario where Usuario = @usuario and Contraseña = @contraseña", con);
                    cmd.Parameters.AddWithValue("Usuario", user);
                    cmd.Parameters.AddWithValue("Contraseña", pass);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MenuPrincipal mp = new MenuPrincipal();
                        this.Hide();
                        mp.Show();

                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas");
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                }
                finally
                {
                    con.Close();
                }
            }
            
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtpass.Text == "hola")
                {
                    MessageBox.Show("Correcto!");
                }
                if (txtuser.Text == "hola")
                {
                    MessageBox.Show("Correcto!");
                }
            }
        }

       

    }
    }
