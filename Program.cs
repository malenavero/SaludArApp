using saludAr.Clases;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Clinica clinica = new Clinica();
        bool continuar = true;

        Console.WriteLine("Bienvenido al Sistema de Facturación de la Clínica Médica");

        while (continuar)
        {
            MostrarMenuPrincipal();
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarNuevoServicio(clinica);
                    break;
                case "2":
                    clinica.MostrarDetalles();
                    break;
                case "3":
                    continuar = false;
                    clinica.MostrarCantServiciosSimples();
                    clinica.MostrarMontoTotalFacturado();
                    break;
                default:
                    Console.WriteLine("Por favor, ingrese una opción válida.");
                    break;
            }
        }
    }

    private static void MostrarMenuPrincipal()
    {
        Console.WriteLine("\n1. Agregar un nuevo servicio");
        Console.WriteLine("2. Mostrar detalles de los servicios");
        Console.WriteLine("3. Salir");
        Console.Write("Ingrese su opción: ");
    }

    private static void MostrarMenuTipoServicio()
    {
        Console.WriteLine("\nPor favor, seleccione el tipo de servicio:");
        Console.WriteLine("1. Laboratorio");
        Console.WriteLine("2. Internación");
        Console.WriteLine("3. Medicamento");
        Console.Write("Ingrese su opción: ");
    }

    private static void AgregarNuevoServicio(Clinica clinica)
    {
        bool opcionValida = false;

        while (!opcionValida)
        {
            MostrarMenuTipoServicio();
            string? tipoServicio = Console.ReadLine();

            switch (tipoServicio)
            {
                case "1":
                    AgregarLaboratorio(clinica);
                    opcionValida = true;
                    break;
                case "2":
                    AgregarInternacion(clinica);
                    opcionValida = true;
                    break;
                case "3":
                    AgregarMedicamento(clinica);
                    opcionValida = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    private static void AgregarLaboratorio(Clinica clinica)
    {
        // Obtenemos los argumentos necesarios para un nuevo laboratorio
        string nombre = TestHelpers.GetStringPorConsola("\nNombre del análisis requerido: ");
        int cantidadDias = TestHelpers.GetIntPorConsola("Cantidad de días que se demora el resultado: ");
        int nivelComplejidad = TestHelpers.GetIntPorConsola("Nivel de complejidad (1-5): ");
        bool nivelComplejidadValido = nivelComplejidad >= 1 && nivelComplejidad <= 5;

        while (!nivelComplejidadValido)
        {
            nivelComplejidad = TestHelpers.GetIntPorConsola("\nPor favor, ingrese un nivel de complejidad válido (entre 1 y 5): ");
            nivelComplejidadValido = nivelComplejidad >= 1 && nivelComplejidad <= 5;
        }

        // Llamamos a la función de la clínica para agregar el laboratorio con los argumentos obtenidos
        clinica.AgregarLaboratorio(nombre, cantidadDias, nivelComplejidad);

        Console.WriteLine("\n¡El servicio de laboratorio ha sido agregado correctamente!");
    }

    private static void AgregarInternacion(Clinica clinica)
    {
        // Obtenemos los argumentos necesarios para un nuevo laboratorio
        string especialidad = TestHelpers.GetStringPorConsola("\nEspecialidad de la internación: ");
        int cantidadDias = TestHelpers.GetIntPorConsola("Cantidad de días de internación: ");


        // Llamamos a la función de la clínica para agregar el servicio de internación con los argumentos obtenidos
        clinica.AgregarInternacion(especialidad, cantidadDias);

        Console.WriteLine("\n¡El servicio de internación ha sido agregado correctamente!");
    }

    private static void AgregarMedicamento(Clinica clinica)
    {
        // Obtenemos los detalles del medicamento
        string nombre = TestHelpers.GetStringPorConsola("\nNombre del medicamento: ");
        double porcentajeGanancia = TestHelpers.GetDoublePorConsola("Porcentaje de ganancia (%): ");
        double precioLista = TestHelpers.GetDoublePorConsola("Precio de lista: ");

        // Llamamos a la función de la clínica para agregar el medicamento con los argumentos obtenidos
        clinica.AgregarMedicamento(nombre, porcentajeGanancia, precioLista);

        Console.WriteLine("\n¡El medicamento ha sido agregado correctamente!");
    }

}
