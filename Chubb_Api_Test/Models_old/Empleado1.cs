using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chubb_Api_Test.Models
{
    public class Empleado1
    {
        public int Id { get; set; }

        public byte Fotografia { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int PuestoId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int EstadoId { get; set; }
    }
}
