using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TRANSMETRO.Models;
using System.Linq;

namespace TuProyectoAca.Controllers
{
    public class TransmetroController : Controller
    {
        // DATOS EN MEMORIA
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

        private static List<Bus> dbBuses = new List<Bus>
        {
            new Bus { IdBus = "B-001", LineaAsignada = "LÍNEA 12", CapacidadMaxima = 160, PasajerosActuales = 25 },
            new Bus { IdBus = "B-002", LineaAsignada = "LÍNEA 1", CapacidadMaxima = 160, PasajerosActuales = 90 },
            new Bus { IdBus = "B-003", LineaAsignada = "LÍNEA 18", CapacidadMaxima = 80, PasajerosActuales = 15 },
            new Bus { IdBus = "B-004", LineaAsignada = "LÍNEA 6", CapacidadMaxima = 80, PasajerosActuales = 60 }
        };

        // VISTA MENÚ PRINCIPAL
        public IActionResult Index()
        {
            ViewBag.TotalEstaciones = dbEstaciones.Count;
            ViewBag.TotalBuses = dbBuses.Count;
            ViewBag.TotalLineas = dbBuses.Select(b => b.LineaAsignada.ToUpper()).Distinct().Count();

            return View();
        }

        // VISTA ESTACIONES
        public IActionResult Estaciones()
        {
            return View(dbEstaciones);
        }

        // REGISTRAR NUEVA ESTACIÓN
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
            return View(dbBuses);
        }

        // REGISTRAR NUEVO BUS
        [HttpPost]
        public IActionResult RegistrarBus(string linea, int capacidad, int ocupacion)
        {
            string nuevoId = "TM-00" + (dbBuses.Count + 1);
            dbBuses.Add(new Bus
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
            return View(dbBuses);
        }
    }
}