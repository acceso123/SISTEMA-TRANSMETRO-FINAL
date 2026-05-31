using System.Collections.Generic;

namespace Transmetro.Models
{
    public static class DataRepository
    {
        // BASE DE DATOS - BUSES
        public static List<Bus> Buses { get; set; } = new List<Bus>
        {
            new Bus { IdBus = "B-001", LineaAsignada = "LÍNEA 12", CapacidadMaxima = 160, PasajerosActuales = 25 },
            new Bus { IdBus = "B-002", LineaAsignada = "LÍNEA 1", CapacidadMaxima = 160, PasajerosActuales = 90 },
            new Bus { IdBus = "B-003", LineaAsignada = "LÍNEA 18", CapacidadMaxima = 80, PasajerosActuales = 15 },
            new Bus { IdBus = "B-004", LineaAsignada = "LÍNEA 6", CapacidadMaxima = 80, PasajerosActuales = 60 },
            new Bus { IdBus = "B-005", LineaAsignada = "LÍNEA 5", CapacidadMaxima = 100, PasajerosActuales = 40 }
        };

        // BASE DE DATOS - PILOTOS
        public static List<Piloto> Pilotos { get; set; } = new List<Piloto>();
    }
}