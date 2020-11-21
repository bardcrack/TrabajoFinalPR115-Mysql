using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Clave3_Grupo04
{
    public partial class Form1 : Form
    {
        public String UserRoot = "root";
        public String PasswordRoot = "root";
        public int userSelected = 0;
        public int cardTypeSelected = 0;
        // Esta variable contempla el numero maximo de intentos fallidos permitidos antes de que se cierre el programa
        public int intentosFallidos = 3;


        /// <summary>
        /// Modificar el valor de las variables para la correcta conexion con la base de datos.
        /// </summary>
        static private String userNameDB      =   "root";    
        static private String userPasswordDB      =   "";
        MySqlConnection conectar = new MySqlConnection("datasource=localhost; port=3306; username="+userNameDB+";password="+userPasswordDB+";");


        public Form1()
        {
            InitializeComponent();
            this.connectToMysql();
            this.CenterToScreen();
        }
        /// <summary>
        /// Metodo creado para llevar a cabo la conexion con la base de datos.
        /// </summary>
        private void connectToMysql() {
            try
            {
                conectar.Open();
                if (conectar.State == ConnectionState.Open)
                {
                    toolStripStatusLabel1.Text = "Conección establecida";
                }
                else
                {
                    toolStripStatusLabel1.Text = "Conección con la base de datos ha fallado.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void resetFormNewUser()
        {
            txtNewNickname.Text = "";
            txtNewEmail.Text = "";
            txtNewPassword.Text = "";
            txtNewFirstName.Text = "";
            txtNewLastName.Text = "";
            isEmployeeCheckBox.Checked = false;
        }
        /// <summary>
        /// Cerrar el formulario por que se ha cancelado el inicio de sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Metodo para salir del programa principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Metodo para poder iniciar sesion en la plataforma segun los valores especificados
        /// por defecto hay un usuario root en todo el sistema con el mismo nombre para la
        /// contraseña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == UserRoot && txtPassword.Text == PasswordRoot)
            {
                groupLogin.Visible = false;
                menuStrip1.Visible = true;
                tabControl1.Visible = true;
                this.resetFormNewUser();
            }
            else
            {
                MessageBox.Show("Lo sentimos credenciales incorrectas vuelve a intentarlo nuevamente.");
                intentosFallidos--;
                if (intentosFallidos == 0)
                {
                    DialogResult results = MessageBox.Show("Has fallado muchas veces, cerraremos la aplicacion para que lo intentes mas tarde.", "Demasiados intentos", MessageBoxButtons.OK);
                    if (results == DialogResult.OK)
                    {
                        this.Close();
                        MessageBox.Show("Se ha cortado la conexion a la base");
                    }
                }
            }
        }
    }
}
