namespace SAIP_MED.CORE.Models
{
    public class SignosVitales
    {
        public int IdSignosVitales { get; set; }
        public int IdDetalleHistoria { get; set; }
        public double Temperatura { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public int Diastolica { get; set; }
        public int Sistolica { get; set; }
    }
}