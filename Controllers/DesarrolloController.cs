using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

[Route("desarrollo")]
public class DesarrolloController : PaginaController
{
    private static readonly MigaPan Inicio = new("Inicio", Rutas.Inicio);
    private static readonly MigaPan Seccion = new("Desarrollo y vida laboral", Rutas.Desarrollo);

    [HttpGet("")]
    public IActionResult Index() => Hub(new PaginaHubViewModel
    {
        Titulo = "Desarrollo y vida laboral",
        Intro = "Capacitación, crecimiento profesional y reconocimientos para la comunidad de colaboradores UDLAP.",
        Migas = [Inicio, new("Desarrollo y vida laboral", null)],
        Enlaces =
        [
            PaletaCajas.Enlace("Capacitación", Rutas.Capacitacion, "Cursos, inscripciones y oferta formativa.", 1),
            PaletaCajas.Enlace("Programas académicos", Rutas.Programas, "Apoyos y programas de formación académica.", 0),
            PaletaCajas.Enlace("Desarrollo profesional", Rutas.Profesional, "Herramientas para tu trayectoria laboral.", 2),
            PaletaCajas.Enlace("Perfil del empleado", Rutas.PerfilEmpleado, "El perfil institucional del colaborador UDLAP.", 3),
            PaletaCajas.Enlace("Entrega de PRESEAS", Rutas.Preseas, "Ceremonia de reconocimiento a la trayectoria del personal.", 5),
        ],
    });

    [HttpGet("capacitacion")]
    public IActionResult Capacitacion() => Detalle(Hoja(
        "Capacitación",
        "Consulta la oferta de capacitación y los periodos de inscripción.",
        [Inicio, Seccion, new("Capacitación", null)],
        "Los cursos se publican de acuerdo con el calendario de Desarrollo Organizacional.",
        "Inscríbete dentro de las fechas abiertas y confirma la autorización de tu jefatura cuando se requiera."));

    [HttpGet("programas-academicos")]
    public IActionResult Programas() => Detalle(Hoja(
        "Programas académicos",
        "Información sobre programas de formación académica para el personal.",
        [Inicio, Seccion, new("Programas académicos", null)],
        "Revisa convocatorias, requisitos de permanencia y beneficios asociados.",
        "Cada programa puede tener un calendario y un responsable distinto."));

    [HttpGet("desarrollo-profesional")]
    public IActionResult Profesional() => Detalle(Hoja(
        "Desarrollo profesional",
        "Recursos para fortalecer tu trayectoria dentro de la universidad.",
        [Inicio, Seccion, new("Desarrollo profesional", null)],
        "Esta sección concentrará herramientas de evaluación, crecimiento y movilidad interna.",
        "Platica con tu jefatura sobre planes de desarrollo y oportunidades de participación."));

    [HttpGet("reconocimientos")]
    public IActionResult Preseas() => Detalle(Hoja(
        "Entrega de PRESEAS",
        "La Ceremonia de Entrega de Preseas es el evento a través del cual la UDLAP reconoce la trayectoria del personal administrativo, sindicalizado y de la facultad, así como agradece su labor, el esfuerzo y dedicación, con las cuales contribuyen al desarrollo y fortalecimiento de la institución. Las preseas que se entregan son el reconocimiento a 5, 10, 15, 20, 25, 30, 35 y 40 años de trayectoria, se diferencian una de otra por el material de la que están hechas o la piedra que las adorna.",
        [Inicio, Seccion, new("Entrega de PRESEAS", null)]));

    [HttpGet("perfil-del-empleado")]
    public IActionResult Perfil() => Detalle(Hoja(
        "Perfil del empleado",
        "El empleado UDLAP debe ser profesional, comprometido y capacitado para el desarrollo de sus actividades de manera eficiente y eficaz, respetando a los demás y a sí mismo, manteniendo buenas relaciones interpersonales basadas en los valores de honestidad, integridad, responsabilidad, solidaridad e inclusión; brindando un servicio integral y con calidad que le permita ofrecer excelentes resultados, contribuyendo con todo esto a la formación de profesionistas de calidad mundial.",
        [Inicio, Seccion, new("Perfil del empleado", null)]));

    [HttpGet("informacion-para-empleados")]
    public IActionResult Informacion() => RedirectToAction(nameof(Perfil));
}
