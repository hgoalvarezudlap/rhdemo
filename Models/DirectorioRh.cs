namespace RecursosHumanos.Models;

public static class DirectorioRh
{
    public static IReadOnlyList<AreaDirectorio> Areas { get; } =
    [
        new()
        {
            Nombre = "Dirección General de Recursos Humanos",
            Contactos =
            [
                new() { Nombre = "Diana Alicia Gayosso", Puesto = "Directora General de Recursos Humanos", Extension = "52114", Correo = "diana.alicia.gayosso@udlap.mx" },
                new() { Nombre = "Mónica Morales", Puesto = "Asistente de Dirección General", Extension = "52144", Correo = "monica.morales@udlap.mx" },
                new() { Nombre = "Angélica Huitzil", Puesto = "Coordinadora de Recursos Humanos", Extension = "23233", Correo = "angelica.huitzil@udlap.mx" },
                new() { Nombre = "Clara Imelda Navarrete", Puesto = "Coordinadora de Recursos Humanos", Extension = "52177", Correo = "clara.navarrete@udlap.mx" },
                new() { Nombre = "Isabel Martínez", Puesto = "Auxiliar Administrativo, Ventanilla Única de Recursos Humanos", Extension = "23244", Correo = "isabel.martinez@udlap.mx" },
                new() { Nombre = "Olivia Cuayea", Puesto = "Auxiliar Administrativo, Ventanilla Única de Recursos Humanos", Extension = "23200", Correo = "olivia.cuayea@udlap.mx" },
            ],
        },
        new()
        {
            Nombre = "Departamento de Personal",
            Contactos =
            [
                new() { Nombre = "Beatriz Adriana Cortez", Puesto = "Directora de Personal", Extension = "52008", Correo = "beatriz.cortez@udlap.mx" },
                new() { Nombre = "Gabriela Solís", Puesto = "Coordinadora de Personal", Extension = "52006", Correo = "gabriela.solis@udlap.mx" },
                new() { Nombre = "Anelice de Jesús Otarula", Puesto = "Coordinadora de Seguros, Prestaciones y Beneficios", Extension = "23222", Correo = "anelice.otarula@udlap.mx" },
                new() { Nombre = "Juan Carlos García", Puesto = "Auxiliar Administrativo, Responsable de Archivos", Extension = "52188", Correo = "juan.garcia@udlap.mx" },
            ],
        },
        new()
        {
            Nombre = "Departamento de Reclutamiento y Capacitación",
            Contactos =
            [
                new() { Nombre = "Rosa María Serrano", Puesto = "Reclutamiento y Capacitación", Extension = "52070", Correo = "rosa.serrano@udlap.mx" },
            ],
        },
    ];
}
