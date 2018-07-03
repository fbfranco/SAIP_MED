using SAIP_MED.CORE.Shared;

namespace SAIP_MED.CORE.Models
{
    public class Medico: Persona
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public int Estado { get; set; }

        public Especialidad Especialidad { get; set; }
    }
}