namespace XCommerce.Servicio.Core._17_Caja.CajaKiosco
{
    partial class _00022_ABM_CajaSalon
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
            this.dtpFechaApertura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMontoApertura = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.nudmontoCierre = new System.Windows.Forms.NumericUpDown();
            this.cmbApertura = new System.Windows.Forms.ComboBox();
            this.cmbCierre = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoApertura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudmontoCierre)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaApertura
            // 
            this.dtpFechaApertura.Enabled = false;
            this.dtpFechaApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaApertura.Location = new System.Drawing.Point(162, 102);
            this.dtpFechaApertura.Name = "dtpFechaApertura";
            this.dtpFechaApertura.Size = new System.Drawing.Size(115, 26);
            this.dtpFechaApertura.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha Apertura :";
            // 
            // nudMontoApertura
            // 
            this.nudMontoApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoApertura.Location = new System.Drawing.Point(162, 156);
            this.nudMontoApertura.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMontoApertura.Name = "nudMontoApertura";
            this.nudMontoApertura.Size = new System.Drawing.Size(120, 26);
            this.nudMontoApertura.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Monto Apertura :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha Cierrre :";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.Enabled = false;
            this.dtpFechaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCierre.Location = new System.Drawing.Point(477, 100);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(120, 26);
            this.dtpFechaCierre.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(349, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Monto Cierre :";
            // 
            // nudmontoCierre
            // 
            this.nudmontoCierre.Enabled = false;
            this.nudmontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudmontoCierre.Location = new System.Drawing.Point(477, 156);
            this.nudmontoCierre.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudmontoCierre.Name = "nudmontoCierre";
            this.nudmontoCierre.Size = new System.Drawing.Size(120, 26);
            this.nudmontoCierre.TabIndex = 15;
            // 
            // cmbApertura
            // 
            this.cmbApertura.FormattingEnabled = true;
            this.cmbApertura.Location = new System.Drawing.Point(626, 63);
            this.cmbApertura.Name = "cmbApertura";
            this.cmbApertura.Size = new System.Drawing.Size(156, 21);
            this.cmbApertura.TabIndex = 16;
            // 
            // cmbCierre
            // 
            this.cmbCierre.FormattingEnabled = true;
            this.cmbCierre.Location = new System.Drawing.Point(635, 188);
            this.cmbCierre.Name = "cmbCierre";
            this.cmbCierre.Size = new System.Drawing.Size(179, 21);
            this.cmbCierre.TabIndex = 17;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(260, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 36);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Cerrar Caja";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // _00022_ABM_CajaSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 204);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cmbCierre);
            this.Controls.Add(this.cmbApertura);
            this.Controls.Add(this.nudmontoCierre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaCierre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMontoApertura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaApertura);
            this.MaximumSize = new System.Drawing.Size(625, 247);
            this.MinimumSize = new System.Drawing.Size(625, 247);
            this.Name = "_00022_ABM_CajaSalon";
            this.Text = "APERTURA / CIERRE DE CAJA";
            this.Load += new System.EventHandler(this._00022_ABM_CajaSalon_Load);
            this.Controls.SetChildIndex(this.dtpFechaApertura, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.nudMontoApertura, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtpFechaCierre, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.nudmontoCierre, 0);
            this.Controls.SetChildIndex(this.cmbApertura, 0);
            this.Controls.SetChildIndex(this.cmbCierre, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoApertura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudmontoCierre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaApertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMontoApertura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudmontoCierre;
        private System.Windows.Forms.ComboBox cmbApertura;
        private System.Windows.Forms.ComboBox cmbCierre;
        private System.Windows.Forms.Button btnSalir;
    }
}