using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

[Route("tramites")]
public class TramitesController : PaginaController
{
    private static readonly MigaPan Inicio = new("Inicio", Rutas.Inicio);
    private static readonly MigaPan Seccion = new("Trámites y servicios", Rutas.Tramites);

    [HttpGet("")]
    public IActionResult Index() => Hub(new PaginaHubViewModel
    {
        Titulo = "Trámites y servicios",
        Intro = "Realiza solicitudes, consulta requisitos y da seguimiento a los trámites más frecuentes de personal.",
        Migas = [Inicio, new("Trámites y servicios", null)],
        Enlaces =
        [
            PaletaCajas.Enlace("Vacaciones y permisos", Rutas.Vacaciones, "Solicitud, saldo y seguimiento de ausencias.", 0),
            PaletaCajas.Enlace("Constancias", Rutas.Constancias, "Constancias laborales e institucionales.", 1),
            PaletaCajas.Enlace("Documentos laborales", Rutas.Documentos, "Documentación requerida durante tu relación laboral.", 2),
            PaletaCajas.Enlace("Actualización de datos", Rutas.Datos, "Mantén actualizado tu expediente personal.", 3),
            PaletaCajas.Enlace("Otros trámites", Rutas.OtrosTramites, "Solicitudes adicionales de Recursos Humanos.", 4),
        ],
    });

    [HttpGet("vacaciones")]
    public IActionResult Vacaciones() => Detalle(Hoja(
        "Vacaciones y permisos",
        "Consulta el proceso para solicitar vacaciones, permisos y otras ausencias.",
        [Inicio, Seccion, new("Vacaciones y permisos", null)],
        "Revisa tu saldo, los periodos autorizados y los plazos de captura antes de registrar una solicitud.",
        "Las solicitudes se canalizan por el sistema institucional y quedan sujetas a la autorización de tu jefatura."));

    [HttpGet("constancias")]
    public IActionResult Constancias() => Detalle(Hoja(
        "Constancias",
        "Genera constancias laborales e institucionales a través de los canales autorizados.",
        [Inicio, Seccion, new("Constancias", null)],
        "Identifica el tipo de constancia que necesitas y los datos que deben aparecer en el documento.",
        "Algunas constancias se emiten de forma automática; otras requieren validación de Recursos Humanos."));

    [HttpGet("documentos-laborales")]
    public IActionResult Documentos() => Detalle(Hoja(
        "Documentos laborales",
        "Consulta la documentación asociada a tu expediente y a los movimientos de personal.",
        [Inicio, Seccion, new("Documentos laborales", null)],
        "Aquí se concentrarán las guías para solicitar, actualizar o entregar documentos laborales.",
        "Conserva copias digitales de tus documentos vigentes para agilizar cualquier trámite posterior."));

    [HttpGet("actualizacion-de-datos")]
    public IActionResult Datos() => Detalle(Hoja(
        "Actualización de datos",
        "Mantén al día tu información personal, de contacto y de beneficiarios.",
        [Inicio, Seccion, new("Actualización de datos", null)],
        "Un expediente actualizado evita retrasos en nómina, seguros y constancias.",
        "Notifica a Recursos Humanos cualquier cambio de domicilio, cuenta bancaria o datos familiares."));

    [HttpGet("otros")]
    public IActionResult Otros() => Detalle(Hoja(
        "Otros trámites",
        "Solicitudes que no están agrupadas en las categorías principales.",
        [Inicio, Seccion, new("Otros trámites", null)],
        "Si no encuentras el trámite que buscas, revisa esta sección o acude a la Ventanilla Única.",
        "El personal de Recursos Humanos te orientará sobre el canal y los requisitos correspondientes."));
}
