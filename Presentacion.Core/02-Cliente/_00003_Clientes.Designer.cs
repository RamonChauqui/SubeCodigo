namespace Presentacion.Core.Cliente
{
    partial class _00003_Clientes
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
            this.btnCtaCte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCtaCte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCtaCte.ForeColor = System.Drawing.Color.White;
            this.btnCtaCte.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCtaCte.Location = new System.Drawing.Point(273, 2);
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.Size = new System.Drawing.Size(65, 52);
            this.btnCtaCte.TabIndex = 10;
            this.btnCtaCte.Text = "Cuentas Corrientes";
            this.btnCtaCte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCtaCte.UseVisualStyleBackColor = false;
            this.btnCtaCte.Click += new System.EventHandler(this.btnCtaCte_Click);
            // 
            // _00003_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.btnCtaCte);
            this.Name = "_00003_Clientes";
            this.Text = "Clientes";
            this.Controls.SetChildIndex(this.btnCtaCte, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCtaCte;
    }
}