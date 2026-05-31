using Microsoft.AspNetCore.Mvc;
using Transmetro.Models;
using System.Linq;
using System.Collections.Generic;

namespace Transmetro.Controllers
{
    public class BusesController : Controller
    {
        public IActionResult Index()
        {
            var busesOcupados = DataRepository.Pilotos
                .Where(p => p.BusAsignado != "Ninguno" && !string.IsNullOrEmpty(p.BusAsignado))
                .Select(p => p.BusAsignado)
                .ToList();

            var busesLibres = new List<string>();
            foreach (var bus in DataRepository.Buses)
            {
                if (!busesOcupados.Contains(bus.IdBus))
                {
                    busesLibres.Add(bus.IdBus);
                }
            }

            ViewBag.BusesDisponibles = busesLibres;
            ViewBag.PilotosDisponibles = DataRepository.Pilotos.Where(p => p.Disponible).ToList();

            return View("AsignarPiloto");
        }

        [HttpPost]
        public IActionResult GuardarAsignacion(string busId, string pilotoId)
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