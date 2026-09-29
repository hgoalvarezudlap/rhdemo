using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

[Route("recursos")]
public class RecursosController : PaginaController
{
    private static readonly MigaPan Inicio = new("Inicio", Rutas.Inicio);
    private static readonly MigaPan Seccion = new("Recursos", Rutas.Recursos);

    [HttpGet("")]
    public IActionResult Index() => Hub(new PaginaHubViewModel
    {
        Titulo = "Recursos",
        Intro = "Formatos, calendarios, guías, políticas y sistemas de apoyo para el trabajo cotidiano.",
        Migas = [Inicio, new("Recursos", null)],
        Enlaces =
        [
            PaletaCajas.Enlace("Formatos", Rutas.Formatos, "Plantillas y formatos oficiales.", 0),
            PaletaCajas.Enlace("Calendarios", Rutas.Calendarios, "Calendarios de RH y de la universidad.", 1),
            PaletaCajas.Enlace("Guías y manuales", Rutas.Guias, "Instructivos de procesos y sistemas.", 2),
            PaletaCajas.Enlace("Políticas y lineamientos", Rutas.Politicas, "Normativa interna de personal.", 3),
            PaletaCajas.Enlace("Sistemas de Recursos Humanos", Rutas.Sistemas, "Acceso a plataformas institucionales.", 4),
        ],
    });

    [HttpGet("formatos")]
    public IActionResult Formatos() => Detalle(Hoja(
        "Formatos",
        "Descarga los formatos oficiales para trámites de personal.",
        [Inicio, Seccion, new("Formatos", null)],
        "Utiliza siempre la versión vigente publicada en esta sección.",
        "Si un formato no aparece, solicita orientación en la Ventanilla Única."));

    [HttpGet("calendarios")]
    public IActionResult Calendarios() => Detalle(Hoja(
        "Calendarios",
        "Consulta calendarios de nómina, vacaciones, capacitación y otros cierres.",
        [Inicio, Seccion, new("Calendarios", null)],
        "Las fechas publicadas son la referencia oficial para capturas y entregas.",
        "También puedes revisar el resumen de fechas importantes desde el inicio."));

    [HttpGet("guias-y-manuales")]
    public IActionResult Guias() => Detalle(Hoja(
        "Guías y manuales",
        "Instructivos para procesos, sistemas y servicios de Recursos Humanos.",
        [Inicio, Seccion, new("Guías y manuales", null)],
        "Las guías se irán publicando por proceso para facilitar el autoservicio.",
        "Si un procedimiento cambió, verifica que estés consultando la versión más reciente."));

    [HttpGet("politicas")]
    public IActionResult Politicas() => Detalle(Hoja(
        "Políticas y lineamientos",
        "Normativa interna que regula la relación laboral en la UDLAP.",
        [Inicio, Seccion, new("Políticas y lineamientos", null)],
        "Consulta políticas de personal, prestaciones, conducta y operación de trámites.",
        "Ante cualquier duda de interpretación, acude a Recursos Humanos."));

    [HttpGet("sistemas")]
    public IActionResult Sistemas() => Detalle(Hoja(
        "Sistemas de Recursos Humanos",
        "Accede a las plataformas institucionales relacionadas con personal.",
        [Inicio, Seccion, new("Sistemas de Recursos Humanos", null)],
        "Desde aquí se concentrarán los accesos a nómina, vacaciones, expediente y otros sistemas.",
        "Usa tus credenciales institucionales. Si no puedes entrar, reporta el incidente a los canales de soporte."));
}
