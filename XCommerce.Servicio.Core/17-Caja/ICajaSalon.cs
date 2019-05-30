using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._17_Caja
{
    public interface ICajaSalon
    {

        long Insertar(DtoCajaSAlon dto);

        void AgregarMonto(decimal total, long cajaId);

        DtoCajaSAlon ObtenerComprobantePorEstado(EstadoCaja estado);

        void CerrarCaja(long cajaId);
    }
}
