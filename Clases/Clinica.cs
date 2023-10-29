using saludAr.Clases;

internal class Clinica
{
    private readonly List<Servicio> items;

    public Clinica()
    {
        items = new List<Servicio>();
    }

    public void AgregarServicio(Servicio item)
    {
        items.Add(item);
    }

    public void AgregarLaboratorio(string nombre, int cantidadDias, int nivelComplejidad)
    {
        ServicioLaboratorio laboratorio = new ServicioLaboratorio(nombre, cantidadDias, nivelComplejidad);
        AgregarServicio(laboratorio);
    }

    public void AgregarInternacion(string especialidad, int cantidadDias)
    {
        ServicioInternacion internacion = new ServicioInternacion(especialidad, cantidadDias);
        AgregarServicio(internacion);
    }

    public void AgregarMedicamento(string nombre, double porcentajeGanancia, double precioLista)
    {
        Medicamento medicamento = new Medicamento(nombre, porcentajeGanancia, precioLista);
        AgregarServicio(medicamento);
    }

    private double MontoTotalFacturado()
    {
        double totalFacturado = 0;

        foreach (Servicio item in items)
        {
            totalFacturado += item.CalcularPrecio();
        }

        return totalFacturado;
    }

    private int CantServiciosSimples()
    {
        int cantidadServiciosSimples = 0;

        foreach (Servicio servicio in items)
        {
            if (servicio is ServicioLaboratorio laboratorio && laboratorio.NivelComplejidad < 3)
            {
                cantidadServiciosSimples++;
            }
        }

        return cantidadServiciosSimples;
    }

    public void MostrarCantServiciosSimples()
    {
        int cantidadServiciosSimples = CantServiciosSimples();
        Console.WriteLine("La cantidad de servicios de laboratorio con nivel de complejidad menor a 3 fue: " + cantidadServiciosSimples);
    }

    public void MostrarMontoTotalFacturado()
    {
        double montoTotalFacturado = MontoTotalFacturado();
        Console.WriteLine("El monto total facturado en la clinica fue: " + montoTotalFacturado);
    }

    public void MostrarDetalles()
    {
        foreach (Servicio item in items)
        {
            Console.WriteLine($"\nNombre del servicio: {item.GetType().Name}");
            Console.WriteLine($"Detalles específicos: {ObtenerDetallesEspecificos(item)}");
            Console.WriteLine($"Precio final calculado: {item.CalcularPrecio():C2}");
        }
    }

    private string ObtenerDetallesEspecificos(Servicio item)
    {
        if (item is ServicioMedico servicioMedico)
        {
            if (servicioMedico is ServicioLaboratorio laboratorio)
            {
                return $"\n\tNombre: {laboratorio.Nombre},\n\tNivel de complejidad: {laboratorio.NivelComplejidad}, " +
                    $"\n\tCantidad de días: {servicioMedico.CantidadDias}";
            }
            else if (servicioMedico is ServicioInternacion internacion)
            {
                return $"\n\tEspecialidad: {internacion.Especialidad}, \n\tCantidad de días: {servicioMedico.CantidadDias}";
            }
        }
        else if (item is Medicamento medicamento)
        {
            return $"\n\tNombre: {medicamento.Nombre},\n\tPorcentaje de ganancia: %{medicamento.PorcentajeGanancia}, " +
                $"\n\tPrecio de lista: {medicamento.PrecioLista:C2}";
        }

        return string.Empty;
    }


}
