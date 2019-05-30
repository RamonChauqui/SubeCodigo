namespace Presentacion.Core._02_Cliente
{
    partial class _00004_CtaCte_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00004_CtaCte_Cliente));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnTodas = new System.Windows.Forms.ToolStripButton();
            this.btnImpagasS = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.lblSaldar = new System.Windows.Forms.Label();
            this.txtSaldarCtaCte = new System.Windows.Forms.TextBox();
            this.btnSaldarCtaCte = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.Menu.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.SteelBlue;
            this.Menu.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnTodas,
            this.btnImpagasS,
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(796, 52);
            this.Menu.TabIndex = 32;
            this.Menu.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(148, 49);
            this.toolStripLabel1.Text = "Cuentas Corrientes";
            // 
            // btnTodas
            // 
            this.btnTodas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(40, 49);
            this.btnTodas.Text = "Total ";
            this.btnTodas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnImpagasS
            // 
            this.btnImpagasS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImpagasS.Name = "btnImpagasS";
            this.btnImpagasS.Size = new System.Drawing.Size(88, 49);
            this.btnImpagasS.Text = "Impagas Salon";
            this.btnImpagasS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(43, 49);
            this.btnSalir.Text = "Volver";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBusqueda.Controls.Add(this.lblSaldar);
            this.pnlBusqueda.Controls.Add(this.txtSaldarCtaCte);
            this.pnlBusqueda.Controls.Add(this.btnSaldarCtaCte);
            this.pnlBusqueda.Controls.Add(this.lblTotal);
            this.pnlBusqueda.Controls.Add(this.txtTotal);
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 296);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(796, 49);
            this.pnlBusqueda.TabIndex = 34;
            // 
            // lblSaldar
            // 
            this.lblSaldar.AutoSize = true;
            this.lblSaldar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSaldar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldar.Location = new System.Drawing.Point(11, 16);
            this.lblSaldar.Name = "lblSaldar";
            this.lblSaldar.Size = new System.Drawing.Size(66, 20);
            this.lblSaldar.TabIndex = 33;
            this.lblSaldar.Text = "MONTO";
            // 
            // txtSaldarCtaCte
            // 
            this.txtSaldarCtaCte.Enabled = false;
            this.txtSaldarCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldarCtaCte.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtSaldarCtaCte.Location = new System.Drawing.Point(83, 12);
            this.txtSaldarCtaCte.Name = "txtSaldarCtaCte";
            this.txtSaldarCtaCte.Size = new System.Drawing.Size(95, 26);
            this.txtSaldarCtaCte.TabIndex = 32;
            this.txtSaldarCtaCte.Text = "0,00";
            this.txtSaldarCtaCte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSaldarCtaCte
            // 
            this.btnSaldarCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaldarCtaCte.Location = new System.Drawing.Point(184, 12);
            this.btnSaldarCtaCte.Name = "btnSaldarCtaCte";
            this.btnSaldarCtaCte.Size = new System.Drawing.Size(87, 28);
            this.btnSaldarCtaCte.TabIndex = 31;
            this.btnSaldarCtaCte.Text = "Pagar";
            this.btnSaldarCtaCte.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(343, 18);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(64, 31);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(413, 8);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(231, 38);
            this.txtTotal.TabIndex = 0;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(12, 55);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(784, 235);
            this.dgvGrilla.TabIndex = 35;
            // 
            // _00004_CtaCte_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 346);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.Menu);
            this.Name = "_00004_CtaCte_Cliente";
            this.Text = "_00004_CtaCte_Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnTodas;
        private System.Windows.Forms.ToolStripButton btnImpagasS;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Label lblSaldar;
        private System.Windows.Forms.TextBox txtSaldarCtaCte;
        private System.Windows.Forms.Button btnSaldarCtaCte;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvGrilla;
    }
}