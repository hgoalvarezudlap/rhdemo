namespace RecursosHumanos.Models;

public record MigaPan(string Texto, string? Url);

public class EncabezadoPagina
{
    public required string Titulo { get; init; }
    public required string Intro { get; init; }
    public required IReadOnlyList<MigaPan> Migas { get; init; }
}

public class EnlaceSeccion
{
    public required string Titulo { get; init; }
    public required string Url { get; init; }
    public string? Descripcion { get; init; }
    public string CajaClase { get; init; } = "bg-udlap-ambar/5 hover:bg-udlap-ambar/10";
    public string AcentoClase { get; init; } = "text-udlap-ambar";
}

public class GrupoEnlaces
{
    public required string Titulo { get; init; }
    public required IReadOnlyList<EnlaceSeccion> Enlaces { get; init; }
}

public class PaginaHubViewModel
{
    public required string Titulo { get; init; }
    public required string Intro { get; init; }
    public required IReadOnlyList<MigaPan> Migas { get; init; }
    public IReadOnlyList<EnlaceSeccion> Enlaces { get; init; } = [];
    public IReadOnlyList<GrupoEnlaces> Grupos { get; init; } = [];
}

public class PaginaDetalleViewModel
{
    public required string Titulo { get; init; }
    public required string Intro { get; init; }
    public required IReadOnlyList<MigaPan> Migas { get; init; }
    public IReadOnlyList<string> Parrafos { get; init; } = [];
}

public class ContactoDirectorio
{
    public required string Nombre { get; init; }
    public required string Puesto { get; init; }
    public required string Extension { get; init; }
    public required string Correo { get; init; }
}

public class AreaDirectorio
{
    public required string Nombre { get; init; }
    public required IReadOnlyList<ContactoDirectorio> Contactos { get; init; }
}

public class DirectorioViewModel
{
    public required EncabezadoPagina Encabezado { get; init; }
    public required IReadOnlyList<AreaDirectorio> Areas { get; init; }
}

public static class Rutas
{
    public const string Inicio = "/";
    public const string Buscar = "/buscar";
    public const string Avisos = "/avisos";
    public const string Fechas = "/fechas";
    public const string Accesos = "/accesos";

    public const string Tramites = "/tramites";
    public const string Vacaciones = "/tramites/vacaciones";
    public const string Constancias = "/tramites/constancias";
    public const string Documentos = "/tramites/documentos-laborales";
    public const string Datos = "/tramites/actualizacion-de-datos";
    public const string OtrosTramites = "/tramites/otros";

    public const string Nomina = "/nomina";
    public const string Recibos = "/nomina/recibos";
    public const string FondoAhorro = "/nomina/fondo-de-ahorro";
    public const string Seguros = "/nomina/seguros";
    public const string Vales = "/nomina/vales-de-despensa";
    public const string Apoyos = "/nomina/apoyos-financieros";
    public const string OtrosBeneficios = "/nomina/otros-beneficios";

    public const string Contratacion = "/contratacion";
    public const string Admvo = "/contratacion/personal-administrativo";
    public const string Ptp = "/contratacion/profesores-tiempo-parcial";
    public const string Ptc = "/contratacion/profesores-tiempo-completo";
    public const string Especiales = "/contratacion/procesos-especiales";
    public const string CursosAcademico = "/contratacion/cursos-personal-academico";
    public const string CursosAdmvo = "/contratacion/cursos-personal-administrativo";
    public const string CursosDoctorado = "/contratacion/cursos-doctorado";

    public const string Desarrollo = "/desarrollo";
    public const string Capacitacion = "/desarrollo/capacitacion";
    public const string Programas = "/desarrollo/programas-academicos";
    public const string Profesional = "/desarrollo/desarrollo-profesional";
    public const string Preseas = "/desarrollo/reconocimientos";
    public const string PerfilEmpleado = "/desarrollo/perfil-del-empleado";
    public const string InfoEmpleados = PerfilEmpleado;

    public const string Recursos = "/recursos";
    public const string Formatos = "/recursos/formatos";
    public const string Calendarios = "/recursos/calendarios";
    public const string Guias = "/recursos/guias-y-manuales";
    public const string Politicas = "/recursos/politicas";
    public const string Sistemas = "/recursos/sistemas";

    public const string Ayuda = "/ayuda/contacto";
    public const string ConQuien = "/ayuda/con-quien-me-comunico";
    public const string Faq = "/ayuda/preguntas-frecuentes";
    public const string Contacto = "/ayuda/contacto";
    public const string Directorio = "/ayuda/contacto";
    public const string Ventanilla = "/ayuda/ventanilla-unica";
    public const string Ubicacion = "/ayuda/ubicacion";
    public const string Horarios = "/ayuda/horarios";
}

public static class PaletaCajas
{
    public static readonly (string Caja, string Acento)[] Ciclo =
    [
        ("bg-udlap-ambar/5 hover:bg-udlap-ambar/10", "text-udlap-ambar"),
        ("bg-udlap-turquesa/5 hover:bg-udlap-turquesa/10", "text-udlap-turquesa"),
        ("bg-udlap-morado/5 hover:bg-udlap-morado/10", "text-udlap-morado"),
        ("bg-udlap-oliva/5 hover:bg-udlap-oliva/10", "text-neutral-700"),
        ("bg-udlap-rojo/5 hover:bg-udlap-rojo/10", "text-udlap-rojo"),
        ("bg-udlap-amarillo/15 hover:bg-udlap-amarillo/25", "text-neutral-800"),
    ];

    public static EnlaceSeccion Enlace(string titulo, string url, string? descripcion, int indice)
    {
        var (caja, acento) = Ciclo[indice % Ciclo.Length];
        return new EnlaceSeccion
        {
            Titulo = titulo,
            Url = url,
            Descripcion = descripcion,
            CajaClase = caja,
            AcentoClase = acento,
        };
    }
}
