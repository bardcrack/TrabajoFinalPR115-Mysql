namespace Clave3_Grupo04
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarjetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ediarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verTodosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteDeTarjetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarTransaccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.configurarNuevoTipoDeTarjetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTransaccionesPorPeriodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAperturasPorPeriodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cantidadDePuntosAcumuladosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(301, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Iniciar sesión";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 237);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Iniciar Sesión";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(94, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel1.Text = "Barra de estado";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.tarjetasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.ediarToolStripMenuItem,
            this.verTodosToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.eliminarToolStripMenuItem1,
            this.ediarToolStripMenuItem1,
            this.verTodosToolStripMenuItem1});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // tarjetasToolStripMenuItem
            // 
            this.tarjetasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteDeTarjetaToolStripMenuItem,
            this.generarTransaccionToolStripMenuItem,
            this.toolStripSeparator1,
            this.configurarNuevoTipoDeTarjetaToolStripMenuItem});
            this.tarjetasToolStripMenuItem.Name = "tarjetasToolStripMenuItem";
            this.tarjetasToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.tarjetasToolStripMenuItem.Text = "Tarjetas";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTransaccionesPorPeriodoToolStripMenuItem,
            this.verAperturasPorPeriodoToolStripMenuItem,
            this.cantidadDePuntosAcumuladosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // ediarToolStripMenuItem
            // 
            this.ediarToolStripMenuItem.Name = "ediarToolStripMenuItem";
            this.ediarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ediarToolStripMenuItem.Text = "Ediar";
            // 
            // verTodosToolStripMenuItem
            // 
            this.verTodosToolStripMenuItem.Name = "verTodosToolStripMenuItem";
            this.verTodosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verTodosToolStripMenuItem.Text = "Ver todos";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            // 
            // ediarToolStripMenuItem1
            // 
            this.ediarToolStripMenuItem1.Name = "ediarToolStripMenuItem1";
            this.ediarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.ediarToolStripMenuItem1.Text = "Ediar";
            // 
            // verTodosToolStripMenuItem1
            // 
            this.verTodosToolStripMenuItem1.Name = "verTodosToolStripMenuItem1";
            this.verTodosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.verTodosToolStripMenuItem1.Text = "Ver todos";
            // 
            // nuevoClienteDeTarjetaToolStripMenuItem
            // 
            this.nuevoClienteDeTarjetaToolStripMenuItem.Name = "nuevoClienteDeTarjetaToolStripMenuItem";
            this.nuevoClienteDeTarjetaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.nuevoClienteDeTarjetaToolStripMenuItem.Text = "Nuevo cliente de tarjeta";
            // 
            // generarTransaccionToolStripMenuItem
            // 
            this.generarTransaccionToolStripMenuItem.Name = "generarTransaccionToolStripMenuItem";
            this.generarTransaccionToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.generarTransaccionToolStripMenuItem.Text = "Generar transaccion";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // configurarNuevoTipoDeTarjetaToolStripMenuItem
            // 
            this.configurarNuevoTipoDeTarjetaToolStripMenuItem.Name = "configurarNuevoTipoDeTarjetaToolStripMenuItem";
            this.configurarNuevoTipoDeTarjetaToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.configurarNuevoTipoDeTarjetaToolStripMenuItem.Text = "Configurar nuevo tipo de tarjeta";
            // 
            // verTransaccionesPorPeriodoToolStripMenuItem
            // 
            this.verTransaccionesPorPeriodoToolStripMenuItem.Name = "verTransaccionesPorPeriodoToolStripMenuItem";
            this.verTransaccionesPorPeriodoToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.verTransaccionesPorPeriodoToolStripMenuItem.Text = "Ver transacciones por periodo";
            // 
            // verAperturasPorPeriodoToolStripMenuItem
            // 
            this.verAperturasPorPeriodoToolStripMenuItem.Name = "verAperturasPorPeriodoToolStripMenuItem";
            this.verAperturasPorPeriodoToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.verAperturasPorPeriodoToolStripMenuItem.Text = "Ver aperturas por periodo";
            // 
            // cantidadDePuntosAcumuladosToolStripMenuItem
            // 
            this.cantidadDePuntosAcumuladosToolStripMenuItem.Name = "cantidadDePuntosAcumuladosToolStripMenuItem";
            this.cantidadDePuntosAcumuladosToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.cantidadDePuntosAcumuladosToolStripMenuItem.Text = "Cantidad de puntos acumulados";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 417);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Banco Universitario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarjetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ediarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verTodosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteDeTarjetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarTransaccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem configurarNuevoTipoDeTarjetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTransaccionesPorPeriodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAperturasPorPeriodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cantidadDePuntosAcumuladosToolStripMenuItem;
    }
}

