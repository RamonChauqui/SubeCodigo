using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Empleado;

namespace Presentacion.Core._01_Empleado
{
    public partial class Empleado_LookUp : FormularioLookUp
    {
        IEmpleadoServicio _empladoServicio;

        public Empleado_LookUp()
            :this(new EmpleadoServicio())
        {
            InitializeComponent();
        }
        public Empleado_LookUp(IEmpleadoServicio empleadoServicio)
        {
            _empladoServicio = empleadoServicio;
        }

        private void Empleado_LookUp_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            var producros = _empladoServicio.Obtener(cadenaBuscar);
            dgvGrilla.DataSource = producros.ToList();
        }
    }
}
