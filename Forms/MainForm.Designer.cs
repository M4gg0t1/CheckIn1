namespace CheckIn.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnMarcarEntrada;
        private System.Windows.Forms.Button btnMarcarSalida;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnEliminarUsuario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnMarcarEntrada = new System.Windows.Forms.Button();
            this.btnMarcarSalida = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // btnMarcarEntrada
            this.btnMarcarEntrada.Location = new System.Drawing.Point(11, 12);
            this.btnMarcarEntrada.Name = "btnMarcarEntrada";
            this.btnMarcarEntrada.Size = new System.Drawing.Size(150, 30);
            this.btnMarcarEntrada.TabIndex = 0;
            this.btnMarcarEntrada.Text = "Marcar Entrada";
            this.btnMarcarEntrada.UseVisualStyleBackColor = true;
            this.btnMarcarEntrada.Click += new System.EventHandler(this.btnMarcarEntrada_Click);

            // btnMarcarSalida
            this.btnMarcarSalida.Location = new System.Drawing.Point(11, 62);
            this.btnMarcarSalida.Name = "btnMarcarSalida";
            this.btnMarcarSalida.Size = new System.Drawing.Size(150, 30);
            this.btnMarcarSalida.TabIndex = 1;
            this.btnMarcarSalida.Text = "Marcar Salida";
            this.btnMarcarSalida.UseVisualStyleBackColor = true;
            this.btnMarcarSalida.Click += new System.EventHandler(this.btnMarcarSalida_Click);

            // btnGenerarReporte
            this.btnGenerarReporte.Location = new System.Drawing.Point(11, 112);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(150, 30);
            this.btnGenerarReporte.TabIndex = 2;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);

            // btnAgregarUsuario
            this.btnAgregarUsuario.Location = new System.Drawing.Point(11, 162); // Ajusta la posición según sea necesario
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarUsuario.TabIndex = 3;
            this.btnAgregarUsuario.Text = "Agregar Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);

            // btnModificarUsuario
            this.btnModificarUsuario.Location = new System.Drawing.Point(11, 202); // Ajusta la posición según sea necesario
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(150, 30);
            this.btnModificarUsuario.TabIndex = 4;
            this.btnModificarUsuario.Text = "Modificar Usuario";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);

            // btnEliminarUsuario
            this.btnEliminarUsuario.Location = new System.Drawing.Point(11, 242); // Ajusta la posición según sea necesario
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(150, 30);
            this.btnEliminarUsuario.TabIndex = 5;
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(439, 303);
            // Agregar los botones al formulario
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.btnMarcarSalida);
            this.Controls.Add(this.btnMarcarEntrada);
            // Otros componentes y configuraciones...
            this.Name = "MainForm";
            this.ResumeLayout(false);
        }
    }
}