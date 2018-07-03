using SAIP_MED.CORE.Shared;

namespace SAIP_MED.CORE.Models
{
    public class Empleado: Persona
    {
        public int IdEmpleado { get; set; } 
        public string Cargo { get; set; }
        public int Estado { get; set; }
    }
}