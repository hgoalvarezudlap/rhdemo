using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

public abstract class PaginaController : Controller
{
    protected IActionResult Hub(PaginaHubViewModel modelo) =>
        View("~/Views/Shared/Hub.cshtml", modelo);

    protected IActionResult Detalle(PaginaDetalleViewModel modelo) =>
        View("~/Views/Shared/Detalle.cshtml", modelo);

    protected static PaginaDetalleViewModel Hoja(string titulo, string intro, IReadOnlyList<MigaPan> migas, params string[] parrafos) =>
        new()
        {
            Titulo = titulo,
            Intro = intro,
            Migas = migas,
            Parrafos = parrafos,
        };
}
