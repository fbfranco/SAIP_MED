using SAIP_MED.CORE.Shared;

namespace SAIP_MED.CORE.Models
{
    public class Contacto: Persona
    {
        public int IdContacto { get; set; } 
        public string Relacion { get; set; }
        public int IdPaciente { get; set; }
    }
}