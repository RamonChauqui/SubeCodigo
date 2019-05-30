namespace Presentacion.Core._21_ListaPrecioProducto
{
    partial class _00021_ABM_ListaPrecioProducto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmdLista = new System.Windows.Forms.ComboBox();
            this.nudPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.nudPrecioPublico = new System.Windows.Forms.NumericUpDown();
            this.dtpActivarHOraventa = new System.Windows.Forms.DateTimePicker();
            this.chActivarHoraVenta = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPublico)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lista";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio Costo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha Actulizacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio Publico";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(129, 207);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(131, 20);
            this.dtpFecha.TabIndex = 16;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(128, 104);
            this.cmbProducto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(130, 21);
            this.cmbProducto.TabIndex = 14;
            // 
            // cmdLista
            // 
            this.cmdLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdLista.FormattingEnabled = true;
            this.cmdLista.Location = new System.Drawing.Point(128, 70);
            this.cmdLista.Margin = new System.Windows.Forms.Padding(2);
            this.cmdLista.Name = "cmdLista";
            this.cmdLista.Size = new System.Drawing.Size(131, 21);
            this.cmdLista.TabIndex = 15;
            // 
            // nudPrecioCosto
            // 
            this.nudPrecioCosto.Location = new System.Drawing.Point(127, 134);
            this.nudPrecioCosto.Margin = new System.Windows.Forms.Padding(2);
            this.nudPrecioCosto.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrecioCosto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecioCosto.Name = "nudPrecioCosto";
            this.nudPrecioCosto.Size = new System.Drawing.Size(129, 20);
            this.nudPrecioCosto.TabIndex = 13;
            this.nudPrecioCosto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPrecioPublico
            // 
            this.nudPrecioPublico.Location = new System.Drawing.Point(128, 168);
            this.nudPrecioPublico.Margin = new System.Windows.Forms.Padding(2);
            this.nudPrecioPublico.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrecioPublico.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecioPublico.Name = "nudPrecioPublico";
            this.nudPrecioPublico.Size = new System.Drawing.Size(129, 20);
            this.nudPrecioPublico.TabIndex = 19;
            this.nudPrecioPublico.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpActivarHOraventa
            // 
            this.dtpActivarHOraventa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActivarHOraventa.Location = new System.Drawing.Point(129, 300);
            this.dtpActivarHOraventa.Margin = new System.Windows.Forms.Padding(2);
            this.dtpActivarHOraventa.Name = "dtpActivarHOraventa";
            this.dtpActivarHOraventa.Size = new System.Drawing.Size(130, 20);
            this.dtpActivarHOraventa.TabIndex = 20;
            // 
            // chActivarHoraVenta
            // 
            this.chActivarHoraVenta.AutoSize = true;
            this.chActivarHoraVenta.Location = new System.Drawing.Point(282, 307);
            this.chActivarHoraVenta.Name = "chActivarHoraVenta";
            this.chActivarHoraVenta.Size = new System.Drawing.Size(115, 17);
            this.chActivarHoraVenta.TabIndex = 21;
            this.chActivarHoraVenta.Text = "Activar Hora venta";
            this.chActivarHoraVenta.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 307);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Hora Venta :";
            // 
            // _00021_ABM_ListaPrecioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 257);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chActivarHoraVenta);
            this.Controls.Add(this.dtpActivarHOraventa);
            this.Controls.Add(this.nudPrecioPublico);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.cmdLista);
            this.Controls.Add(this.nudPrecioCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(431, 300);
            this.MinimumSize = new System.Drawing.Size(431, 300);
            this.Name = "_00021_ABM_ListaPrecioProducto";
            this.Text = "ABM ListaPrecio Producto";
            this.Load += new System.EventHandler(this._00021_ABM_ListaPrecioProducto_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.nudPrecioCosto, 0);
            this.Controls.SetChildIndex(this.cmdLista, 0);
            this.Controls.SetChildIndex(this.cmbProducto, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.nudPrecioPublico, 0);
            this.Controls.SetChildIndex(this.dtpActivarHOraventa, 0);
            this.Controls.SetChildIndex(this.chActivarHoraVenta, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPublico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmdLista;
        private System.Windows.Forms.NumericUpDown nudPrecioCosto;
        private System.Windows.Forms.NumericUpDown nudPrecioPublico;
        private System.Windows.Forms.DateTimePicker dtpActivarHOraventa;
        private System.Windows.Forms.CheckBox chActivarHoraVenta;
        private System.Windows.Forms.Label label4;
    }
}