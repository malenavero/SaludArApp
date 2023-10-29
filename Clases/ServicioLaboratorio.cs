
namespace saludAr.Clases
{
    internal class ServicioLaboratorio : ServicioMedico
    {
        public string Nombre { get; set; }
        public int NivelComplejidad { get; set; }

        public ServicioLaboratorio(string nombre, int nivelComplejidad, int cantidadDias)
           : base(cantidadDias)

        {
            Nombre = nombre;
            NivelComplejidad = nivelComplejidad;
        }

        public override double CalcularPrecio()
        {
            double precioBase = CantidadDias * 10000.0;
            if (NivelComplejidad > 3)
            {
                precioBase += 0.25 * precioBase;
            }
            double iva = precioBase * 0.21;
            return precioBase + (iva/2);
        }
    }
}
