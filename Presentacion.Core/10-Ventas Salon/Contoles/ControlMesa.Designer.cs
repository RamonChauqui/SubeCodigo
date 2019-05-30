namespace Presentacion.Core._10_Ventas_Salon.Contoles
{
    partial class ControlMesa
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblNumeroMesa = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAbrirMesa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrarMesa = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrecioConsumido = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.menuReservarMesa = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumeroMesa
            // 
            this.lblNumeroMesa.ContextMenuStrip = this.menu;
            this.lblNumeroMesa.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumeroMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroMesa.ForeColor = System.Drawing.Color.White;
            this.lblNumeroMesa.Location = new System.Drawing.Point(0, 0);
            this.lblNumeroMesa.Name = "lblNumeroMesa";
            this.lblNumeroMesa.Size = new System.Drawing.Size(153, 38);
            this.lblNumeroMesa.TabIndex = 0;
            this.lblNumeroMesa.Text = "0";
            this.lblNumeroMesa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNumeroMesa.DoubleClick += new System.EventHandler(this.lblPrecioConsumido_DoubleClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbrirMesa,
            this.menuCerrarMesa,
            this.menuReservarMesa});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(153, 92);
            // 
            // menuAbrirMesa
            // 
            this.menuAbrirMesa.Name = "menuAbrirMesa";
            this.menuAbrirMesa.Size = new System.Drawing.Size(149, 22);
            this.menuAbrirMesa.Text = "Abrir Mesa";
            this.menuAbrirMesa.Click += new System.EventHandler(this.menuAbrirMesa_Click);
            // 
            // menuCerrarMesa
            // 
            this.menuCerrarMesa.Name = "menuCerrarMesa";
            this.menuCerrarMesa.Size = new System.Drawing.Size(149, 22);
            this.menuCerrarMesa.Text = "Cerrar Mesa";
            this.menuCerrarMesa.Click += new System.EventHandler(this.menuCerrarMesa_Click);
            // 
            // lblPrecioConsumido
            // 
            this.lblPrecioConsumido.ContextMenuStrip = this.menu;
            this.lblPrecioConsumido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPrecioConsumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioConsumido.ForeColor = System.Drawing.Color.White;
            this.lblPrecioConsumido.Location = new System.Drawing.Point(0, 79);
            this.lblPrecioConsumido.Name = "lblPrecioConsumido";
            this.lblPrecioConsumido.Size = new System.Drawing.Size(153, 31);
            this.lblPrecioConsumido.TabIndex = 1;
            this.lblPrecioConsumido.Text = "0";
            this.lblPrecioConsumido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPrecioConsumido.DoubleClick += new System.EventHandler(this.lblPrecioConsumido_DoubleClick);
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinea.Location = new System.Drawing.Point(0, 38);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(153, 3);
            this.pnlLinea.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 3);
            this.panel1.TabIndex = 7;
            // 
            // lblEstado
            // 
            this.lblEstado.ContextMenuStrip = this.menu;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(0, 41);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(153, 35);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "0";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblEstado.DoubleClick += new System.EventHandler(this.lblPrecioConsumido_DoubleClick);
            // 
            // menuReservarMesa
            // 
            this.menuReservarMesa.Name = "menuReservarMesa";
            this.menuReservarMesa.Size = new System.Drawing.Size(152, 22);
            this.menuReservarMesa.Text = "Reservar Mesa";
            this.menuReservarMesa.Click += new System.EventHandler(this.menuReservarMesa_Click);
            // 
            // ControlMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.lblPrecioConsumido);
            this.Controls.Add(this.lblNumeroMesa);
            this.Name = "ControlMesa";
            this.Size = new System.Drawing.Size(153, 110);
            this.DoubleClick += new System.EventHandler(this.menuAbrirMesa_Click);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroMesa;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuAbrirMesa;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarMesa;
        public System.Windows.Forms.Label lblPrecioConsumido;
        private System.Windows.Forms.ToolStripMenuItem menuReservarMesa;
    }
}
