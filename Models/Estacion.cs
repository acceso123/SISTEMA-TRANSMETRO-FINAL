namespace Transmetro.Models
{
    public class Estacion
    {
        public string? IdEstacion { get; set; }
        public string? Nombre { get; set; }
        public int CapacidadMaxima { get; set; }
        public int OcupacionActual { get; set; }

        public double PorcentajeOcupacion
        {
            get { return ((double)OcupacionActual / CapacidadMaxima) * 100; }
        }

        public bool RequiereAlerta
        {
            get { return PorcentajeOcupacion > 50; }
        }
    }
}