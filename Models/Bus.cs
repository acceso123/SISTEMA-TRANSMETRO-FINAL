namespace Transmetro.Models
{
    public class Bus
    {
        public string? IdBus { get; set; }
        public string? LineaAsignada { get; set; }
        public int CapacidadMaxima { get; set; }
        public int PasajerosActuales { get; set; }

        public double PorcentajeOcupacion
        {
            get { return ((double)PasajerosActuales / CapacidadMaxima) * 100; }
        }

        public bool RequiereEspera
        {
            get { return PorcentajeOcupacion < 25; }
        }
    }
}