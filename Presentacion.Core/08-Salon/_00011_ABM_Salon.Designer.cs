namespace Presentacion.Core._8_Salon
{
    partial class _00011_ABM_Salon
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
            this.txtDescrpcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CMBListaPrecio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescrpcion
            // 
            this.txtDescrpcion.Location = new System.Drawing.Point(116, 78);
            this.txtDescrpcion.Name = "txtDescrpcion";
            this.txtDescrpcion.Size = new System.Drawing.Size(195, 20);
            this.txtDescrpcion.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DESCRIPCIÓN:";
            // 
            // CMBListaPrecio
            // 
            this.CMBListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBListaPrecio.FormattingEnabled = true;
            this.CMBListaPrecio.Location = new System.Drawing.Point(116, 148);
            this.CMBListaPrecio.Name = "CMBListaPrecio";
            this.CMBListaPrecio.Size = new System.Drawing.Size(195, 21);
            this.CMBListaPrecio.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lista Precios :";
            // 
            // _00011_ABM_Salon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CMBListaPrecio);
            this.Controls.Add(this.txtDescrpcion);
            this.Controls.Add(this.label1);
            this.Name = "_00011_ABM_Salon";
            this.Text = "ABM Salon";
            this.Load += new System.EventHandler(this._00011_ABM_Salon_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDescrpcion, 0);
            this.Controls.SetChildIndex(this.CMBListaPrecio, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescrpcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBListaPrecio;
        private System.Windows.Forms.Label label2;
    }
}