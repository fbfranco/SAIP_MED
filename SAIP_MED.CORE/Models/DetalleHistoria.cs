using System;

namespace SAIP_MED.CORE.Models
{
    public class DetalleHistoria
    {
        public int IdDetalleHistoria { get; set; }
        public string IdHistoria { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string MotivoConsulta { get; set; }
        public int? IdCentroRef { get; set; }
        public int? IdSignosVitales { get; set; }
        public CentroRef Centro { get; set; }
        public SignosVitales Signos { get; set; }
    }
}