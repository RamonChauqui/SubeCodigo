using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.FormularioBase
{
    public partial class FormularioLookUp : FormularioBase
    {
        private bool puedeEjecutarComando;
        public object Entidad { get; set; }

        public FormularioLookUp()
        {
            InitializeComponent();
            this.puedeEjecutarComando = false;

        }
        public virtual void ActualizarDatos(string cadenaBuscar)
        {

        }

        private void dgvGrilla_DataSourceChanged(object sender, EventArgs e)
        {
            this.puedeEjecutarComando = this.dgvGrilla.RowCount > 0;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Entidad = this.dgvGrilla.RowCount > 0 ? dgvGrilla.Rows[e.RowIndex].DataBoundItem : null;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(this.txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Entidad = null;
            this.Close();
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (!puedeEjecutarComando) return;
            this.Close();
        }
      
        private void FormularioLookUp_Load_1(object sender, EventArgs e)
        {

            ActualizarDatos(string.Empty);
        }
    }
}
