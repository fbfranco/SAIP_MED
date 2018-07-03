using System;
using System.Collections.Generic;

namespace SAIP_MED.CORE.Models
{
    public class Historia
    {
        public string IdHistoria { get; set; }
        public int Correlativo { get; set; }
        public int IdPaciente { get; set; }
        public int Estado { get; set; }
        public ICollection<DetalleHistoria> Detalles { get; set; }
    }
}
