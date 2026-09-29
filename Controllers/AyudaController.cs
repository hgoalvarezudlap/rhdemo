using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

[Route("ayuda")]
public class AyudaController : PaginaController
{
    private static readonly MigaPan Inicio = new("Inicio", Rutas.Inicio);
    private static readonly MigaPan Seccion = new("Ayuda y contacto", Rutas.Ayuda);

    [HttpGet("")]
    public IActionResult Index() => RedirectToAction(nameof(Contacto));

    [HttpGet("con-quien-me-comunico")]
    public IActionResult ConQuien() => Detalle(Hoja(
        "¿Con quién me comunico?",
        "Identifica el área correcta según el tipo de solicitud.",
        [Inicio, Seccion, new("¿Con quién me comunico?", null)],
        "Nómina, vacaciones, contratación y capacitación pueden tener interlocutores distintos.",
        "Si no estás seguro, inicia en la Ventanilla Única o escribe a recursos.humanos@udlap.mx."));

    [HttpGet("preguntas-frecuentes")]
    public IActionResult Faq() => Detalle(Hoja(
        "Preguntas frecuentes",
        "Respuestas breves a las consultas más comunes del personal.",
        [Inicio, Seccion, new("Preguntas frecuentes", null)],
        "Esta sección se irá alimentando con dudas reales de trámites, prestaciones y sistemas.",
        "Si no encuentras tu pregunta, utiliza el directorio o acude a la Ventanilla Única."));

    [HttpGet("contacto")]
    public IActionResult Contacto() => View("Directorio", new DirectorioViewModel
    {
        Encabezado = new EncabezadoPagina
        {
            Titulo = "Contacto",
            Intro = "Encuentra a la persona o el área de Recursos Humanos con quien debes comunicarte. El conmutador es (222) 229 2000.",
            Migas = [Inicio, new("Ayuda y contacto", null)],
        },
        Areas = DirectorioRh.Areas,
    });

    [HttpGet("directorio")]
    public IActionResult Directorio() => RedirectToAction(nameof(Contacto));

    [HttpGet("ventanilla-unica")]
    public IActionResult Ventanilla() => Detalle(Hoja(
        "Ventanilla Única",
        "Atención presencial para trámites de personal.",
        [Inicio, Seccion, new("Ventanilla Única", null)],
        "La Ventanilla Única concentra la recepción de documentos y la orientación de primer contacto.",
        "Lleva una identificación institucional y, si aplica, los formatos vigentes."));

    [HttpGet("ubicacion")]
    public IActionResult Ubicacion() => Detalle(Hoja(
        "Ubicación",
        "Recursos Humanos se encuentra en el Edificio 19, Ventanilla Única de Trámites.",
        [Inicio, Seccion, new("Ubicación", null)],
        "Universidad de las Américas Puebla, Ex Hacienda Santa Catarina Mártir, San Andrés Cholula.",
        "Si vienes por primera vez, pregunta en caseta o recepción por la Ventanilla Única de Trámites."));

    [HttpGet("horarios")]
    public IActionResult Horarios() => Detalle(Hoja(
        "Horarios",
        "Horario de atención de la Ventanilla Única de Trámites.",
        [Inicio, Seccion, new("Horarios", null)],
        "Lunes a viernes, de 8:30 a 12:30 y de 15:00 a 16:30 horas.",
        "Los sistemas en línea pueden permanecer disponibles fuera de este horario, sujetos a ventanas de nómina o captura."));
}
