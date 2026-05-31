using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Transmetro.Models;
using System.Linq;

namespace Transmetro.Controllers
{
    public class TransmetroController : Controller
    {
        // BASE DE DATOS - ESTACIONES
        private static List<Estacion> dbEstaciones = new List<Estacion>
        {

            new Estacion { IdEstacion = "EST-01", Nombre = "CENTRA SUR - ZONA 12", CapacidadMaxima = 500, OcupacionActual = 210 },
            new Estacion { IdEstacion = "EST-02", Nombre = "EL TRÉBOL - ZONA 8", CapacidadMaxima = 300, OcupacionActual = 180 },
            new Estacion { IdEstacion = "EST-03", Nombre = "PLAZA BARRIOS - ZONA 1", CapacidadMaxima = 200, OcupacionActual = 85 },
            new Estacion { IdEstacion = "EST-04", Nombre = "USAC PERIFÉRICO - ZONA 12", CapacidadMaxima = 400, OcupacionActual = 350 },
            new Estacion { IdEstacion = "EST-05", Nombre = "CAPUCHINAS", CapacidadMaxima = 150, OcupacionActual = 40 },
            new Estacion { IdEstacion = "EST-06", Nombre = "SAN SEBASTIÁN", CapacidadMaxima = 120, OcupacionActual = 90 }, 
            new Estacion { IdEstacion = "EST-07", Nombre = "FEGUA", CapacidadMaxima = 180, OcupacionActual = 50 },
            new Estacion { IdEstacion = "EST-08", Nombre = "PARQUE COLÓN", CapacidadMaxima = 150, OcupacionActual = 110 },
            new Estacion { IdEstacion = "EST-09", Nombre = "ATLÁNTIDA - ZONA 18", CapacidadMaxima = 250, OcupacionActual = 60 },
            new Estacion { IdEstacion = "EST-10", Nombre = "PLAZA ARGENTINA - ZONA 13", CapacidadMaxima = 150, OcupacionActual = 30 }
        };

        // INICIO - MENÚ PRINCIPAL
        public IActionResult Index()
        {
            ViewBag.TotalEstaciones = dbEstaciones.Count;
            ViewBag.TotalBuses = DataRepository.Buses.Count;

            // CONTAR LÍNEAS CON PILOTOS ASIGNADOS
            var pilotosAsignados = DataRepository.Pilotos
                .Where(p => p.BusAsignado != "Ninguno" && !string.IsNullOrEmpty(p.BusAsignado))
                .Select(p => p.BusAsignado)
                .ToList();

            ViewBag.TotalLineas = DataRepository.Buses
                .Where(b => pilotosAsignados.Contains(b.IdBus) && !string.IsNullOrEmpty(b.LineaAsignada))
                .Select(b => b.LineaAsignada.ToUpper())
                .Distinct()
                .Count();

            return View();
        }

        // VISTA ESTACIONES
        public IActionResult Estaciones()
        {
            return View(dbEstaciones);
        }

        // REGISTRAR ESTACIÓN
        [HttpPost]
        public IActionResult RegistrarEstacion(string nombre, int capacidad, int ocupacion)
        {
            string nuevoId = "EST-0" + (dbEstaciones.Count + 1);
            dbEstaciones.Add(new Estacion
            {
                IdEstacion = nuevoId,
                Nombre = nombre,
                CapacidadMaxima = capacidad,
                OcupacionActual = ocupacion
            });
            return RedirectToAction("Estaciones");
        }

        // VISTA BUSES
        public IActionResult Buses()
        {
            return View(DataRepository.Buses);
        }

        // REGISTRAR BUS
        [HttpPost]
        public IActionResult RegistrarBus(string linea, int capacidad, int ocupacion)
        {
            // GENERAR ID AUTOMÁTICO
            int maxNumber = 0;
            foreach (var bus in DataRepository.Buses)
            {
                if (bus.IdBus.StartsWith("B-") && int.TryParse(bus.IdBus.Substring(2), out int num))
                {
                    if (num > maxNumber)
                        maxNumber = num;
                }
            }
            string nuevoId = "B-" + (maxNumber + 1).ToString("D3");

            DataRepository.Buses.Add(new Bus
            {
                IdBus = nuevoId,
                LineaAsignada = linea,
                CapacidadMaxima = capacidad,
                PasajerosActuales = ocupacion
            });
            return RedirectToAction("Buses");
        }

        // VISTA RUTAS
        public IActionResult Rutas()
        {
            return View(DataRepository.Buses);
        }
    }
}