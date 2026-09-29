using System.Globalization;
using System.Text;

namespace RecursosHumanos.Models;

public class EntradaBusqueda
{
    public required string Titulo { get; init; }
    public required string Url { get; init; }
    public required string Seccion { get; init; }
    public required string Resumen { get; init; }
    public required string Tipo { get; init; }
    public required string TextoBusqueda { get; init; }
}

public class BusquedaViewModel
{
    public required EncabezadoPagina Encabezado { get; init; }
    public required string Consulta { get; init; }
    public required IReadOnlyList<EntradaBusqueda> Resultados { get; init; }
}

public class BuscadorFormulario
{
    public required string InputId { get; init; }
    public string Valor { get; init; } = "";
    public string Placeholder { get; init; } = "Buscar en Recursos Humanos...";
    public string FormClass { get; init; } = "";
    public string InputClass { get; init; } = "";
    public string IconClass { get; init; } = "left-3 h-4 w-4";
}

public static class CatalogoBusqueda
{
    public static IReadOnlyList<EntradaBusqueda> Entradas { get; } = CrearEntradas();

    public static IReadOnlyList<EntradaBusqueda> Buscar(string? consulta)
    {
        var q = Normalizar(consulta);
        if (q.Length == 0)
        {
            return [];
        }

        return Entradas
            .Where(entrada => entrada.TextoBusqueda.Contains(q, StringComparison.Ordinal))
            .OrderBy(entrada => Prioridad(entrada, q))
            .ThenBy(entrada => entrada.Tipo == "pagina" ? 0 : 1)
            .ThenBy(entrada => entrada.Titulo, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public static string Normalizar(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return "";
        }

        var formD = texto.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(formD.Length);
        foreach (var caracter in formD)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(caracter) != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(caracter);
            }
        }

