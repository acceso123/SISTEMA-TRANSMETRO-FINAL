using Microsoft.AspNetCore.Mvc;
using Transmetro.Models;
using System.Linq;
using System.Collections.Generic;

namespace Transmetro.Controllers
{
    public class PilotosController : Controller
    {
        public IActionResult Index()
        {
            // OBTENER PILOTOS DISPONIBLES
            ViewBag.PilotosDisponibles = DataRepository.Pilotos.Where(p => p.Disponible).ToList();

            // OBTENER BUSES OCUPADOS
            var busesOcupados = DataRepository.Pilotos
                .Where(p => p.BusAsignado != "Ninguno" && !string.IsNullOrEmpty(p.BusAsignado))
                .Select(p => p.BusAsignado)
                .ToList();

            // OBTENER BUSES LIBRES
            var busesLibres = new List<string>();

            // FILTRAR BUSES NO OCUPADOS
            foreach (var bus in DataRepository.Buses)
            {
                if (!busesOcupados.Contains(bus.IdBus))
                {
                    busesLibres.Add(bus.IdBus);
                }
            }
            ViewBag.BusesDisponibles = busesLibres;

            return View(DataRepository.Pilotos);
        }

        [HttpPost]
        public IActionResult Registrar(string Nombre, string Telefono, string HistorialEducativo)
        {
            DataRepository.Pilotos.Add(new Piloto
            {
                Id = "PIL-" + (DataRepository.Pilotos.Count + 1).ToString("D3"),
                Nombre = Nombre,
                Telefono = Telefono,
                HistorialEducativo = HistorialEducativo,
                Disponible = true,
                BusAsignado = "Ninguno"
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Asignar(string busId, string pilotoId)
        {
            var piloto = DataRepository.Pilotos.FirstOrDefault(p => p.Id == pilotoId);
            if (piloto != null)
            {
                piloto.Disponible = false;
                piloto.BusAsignado = busId;
            }
            return RedirectToAction("Index");
        }
    }
}