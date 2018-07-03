using System.Collections.Generic;
using SAIP_MED.CORE.Shared;

namespace SAIP_MED.CORE.Models
{
    public class Paciente: Persona
    {
        public int IdPaciente { get; set; }
        public int? IdSeguro { get; set; }
        public string IdHistoria { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int Estado { get; set; }
        public Seguro Seguro { get; set; }
        public Historia Historia { get; set; }  
        public ICollection<Contacto> Contactos { get; set; }
    }
}