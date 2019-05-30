namespace Presentacion.Core._10_Ventas_Salon
{
    partial class _00019_ComprobanteSalon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecios = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudSubTotoal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIDMozo = new System.Windows.Forms.TextBox();
            this.txtDescripcionMozo = new System.Windows.Forms.TextBox();
            this.btnBuscarMozo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudComensales = new System.Windows.Forms.NumericUpDown();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.controlMesa1 = new Presentacion.Core._10_Ventas_Salon.Contoles.ControlMesa();
            this.btnDescuento = new System.Windows.Forms.Button();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComensales)).BeginInit();
            this.panel22.SuspendLayout();
            this.panel11.SuspendLayout();
            this.pnlLinea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 157);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(767, 284);
            this.dgvGrilla.TabIndex = 0;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(17, 39);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(182, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(205, 39);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(157, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtPrecios
            // 
            this.txtPrecios.Enabled = false;
            this.txtPrecios.Location = new System.Drawing.Point(368, 39);
            this.txtPrecios.Name = "txtPrecios";
            this.txtPrecios.Size = new System.Drawing.Size(115, 20);
            this.txtPrecios.TabIndex = 3;
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Location = new System.Drawing.Point(489, 40);
            this.nudCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(116, 20);
            this.nudCantidad.TabIndex = 4;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Codigo/Codigo barra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Precio Unitario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(486, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cantidad";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(618, 40);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(148, 21);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudSubTotoal
            // 
            this.nudSubTotoal.DecimalPlaces = 2;
            this.nudSubTotoal.Enabled = false;
            this.nudSubTotoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubTotoal.Location = new System.Drawing.Point(633, 452);
            this.nudSubTotoal.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudSubTotoal.Name = "nudSubTotoal";
            this.nudSubTotoal.Size = new System.Drawing.Size(99, 26);
            this.nudSubTotoal.TabIndex = 11;
            this.nudSubTotoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSubTotoal.ValueChanged += new System.EventHandler(this.nudSubTotoal_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(523, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sub-Total :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(486, 492);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Descuento [%] :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(558, 528);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Mozo :";
            // 
            // txtIDMozo
            // 
            this.txtIDMozo.Location = new System.Drawing.Point(84, 37);
            this.txtIDMozo.Name = "txtIDMozo";
            this.txtIDMozo.Size = new System.Drawing.Size(166, 20);
            this.txtIDMozo.TabIndex = 17;
            // 
            // txtDescripcionMozo
            // 
            this.txtDescripcionMozo.Location = new System.Drawing.Point(268, 38);
            this.txtDescripcionMozo.Name = "txtDescripcionMozo";
            this.txtDescripcionMozo.Size = new System.Drawing.Size(317, 20);
            this.txtDescripcionMozo.TabIndex = 22;
            // 
            // btnBuscarMozo
            // 
            this.btnBuscarMozo.Location = new System.Drawing.Point(603, 32);
            this.btnBuscarMozo.Name = "btnBuscarMozo";
            this.btnBuscarMozo.Size = new System.Drawing.Size(68, 29);
            this.btnBuscarMozo.TabIndex = 23;
            this.btnBuscarMozo.Text = "Buscar";
            this.btnBuscarMozo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Cantidad comensales:";
            // 
            // nudComensales
            // 
            this.nudComensales.Enabled = false;
            this.nudComensales.Location = new System.Drawing.Point(166, 11);
            this.nudComensales.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudComensales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudComensales.Name = "nudComensales";
            this.nudComensales.Size = new System.Drawing.Size(71, 20);
            this.nudComensales.TabIndex = 24;
            this.nudComensales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel22.Controls.Add(this.txtIDMozo);
            this.panel22.Controls.Add(this.label11);
            this.panel22.Controls.Add(this.label8);
            this.panel22.Controls.Add(this.txtDescripcionMozo);
            this.panel22.Controls.Add(this.nudComensales);
            this.panel22.Controls.Add(this.btnBuscarMozo);
            this.panel22.Location = new System.Drawing.Point(1, 78);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(769, 73);
            this.panel22.TabIndex = 26;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel11.Controls.Add(this.txtCodigo);
            this.panel11.Controls.Add(this.txtDescripcion);
            this.panel11.Controls.Add(this.txtPrecios);
            this.panel11.Controls.Add(this.nudCantidad);
            this.panel11.Controls.Add(this.btnAgregar);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.label4);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(769, 75);
            this.panel11.TabIndex = 27;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlLinea.Controls.Add(this.controlMesa1);
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinea.Location = new System.Drawing.Point(0, 75);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(769, 3);
            this.pnlLinea.TabIndex = 28;
            // 
            // controlMesa1
            // 
            this.controlMesa1.BackColor = System.Drawing.Color.Red;
            this.controlMesa1.Location = new System.Drawing.Point(0, 0);
            this.controlMesa1.Name = "controlMesa1";
            this.controlMesa1.Size = new System.Drawing.Size(107, 89);
            this.controlMesa1.TabIndex = 0;
            // 
            // btnDescuento
            // 
            this.btnDescuento.Location = new System.Drawing.Point(333, 484);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(98, 35);
            this.btnDescuento.TabIndex = 29;
            this.btnDescuento.Text = "Activar descuento";
            this.btnDescuento.UseVisualStyleBackColor = true;
            this.btnDescuento.Click += new System.EventHandler(this.btnDescuento_Click);
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Location = new System.Drawing.Point(633, 484);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(99, 26);
            this.nudDescuento.TabIndex = 30;
            this.nudDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Enabled = false;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(633, 520);
            this.nudTotal.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(99, 26);
            this.nudTotal.TabIndex = 31;
            this.nudTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _00019_ComprobanteSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(769, 553);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.btnDescuento);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel22);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudSubTotoal);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "_00019_ComprobanteSalon";
            this.Text = "Venta en salon";
            this.Load += new System.EventHandler(this._00019_ComprobanteSalon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComensales)).EndInit();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnlLinea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecios;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudSubTotoal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIDMozo;
        private System.Windows.Forms.TextBox txtDescripcionMozo;
        private System.Windows.Forms.Button btnBuscarMozo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudComensales;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel pnlLinea;
        private Contoles.ControlMesa controlMesa1;
        private System.Windows.Forms.Button btnDescuento;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.NumericUpDown nudTotal;
    }
}