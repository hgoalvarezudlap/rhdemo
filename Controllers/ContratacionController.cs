using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

[Route("contratacion")]
public class ContratacionController : PaginaController
{
    private static readonly MigaPan Inicio = new("Inicio", Rutas.Inicio);
    private static readonly MigaPan Seccion = new("Contratación y movimientos", Rutas.Contratacion);

    [HttpGet("")]
    public IActionResult Index() => Hub(new PaginaHubViewModel
    {
        Titulo = "Contratación y movimientos",
        Intro = "Procesos de ingreso, contratación y asignación de cursos para personal y programas académicos.",
        Migas = [Inicio, new("Contratación y movimientos", null)],
        Grupos =
        [
            new GrupoEnlaces
            {
                Titulo = "Contratación",
                Enlaces =
                [
                    PaletaCajas.Enlace("Personal administrativo", Rutas.Admvo, "Ingreso y movimientos de personal administrativo.", 0),
                    PaletaCajas.Enlace("Profesores de tiempo parcial", Rutas.Ptp, "Contratación de profesorado de tiempo parcial.", 1),
                    PaletaCajas.Enlace("Profesores de tiempo completo", Rutas.Ptc, "Contratación de profesorado de tiempo completo.", 2),
                    PaletaCajas.Enlace("Procesos especiales", Rutas.Especiales, "Contrataciones con lineamientos particulares.", 3),
                ],
            },
            new GrupoEnlaces
            {
                Titulo = "Asignación de cursos",
                Enlaces =
                [
                    PaletaCajas.Enlace("Personal académico", Rutas.CursosAcademico, "Asignación de carga académica.", 4),
                    PaletaCajas.Enlace("Personal administrativo", Rutas.CursosAdmvo, "Asignación de cursos al personal administrativo.", 5),
                    PaletaCajas.Enlace("Estudiantes de doctorado", Rutas.CursosDoctorado, "Asignación de cursos a estudiantes de doctorado.", 0),
                ],
            },
        ],
    });

    [HttpGet("personal-administrativo")]
    public IActionResult Administrativo() => Detalle(Hoja(
        "Personal administrativo",
        "Lineamientos y pasos para la contratación de personal administrativo.",
        [Inicio, Seccion, new("Personal administrativo", null)],
        "Revisa los documentos, autorizaciones y tiempos que intervienen en un alta o movimiento.",
        "El área requirente y Recursos Humanos coordinan la captura y validación del expediente."));

    [HttpGet("profesores-tiempo-parcial")]
    public IActionResult ProfesoresParcial() => Detalle(Hoja(
        "Profesores de tiempo parcial",
        "Proceso de contratación para profesorado de tiempo parcial.",
        [Inicio, Seccion, new("Profesores de tiempo parcial", null)],
        "La contratación se sujeta a la carga académica autorizada y a los requisitos de la escuela o departamento.",
        "Conserva la documentación académica y fiscal necesaria para agilizar el alta."));

    [HttpGet("profesores-tiempo-completo")]
    public IActionResult ProfesoresCompleto() => Detalle(Hoja(
        "Profesores de tiempo completo",
        "Proceso de contratación para profesorado de tiempo completo.",
        [Inicio, Seccion, new("Profesores de tiempo completo", null)],
        "Este proceso incluye validaciones académicas, administrativas y de expediente.",
        "Consulta con tu departamento las etapas y los responsables de cada autorización."));

    [HttpGet("procesos-especiales")]
    public IActionResult Especiales() => Detalle(Hoja(
        "Procesos especiales",
        "Contrataciones que siguen un procedimiento distinto al estándar.",
        [Inicio, Seccion, new("Procesos especiales", null)],
        "Pueden aplicar a convenios, sustituciones u otras figuras definidas por la universidad.",
        "Recursos Humanos indicará el protocolo y la evidencia requerida en cada caso."));

    [HttpGet("cursos-personal-academico")]
    public IActionResult CursosAcademico() => Detalle(Hoja(
        "Asignación de cursos · Personal académico",
        "Consulta el proceso de asignación de carga para personal académico.",
        [Inicio, Seccion, new("Personal académico", null)],
        "La asignación considera disponibilidad, perfil y autorización de la academia o departamento.",
        "Cualquier cambio de curso debe registrarse antes de las fechas de cierre publicadas."));

    [HttpGet("cursos-personal-administrativo")]
    public IActionResult CursosAdministrativo() => Detalle(Hoja(
        "Asignación de cursos · Personal administrativo",
        "Asignación de cursos o actividades académicas al personal administrativo.",
        [Inicio, Seccion, new("Personal administrativo", null)],
        "Este proceso aplica cuando el personal administrativo participa en actividades de docencia o apoyo académico.",
        "Verifica con tu jefatura las autorizaciones y el impacto en tu jornada."));

    [HttpGet("cursos-doctorado")]
    public IActionResult CursosDoctorado() => Detalle(Hoja(
        "Asignación de cursos · Estudiantes de doctorado",
        "Asignación de cursos a estudiantes de doctorado que colaboran en actividades académicas.",
        [Inicio, Seccion, new("Estudiantes de doctorado", null)],
        "La asignación se coordina con el programa doctoral y las áreas académicas correspondientes.",
        "Revisa requisitos de elegibilidad, horarios y documentación de alta."));
}