        return builder.ToString().Normalize(NormalizationForm.FormC);
    }

    private static int Prioridad(EntradaBusqueda entrada, string consulta)
    {
        var titulo = Normalizar(entrada.Titulo);
        if (titulo.StartsWith(consulta, StringComparison.Ordinal))
        {
            return 0;
        }

        return titulo.Contains(consulta, StringComparison.Ordinal) ? 1 : 2;
    }

    private static IReadOnlyList<EntradaBusqueda> CrearEntradas()
    {
        var paginas = new List<EntradaBusqueda>
        {
            Pagina("Inicio", Rutas.Inicio, "Inicio", "Portal de Recursos Humanos UDLAP.", "intranet home"),
            Pagina("Fechas importantes", Rutas.Fechas, "Inicio", "Calendario de fechas clave de Recursos Humanos.", "calendario plazos"),
            Pagina("Avisos", Rutas.Avisos, "Inicio", "Avisos institucionales para el personal.", "comunicados"),
            Pagina("Accesos a sistemas", Rutas.Accesos, "Inicio", "Acceso a plataformas y sistemas de RH.", "sistemas login"),

            Pagina("Trámites y servicios", Rutas.Tramites, "Trámites y servicios", "Solicitudes, requisitos y seguimiento de trámites de personal."),
            Pagina("Vacaciones y permisos", Rutas.Vacaciones, "Trámites y servicios", "Solicitud, saldo y seguimiento de ausencias.", "vacaciones permisos ausencias"),
            Pagina("Constancias", Rutas.Constancias, "Trámites y servicios", "Constancias laborales e institucionales."),
            Pagina("Documentos laborales", Rutas.Documentos, "Trámites y servicios", "Documentación de tu expediente y movimientos de personal."),
            Pagina("Actualización de datos", Rutas.Datos, "Trámites y servicios", "Actualiza tu información personal, de contacto y beneficiarios.", "expediente domicilio cuenta bancaria"),
            Pagina("Otros trámites", Rutas.OtrosTramites, "Trámites y servicios", "Solicitudes adicionales de Recursos Humanos."),

            Pagina("Nómina, prestaciones y beneficios", Rutas.Nomina, "Nómina, prestaciones y beneficios", "Recibos, prestaciones económicas y beneficios institucionales.", "nomina"),
            Pagina("Recibos de nómina", Rutas.Recibos, "Nómina, prestaciones y beneficios", "Consulta y descarga de comprobantes de pago.", "recibo pago"),
            Pagina("Fondo de ahorro", Rutas.FondoAhorro, "Nómina, prestaciones y beneficios", "Saldo, aportaciones, préstamos y comprobantes.", "prestamo ahorro"),
            Pagina("Seguros", Rutas.Seguros, "Nómina, prestaciones y beneficios", "Coberturas, pólizas y procedimiento en caso de siniestro."),
            Pagina("Vales de despensa en monedero electrónico", Rutas.Vales, "Nómina, prestaciones y beneficios", "Tarjeta Edenred, comercios autorizados y qué hacer en caso de extravío.", "vales despensa edenred monedero tarjeta cancela extravio robo"),
            Pagina("Apoyos financieros", Rutas.Apoyos, "Nómina, prestaciones y beneficios", "Convocatorias y requisitos de apoyos institucionales.", "dependientes economicos"),
            Pagina("Otros beneficios", Rutas.OtrosBeneficios, "Nómina, prestaciones y beneficios", "Prestaciones adicionales al personal."),

            Pagina("Contratación y movimientos", Rutas.Contratacion, "Contratación y movimientos", "Ingreso, contratación y asignación de cursos."),
            Pagina("Personal administrativo", Rutas.Admvo, "Contratación y movimientos", "Contratación e ingreso de personal administrativo."),
            Pagina("Profesores de tiempo parcial", Rutas.Ptp, "Contratación y movimientos", "Contratación de profesorado de tiempo parcial.", "ptp"),
            Pagina("Profesores de tiempo completo", Rutas.Ptc, "Contratación y movimientos", "Contratación de profesorado de tiempo completo.", "ptc"),
            Pagina("Procesos especiales", Rutas.Especiales, "Contratación y movimientos", "Contrataciones con lineamientos particulares."),
            Pagina("Asignación de cursos al personal académico", Rutas.CursosAcademico, "Contratación y movimientos", "Asignación de carga académica."),
            Pagina("Asignación de cursos al personal administrativo", Rutas.CursosAdmvo, "Contratación y movimientos", "Asignación de cursos al personal administrativo."),
            Pagina("Asignación de cursos a estudiantes de doctorado", Rutas.CursosDoctorado, "Contratación y movimientos", "Asignación de cursos a estudiantes de doctorado."),

            Pagina("Desarrollo y vida laboral", Rutas.Desarrollo, "Desarrollo y vida laboral", "Capacitación, crecimiento profesional y reconocimientos."),
            Pagina("Capacitación", Rutas.Capacitacion, "Desarrollo y vida laboral", "Cursos, inscripciones y oferta formativa."),
            Pagina("Programas académicos", Rutas.Programas, "Desarrollo y vida laboral", "Apoyos y programas de formación académica."),
            Pagina("Desarrollo profesional", Rutas.Profesional, "Desarrollo y vida laboral", "Herramientas para tu trayectoria laboral."),
            Pagina("Perfil del empleado", Rutas.PerfilEmpleado, "Desarrollo y vida laboral", "Perfil institucional del colaborador UDLAP.", "valores honestidad integridad"),
            Pagina("Entrega de PRESEAS", Rutas.Preseas, "Desarrollo y vida laboral", "Ceremonia de reconocimiento a la trayectoria del personal.", "reconocimientos preseas antiguedad"),

            Pagina("Recursos", Rutas.Recursos, "Recursos", "Formatos, calendarios, guías, políticas y sistemas de RH."),
            Pagina("Formatos", Rutas.Formatos, "Recursos", "Plantillas y formatos oficiales."),
            Pagina("Calendarios", Rutas.Calendarios, "Recursos", "Calendarios de RH y de la universidad."),
            Pagina("Guías y manuales", Rutas.Guias, "Recursos", "Instructivos de procesos y sistemas."),
            Pagina("Políticas y lineamientos", Rutas.Politicas, "Recursos", "Normativa interna de personal."),
            Pagina("Sistemas de Recursos Humanos", Rutas.Sistemas, "Recursos", "Acceso a plataformas institucionales."),

            Pagina("Contacto", Rutas.Contacto, "Ayuda y contacto", "Directorio, teléfono, correo, ventanilla y horario de atención.", "directorio telefono extension correo recursos.humanos"),
            Pagina("¿Con quién me comunico?", Rutas.ConQuien, "Ayuda y contacto", "Identifica el área correcta según el tipo de solicitud."),
            Pagina("Preguntas frecuentes", Rutas.Faq, "Ayuda y contacto", "Respuestas breves a las consultas más comunes.", "faq dudas"),
            Pagina("Ventanilla Única", Rutas.Ventanilla, "Ayuda y contacto", "Atención presencial para trámites de personal.", "edificio 19"),
            Pagina("Ubicación", Rutas.Ubicacion, "Ayuda y contacto", "Recursos Humanos en el Edificio 19.", "campus cholula"),
            Pagina("Horarios", Rutas.Horarios, "Ayuda y contacto", "Horario de atención de la Ventanilla Única.", "8:30 12:30 15:00 16:30"),
        };

        var contactos = DirectorioRh.Areas.SelectMany(area => area.Contactos.Select(persona =>
            Contacto(persona.Nombre, Rutas.Contacto, area.Nombre, $"{persona.Puesto}. Ext. {persona.Extension}. {persona.Correo}", $"{persona.Puesto} {persona.Extension} {persona.Correo}")));

        return [.. paginas, .. contactos];
    }

    private static EntradaBusqueda Pagina(string titulo, string url, string seccion, string resumen, string extra = "") =>
        new()
        {
            Titulo = titulo,
            Url = url,
            Seccion = seccion,
            Resumen = resumen,
            Tipo = "pagina",
            TextoBusqueda = Normalizar($"{titulo} {seccion} {resumen} {extra}"),
        };

    private static EntradaBusqueda Contacto(string titulo, string url, string seccion, string resumen, string extra) =>
        new()
        {
            Titulo = titulo,
            Url = url,
            Seccion = seccion,
            Resumen = resumen,
            Tipo = "contacto",
            TextoBusqueda = Normalizar($"{titulo} {seccion} {resumen} {extra}"),
        };
}
