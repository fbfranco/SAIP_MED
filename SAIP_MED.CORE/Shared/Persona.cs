using SAIP_MED.CORE.Models;

namespace SAIP_MED.CORE.Shared
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int? IdDocumento { get; set; }
        public string NroDocumento { get; set; }

        public Documento Documento { get; set; }
    }
}