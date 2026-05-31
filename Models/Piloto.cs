namespace Transmetro.Models
{
    public class Piloto
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string HistorialEducativo { get; set; } = string.Empty;
        public bool Disponible { get; set; } = true;
        public string BusAsignado { get; set; } = "Ninguno";
    }
}