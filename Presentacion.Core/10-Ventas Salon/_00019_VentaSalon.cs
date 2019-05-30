using Presentacion.Core._10_Ventas_Salon.Contoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Mesas;
using XCommerce.Servicio.Core.Sala;

namespace Presentacion.Core._10_Ventas
{
    public partial class Venta : Presentacion.FormularioBase.FormularioBase
    {
        /*========TRAEMOS LOS SALONES=======*/
        private readonly ISalaServicio _salonServicio;
        /*========TRAEMOS LOS SALONES=======*/

        ///*============PARA CREAR LAS MESAS =============*/
        private readonly IMesaServicio _mesaServicio;
        ///*============PARA CREAR LAS MESAS =============*/


        public Venta()
            : this(new SalaServicio(), new MesaServicio())
        {
            InitializeComponent();

        }

        public Venta(ISalaServicio salaServicio, IMesaServicio mesaServicio)
        {

            _salonServicio = salaServicio;
            _mesaServicio = mesaServicio;

            crearControles();
        }

       
        private void crearControles()
        {
            var contenedorSalones = new TabControl
            {
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 57),
                Name = "controlSalones",
                SelectedIndex = 0,
                Size = new System.Drawing.Size(1172, 508),
                TabIndex = 6
            };


            var Salones = _salonServicio.ObtenerCAdena(string.Empty);

            foreach (var salon in Salones
                .Where(x => !x.EstaEliminado))
            {


                var flow = new FlowLayoutPanel
                {

                    Name = $"flow {salon.Id}",
                    Dock = DockStyle.Fill,
                    Location = new Point(3, 3),
                    Size = new Size(848, 351),
                    TabIndex = 0


                };

                foreach (var mesa in _mesaServicio.obtenerPorSala(salon.Id)
                    .Where(x => !x.EstaEliminado))
                {
           

                    var control = new ControlMesa()
                    {


                        MesaID = mesa.Id,
                        Name = $"Mesa {mesa.Id}",
                        NumeroMesa = mesa.Numero,
                        PrecioConsumido = mesa.Total,
                        EsatdoDeMEsa = mesa.EstadoMesa


                    };

                    flow.Controls.Add(control);

                }

                var salonPage = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = $"Page{salon.Id}",
                    Padding = new System.Windows.Forms.Padding(3),
                    Size = new System.Drawing.Size(1164, 482),
                    TabIndex = 0,
                    Text = salon.Descripcion,
                    UseVisualStyleBackColor = true

                };

                salonPage.Controls.Add(flow);

                contenedorSalones.Controls.Add(salonPage);
            }

            this.Controls.Add(contenedorSalones);
            contenedorSalones.ResumeLayout(false);


        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}

