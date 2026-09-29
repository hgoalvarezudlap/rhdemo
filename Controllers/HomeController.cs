using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/buscar")]
    public IActionResult Buscar(string? q)
    {
        var consulta = q?.Trim() ?? "";
        var resultados = CatalogoBusqueda.Buscar(consulta);
        var intro = consulta.Length == 0
            ? "Escribe un término para encontrar trámites, prestaciones, páginas o personas de Recursos Humanos."
            : resultados.Count == 0
                ? $"No hay coincidencias para «{consulta}»."
                : resultados.Count == 1
                    ? $"1 resultado para «{consulta}»."
                    : $"{resultados.Count} resultados para «{consulta}».";

        return View(new BusquedaViewModel
        {
            Encabezado = new EncabezadoPagina
            {
                Titulo = "Buscar",
                Intro = intro,
                Migas = [new("Inicio", Rutas.Inicio), new("Buscar", null)],
            },
            Consulta = consulta,
            Resultados = resultados,
        });
    }

    [HttpGet("/buscar/indice")]
    public IActionResult Indice() => Json(CatalogoBusqueda.Entradas);

    [HttpGet("/avisos")]
    public IActionResult Avisos()
    {
        return View();
    }

    [HttpGet("/fechas")]
    public IActionResult Fechas()
    {
        return View();
    }

    [HttpGet("/accesos")]
    public IActionResult Accesos()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
