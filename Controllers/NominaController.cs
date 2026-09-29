using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers;

[Route("nomina")]
public class NominaController : PaginaController
{
    private static readonly MigaPan Inicio = new("Inicio", Rutas.Inicio);
    private static readonly MigaPan Seccion = new("Nómina, prestaciones y beneficios", Rutas.Nomina);

    [HttpGet("")]
    public IActionResult Index() => Hub(new PaginaHubViewModel
    {
        Titulo = "Nómina, prestaciones y beneficios",
        Intro = "Consulta recibos, prestaciones económicas y beneficios institucionales para el personal UDLAP.",
        Migas = [Inicio, new("Nómina, prestaciones y beneficios", null)],
        Enlaces =
        [
            PaletaCajas.Enlace("Recibos de nómina", Rutas.Recibos, "Consulta y descarga de comprobantes.", 2),
            PaletaCajas.Enlace("Fondo de ahorro", Rutas.FondoAhorro, "Saldo, préstamos y requisitos.", 3),
            PaletaCajas.Enlace("Seguros", Rutas.Seguros, "Coberturas y uso de pólizas.", 4),
            PaletaCajas.Enlace("Vales de despensa", Rutas.Vales, "Monedero electrónico Edenred y qué hacer en caso de extravío.", 0),
            PaletaCajas.Enlace("Apoyos financieros", Rutas.Apoyos, "Solicitudes de apoyo económico.", 1),
            PaletaCajas.Enlace("Otros beneficios", Rutas.OtrosBeneficios, "Prestaciones adicionales al personal.", 5),
        ],
    });

    [HttpGet("recibos")]
    public IActionResult Recibos() => Detalle(Hoja(
        "Recibos de nómina",
        "Consulta y descarga tus comprobantes de pago.",
        [Inicio, Seccion, new("Recibos de nómina", null)],
        "Los recibos se publican de acuerdo con el calendario de nómina institucional.",
        "Verifica que tus datos bancarios y fiscales estén actualizados para evitar incidencias."));

    [HttpGet("fondo-de-ahorro")]
    public IActionResult FondoAhorro() => Detalle(Hoja(
        "Fondo de ahorro",
        "Revisa saldo, aportaciones, préstamos y periodos de comprobación.",
        [Inicio, Seccion, new("Fondo de ahorro", null)],
        "El fondo de ahorro se rige por las políticas vigentes de la universidad.",
        "Consulta fechas límite de registro de comprobantes y requisitos para préstamos."));

    [HttpGet("seguros")]
    public IActionResult Seguros() => Detalle(Hoja(
        "Seguros",
        "Conoce las coberturas a las que tienes acceso y cómo utilizarlas.",
        [Inicio, Seccion, new("Seguros", null)],
        "Consulta pólizas, beneficiarios y el procedimiento en caso de siniestro o atención médica.",
        "Mantén actualizados a tus beneficiarios para que la cobertura proceda sin contratiempos."));

    [HttpGet("vales-de-despensa")]
    public IActionResult Vales() => View("Vales", new EncabezadoPagina
    {
        Titulo = "Vales de despensa en monedero electrónico",
        Intro = "Los vales de despensa se entregan en tarjeta que funciona como monedero electrónico, el cual opera en comercios autorizados tales como: cadenas de autoservicio, tiendas de conveniencia, mayoristas abarroteros y farmacias, entre otros.",
        Migas = [Inicio, Seccion, new("Vales de despensa", null)],
    });

    [HttpGet("apoyos-financieros")]
    public IActionResult Apoyos() => Detalle(Hoja(
        "Apoyos financieros",
        "Revisa convocatorias, requisitos y plazos de los apoyos institucionales.",
        [Inicio, Seccion, new("Apoyos financieros", null)],
        "Los apoyos pueden incluir beneficios para dependientes económicos u otras ayudas temporales.",
        "Entrega la documentación completa dentro de las fechas publicadas en el calendario."));

    [HttpGet("otros-beneficios")]
    public IActionResult Otros() => Detalle(Hoja(
        "Otros beneficios",
        "Prestaciones y beneficios que complementan el paquete laboral.",
        [Inicio, Seccion, new("Otros beneficios", null)],
        "Esta sección reunirá beneficios adicionales que no pertenecen a nómina, fondo o seguros.",
        "Consulta periódicamente los avisos institucionales para conocer nuevas prestaciones."));
}
