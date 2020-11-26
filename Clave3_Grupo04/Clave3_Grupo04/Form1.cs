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
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Clave3_Grupo04
{
    public partial class Form1 : Form
    {
        TabPage current;
        public String UserRoot = "root";
        public String PasswordRoot = "root";
        public int userSelected = 0;
        public int cardTypeSelected = 0;
        // Esta variable contempla el numero maximo de intentos fallidos permitidos antes de que se cierre el programa
        public int intentosFallidos = 3;
        ClaseUsuario classUsuario = new ClaseUsuario();

        /// <summary>
        /// Modificar el valor de las variables para la correcta conexion con la base de datos.
        /// </summary>
        static public String userNameDB = "root";
        static public String userPasswordDB = "";
        public MySqlConnection conectar = new MySqlConnection("datasource=localhost; port=3306; username=" + userNameDB + ";password=" + userPasswordDB + ";");


        public Form1()
        {
            InitializeComponent();
            this.connectToMysql();
            this.CenterToScreen();
            this.loadUser();
            this.loadOnlyCustomer();
            this.loadCardType();
            /// Para detectar cual es el Tab activo
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            tabControl4.Selecting += new TabControlCancelEventHandler(tabControl4_Selecting);
            //tabControl4.Selecting += new TabControlCancelEventHandler(tabControl4_Selecting);
        }
        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            current = (sender as TabControl).SelectedTab;
            String TabName = current.ToString().Replace("TabPage: {", "").Replace("}", "");
            if (TabName == "Usuarios")
            {
                this.loadUser();
            }
            if (TabName == "Clientes")
            {
                this.loadOnlyCustomer();
            }
            if (TabName == "Tarjetas")
            {
                this.loadCustomerWithCardComboBox();
                this.loadCustomerComboBox();
                this.loadCardsComboBox();
                this.loadTransaction();
                this.loadCards();
            }
            if (TabName == "Reportes")
            {
                
            }
            toolStripStatusLabel1.Text = TabName;
        }
        
        void tabControl4_Selecting(object sender, TabControlCancelEventArgs e)
        {
            current = (sender as TabControl).SelectedTab;
            String TabName = current.ToString().Replace("TabPage: {", "").Replace("}", "");
            this.loadCustomerWithCardComboBox();
            this.loadCustomerComboBox();
            this.loadTransaction();
            this.loadCards();
            toolStripStatusLabel1.Text = TabName;
        }
        /*
        void tabControl4_Selecting(object sender, TabControlCancelEventArgs e)
        {
            current = (sender as TabControl).SelectedTab;
            String TabName = current.ToString().Replace("TabPage: {", "").Replace("}", "");
            if (TabName == "Nuevo Cliente de Tarjeta")
            {
                var Customers = comboBox1.Items.Count;
                var TypeCard = comboBox2.Items.Count;
                if (Customers == 0 || TypeCard == 0)
                {
                    if (Customers == 0)
                    {
                        MessageBox.Show("No hay suficientes usuarios registrados en la plataforma. Debes de crear por lo menos un usuario para poder asignarle una tarjeta.", "Necesita ingresar registros");
                    }
                    else
                    {
                        MessageBox.Show("Actualmente no hay configurados tipos de tarjeta en la plataforma. Debes de crear un tipo de tarjeta por lo menos. Para hacerlo presiona las teclas ALT + T.", "Necesita ingresar registros");
                        tabControl2.SelectTab(2);
                        tabControl4.SelectTab(2);
                    }

                }
            }
            if (TabName == "Generar Transaccion" || TabName == "Nuevo Cliente")
            {
                this.userTableAdapter.FillByOnlyCustomers(this.trabajoFinalDataSet.user);
            }
            toolStripStatusLabel1.Text = TabName;
        }*/

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
        private void resetFormNewCustomer()
        {
            txtNicknameCliente.Text = "";
            txtEmailCliente.Text = "";
            txtPasswordCliente.Text = "";
            txtFirstNameCliente.Text = "";
            txtLastNameCliente.Text = "";
        }
        private void resetFormEditCustomer()
        {
            txtEditCustomerCode.Enabled = true;
            txtEditNicknameCustomer.Enabled = false;
            txtEditEmailCustomer.Enabled = false;
            txtEditFirstNameCustomer.Enabled = false;
            txtLastNameCustomer.Enabled = false;
            txtEditPasswordCustomer.Enabled = false;

            txtEditCustomerCode.Text = "";
            txtSearchUserByCode.Text = "";
            txtEditNicknameCustomer.Text = "";
            txtEditEmailCustomer.Text = "";
            txtEditPasswordCustomer.Text = "";
            txtEditFirstNameCustomer.Text = "";
            txtLastNameCustomer.Text = "";
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
        /// <summary>
        /// Cuando seleccionamos la opcion de Crear un nuevo Usuario se activan las tabs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            tabControl2.SelectTab(0);
        }
        /// <summary>
        /// Cuando seleccionamos la opcion de Eliminar un nuevo Usuario se activan las tabs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            tabControl2.SelectTab(1);
        }
        /// <summary>
        /// Cuando seleccionamos la opcion de Editar un nuevo Usuario se activan las tabs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ediarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            tabControl2.SelectTab(2);
        }
        /// <summary>
        /// Cuando seleccionamos la opcion de ver todos los usuarios se activan las tabs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            tabControl2.SelectTab(3);
        }
        /// <summary>
        /// Para crear nuevo cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabControl3.SelectTab(0);
        }
        /// <summary>
        /// Para eliminar a un cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabControl3.SelectTab(1);
        }
        /// <summary>
        /// Para editar a un cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ediarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabControl3.SelectTab(2);
        }
        /// <summary>
        /// Para ver a todos los clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabControl3.SelectTab(3);
        }
        /// <summary>
        /// Para crear a un nuevo cliente de tarjeta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoClienteDeTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            tabControl4.SelectTab(0);
        }
        /// <summary>
        /// Para generar una nueva transaccion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generarTransaccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            tabControl4.SelectTab(1);
        }
        /// <summary>
        /// Para configurar nuevo tipo de tarjeta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configurarNuevoTipoDeTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            tabControl4.SelectTab(2);
        }
        /// <summary>
        /// Para ver transacciones por periodo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verTransaccionesPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            tabControl5.SelectTab(0);
        }
        /// <summary>
        /// Para ver aperturas por periodo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verAperturasPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            tabControl5.SelectTab(1);
        }
        /// <summary>
        /// Para ver puntos acumulados por periodo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cantidadDePuntosAcumuladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            tabControl5.SelectTab(2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.loadUser();
        }
        public void loadCustomerWithCardComboBox() {
            try
            {
                String query = "SELECT * FROM problema3pr115.user,problema3pr115.card WHERE user.id_user=card.id_customer GROUP BY card.id_customer";
                MySqlCommand command = new MySqlCommand(query,conectar);
                MySqlDataReader reader = command.ExecuteReader();
                Dictionary<int, String> comboSource = new Dictionary<int, String>();
                while (reader.Read()) {
                    comboSource.Add(reader.GetInt32("id_card"), reader.GetString("user_nickname"));
                }
                comboBox1.DataSource = new BindingSource(comboSource, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void loadCustomerComboBox()
        {
            try
            {
                String query = "SELECT * FROM problema3pr115.user WHERE user.isEmployee=0";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataReader reader = command.ExecuteReader();
                Dictionary<int, String> comboSource = new Dictionary<int, String>();
                while (reader.Read())
                {
                    comboSource.Add(reader.GetInt32("id_user"), reader.GetString("user_nickname"));
                }
                comboBox2.DataSource = new BindingSource(comboSource, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void loadCardsComboBox()
        {
            try
            {
                String query = "SELECT * FROM problema3pr115.card_type";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataReader reader = command.ExecuteReader();
                Dictionary<int, String> comboSource = new Dictionary<int, String>();
                while (reader.Read())
                {
                    comboSource.Add(reader.GetInt32("id_card_type"), reader.GetString("card_name"));
                }
                comboBox3.DataSource = new BindingSource(comboSource, null);
                comboBox3.DisplayMember = "Value";
                comboBox3.ValueMember = "Key";
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }

        /// <summary>
        /// Medodo utilizado para seleccionar a todos los usuarios desde la base de datos
        /// </summary>
        public void loadUser() {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_user as 'Codigo de Usuario', user_nickname as 'Nombre de Usuario', user_email as 'Correo electronico', user_firstname as 'Nombres', user_lastname as 'Apellidos', isEmployee as 'Es empleado?' FROM problema3pr115.user", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                dataGridView1.DataSource = ds.Tables["user"];
                dataGridView2.DataSource = ds.Tables["user"];
                dataGridView3.DataSource = ds.Tables["user"];
                dataGridView4.DataSource = ds.Tables["user"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }

        public void loadCards()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT card.date_created as 'Fecha de Apertura' ,user.user_nickname as 'Nombre de Usuario', user.user_firstname as 'Primer Nombre', user.user_lastname as 'Apellidos', card_type.card_name as 'Nombre de Tarjeta', card.percentage_credit as 'Tasa de Interes', card.amount_credit as 'Monto del Credito'  FROM problema3pr115.user,problema3pr115.card,problema3pr115.card_type WHERE user.id_user=card.id_customer AND card.id_card_type=card_type.id_card_type GROUP BY card.id_card", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                adapter.Fill(ds, "card");
                adapter.Fill(ds, "card_type");
                dataGridView10.DataSource = ds.Tables["user"];
                dataGridView10.DataSource = ds.Tables["card"];
                dataGridView10.DataSource = ds.Tables["card_type"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }

        /// <summary>
        /// Metodo para mostrar solo a los empleados
        /// </summary>
        public void loadOnlyUser()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_user as 'Codigo de Usuario', user_nickname as 'Nombre de Usuario', user_email as 'Correo electronico', user_firstname as 'Nombres', user_lastname as 'Apellidos', isEmployee as 'Es empleado?' FROM problema3pr115.user WHERE isEmployee=1", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                dataGridView4.DataSource = ds.Tables["user"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        /// <summary>
        /// Metodo para mostrar solo a los clientes
        /// </summary>
        public void loadOnlyCustomer()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_user as 'Codigo de Usuario', user_nickname as 'Nombre de Usuario', user_email as 'Correo electronico', user_firstname as 'Nombres', user_lastname as 'Apellidos', isEmployee as 'Es empleado?' FROM problema3pr115.user WHERE isEmployee=0", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                dataGridView4.DataSource = ds.Tables["user"];
                dataGridView5.DataSource = ds.Tables["user"];
                dataGridView6.DataSource = ds.Tables["user"];
                dataGridView7.DataSource = ds.Tables["user"];
                dataGridView8.DataSource = ds.Tables["user"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        /// <summary>
        /// Metodo que ejecuta la sentencia SQL para actualizar a un usuario
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="isEmployee"></param>
        /// <param name="codigoUser"></param>
        public void updateUserById(String nickname, String Email, String firstName, String lastName, String password, int isEmployee, int codigoUser) {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("UPDATE problema3pr115.user SET user_nickname='"+nickname+"',user_email='"+Email+"',user_firstname='"+firstName+"', user_lastname='"+ lastName+ "',user_password='"+password+"', isEmployee="+isEmployee+"  WHERE id_user=" + codigoUser, conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                this.loadUserById(codigoUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }

        }
        /// <summary>
        /// Metodo para actualizar a un cliente
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="Email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="isEmployee"></param>
        /// <param name="codigoUser"></param>
        public void updateCustomerById(String nickname, String Email, String firstName, String lastName, String password, int codigoUser)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("UPDATE problema3pr115.user SET user_nickname='" + nickname + "',user_email='" + Email + "',user_firstname='" + firstName + "', user_lastname='" + lastName + "',user_password='" + password + "'  WHERE id_user=" + codigoUser +  " AND isEmployee=0", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                this.loadUserById(codigoUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }

        }
        /// <summary>
        /// Medodo utilizado para seleccionar a todos los usuarios desde la base de datos que coincidan
        /// con el codigo del usuario insertado
        /// </summary>
        public void loadUserById(int codigoUser)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_user as 'Codigo de Usuario', user_nickname as 'Nombre de Usuario', user_email as 'Correo electronico', user_firstname as 'Nombres', user_lastname as 'Apellidos', isEmployee as 'Es empleado?' FROM problema3pr115.user WHERE id_user="+codigoUser, conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                dataGridView3.DataSource = ds.Tables["user"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        /// <summary>
        /// Metodo para buscar el Cliente en base a su id para poder editar la informacion del mismo.
        /// </summary>
        /// <param name="codigoUser"></param>
        public void loadCustomerById(int codigoUser)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_user as 'Codigo de Usuario', user_nickname as 'Nombre de Usuario', user_email as 'Correo electronico', user_firstname as 'Nombres', user_lastname as 'Apellidos', isEmployee as 'Es empleado?' FROM problema3pr115.user WHERE id_user=" + codigoUser+" AND isEmployee=0" , conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                dataGridView7.DataSource = ds.Tables["user"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        /// <summary>
        /// Modulo para cargar todas las transacciones de los Clientes.
        /// </summary>
        public void loadTransaction()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT card_transaction.date_created as 'Fecha de transaccion',card_transaction.id_card_transaction as 'Codigo de Transaccion', user.user_nickname as 'Nombre de Usuario',user.user_firstname as 'Primer Nombre', user.user_lastname as 'Apellidos', card_type.card_name as 'Nombre de la Tarjeta', card.percentage_credit as 'Tasa %',card.amount_credit as 'Monto Credito', card_transaction.amount_transaction as 'Monto Transaccion', card_transaction.points_transactions  as 'Puntos' FROM problema3pr115.user,problema3pr115.card, problema3pr115.card_transaction, problema3pr115.card_type WHERE user.id_user=card.id_customer AND card.id_card_type=card_type.id_card_type AND card.id_card=card_transaction.id_card GROUP BY card_transaction.id_card_transaction", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "user");
                adapter.Fill(ds, "card");
                adapter.Fill(ds, "card_transaction");
                adapter.Fill(ds, "card_type");
                dataGridView11.DataSource = ds.Tables["user"];
                dataGridView11.DataSource = ds.Tables["card"];
                dataGridView11.DataSource = ds.Tables["card_transaction"];
                dataGridView11.DataSource = ds.Tables["card_type"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }

        public void insertNewTransaction(DateTime fechaActual, int id_card, float amountTransaction)
        {
            try
            {
                int points = 0;
                if (amountTransaction > 500)
                {
                    points += 20;
                }
                else {
                    points += 5;
                }
                String query = "INSERT INTO problema3pr115.card_transaction (date_created,id_card, amount_transaction, points_transactions) VALUES ('" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "',"+id_card+","+ amountTransaction + ","+points+")";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Transaccion insertada con exito");
                    this.resetFormNewUser();
                }
                else
                {
                    MessageBox.Show("La Transaccion no se ejecuto");
                }
                this.loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
       
        public void insertNewUser(String fechaActual,String txtNewNickname, String txtNewEmail, String txtNewPassword,String txtNewFirstName,String txtNewLastName, int isEmployee) {
            try
            {
                String query = "INSERT INTO problema3pr115.user (date_created,user_nickname, user_email, user_password, user_firstname, user_lastname, isEmployee) VALUES ('"+fechaActual+"','" + txtNewNickname + "','" + txtNewEmail + "','" + txtNewPassword + "','" + txtNewFirstName + "','" + txtNewLastName + "'," + isEmployee + ")";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Usuario insertado");
                    this.resetFormNewUser();
                }
                else {
                    MessageBox.Show("Usuario no insertado");
                }
                this.loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void insertNewCard(int userSelected, int cardSelected, float tasaInteres,float montoCredito) {
            try
            {
                var fechaActual = DateTime.Now;
                String query = "INSERT INTO problema3pr115.card (date_created, id_customer, id_card_type, percentage_credit, amount_credit) VALUES ('" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "'," + userSelected + ","+cardSelected+","+ tasaInteres + ","+ montoCredito + ")";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                if (command.ExecuteNonQuery() == 1)
                {
                    this.loadCards();
                    MessageBox.Show("Tarjeta asociada al usuario de manera correcta");
                }
                else
                {
                    MessageBox.Show("Tarjeta no asociada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void insertNewCardType(String cardName)
        {
            try
            {
                String query = "INSERT INTO problema3pr115.card_type (card_name) VALUES ('"+ cardName + "')";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Tipo de tarjeta insertado");
                    
                }
                else
                {
                    MessageBox.Show("Usuario no insertado");
                }
                this.loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void loadCardType()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id_card_type as 'Codigo de Tarjeta', card_name as 'Nombre de Tarjeta' FROM problema3pr115.card_type", conectar);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "card_type");
                dataGridView9.DataSource = ds.Tables["card_type"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void deleteUser(int codigoUsuario) {
            try
            {
                String query = "DELETE FROM problema3pr115.user WHERE id_user="+ codigoUsuario;
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                if (command.ExecuteNonQuery() == 1)
                {
                    this.resetFormNewUser();
                    this.loadUser();
                    MessageBox.Show("Usuario eliminado con exito", "Operacion exitosa");
                }
                else
                {
                    MessageBox.Show("Usuario no eliminado");
                }
                this.loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }
        public void deleteCustomer(int codigoUsuario)
        {
            try
            {
                String query = "DELETE FROM problema3pr115.user WHERE id_user=" + codigoUsuario+" AND isEmployee=0";
                MySqlCommand command = new MySqlCommand(query, conectar);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                if (command.ExecuteNonQuery() == 1)
                {
                    this.loadOnlyCustomer();
                    MessageBox.Show("Cliente eliminado con exito", "Operacion exitosa");
                }
                else
                {
                    MessageBox.Show("Cliente no eliminado");
                }
                this.loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de ejecucion.");
            }
        }

        /// <summary>
        /// Metodo para insertar a un nuevo usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            // 0 = False, es decir que no es empleado
            int isEmployee = 0;
            if (txtNewNickname.Text != "" && txtNewEmail.Text != "" && txtNewPassword.Text != "" && txtNewFirstName.Text != "" && txtNewLastName.Text != "")
            {
                if (isEmployeeCheckBox.Checked)
                {
                    isEmployee = 1;
                }
                var fechaActual = DateTime.Now;
                if (this.IsValid(txtNewEmail.Text)) {
                    this.insertNewUser(fechaActual.ToString("yyyy-MM-dd HH:mm:ss"), txtNewNickname.Text, txtNewEmail.Text, txtNewPassword.Text, txtNewFirstName.Text, txtNewLastName.Text, isEmployee);
                }
                else {
                    MessageBox.Show("La cuenta de correo electronico no es valida.", "Email invalido");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos", "Campos requeridos");
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        /// <summary>
        /// Metodo para eliminar a un usuario basado en el id del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            String codigoUser = txtCodigoUser.Text;
            int userCode;   
            bool eval = int.TryParse(codigoUser, out userCode);
            if (codigoUser != "")
            {
                if (eval)
                {
                    DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar a este usuario?", "Confirmacion de accion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.deleteUser(int.Parse(codigoUser));
                        txtCodigoUser.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No ha pasado nada, la operacion fue cancelada.", "Todo bien");
                    }
                }
                else {
                    MessageBox.Show("El codigo del usuario debe de ser un numero entero", "Numero invalido");
                }
            }
            else
            {
                MessageBox.Show("El codigo de usuario es requerido", "Campos obligatorios");
            }
        }
        /// <summary>
        /// Muestra el formulario con la informacion acerca del programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe aboutus = new AcercaDe();
            aboutus.Show();
        }
        /// <summary>
        /// Metodo que se utiliza para buscar si existe el codigo de un usuario, y 
        /// poder asi editar la informacion del mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            String codigoUser = txtSearchUserByCode.Text;
            int userCode;
            bool result = int.TryParse(codigoUser,out userCode);
            if (codigoUser != "")
            {
                if (result)
                {
                    this.loadUserById(userCode);
                    /*
                    id_user as 'Codigo de Usuario', 
                    user_nickname as 'Nombre de Usuario', 
                    user_email as 'Correo electronico', 
                    user_firstname as 'Nombres', 
                    user_lastname as 'Apellidos', 
                    isEmployee as 'Es empleado?' 
                    */
                    int amountRows = dataGridView3.Rows.Count;
                    if (amountRows>1) {
                        txtSearchNickname.Text = dataGridView3.Rows[0].Cells[1].Value.ToString();
                        txtSearchEmail.Text = dataGridView3.Rows[0].Cells[2].Value.ToString();
                        txtSearchFirstname.Text = dataGridView3.Rows[0].Cells[3].Value.ToString();
                        txtSearchLastname.Text = dataGridView3.Rows[0].Cells[4].Value.ToString();
                        if (dataGridView3.Rows[0].Cells[5].Value.ToString() == "True")
                            checkBox1.Checked = true;
                        else
                            checkBox1.Checked = false;

                        txtSearchUserByCode.Enabled = false;
                        txtSearchNickname.Enabled = true;
                        txtSearchEmail.Enabled = true;
                        txtSearchFirstname.Enabled = true;
                        txtSearchLastname.Enabled = true;
                        txtSearchPassword.Enabled = true;
                        checkBox1.Enabled = true;
                    }
                    else {
                        MessageBox.Show("El usuario no fue encontrado con el codigo insertado, ingresa otro e intentalo nuevamente.", "Registro no encontrado");
                    }
                }
                else {
                    MessageBox.Show("El codigo del usuario debe de ser un numero entero", "Numero invalido");
                }
            }
            else
            {
                MessageBox.Show("El codigo del usuario es requerido", "Campos requeridos");
            }
        }
        /// <summary>
        /// Con este metodo se cancela la edicion y todos los valores regresan a la normalidad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            this.resetFormEditUser();
        }
        public void resetFormEditUser() {
            this.loadUser();
            txtSearchUserByCode.Enabled = true;
            txtSearchNickname.Enabled = false;
            txtSearchEmail.Enabled = false;
            txtSearchFirstname.Enabled = false;
            txtSearchLastname.Enabled = false;
            txtSearchPassword.Enabled = false;
            checkBox1.Enabled = false;

            txtSearchUserByCode.Text = "";
            txtSearchNickname.Text = "";
            txtSearchEmail.Text = "";
            txtSearchFirstname.Text = "";
            txtSearchLastname.Text = "";
            txtSearchPassword.Text = "";
            checkBox1.Checked = false;
        }
        /// <summary>
        /// Metodo que actualiza la informacion del usuario segun el codigo de usuario ingresado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int isEmployee = 0;
            if (txtSearchNickname.Text != "" && txtSearchEmail.Text != "" && txtSearchPassword.Text != "" && txtSearchFirstname.Text != "" && txtSearchLastname.Text != "")
            {
                if (checkBox1.Checked)
                {
                    isEmployee = 1;
                }
                this.updateUserById(txtSearchNickname.Text, txtSearchEmail.Text, txtSearchFirstname.Text,txtSearchLastname.Text, txtSearchPassword.Text,isEmployee,int.Parse(txtSearchUserByCode.Text));
                this.resetFormEditUser();
                MessageBox.Show("Registro actualizado con exito", "Operacion exitosa");
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos", "Campos requeridos");
            }
        }
        /// <summary>
        /// Mostrar el listado de usuarios sean estos empleados o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.loadOnlyCustomer();
            }
            else {
                this.loadOnlyUser();
            }
        }
        /// <summary>
        /// Para mostrar a todos los usuarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.loadUser();
        }
        /// <summary>
        /// Metodo para insertar clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            // 0 = False, es decir que no es empleado
            int isEmployee = 0;
            if (txtNicknameCliente.Text != "" && txtEmailCliente.Text != "" && txtPasswordCliente.Text != "" && txtFirstNameCliente.Text != "" && txtLastNameCliente.Text != "")
            {
                var fechaActual = DateTime.Now;
                if (this.IsValid(txtEmailCliente.Text))
                {
                    this.insertNewUser(fechaActual.ToString("yyyy-MM-dd HH:mm:ss"), txtNicknameCliente.Text, txtEmailCliente.Text, txtPasswordCliente.Text, txtFirstNameCliente.Text, txtLastNameCliente.Text, isEmployee);
                    this.resetFormNewCustomer();
                    this.loadOnlyCustomer();
                }
                else
                {
                    MessageBox.Show("La cuenta de correo electronico no es valida.", "Email invalido");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos", "Campos requeridos");
            }
        }
        /// <summary>
        /// Metodo para eliminar a un cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            String codigoUser = txtCustomerCode.Text;
            int userCode;
            bool eval = int.TryParse(codigoUser, out userCode);
            if (codigoUser != "")
            {
                if (eval)
                {
                    DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar a este Cliente?", "Confirmacion de accion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.deleteCustomer(int.Parse(codigoUser));
                        txtCustomerCode.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No ha pasado nada, la operacion fue cancelada.", "Todo bien");
                    }
                }
                else
                {
                    MessageBox.Show("El codigo del usuario debe de ser un numero entero", "Numero invalido");
                }
            }
            else
            {
                MessageBox.Show("El codigo de usuario es requerido", "Campos obligatorios");
            }
        }
        /// <summary>
        /// Metodo para buscar el cliente que voy a editar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            String codigoUser = txtEditCustomerCode.Text;
            int userCode;
            bool result = int.TryParse(codigoUser, out userCode);
            if (codigoUser != "")
            {
                if (result)
                {
                    this.loadCustomerById(userCode);
                    /*
                    id_user as 'Codigo de Usuario', 
                    user_nickname as 'Nombre de Usuario', 
                    user_email as 'Correo electronico', 
                    user_firstname as 'Nombres', 
                    user_lastname as 'Apellidos', 
                    isEmployee as 'Es empleado?' 
                    */
                    int amountRows = dataGridView7.Rows.Count;
                    if (amountRows >= 1)
                    {
                        txtEditNicknameCustomer.Text = dataGridView7.Rows[0].Cells[1].Value.ToString();
                        txtEditEmailCustomer.Text = dataGridView7.Rows[0].Cells[2].Value.ToString();
                        txtEditFirstNameCustomer.Text = dataGridView7.Rows[0].Cells[3].Value.ToString();
                        txtLastNameCustomer.Text = dataGridView7.Rows[0].Cells[4].Value.ToString();
                        if (dataGridView7.Rows[0].Cells[5].Value.ToString() == "True")
                            checkBox4.Checked = true;
                        else
                            checkBox4.Checked = false;

                        txtEditCustomerCode.Enabled = false;
                        txtEditNicknameCustomer.Enabled = true;
                        txtEditEmailCustomer.Enabled = true;
                        txtEditFirstNameCustomer.Enabled = true;
                        txtLastNameCustomer.Enabled = true;
                        txtEditPasswordCustomer.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El usuario no fue encontrado con el codigo insertado, ingresa otro e intentalo nuevamente.", "Registro no encontrado");
                    }
                }
                else
                {
                    MessageBox.Show("El codigo del usuario debe de ser un numero entero", "Numero invalido");
                }
            }
            else
            {
                MessageBox.Show("El codigo del usuario es requerido", "Campos requeridos");
            }
        }
        /// <summary>
        /// Metodo que se encarga de actualizar la informacion del cliente que se ha insertado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            if (txtEditNicknameCustomer.Text != "" && txtEditEmailCustomer.Text != "" && txtEditPasswordCustomer.Text != "" && txtEditFirstNameCustomer.Text != "" && txtLastNameCustomer.Text != "")
            {
                this.updateCustomerById(txtEditNicknameCustomer.Text, txtEditEmailCustomer.Text, txtEditFirstNameCustomer.Text, txtLastNameCustomer.Text, txtEditPasswordCustomer.Text, int.Parse(txtEditCustomerCode.Text));
                this.loadOnlyCustomer();
                this.resetFormEditCustomer();
                this.loadCustomerWithCardComboBox();
                this.loadCustomerComboBox();
                MessageBox.Show("Registro actualizado con exito", "Operacion exitosa");
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos", "Campos requeridos");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.resetFormEditCustomer();
            this.loadOnlyCustomer();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtNewCardType.Text!="") {
                this.insertNewCardType(txtNewCardType.Text);
                txtNewCardType.Text = "";
                txtNewCardType.Focus();
                this.loadCardType();
            }
            else {
                MessageBox.Show("El nombre del tipo de tarjeta es obligatorio","Campos obligatorios");
                txtNewCardType.Focus();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

            }
            else {
                MessageBox.Show("Debe de seleccionar el Cliente","Campos obligatorios");
                comboBox1.Focus();
            }
        }
        /// <summary>
        /// Metodo para crear transaccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox1.ValueMember!="" && dateTimePicker1.Text!="" && txtMontoTransaccion.Text!="") {
                float amountTransaction;
                bool eval = float.TryParse(txtMontoTransaccion.Text, out amountTransaction);
                if (eval) {
                    if (float.Parse(txtMontoTransaccion.Text)>0) {
                        int userSelected;
                        userSelected = int.Parse(comboBox1.SelectedValue.ToString());
                        this.insertNewTransaction(DateTime.Parse(dateTimePicker1.Text), userSelected, float.Parse(txtMontoTransaccion.Text));
                        this.loadTransaction();
                    }
                    else {
                        MessageBox.Show("El monto de la transaccion debe de ser mayor a cero", "Monto de transaccion invalido");
                    }
                }
                else {
                    MessageBox.Show("El monto de la transaccion especificado es invalido.", "Monto de transaccion invalido");
                }
            }
            else {
                MessageBox.Show("Todos los campos son requeridos", "Campos obligatorios");
            }
        }
        /// <summary>
        /// Metodo para asociar una tarjeta a un usuario en especifico. Esto se refiere a las aperturas de las cuentas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click_1(object sender, EventArgs e)
        {
            if (txtTasaInteres.Text!="" && txtMontoCredito.Text!="") {
                float amountCredito;
                float tasaInteres;
                bool evalAmountCredito = float.TryParse(txtMontoCredito.Text, out amountCredito);
                bool evalTasaInteres = float.TryParse(txtTasaInteres.Text, out tasaInteres);
                if (evalAmountCredito) {
                    if (evalTasaInteres) {
                        if (float.Parse(txtMontoCredito.Text) > 0)
                        {
                            if (float.Parse(txtTasaInteres.Text)>0 && float.Parse(txtTasaInteres.Text) <= 100) {
                                int userSelected;
                                userSelected = int.Parse(comboBox2.SelectedValue.ToString());
                                int cardSelected;
                                cardSelected = int.Parse(comboBox3.SelectedValue.ToString());
                                this.insertNewCard(userSelected, cardSelected, float.Parse(txtTasaInteres.Text), float.Parse(txtMontoCredito.Text));
                            }
                        }
                        else {
                            MessageBox.Show("El monto no puede ser cero, o mayor a 100%.", "Monto invalido");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La tasa de interes invalido, no es un numero valido.", "Tasa de interes invalida");
                    }
                }
                else {
                    MessageBox.Show("El monto del credito es invalido, no es un monto valido.","Monto invalido");
                }
            }
            else {
                MessageBox.Show("La tasa de interes, y el monto del credito son obligatorios", "Campos obligatorios");
            }
        }
    }
}
